using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Ctm.Packer.Scheduler;

namespace Ctm.Packer.Heuristics
{
	/// <summary>
	/// Some basic bin packagers; there are various types, but these should suffice as examples
	/// </summary>
	internal class LargeToSmallParcels : IPackager
	{
		private int[] _containerSizes;
		private List<int> _parcelSizes;
		private List<int> _packedParcels; 

		public LargeToSmallParcels(int[] containerSizes, IEnumerable<int> parcelSizes)
		{
			_containerSizes = containerSizes;
			_parcelSizes = new List<int>(parcelSizes.OrderByDescending(p=>p));
			_packedParcels = new List<int>();
		}

		public ScheduleResults Pack(ScheduleResults results, CancellationToken cancelToken)
		{
			IList<ResultContainer> containers = new List<ResultContainer>();
			while (_parcelSizes.Count > 0)
			{
				foreach (var containerSize in _containerSizes)
				{
					if (cancelToken.IsCancellationRequested) return results;

					var conveyer = new ResultContainer {ContainerSize = containerSize};

					int i;
					bool firstPass = true;
					for (i = 0; i < _parcelSizes.Count;)
					{
						if (cancelToken.IsCancellationRequested) return results;

						int parcel = _parcelSizes[i];
						int sumParcelSizes = conveyer.PackedParcelSizes == null ? 0 :conveyer.PackedParcelSizes.Sum();

						if ((conveyer.PackedParcelSizes == null || conveyer.PackedParcelSizes.Count <= 0 || (conveyer.PackedParcelSizes.Last() > parcel || !firstPass))
						     && sumParcelSizes + parcel <= containerSize)
						{
							conveyer.PackedParcelSizes.Add(parcel);
							_packedParcels.Add(parcel);
							_parcelSizes.RemoveAt(i);

							if (conveyer.PackedParcelSizes.Sum() == containerSize) i = _parcelSizes.Count; //short circuit inner for loop
							continue;
						}

						i++;
						//if we get to the end and we still have room enough for at least the smallest of our packages, then reset and go from 
						//largest to smallest, again.  until our smallest sized parcel remaining is bigger than the container delta.
						if(i >=_parcelSizes.Count && sumParcelSizes < containerSize && containerSize - sumParcelSizes >= _parcelSizes.Last())
						{
							firstPass = false;
							i = 0;
						}
					}

					containers.Add(conveyer);
				}
			}

			if (IsMoreOptimal(containers, results.CurrentBestResults))
			{
				results.CurrentBestResults = containers;
			}

			return results;
		}

		private bool IsMoreOptimal(IList<ResultContainer> containers, IList<ResultContainer> currentBestResults)
		{
			if(currentBestResults == null || currentBestResults.Count <= 0) return true;
			if(containers == null || containers.Count <= 0) return false;

			return
				containers.Count <= currentBestResults.Count /*fewer or equal sessions*/
				&&
				containers.Sum(a => a.PackedParcelSizes.Count) >= currentBestResults.Sum(a => a.PackedParcelSizes.Count) /*more or same talks*/
				&&
				_parcelSizes.Count <= 0 /*all current parcels were packed*/;
		}

	}
}

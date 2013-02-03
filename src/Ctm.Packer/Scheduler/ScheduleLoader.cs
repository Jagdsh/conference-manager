using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ctm.Packer.BruteForce;
using Ctm.Packer.Heuristics;

namespace Ctm.Packer.Scheduler
{
	/// <summary>
	/// 
	/// </summary>
	public class ScheduleLoader : ILoader
	{
		private readonly int[] _containerSizes;
		private readonly int[] _parcelSizes;
		private readonly CancellationTokenSource _tokenSource;
		private readonly CancellationToken _cancelToken;
		private Task[] _tasks;
		private ScheduleResults _results;

		/// <summary>
		/// Initializes a new instance of the <see cref="ScheduleLoader"/> class.
		/// </summary>
		public ScheduleLoader(int[] containerSizes, int[] parcelSizes)
		{
			_containerSizes = containerSizes;
			_parcelSizes = parcelSizes;
			_tokenSource = new CancellationTokenSource();
			_cancelToken = _tokenSource.Token;
		}

		public void Load()
		{
			_results = new ScheduleResults();

			var hilo = Task<ScheduleResults>.Factory.StartNew(() => new LargeToSmallParcels(_containerSizes, _parcelSizes).Pack(_results, _cancelToken), _cancelToken);
			var brute = new Task<ScheduleResults>(() => new Solver(_containerSizes, _parcelSizes).Pack(_results, _cancelToken), _cancelToken, TaskCreationOptions.LongRunning);
			brute.Start();

			_tasks = new Task[]{hilo,brute};
		}
		public ScheduleResults Results()
		{
			return _results;
		}
		public bool AreResultsReady()
		{
			return _results.CurrentBestResults != null && _results.CurrentBestResults.Any();
		}
		public bool AreRunsFinished()
		{
			return _tasks.All(t => t.IsCompleted);
		}
		public void Cancel()
		{
			if(!_tokenSource.IsCancellationRequested) _tokenSource.Cancel();
		}
	}
}

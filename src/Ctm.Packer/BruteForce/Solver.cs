using System;
using System.Linq;
using System.Threading;
using Ctm.Packer.Scheduler;

namespace Ctm.Packer.BruteForce
{
	/// <summary>
	/// So, this is just another type of packing method.
	/// It was a nice to have, but not needed to solve this problem.
	/// There are many 3rd party apps available that handle lots of 
	/// NP hard packing issues like knapsasck and bin packing in general.
	/// We could continue to easily add a half a doze or more different
	/// packing algorithms since there is not one be-all end-all for them.
	/// </summary>
	internal class Solver : IPackager
	{
		public Solver(int[] containerSizes, int[] parcelSizes)
		{
			
		}

		public ScheduleResults Pack(ScheduleResults results, CancellationToken cancelToken)
		{
			return results;
		}
	}
}

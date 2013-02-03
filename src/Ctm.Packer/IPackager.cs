using System;
using System.Threading;
using Ctm.Packer.Scheduler;


namespace Ctm.Packer
{
	public interface IPackager
	{
		/// <summary>
		/// Packs the specified cancel token.
		/// </summary>
		/// <param name="results">The results.</param>
		/// <param name="cancelToken">The cancel token.</param>
		/// <returns>
		/// Should be make generic for different types of package managers
		/// </returns>
		ScheduleResults Pack(ScheduleResults results, CancellationToken cancelToken);
	}
}
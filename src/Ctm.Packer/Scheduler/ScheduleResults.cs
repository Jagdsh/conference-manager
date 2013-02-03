using System;
using System.Collections.Generic;
using System.Linq;

namespace Ctm.Packer.Scheduler
{
	/// <summary>
	/// 
	/// </summary>
	public class ScheduleResults
	{
		public IList<ResultContainer> OptimizedResults { get; set; }
		public IList<ResultContainer> CurrentBestResults { get; set; }
	}
}

using System;
using Ctm.Packer.Scheduler;


namespace Ctm.Packer
{
	public interface ILoader
	{
		void Load();
		ScheduleResults Results();
		void Cancel();
		bool AreRunsFinished();
		bool AreResultsReady();
	}
}
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Ctm.Domain;
using Ctm.Domain.Mappers;
using Ctm.Packer;
using Ctm.Packer.Scheduler;
using Ctm.Service.Properties;

namespace Ctm.Service
{
	public class SessionService
	{
		private IList<Session> _sessions; 
		
		public IEnumerable<Session> CreateSessions(IEnumerable<Talk> talks)
		{
			_sessions = new List<Session>();
		
			Load(talks);

			return _sessions;
		}
		public IEnumerable<Session> GetSessions()
		{
			return _sessions;
		} 
		/// <summary>
		/// Gets the unique session sizes in order of sessions per track
		/// </summary>
		/// <returns>ordered session sizes in minutes (e.g. morning session is 3hr max; afternoon is 5hr max; so returns 180,300)</returns>
		private static int[] GetUniqueFifoSessionMaxSizesPerTrack()
		{
			StringCollection sc = Settings.Default.UniqueFifoSessionMaxSize;
			var sizes = new string[sc.Count];
			sc.CopyTo(sizes, 0);
			return sizes.Select(int.Parse).ToArray();
		}
		private void Load(IEnumerable<Talk> talks)
		{
			IList<Talk> ltalks = new List<Talk>(talks);
			ILoader loader = new ScheduleLoader(GetUniqueFifoSessionMaxSizesPerTrack(), ltalks.Select(t => t.Duration).ToArray());
			loader.Load();
			//we can run off and do stuff here; if we add an even publisher in the package loader, then we could just wait for it.  
			//here we will skimp and just sit and wait since we don't have anything else to do right now since it is a small demo.
			while (!loader.AreResultsReady()) ;

			ScheduleResults results = loader.Results();
			IList<ResultContainer> resultGroup = results.OptimizedResults ?? results.CurrentBestResults;
			_sessions = Mapper.Map(_sessions, ltalks, resultGroup);
		}
	}
}
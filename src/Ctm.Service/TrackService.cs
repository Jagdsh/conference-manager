using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ctm.Domain;
using Ctm.Service.Properties;

namespace Ctm.Service
{
	/// <summary>
	/// 
	/// </summary>
	public class TrackService
	{
		/// <summary>
		/// Creates the schedule.
		/// </summary>
		/// <param name="sessions"> </param>
		/// <returns></returns>
		public string CreateSchedule(IEnumerable<Session> sessions)
		{
			IList<Track> track = CreateTrack(new List<Session>(sessions));
			return ScheduleFormatter(track);
		}

		/// <summary>
		/// Schedules the formatter.
		/// </summary>
		/// <remarks>
		/// </remarks>
		/// <param name="tracks">The tracks.</param>
		/// <returns></returns>
		private string ScheduleFormatter(IList<Track> tracks)
		{
			StringBuilder sb = new StringBuilder();

			foreach (var track in tracks)
			{
				var queue = new Queue<Session>(track.Sessions);

				sb.AppendLine(track.Title);
				sb.AppendLine();
				
				foreach (var talk in queue.Dequeue().Talks)
				{
					sb.AppendFormat("{0}\t\t{1}{2}", talk.StartTime.ToShortTimeString(), talk.Title, Environment.NewLine);
				}
				
				sb.AppendFormat("{0}\t\t{1}{2}", track.LunchStart.ToShortTimeString(), track.LunchTitle, Environment.NewLine);
				
				foreach (var talk in queue.Dequeue().Talks)
				{
					sb.AppendFormat("{0}\t\t{1}{2}", talk.StartTime.ToShortTimeString(), talk.Title, Environment.NewLine);
				}

				sb.AppendFormat("{0}\t\t{1}{2}", track.NetworkingEventStart.ToShortTimeString(), track.NetworkingEventTitle, Environment.NewLine);
				sb.AppendLine();
			}

			return sb.ToString();
		}

		private IList<Track> CreateTrack(IList<Session> sessions)
		{
			var queue = new Queue<Session>(sessions);
			IList<Track> tracks = new List<Track>();
			int t1 = 1;

			while (queue.Count > 0)
			{
				var track = new Track() {Sessions = new List<Session>()};

				track.Title = "TRACK " + t1++;
				track.Sessions.Add(queue.Dequeue());
				track.LunchStart = Convert.ToDateTime(Settings.Default.LunchTime);
				track.Sessions.Add(queue.Peek());
				track.NetworkingEventStart = CalculateEventTime(queue.Dequeue());

				tracks.Add(track);
			}

			return tracks;
		}

		private DateTime CalculateEventTime(Session session)
		{
			DateTime networkMin = Convert.ToDateTime(Settings.Default.NetworkEventMinTime);
			Talk lastTalk;
			if(session.Talks.Count > 0)
			{
				lastTalk = session.Talks.Last();
			} else
			{
				return networkMin;
			}
			DateTime sessionEnds = lastTalk.StartTime.AddMinutes(lastTalk.Duration);

			return DateTime.Compare(sessionEnds, networkMin) <= 0
				       ? networkMin
				       : sessionEnds;
		}
	}
}

using System;
using System.Collections.Generic;
using Ctm.Domain.Properties;

namespace Ctm.Domain
{
    public class Track
    {
		public string Title { get; set; }
		public string LunchTitle { get { return Settings.Default.LunchTitle; } }
		public IList<Session> Sessions { get; set; }
		public DateTime LunchStart { get; set; }
		public DateTime NetworkingEventStart { get; set; }
		public string NetworkingEventTitle { get { return Settings.Default.NetworkingEventTitle; } }

    }
}
using System;
using System.Collections.Generic;

namespace Ctm.Domain
{
	public class Session 
	{
	    public DateTime StartTime { get; set; }
	    public DateTime EndTime { get; set; }
		public int Duration { get; set; }
	    public IList<Talk> Talks { get; set; }
    }
}
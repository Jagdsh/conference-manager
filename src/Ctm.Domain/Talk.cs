using System;

namespace Ctm.Domain
{
	public class Talk 
	{
        public int Id { get; set; }
        public string Title { get; set; }
		/// <summary>
		/// Gets or sets the duration.
		/// </summary>
		/// <value>
		/// The duration in minutes
		/// </value>
        public int Duration { get; set; }
		public DateTime StartTime { get; set; }
    }
}
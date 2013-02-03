using System;
using System.Collections.Generic;
using System.Linq;

namespace Ctm.Packer.Scheduler
{
	/// <summary>
	/// 
	/// </summary>
	public class ResultContainer
	{
		private IList<int> _packedParcelSizes = new List<int>();

		public int ContainerSize { get; set; }
		public IList<int> PackedParcelSizes
		{
			get { return _packedParcelSizes; }
			set { _packedParcelSizes = value; }
		}
	}
}

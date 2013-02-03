using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Ctm.Domain;
using Ctm.Service.Properties;
using Ctm.Service.ValidateStrategies;

namespace Ctm.Service
{
    public class TalkService
    {
        /// <summary>
        /// A collection of talks.
        /// Representative of data normally found in a data storage device, such as a database.
        /// For the purposes of this demo, I have placed it here.
        /// Normally, the service layer would call though a DAL to retreive its objects (e.g. hibernate, mongodb dal, etc.)
        /// </summary>
        private  IList<Talk> _talks = new List<Talk>();  

        public IEnumerable<Talk> GetTalks()
        {
            return _talks;
        }
        public Talk GetTalk(int id)
        {
            return _talks.FirstOrDefault(t => t.Id == id);
        }
		public void Reset()
		{
			_talks = new List<Talk>();
		}
        public bool TryAddTalk(string rawData)
        {
            if (!IsValidData(rawData)) return false;

            try
            {
                _talks.Add(ParseRawDataToTalk(rawData));
            }
            catch
            {
				//TODO add logging like log4net or elmah
                return false;
            }

            return true;
        }
		/// <summary>
		/// Determines whether [is valid data] [the specified raw data].
		/// </summary>
		/// <param name="rawData">The raw data.</param>
		/// <returns>
		///   <c>true</c> if [is valid data] [the specified raw data]; otherwise, <c>false</c>.
		/// </returns>
	    private bool IsValidData(string rawData)
		{
			var validateTime = new ValidateContext(new RawTime());
			var validateTitle = new ValidateContext(new RawTitle());

			return validateTime.IsValid(rawData) && validateTitle.IsValid(rawData);
		}
		private Talk ParseRawDataToTalk(string rawData)
		{
			string upperClean = rawData.Trim().ToUpper();

			if (upperClean.EndsWith(Settings.Default.TalkTimeKeyword))
			{
				return new Talk()
					       {
						       Id = _talks.Count,
						       Duration = Settings.Default.LightningValue,
						       Title = rawData.Substring(0, upperClean.LastIndexOf(Settings.Default.TalkTimeKeyword))
					       };
			}

			var regex = new Regex(Settings.Default.TalkTimePattern);
			var match = regex.Match(rawData);

			return new Talk()
				       {
					       Id = _talks.Count,
					       Duration = Int32.Parse(match.Groups["time"].Value),
					       Title = rawData.Substring(0,  match.Index).Trim()
				       };
		}
    }
}
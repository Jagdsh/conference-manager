using System;
using System.Linq;
using Ctm.Domain;
using Ctm.Service;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Ctm.Presenter.Specs
{
    [Binding]
    public class SessionSteps
    {
	    private SessionService _sessionService;
	    private TalkService _talkService;

        [Given]
        public void Given_I_have_a_new_session()
        {
	        _sessionService = new SessionService();
        }
        
        [When]
        public void When_I_add_several_talks_as_raw_data(string multilineText)
        {
	        _talkService = new TalkService();

			foreach (var line in multilineText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
			{
				_talkService.TryAddTalk(line.Trim());
			}
		}
        
        [Then]
        public void Then_there_should_be_a_morning_session()
        {
			Assert.IsNotEmpty(_sessionService.CreateSessions(_talkService.GetTalks()));
        }
        
        [Then]
        public void Then_there_shold_be_an_afternoon_session()
        {
			Assert.IsNotEmpty(_sessionService.CreateSessions(_talkService.GetTalks()));
		}
        
		/***************************/

		[Then(@"the first morning talk should be at (.*)AM")]
		public void ThenTheFirstMorningTalkShouldBeAtAM(int p0)
		{
			Assert.IsTrue(_sessionService.CreateSessions(_talkService.GetTalks()).Any(s =>
															(DateTime.Compare(s.StartTime, Convert.ToDateTime("9:00:00 AM")) == 0)
															||
															(DateTime.Compare(s.StartTime, Convert.ToDateTime("1:00:00 PM")) == 0)));
		}

		[Then(@"the last morning talk should end before (.*)PM")]
		public void ThenTheLastMorningTalkShouldEndBeforePM(int p0)
		{
			Assert.IsTrue(_sessionService.CreateSessions(_talkService.GetTalks())
				.Where(s => DateTime.Compare(s.StartTime, Convert.ToDateTime("9:00:00 AM")) == 0)
				.All(s => (DateTime.Compare(s.EndTime, Convert.ToDateTime("12:00:00 PM")) <= 0)));
		}

		[Then(@"the first afternoon talk should be at (.*)PM")]
		public void ThenTheFirstAfternoonTalkShouldBeAtPM(int p0)
		{
			Assert.IsTrue(_sessionService.CreateSessions(_talkService.GetTalks()).Any(s =>
															(DateTime.Compare(s.StartTime, Convert.ToDateTime("9:00:00 AM")) == 0)
															||
															(DateTime.Compare(s.StartTime, Convert.ToDateTime("1:00:00 PM")) == 0)));
		}

		[Then(@"the last afternoon talk should end before (.*)PM")]
		public void ThenTheLastAfternoonTalkShouldEndBeforePM(int p0)
		{
			Assert.IsTrue(_sessionService.CreateSessions(_talkService.GetTalks())
				.Where(s => DateTime.Compare(s.StartTime, Convert.ToDateTime("1:00:00 PM")) == 0)
				.All(s => (DateTime.Compare(s.EndTime, Convert.ToDateTime("5:00:00 PM")) <= 0)));
		}

	}
}

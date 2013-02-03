using System;
using System.Linq;
using Ctm.Service;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Ctm.Presenter.Specs
{
    [Binding]
    public class TalksSteps
    {
	    private TalkService _service;

        [Given]
        public void Given_I_have_a_new_schedule()
        {
	        _service = new TalkService();
        }
        
        [Given]
        public void Given_there_exists_room_for_it_on_the_schedule()
        {
			//TODO
            ScenarioContext.Current.Pending();
        }
        
        [When]
        public void When_I_enter_several_talks_as_raw_data(string multilineText)
        {
	        foreach (var line in multilineText.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries))
	        {
		        _service.TryAddTalk(line.Trim());
	        }
        }
        
        [When]
        public void When_I_add_a_talk_that_has_a_number_at_the_end_of_the_raw_data(string multilineText)
        {
	        _service.TryAddTalk(multilineText);
        }
        
        [When]
        public void When_I_add_a_talk_that_has_the_lightning_keywork_in_the_raw_data(string multilineText)
        {
	        _service.TryAddTalk(multilineText);
        }
        
        [When]
        public void When_I_add_talk_title_that_has_numbers_not_at_the_end_of_the_raw_data(string multilineText)
        {
	        _service.TryAddTalk(multilineText);
        }
        
        [When]
        public void When_the_talk_is_added_to_the_schedule()
        {
			//TODO
            ScenarioContext.Current.Pending();
        }

		[Then]
		public void Then_I_should_receive_P0_talks_returned(int p0)
		{
			Assert.AreEqual(_service.GetTalks().Count(), p0);
		}

		[Then]
        public void Then_the_talk_duration_should_be_P0_minutes(int p0)
        {
	        Assert.AreEqual(_service.GetTalks().Last().Duration, p0);
        }

        [Then]
        public void Then_the_talk_will_not_be_added()
        {
            Assert.IsTrue(!_service.GetTalks().Any());
        }
        
        [Then]
        public void Then_there_should_be_no_gaps()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

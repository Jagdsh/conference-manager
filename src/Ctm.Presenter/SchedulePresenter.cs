using System;
using System.Linq;
using Ctm.Presenter.ViewContracts;
using Ctm.Service;

namespace Ctm.Presenter
{
	/// <summary>
	/// 
	/// </summary>
	public class SchedulePresenter
	{
		private readonly IViewScheduler _view;
		private readonly TalkService _talkService;
		private readonly SessionService _sessionService;
		private readonly TrackService _trackService;

		/// <summary>
		/// Initializes a new instance of the <see cref="SchedulePresenter"/> class.
		/// </summary>
		public SchedulePresenter(IViewScheduler view)
		{
			_view = view;
			_talkService = new TalkService();
			_sessionService = new SessionService();
			_trackService = new TrackService();

			_view.SubmitTalks += SubmitSchedule;
		}

		private void SubmitSchedule(object sender, EventArgs e)
		{
			_talkService.Reset();
			foreach (var line in _view.PrposedTalks.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
			{
				_talkService.TryAddTalk(line.Trim());
			}

			_sessionService.CreateSessions(_talkService.GetTalks());

			_view.Schedule = _trackService.CreateSchedule(_sessionService.GetSessions());
		}
	}
}

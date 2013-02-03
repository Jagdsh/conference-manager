using System;

namespace Ctm.Presenter.ViewContracts
{
    public interface IViewScheduler
    {
		string Schedule { set; get; }
		string PrposedTalks { get; set; }
        event EventHandler<EventArgs> SubmitTalks;
    }
}
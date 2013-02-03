using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ctm.Presenter;
using Ctm.Presenter.ViewContracts;

namespace Cfm.Winform.View
{
	public partial class frmMain : Form, IViewScheduler
	{
		private SchedulePresenter _presenter;
		public frmMain()
		{
			InitializeComponent();

			_presenter = new SchedulePresenter(this);
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			EventHandler<EventArgs> submitting = SubmitTalks;

			if (submitting != null)
			{
				submitting(this, EventArgs.Empty);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		public string Schedule
		{
			set { txtOutput.Text = value; }
			get { return txtOutput.Text.Trim(); }
		}

		public string PrposedTalks
		{
			get { return txtInput.Text.Trim(); } 
			set { txtInput.Text = value; }
		}

		public event EventHandler<EventArgs> SubmitTalks;
	}
}

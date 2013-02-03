namespace Cfm.Winform.View
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.txtInput = new System.Windows.Forms.TextBox();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.btnCreate = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(12, 48);
			this.txtInput.Multiline = true;
			this.txtInput.Name = "txtInput";
			this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtInput.Size = new System.Drawing.Size(342, 405);
			this.txtInput.TabIndex = 0;
			this.txtInput.Text = resources.GetString("txtInput.Text");
			// 
			// txtOutput
			// 
			this.txtOutput.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.txtOutput.Location = new System.Drawing.Point(393, 48);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOutput.Size = new System.Drawing.Size(393, 405);
			this.txtOutput.TabIndex = 1;
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(12, 465);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(96, 23);
			this.btnCreate.TabIndex = 2;
			this.btnCreate.Text = "Create &Schedule";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(690, 465);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(96, 23);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(13, 29);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(168, 13);
			this.lblName.TabIndex = 4;
			this.lblName.Text = "Please enter your schedule here...";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(393, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(180, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Here is a proposed schedule for you:";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 500);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.txtInput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "YIP - Yeah, I\'m Punctual!";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label label1;
	}
}


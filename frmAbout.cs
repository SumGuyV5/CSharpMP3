/***************************************************************
**  Program Name:   C# MP3!						              **
**  Version Number: V1.0                                      **
**  Copyright (C):	October 1, 2003 Richard W. Allen		  **
**	Date Started:   September 28, 2003                        **
**  Date Ended:     October 1, 2003                           **
**  Author:         Richardn W. Allen                         **
**  Webpage:        http://richard-allen.homelinux.com		  **
**  IDE:            Micosoft Visual Stuido .NET 2002          **
**  Compiler:       C# 2002                                   **
**  Langage:        C#										  **
**	License:		GNU GENERAL PUBLIC LICENSE Version 2	  **
**					see license.txt for for details	          **
***************************************************************/

using System;
using System.Windows.Forms;	//Used the make this class a form.

namespace frmAbout
{
	public class cfrmAbout : Form
	{
		//Constructor.
		public cfrmAbout()
		{	
			InitializeComponent();
			lblTitle.Text = "C# MP3!";
			lblVersion.Text = "V1.0";
			lblDescription.Text = "\"C# MP3!\" is an MP3 player written in Visual C# and use DirectShow 9.";
			lblDisclaimer.Text = "\"C# MP3!\" Copyright (C) 2003 Richard W. Allen  \"C# MP3!\" Comes with ABSOLUTELY NO WARRANTY; for details see the license.txt include with this program."; 
		}
		
		/***  Events  ***/
		//Buttons.
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		/***  Auto generated form objects/variables  ***/
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Label lblDisclaimer;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblTitle;

		private void InitializeComponent()
		{
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblDisclaimer = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(100, 20);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(0, 13);
			this.lblTitle.TabIndex = 0;
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new System.Drawing.Point(100, 60);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(0, 13);
			this.lblVersion.TabIndex = 1;
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(10, 100);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(360, 36);
			this.lblDescription.TabIndex = 2;
			// 
			// lblDisclaimer
			// 
			this.lblDisclaimer.Location = new System.Drawing.Point(10, 180);
			this.lblDisclaimer.Name = "lblDisclaimer";
			this.lblDisclaimer.Size = new System.Drawing.Size(360, 50);
			this.lblDisclaimer.TabIndex = 3;
			// 
			// btnClose
			// 
			this.btnClose.Location = new System.Drawing.Point(15, 240);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(360, 40);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// cfrmAbout
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 292);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnClose,
																		  this.lblDisclaimer,
																		  this.lblDescription,
																		  this.lblVersion,
																		  this.lblTitle});
			this.Name = "cfrmAbout";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);
		}//InitializeComponent function ends here.
	}//cfrmAbout class ends here.
}//frmAbout name space ends here.
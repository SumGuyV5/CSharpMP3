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
using System.IO;			//Used to access the files and folders.

namespace frmMain
{
	public class cfrmMain : Form
	{	
		/***  Programmer made objects/variables  ***/
		//Member objects/variables.
		//private.
		private AudioCode.cAudioCode my_musicFile = new AudioCode.cAudioCode();
		private string my_totalPlayTime = "\0";

		/***  Programmer made functions  ***/
		//Constructor.
		public cfrmMain()
		{
			my_musicFile = new AudioCode.cAudioCode();
			
			InitializeComponent();
			Drives();
		}

		//Member functions.
		//public.
		
		//This function will get the name of the drives
		//and put it in the tree view control named "tvwFolders".
		//It is called by the constructor.
		private void Drives()
		{
			tvwFolders.Nodes.Clear();	//Clears the Tree View.
			
			//Gets the first drive Letter and puts it in the "drive" variable .
			foreach (string drive in Directory.GetLogicalDrives())
			{
				//We add the name of the drive to the Tree View 
				//and a dummy child node to get a "+" to show
				//up next to the drive.
				tvwFolders.Nodes.Add(drive).Nodes.Add("DUMMY");
			}
		}
		
		//It is call by the "lstFiles_SelectedValueChanged" event.
		private void FileLoaded()
		{
			if (my_musicFile.autorun == true)
				lblStatus.Text = "Playing";
			else
				lblStatus.Text = "Stopped";

			//We put the name of the file in the lable
			//and the forms title bar.
			lblFile.Text = lstFiles.Text;
			this.Text = "C# MP3! " + lstFiles.Text;

			//set up the PlayTime scroll bar.
			hsbPlayTime.Maximum = (int)my_musicFile.duration;
			//call the TotalPlayTime function.
			TotalPlayTime();
			
		}
	
		//This function will calculate how much time is left.
		//It is call by the "tmrTimer_Tick" event.
		private void PlayTimeUpdate()
		{
			//There we can not find out the play time 
			//if the mp3 is not load.
			if (my_musicFile.loaded == true)
			{
				//Variables
				int position = 0;
				int minutes = 0;
				int seconds = 0;
				
				position = (int)my_musicFile.position;

				//The position is in seconds.
				minutes = position / 60;

				//Find out how many seconds are left. 
				seconds = position - (minutes * 60);
                
				//If we displayed the elapsed time with out this
				//we would end up with this 
				//"Play Time: 1:8" when it sould be "Play Time: 01:08".
				if (minutes < 10)
				{
					if (seconds < 10)
						lblPlayTime.Text = "Play Time: 0" + minutes + ":0" + seconds + " / " + my_totalPlayTime;
					else
						lblPlayTime.Text = "Play Time: 0" + minutes + ":" + seconds + " / " + my_totalPlayTime;
				}
				else
				{
					if (seconds < 10)
						lblPlayTime.Text = "Play Time: " + minutes + ":0" + seconds + " / " + my_totalPlayTime;
					else
						lblPlayTime.Text = "Play Time: " + minutes + ":" + seconds + " / " + my_totalPlayTime;
				}
				//We update the bar at this time.
				hsbPlayTime.Value = position;
			}
		}
		
		//This function will calculate how much time is left.
		//It is call by the FileLoad() function.
		private void TotalPlayTime()
		{
			//There we can not find out the play time 
			//if the mp3 is not load.
			if (my_musicFile.loaded == true)
			{
				//Variables.
				int duration = 0;
				int minutes = 0;
				int seconds = 0;

				duration = (int)my_musicFile.duration;

				//The position is in seconds.
				minutes = duration / 60;

				//Find out how many seconds are left.
				seconds = duration - (minutes * 60);

				//If we displayed the elapsed time with out this
				//we would end up with this 
				//"Play Time: 1:8" when it sould be "Play Time: 01:08".
				if (minutes < 10)
				{
					if (seconds < 10)
						my_totalPlayTime = "0" + minutes + ":0" + seconds;
					else
						my_totalPlayTime = "0" + minutes + ":" + seconds;
				}
				else
				{
					if (seconds < 10)
						my_totalPlayTime = minutes + ":0" + seconds;
					else
						my_totalPlayTime = minutes + ":" + seconds;
				}
			}
		}

		/***  Events  ***/
		//Menu.
		//File Menu.
		private void mnuPlayFile_Click(object sender, System.EventArgs e)
		{
			my_musicFile.Play();
			lblStatus.Text = "Playing";
		}
		
		private void mnuStopFile_Click(object sender, System.EventArgs e)
		{
			my_musicFile.Stop();
			lblStatus.Text = "Stopped";
		}

		private void mnuPauseFile_Click(object sender, System.EventArgs e)
		{
			my_musicFile.Pause();
			if (my_musicFile.paused == true)
				lblStatus.Text = "Paused";
			else
				lblStatus.Text = "Playing";				
		}

		private void mnuExitFile_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		//Options Menu.
		private void mnuOptionsAutoPlay_Click(object sender, System.EventArgs e)
		{
			if (mnuOptionsAutoPlay.Checked == true)
				mnuOptionsAutoPlay.Checked = false;
			else
				mnuOptionsAutoPlay.Checked = true;
			
			my_musicFile.autorun = mnuOptionsAutoPlay.Checked;
		}

		//Help Menu.
		private void mnuAboutHelp_Click(object sender, EventArgs e)
		{
			frmAbout.cfrmAbout AboutForm = new frmAbout.cfrmAbout();
			AboutForm.Show();
			
		}
		
		//Buttons.
		private void btnPlay_Click(object sender, System.EventArgs e)
		{
			my_musicFile.Play();
			lblStatus.Text = "Playing";
		}
		
		private void btnStop_Click(object sender, System.EventArgs e)
		{
			my_musicFile.Stop();
			lblStatus.Text = "Stopped";
		}

		private void btnPause_Click(object sender, System.EventArgs e)
		{
			my_musicFile.Pause();
			if (my_musicFile.paused == true)
				lblStatus.Text = "Paused";
			else
				lblStatus.Text = "Playing";

		}
        
		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//Tree View.
		private void tvwFolders_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			try
			{
				string path = e.Node.FullPath;
				
				e.Node.Nodes.Clear();
				

				foreach (string dir in Directory.GetDirectories(path))
				{
					e.Node.Nodes.Add(Path.GetFileName(dir)).Nodes.Add("DUMMY");
				}
				
			}
			catch
			{
				MessageBox.Show("There was an error! When try to Expand that folder", "Folder Expand error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void tvwFolders_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			lstFiles.Items.Clear();
			string path = e.Node.FullPath;

			my_musicFile.dir = path;
			
			try
			{
				foreach (string file in Directory.GetFiles(path))
				{
					FileInfo fi = new FileInfo(file);
					if (fi.Extension == ".mp3")
					{
						lstFiles.Items.Add(fi.Name);
					}
				}
			}
			catch
			{
				MessageBox.Show("There was an error! When try to Access Directory", "Directory Access error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		//List Box.
		private void lstFiles_SelectedValueChanged(object sender, System.EventArgs e)
		{
			my_musicFile.filename = "\\" + lstFiles.Text;
			my_musicFile.Stop();
			my_musicFile.Load();
			FileLoaded();
		}

		//Timer.
		private void tmrTimer_Tick(object sender, System.EventArgs e)
		{
			PlayTimeUpdate();
		}

		//Scroll bar.
		private void hsbPlayTime_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			my_musicFile.position = hsbPlayTime.Value;
		}

		private void hsbBalance_ValueChanged(object sender, System.EventArgs e)
		{
			my_musicFile.Balance( hsbBalance.Value );
			if ( hsbBalance.Value == 0 )
				lblBalance.Text = "Balance: Center";
			else
			{
				if ( hsbBalance.Value < 0 )
					lblBalance.Text = "Balance: Left " + (hsbBalance.Value / -50)  + "%";
				else
					lblBalance.Text = "Balance: Right " + (hsbBalance.Value / 50) + "%";
			}

		}

		private void hsbVolume_ValueChanged(object sender, System.EventArgs e)
		{
			my_musicFile.Volume( hsbVolume.Value );
			lblVolume.Text = "Volume: " + (hsbVolume.Value + 100) + "%";
		}

		/***  Auto generated form objects/variables  ***/
		private System.Windows.Forms.MainMenu mnuMainMenu;
		private System.Windows.Forms.MenuItem mnuFile;
		private System.Windows.Forms.MenuItem mnuPlayFile;
		private System.Windows.Forms.MenuItem mnuStopFile;
		private System.Windows.Forms.MenuItem mnuPauseFile;
		private System.Windows.Forms.MenuItem mnuHyphenFile;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuAboutHelp;
		private System.Windows.Forms.TreeView tvwFolders;
		private System.Windows.Forms.ListBox lstFiles;
		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.HScrollBar hsbPlayTime;
		private System.Windows.Forms.Label lblPlayTime;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label lblFile;
		private System.Windows.Forms.Timer tmrTimer;
		private System.Windows.Forms.MenuItem mnuOptions;
		private System.Windows.Forms.MenuItem mnuOptionsAutoPlay;
		private System.Windows.Forms.MenuItem mnuExitFile;
		private System.Windows.Forms.Label lblBalance;
		private System.Windows.Forms.HScrollBar hsbBalance;
		private System.Windows.Forms.Label lblVolume;
		private System.Windows.Forms.HScrollBar hsbVolume;
	
		/*** Auto generated form functions  ***/
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.mnuMainMenu = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuPlayFile = new System.Windows.Forms.MenuItem();
			this.mnuStopFile = new System.Windows.Forms.MenuItem();
			this.mnuPauseFile = new System.Windows.Forms.MenuItem();
			this.mnuHyphenFile = new System.Windows.Forms.MenuItem();
			this.mnuExitFile = new System.Windows.Forms.MenuItem();
			this.mnuOptions = new System.Windows.Forms.MenuItem();
			this.mnuOptionsAutoPlay = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuAboutHelp = new System.Windows.Forms.MenuItem();
			this.tvwFolders = new System.Windows.Forms.TreeView();
			this.lstFiles = new System.Windows.Forms.ListBox();
			this.btnPlay = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnPause = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.lblFile = new System.Windows.Forms.Label();
			this.lblStatus = new System.Windows.Forms.Label();
			this.hsbPlayTime = new System.Windows.Forms.HScrollBar();
			this.lblPlayTime = new System.Windows.Forms.Label();
			this.tmrTimer = new System.Windows.Forms.Timer(this.components);
			this.lblBalance = new System.Windows.Forms.Label();
			this.hsbBalance = new System.Windows.Forms.HScrollBar();
			this.lblVolume = new System.Windows.Forms.Label();
			this.hsbVolume = new System.Windows.Forms.HScrollBar();
			this.SuspendLayout();
			// 
			// mnuMainMenu
			// 
			this.mnuMainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.mnuFile,
																						this.mnuOptions,
																						this.mnuHelp});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuPlayFile,
																					this.mnuStopFile,
																					this.mnuPauseFile,
																					this.mnuHyphenFile,
																					this.mnuExitFile});
			this.mnuFile.Text = "&File";
			// 
			// mnuPlayFile
			// 
			this.mnuPlayFile.Index = 0;
			this.mnuPlayFile.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.mnuPlayFile.Text = "&Play";
			this.mnuPlayFile.Click += new System.EventHandler(this.mnuPlayFile_Click);
			// 
			// mnuStopFile
			// 
			this.mnuStopFile.Index = 1;
			this.mnuStopFile.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.mnuStopFile.Text = "&Stop";
			this.mnuStopFile.Click += new System.EventHandler(this.mnuStopFile_Click);
			// 
			// mnuPauseFile
			// 
			this.mnuPauseFile.Index = 2;
			this.mnuPauseFile.Shortcut = System.Windows.Forms.Shortcut.CtrlU;
			this.mnuPauseFile.Text = "Pa&use";
			this.mnuPauseFile.Click += new System.EventHandler(this.mnuPauseFile_Click);
			// 
			// mnuHyphenFile
			// 
			this.mnuHyphenFile.Index = 3;
			this.mnuHyphenFile.Text = "-";
			// 
			// mnuExitFile
			// 
			this.mnuExitFile.Index = 4;
			this.mnuExitFile.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.mnuExitFile.Text = "E&xit";
			this.mnuExitFile.Click += new System.EventHandler(this.mnuExitFile_Click);
			// 
			// mnuOptions
			// 
			this.mnuOptions.Index = 1;
			this.mnuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mnuOptionsAutoPlay});
			this.mnuOptions.Text = "&Options";
			// 
			// mnuOptionsAutoPlay
			// 
			this.mnuOptionsAutoPlay.Checked = true;
			this.mnuOptionsAutoPlay.Index = 0;
			this.mnuOptionsAutoPlay.Text = "Auto Play";
			this.mnuOptionsAutoPlay.Click += new System.EventHandler(this.mnuOptionsAutoPlay_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 2;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuAboutHelp});
			this.mnuHelp.Text = "&Help";
			// 
			// mnuAboutHelp
			// 
			this.mnuAboutHelp.Index = 0;
			this.mnuAboutHelp.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.mnuAboutHelp.Text = "&About";
			this.mnuAboutHelp.Click += new System.EventHandler(this.mnuAboutHelp_Click);
			// 
			// tvwFolders
			// 
			this.tvwFolders.ImageIndex = -1;
			this.tvwFolders.Location = new System.Drawing.Point(5, 5);
			this.tvwFolders.Name = "tvwFolders";
			this.tvwFolders.SelectedImageIndex = -1;
			this.tvwFolders.Size = new System.Drawing.Size(320, 200);
			this.tvwFolders.TabIndex = 0;
			this.tvwFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwFolders_AfterSelect);
			this.tvwFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwFolders_BeforeExpand);
			// 
			// lstFiles
			// 
			this.lstFiles.Location = new System.Drawing.Point(5, 210);
			this.lstFiles.Name = "lstFiles";
			this.lstFiles.Size = new System.Drawing.Size(320, 199);
			this.lstFiles.TabIndex = 1;
			this.lstFiles.SelectedValueChanged += new System.EventHandler(this.lstFiles_SelectedValueChanged);
			// 
			// btnPlay
			// 
			this.btnPlay.Location = new System.Drawing.Point(8, 424);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(96, 40);
			this.btnPlay.TabIndex = 2;
			this.btnPlay.Text = "&Play";
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(112, 424);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(96, 40);
			this.btnStop.TabIndex = 3;
			this.btnStop.Text = "&Stop";
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnPause
			// 
			this.btnPause.Location = new System.Drawing.Point(216, 424);
			this.btnPause.Name = "btnPause";
			this.btnPause.Size = new System.Drawing.Size(96, 40);
			this.btnPause.TabIndex = 4;
			this.btnPause.Text = "Pa&use";
			this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(592, 424);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(96, 40);
			this.btnExit.TabIndex = 6;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// lblFile
			// 
			this.lblFile.AutoSize = true;
			this.lblFile.Location = new System.Drawing.Point(336, 40);
			this.lblFile.Name = "lblFile";
			this.lblFile.Size = new System.Drawing.Size(0, 13);
			this.lblFile.TabIndex = 7;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(336, 8);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(0, 13);
			this.lblStatus.TabIndex = 8;
			// 
			// hsbPlayTime
			// 
			this.hsbPlayTime.Location = new System.Drawing.Point(336, 120);
			this.hsbPlayTime.Name = "hsbPlayTime";
			this.hsbPlayTime.Size = new System.Drawing.Size(344, 16);
			this.hsbPlayTime.TabIndex = 9;
			this.hsbPlayTime.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbPlayTime_Scroll);
			// 
			// lblPlayTime
			// 
			this.lblPlayTime.AutoSize = true;
			this.lblPlayTime.Location = new System.Drawing.Point(336, 80);
			this.lblPlayTime.Name = "lblPlayTime";
			this.lblPlayTime.Size = new System.Drawing.Size(127, 13);
			this.lblPlayTime.TabIndex = 10;
			this.lblPlayTime.Text = "Play Time: 00:00 / 00:00";
			// 
			// tmrTimer
			// 
			this.tmrTimer.Enabled = true;
			this.tmrTimer.Tick += new System.EventHandler(this.tmrTimer_Tick);
			// 
			// lblBalance
			// 
			this.lblBalance.AutoSize = true;
			this.lblBalance.Location = new System.Drawing.Point(336, 160);
			this.lblBalance.Name = "lblBalance";
			this.lblBalance.Size = new System.Drawing.Size(85, 13);
			this.lblBalance.TabIndex = 11;
			this.lblBalance.Text = "Balance: Center";
			// 
			// hsbBalance
			// 
			this.hsbBalance.LargeChange = 1;
			this.hsbBalance.Location = new System.Drawing.Point(336, 200);
			this.hsbBalance.Maximum = 5000;
			this.hsbBalance.Minimum = -5000;
			this.hsbBalance.Name = "hsbBalance";
			this.hsbBalance.Size = new System.Drawing.Size(344, 16);
			this.hsbBalance.TabIndex = 12;
			this.hsbBalance.ValueChanged += new System.EventHandler(this.hsbBalance_ValueChanged);
			// 
			// lblVolume
			// 
			this.lblVolume.AutoSize = true;
			this.lblVolume.Location = new System.Drawing.Point(336, 240);
			this.lblVolume.Name = "lblVolume";
			this.lblVolume.Size = new System.Drawing.Size(78, 13);
			this.lblVolume.TabIndex = 13;
			this.lblVolume.Text = "Volume: 100%";
			// 
			// hsbVolume
			// 
			this.hsbVolume.LargeChange = 1;
			this.hsbVolume.Location = new System.Drawing.Point(336, 280);
			this.hsbVolume.Maximum = 0;
			this.hsbVolume.Minimum = -100;
			this.hsbVolume.Name = "hsbVolume";
			this.hsbVolume.Size = new System.Drawing.Size(344, 16);
			this.hsbVolume.TabIndex = 14;
			this.hsbVolume.ValueChanged += new System.EventHandler(this.hsbVolume_ValueChanged);
			// 
			// cfrmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(692, 473);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.hsbVolume,
																		  this.lblVolume,
																		  this.hsbBalance,
																		  this.lblBalance,
																		  this.lblPlayTime,
																		  this.hsbPlayTime,
																		  this.lblStatus,
																		  this.lblFile,
																		  this.btnExit,
																		  this.btnPause,
																		  this.btnStop,
																		  this.btnPlay,
																		  this.lstFiles,
																		  this.tvwFolders});
			this.MaximizeBox = false;
			this.Menu = this.mnuMainMenu;
			this.MinimizeBox = false;
			this.Name = "cfrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.ResumeLayout(false);

		}//InitializeComponent function ends here.
	}//cfrmMain class ends here.
}//frmMain name space ends here.
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
using System.Windows.Forms;					//Used the make this class a form.
using Microsoft.DirectX.AudioVideoPlayback;	//Used the Audio class from directshow 9.

namespace AudioCode
{
	public class cAudioCode
	{
		//Member objects/variables.
		//private.
		private Audio my_mp3;	//Audio is the DX class for DirectShow 9.

		//Used to store the directory and filename of the file.
		private string my_dir = "\0";
		private string my_fileName = "\0";

		//Used to store the status of auto run.
		private bool my_autorun = true;
		private bool my_paused = false;
		private bool my_play = false;
		private bool my_loaded = false;

		private double my_position = 0.0;
		private double my_duration = 0.0;

		//Constructor.
		public cAudioCode()
		{
		}
		
		//Member functions.
		//public.
		public void Play()
		{
			try
			{
				if (my_play == false)
				{
					my_mp3.Play();
				}
			}
			catch
			{
				MessageBox.Show("There was an error! When try to Play " + my_fileName + "!", "Play error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			
		}

		public void Stop()
        {
			try
			{	
				if (my_loaded == true)
					my_mp3.Stop();
			}
			catch
			{
				MessageBox.Show("There was an error! When try to Stop " + my_fileName + "!", "Stop error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void Pause()
		{
			try
			{
				if (my_paused == false)
					my_mp3.Pause();
				else
					my_mp3.Play();
			}
			catch
			{
				MessageBox.Show("There was an error! When try to Pause " + my_fileName + "!", "Pause error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void Load()
		{
			try
			{
				my_mp3 = new Audio(string.Concat(my_dir, my_fileName), my_autorun);
				my_loaded = true;
			}
			catch
			{
				MessageBox.Show("There was an error! When try to Load " + my_fileName + "!", "Load error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void Balance( int balance )
		{
			try
			{
				if (my_loaded == true)
					my_mp3.Balance = balance;
			}
			catch
			{
				MessageBox.Show("There was an error! When try to change the balance", "Sound balance error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void Volume( int volume )
		{
			try
			{
				if (my_loaded == true)
					my_mp3.Volume = ((volume) * 20);
			}
			catch
			{
				MessageBox.Show("There was an error! When try to change the volume", "Sound volume error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}


		//Member objects/variables get and set.
		public string dir
		{
			get
			{
				return my_dir;
			}
			set
			{
				my_dir = value;
			}
		}

		public string filename
		{
			get
			{
				return my_fileName;
			}
			set
			{
				my_fileName = value;
			}
		}

		public bool autorun
		{
			get
			{
				return my_autorun;
			}
			set
			{
				my_autorun = value;
			}
		}

		public bool paused
		{
			get
			{
				my_paused = my_mp3.Paused;
				return my_paused;
			}
		}

		public bool play
		{
			get
			{
				my_play = my_mp3.Playing;
				return my_play;
			}
		}

		public bool loaded
		{
			get
			{
				return my_loaded;
			}
		}

		public double position
		{
			get
			{
				my_position = my_mp3.CurrentPosition;
				return my_position;
			}
			set
			{
				my_position = value;
				my_mp3.CurrentPosition = my_position;
			}
		}
		
		public double duration
		{
			get
			{
				my_duration = my_mp3.Duration;
				return my_duration;
			}
		}
	}//cAudioCode class ends here.
}//AudioCode name space ends here.

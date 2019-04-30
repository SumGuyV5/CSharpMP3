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

//Used in this file
using System;								//Used in all files
//Not Used here
using System.Windows.Forms;					//Used in frmMain.cs fromAbout.cs and AudioCode.cs
using System.IO;							//Used in frmMain.cs
using Microsoft.DirectX.AudioVideoPlayback;	//Used in AudioCode.cs

namespace Main
{
	public class cMain
	{
		//Program starts here.
		public static void Main()
		{
			frmMain.cfrmMain MainForm = new frmMain.cfrmMain();
			Application.Run(MainForm);
		}
		
		//Constructor.
		public cMain()
		{
		}
	}
		
}
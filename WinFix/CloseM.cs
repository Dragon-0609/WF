using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

//:: Class that is used for in-game sound effects ::
namespace RA {
	public class CloseM
	{
		[DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]

		private static extern int mciSendString (string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);


		private string strAudioLen = new string (Convert.ToChar (" "), 128);
	//:: Properties for this class ::


		private string SndToPLay;
		public CloseM (string Snd)
		{
			//------------------------------------------------------------------------------------------------------------------
			// Purpose: Constructor for creating an instance of this class 
			//------------------------------------------------------------------------------------------------------------------

			this.SndToPLay = Snd;

		}

		public void Open ()
		{
			//------------------------------------------------------------------------------------------------------------------
			// Purpose: Open audio file
			//------------------------------------------------------------------------------------------------------------------

			string Path = null;

			Path = this.SndToPLay;

			mciSendString ("close myaudio", "", 0, 0);
			mciSendString ("open \"" + Path + "\" alias myaudio", "", 0, 0);
			mciSendString ("set myaudio time format ms", "", 0, 0);
			mciSendString ("status myaudio length", strAudioLen, 128, 0);

		}

		public static void Close ()
		{
			//------------------------------------------------------------------------------------------------------------------
			// Purpose: Close audio file
			//------------------------------------------------------------------------------------------------------------------

			mciSendString ("close myaudio", "", 0, 0);

		}

		public void PlaySnd ()
		{
			//------------------------------------------------------------------------------------------------------------------
			// Purpose: Play audio file
			//------------------------------------------------------------------------------------------------------------------

			mciSendString ("play myaudio", "", 0, 0);

		}

		public void StartFrom(int Milliseconds)
		{
			//------------------------------------------------------------------------------------------------------------------
			// Purpose: Play audio file from (n) mS position 
			//------------------------------------------------------------------------------------------------------------------

			mciSendString ("play myaudio from " + Milliseconds.ToString (), "", 0, 0);

		}
	}

}

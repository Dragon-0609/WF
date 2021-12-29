using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace RA
{
	public static class HControl
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
		static extern IntPtr SendMessage(IntPtr handle, UInt32 message, IntPtr w, IntPtr l);

		static uint WM_CLOSE = 0x10;

		public static void CloseWindow(IntPtr handle)
		{
			SendMessage(handle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
		}

		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd,
			int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();

		public static void Move(IntPtr Handle, MouseEventArgs e)
		{
			//Add the the .MouseDown() event:
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

	}
}


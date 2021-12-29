using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace RA
{
	public class NativeMethods
	{


		#region WindowMessages
		public enum WindowMessages
		{
			WM_NULL = 0x0000,
			WM_CREATE = 0x0001,
			WM_DESTROY = 0x0002,
			WM_MOVE = 0x0003,
			WM_SIZE = 0x0005,
			WM_ACTIVATE = 0x0006,
			WM_SETFOCUS = 0x0007,
			WM_KILLFOCUS = 0x0008,
			WM_ENABLE = 0x000A,
			WM_SETREDRAW = 0x000B,
			WM_SETTEXT = 0x000C,
			WM_GETTEXT = 0x000D,
			WM_GETTEXTLENGTH = 0x000E,
			WM_PAINT = 0x000F,
			WM_CLOSE = 0x0010,

			WM_QUIT = 0x0012,
			WM_ERASEBKGND = 0x0014,
			WM_SYSCOLORCHANGE = 0x0015,
			WM_SHOWWINDOW = 0x0018,

			WM_ACTIVATEAPP = 0x001C,

			WM_SETCURSOR = 0x0020,
			WM_MOUSEACTIVATE = 0x0021,
			WM_GETMINMAXINFO = 0x24,
			WM_WINDOWPOSCHANGING = 0x0046,
			WM_WINDOWPOSCHANGED = 0x0047,

			WM_CONTEXTMENU = 0x007B,
			WM_STYLECHANGING = 0x007C,
			WM_STYLECHANGED = 0x007D,
			WM_DISPLAYCHANGE = 0x007E,
			WM_GETICON = 0x007F,
			WM_SETICON = 0x0080,

			// non client area
			WM_NCCREATE = 0x0081,
			WM_NCDESTROY = 0x0082,
			WM_NCCALCSIZE = 0x0083,
			WM_NCHITTEST = 0x84,
			WM_NCPAINT = 0x0085,
			WM_NCACTIVATE = 0x0086,

			WM_GETDLGCODE = 0x0087,

			WM_SYNCPAINT = 0x0088,

			// non client mouse
			WM_NCMOUSEMOVE = 0x00A0,
			WM_NCLBUTTONDOWN = 0x00A1,
			WM_NCLBUTTONUP = 0x00A2,
			WM_NCLBUTTONDBLCLK = 0x00A3,
			WM_NCRBUTTONDOWN = 0x00A4,
			WM_NCRBUTTONUP = 0x00A5,
			WM_NCRBUTTONDBLCLK = 0x00A6,
			WM_NCMBUTTONDOWN = 0x00A7,
			WM_NCMBUTTONUP = 0x00A8,
			WM_NCMBUTTONDBLCLK = 0x00A9,

			// keyboard
			WM_KEYDOWN = 0x0100,
			WM_KEYUP = 0x0101,
			WM_CHAR = 0x0102,

			WM_SYSCOMMAND = 0x0112,

			// menu
			WM_INITMENU = 0x0116,
			WM_INITMENUPOPUP = 0x0117,
			WM_MENUSELECT = 0x011F,
			WM_MENUCHAR = 0x0120,
			WM_ENTERIDLE = 0x0121,
			WM_MENURBUTTONUP = 0x0122,
			WM_MENUDRAG = 0x0123,
			WM_MENUGETOBJECT = 0x0124,
			WM_UNINITMENUPOPUP = 0x0125,
			WM_MENUCOMMAND = 0x0126,

			WM_CHANGEUISTATE = 0x0127,
			WM_UPDATEUISTATE = 0x0128,
			WM_QUERYUISTATE = 0x0129,

			// mouse
			WM_MOUSEFIRST = 0x0200,
			WM_MOUSEMOVE = 0x0200,
			WM_LBUTTONDOWN = 0x0201,
			WM_LBUTTONUP = 0x0202,
			WM_LBUTTONDBLCLK = 0x0203,
			WM_RBUTTONDOWN = 0x0204,
			WM_RBUTTONUP = 0x0205,
			WM_RBUTTONDBLCLK = 0x0206,
			WM_MBUTTONDOWN = 0x0207,
			WM_MBUTTONUP = 0x0208,
			WM_MBUTTONDBLCLK = 0x0209,
			WM_MOUSEWHEEL = 0x020A,
			WM_MOUSELAST = 0x020D,

			WM_PARENTNOTIFY = 0x0210,
			WM_ENTERMENULOOP = 0x0211,
			WM_EXITMENULOOP = 0x0212,

			WM_NEXTMENU = 0x0213,
			WM_SIZING = 0x0214,
			WM_CAPTURECHANGED = 0x0215,
			WM_MOVING = 0x0216,

			WM_ENTERSIZEMOVE = 0x0231,
			WM_EXITSIZEMOVE = 0x0232,

			WM_MOUSELEAVE = 0x02A3,
			WM_MOUSEHOVER = 0x02A1,
			WM_NCMOUSEHOVER = 0x02A0,
			WM_NCMOUSELEAVE = 0x02A2,

			WM_MDIACTIVATE = 0x0222,
			WM_HSCROLL = 0x0114,
			WM_VSCROLL = 0x0115,

			WM_PRINT = 0x0317,
			WM_PRINTCLIENT = 0x0318,
		}
		#endregion //WindowMessages



		#region DCX enum
		[Flags()]
		internal enum DCX
		{
			DCX_CACHE = 0x2,
			DCX_CLIPCHILDREN = 0x8,
			DCX_CLIPSIBLINGS = 0x10,
			DCX_EXCLUDERGN = 0x40,
			DCX_EXCLUDEUPDATE = 0x100,
			DCX_INTERSECTRGN = 0x80,
			DCX_INTERSECTUPDATE = 0x200,
			DCX_LOCKWINDOWUPDATE = 0x400,
			DCX_NORECOMPUTE = 0x100000,
			DCX_NORESETATTRS = 0x4,
			DCX_PARENTCLIP = 0x20,
			DCX_VALIDATE = 0x200000,
			DCX_WINDOW = 0x1,
		}
		#endregion //DCX







		#region RECT structure

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;

			public RECT(int left, int top, int right, int bottom)
			{
				this.left = left;
				this.top = top;
				this.right = right;
				this.bottom = bottom;
			}

			public Rectangle Rect { get { return new Rectangle(this.left, this.top, this.right - this.left, this.bottom - this.top); } }

			public static RECT FromXYWH(int x, int y, int width, int height)
			{
				return new RECT(x,
					y,
					x + width,
					y + height);
			}

			public static RECT FromRectangle(Rectangle rect)
			{
				return new RECT(rect.Left,
					rect.Top,
					rect.Right,
					rect.Bottom);
			}
		}

		#endregion RECT structure





		#region TRACKMOUSEEVENT structure

		[StructLayout(LayoutKind.Sequential)]
		public class TRACKMOUSEEVENT
		{
			public TRACKMOUSEEVENT()
			{
				this.cbSize = Marshal.SizeOf(typeof(NativeMethods.TRACKMOUSEEVENT));
				this.dwHoverTime = 100;
			}

			public int cbSize;
			public int dwFlags;
			public IntPtr hwndTrack;
			public int dwHoverTime;
		}

		#endregion



		#region TernaryRasterOperations enum

		public enum TernaryRasterOperations
		{
			SRCCOPY = 0x00CC0020, /* dest = source*/
			SRCPAINT = 0x00EE0086, /* dest = source OR dest*/
			SRCAND = 0x008800C6, /* dest = source AND dest*/
			SRCINVERT = 0x00660046, /* dest = source XOR dest*/
			SRCERASE = 0x00440328, /* dest = source AND (NOT dest )*/
			NOTSRCCOPY = 0x00330008, /* dest = (NOT source)*/
			NOTSRCERASE = 0x001100A6, /* dest = (NOT src) AND (NOT dest) */
			MERGECOPY = 0x00C000CA, /* dest = (source AND pattern)*/
			MERGEPAINT = 0x00BB0226, /* dest = (NOT source) OR dest*/
			PATCOPY = 0x00F00021, /* dest = pattern*/
			PATPAINT = 0x00FB0A09, /* dest = DPSnoo*/
			PATINVERT = 0x005A0049, /* dest = pattern XOR dest*/
			DSTINVERT = 0x00550009, /* dest = (NOT dest)*/
			BLACKNESS = 0x00000042, /* dest = BLACK*/
			WHITENESS = 0x00FF0062, /* dest = WHITE*/
		};

		#endregion

		#region Constants

		public static readonly IntPtr TRUE = new IntPtr(1);
		public static readonly IntPtr FALSE = new IntPtr(0);

		public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

		#endregion

		#region API methods



		[DllImport("user32.dll")]
		public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

		[DllImport("user32.dll")]
		public static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);

		[DllImport("user32.dll")]
		public static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);



		public const int VK_LBUTTON = 0x01;
		public const int VK_RBUTTON = 0x02;





		public static int GetLastError()
		{
			return System.Runtime.InteropServices.Marshal.GetLastWin32Error();
		}



		[DllImport("gdi32.dll")]
		public static extern bool DeleteDC(IntPtr hDC);

		#endregion


	}
}


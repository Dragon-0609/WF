using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RA
{
	public enum SystemMetric : int
	{


		/// <summary>
		/// The width of a window border, in pixels. This is equivalent to the SM_CXEDGE value for windows with the 3-D look.
		/// </summary>
		SM_CXBORDER = 5,

		/// <summary>
		/// The width of a cursor, in pixels. The system cannot create cursors of other sizes.
		/// </summary>
		SM_CXCURSOR = 13,

		/// <summary>
		/// This value is the same as SM_CXFIXEDFRAME.
		/// </summary>
		SM_CXDLGFRAME = 7,



		/// <summary>
		/// This value is the same as SM_CXSIZEFRAME.
		/// </summary>
		SM_CXFRAME = 32,


		/// <summary>
		/// The width of a button in a window caption or title bar, in pixels.
		/// </summary>
		SM_CXSIZE = 30,

		/// <summary>
		/// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. 
		/// SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. 
		/// This value is the same as SM_CXFRAME.
		/// </summary>
		SM_CXSIZEFRAME = 32,


		/// <summary>
		/// The height of a window border, in pixels. This is equivalent to the SM_CYEDGE value for windows with the 3-D look.
		/// </summary>
		SM_CYBORDER = 6,

		/// <summary>
		/// The height of a caption area, in pixels.
		/// </summary>
		SM_CYCAPTION = 4,





		/// <summary>
		/// This value is the same as SM_CYSIZEFRAME.
		/// </summary>
		SM_CYFRAME = 33,


		/// <summary>
		/// The height of a button in a window caption or title bar, in pixels.
		/// </summary>
		SM_CYSIZE = 31,

		/// <summary>
		/// The thickness of the sizing border around the perimeter of a window that can be resized, in pixels. 
		/// SM_CXSIZEFRAME is the width of the horizontal border, and SM_CYSIZEFRAME is the height of the vertical border. 
		/// This value is the same as SM_CYFRAME.
		/// </summary>
		SM_CYSIZEFRAME = 33,

		/// <summary>
		/// The height of a small caption, in pixels.
		/// </summary>
		SM_CYSMCAPTION = 51,

		/// <summary>
		/// The recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
		/// </summary>
		SM_CYSMICON = 50,

		/// <summary>
		/// The height of small caption buttons, in pixels.
		/// </summary>
		SM_CYSMSIZE = 53,



	}
}


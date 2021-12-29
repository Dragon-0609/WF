using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RA
{
	public class MButton:Button{
		public MButton(){
			SetStyle (ControlStyles.Selectable, false);
		}
	}
}


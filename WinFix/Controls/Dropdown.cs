using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace RA
{
	public class Dropdown:ComboBox{
		public Dropdown(){
			SetStyle (ControlStyles.Selectable, false);

		}
	}
}


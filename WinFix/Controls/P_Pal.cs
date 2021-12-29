using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace RA
{
	public class P_Pal:Panel{
		public Label lb;
		public P_Pal(string text,EventHandler events){
			Size = new Size (180, 20);
			lb = new Label ();
			lb.Text = text;
			lb.TextAlign = ContentAlignment.MiddleLeft;
			lb.Size = new Size (200, 20);
			lb.BackColor = Color.FromArgb (0, 0, 0, 0);
			BackColor = Color.Gray;
			lb.ForeColor = Color.White;
			lb.Click += events;
			Controls.Add (lb);
		}
	}
}


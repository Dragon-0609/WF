using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace WF_PRO
{
	public class G2Button:Button
	{
		public Point locs;
		public string TX;
		public G2Button ()
		{
			SetStyle (ControlStyles.Selectable, false);
			FlatStyle = FlatStyle.Flat;
			FlatAppearance.BorderSize = 0;
			AccessibleName = "GButton";
			Size = new Size (20, 40);
			Font = new Font ("Consolas", 14);
			locs = new Point (5, 15);
			DrawT ();
		}


		public void ChangeStyle(int rotate)
		{
			switch (rotate) {
			case 1:
				{
					locs = new Point (-2, 15);
					Size = new Size (20, 40);
				}
				break;
			case 2:
				{
					locs = new Point (25, 0);
					Size = new Size (40, 20);
				}
				break;
			case 3:
				{
					locs = new Point (5, 15);
					Size = new Size (20, 40);
				}
				break;
			case 4:
				{
					locs = new Point (0, 0);
					Size = new Size (40, 20);
				}
				break;
			case 5:
				{
					locs = new Point (25, 0);
					Size = new Size (40, 20);
				}
				break;
			case 6:
				{
					locs = new Point (0, 0);
					Size = new Size (40, 20);
				}
				break;
			}
			Region = new Region (CreateReg (this.ClientRectangle, rotate));
			Refresh ();
		}

		public void DrawT()
		{
			Paint+= (object sender, PaintEventArgs e) => {
				e.Graphics.DrawString(TX,Font,new SolidBrush(ForeColor),locs);
			};
		}

		public static GraphicsPath CreateReg(Rectangle rect,int mode)
		{
			GraphicsPath gp = new GraphicsPath ();
			switch (mode) {
			case 1:
				{
					gp.AddLine (0, rect.Height, 0 , 0);
					gp.AddLine (0, 0, rect.Width, rect.Height);
					gp.AddLine (rect.Width , rect.Height, 0,rect.Height);
				}
				break;
			case 2:
				{
					gp.AddLine (rect.Width, rect.Height, 0 , 0);
					gp.AddLine (0, 0, rect.Width, 0);
					gp.AddLine (rect.Width , 0, rect.Width,rect.Height);

				}
				break;
			case 3:
				{
					gp.AddLine (0, rect.Height, rect.Width , 0);
					gp.AddLine (rect.Width , 0, rect.Width,rect.Height);
					gp.AddLine ( rect.Width,rect.Height, 0,rect.Height);
				}
				break;
			case 4:
				{
					gp.AddLine (0, 0, rect.Width, rect.Height);
					gp.AddLine (rect.Width, rect.Height, 0, rect.Height);
					gp.AddLine (0, rect.Height, 0, 0);

				}
				break;
			case 5:
				{
					gp.AddLine (rect.Width, 0, 0, rect.Height);
					gp.AddLine (0, rect.Height, rect.Width, rect.Height);
					gp.AddLine (rect.Width, rect.Height, rect.Width, 0);

				}
				break;
			case 6:
				{
					gp.AddLine (0, 0, rect.Width,0);
					gp.AddLine (rect.Width, 0, 0, rect.Height);
					gp.AddLine (0, rect.Height, 0, 0);

				}
				break;
			}
			gp.CloseFigure ();

			gp.FillMode = FillMode.Winding;

			return gp;
		}

	}
}


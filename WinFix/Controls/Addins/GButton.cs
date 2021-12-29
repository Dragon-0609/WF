using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace WF_PRO
{
	public class GButton:Button
	{
		public GButton ()
		{
			SetStyle (ControlStyles.Selectable, false);
			FlatStyle = FlatStyle.Flat;
			FlatAppearance.BorderSize = 0;
			AccessibleName = "GButton";
			Size = new Size (40, 40);
			Font = new Font ("Consolas", 14);

		}

		public void ChangeStyle(int rotate)
		{
			Region = new Region (CreateReg (this.ClientRectangle, rotate));
		}

		public static GraphicsPath CreateReg(Rectangle rect,int mode)
		{
			GraphicsPath gp = new GraphicsPath ();
			switch (mode) {
			case 1:
				{
					gp.AddLine (rect.Width, 0, (rect.Width / 2) + 5, rect.Height / 3);
					gp.AddLine ((rect.Width / 2) + 5, rect.Height / 3, rect.Width/2,rect.Height);
					gp.AddLine ( rect.Width/2,rect.Height, 0, 0);
					gp.AddLine (0, 0, rect.Width, 0);
				}
				break;

			case 2:
				{
					gp.AddLine (0, rect.Height, rect.Width / 3, (rect.Height / 2) + 5);
					gp.AddLine ( rect.Width / 3, (rect.Height / 2) + 5, rect.Width,rect.Height/2);
					gp.AddLine ( rect.Width,rect.Height/2, 0, 0);
					gp.AddLine (0, 0, 0, rect.Height);

				}
				break;
			case 3:
				{
					gp.AddLine (0, 0, (rect.Width / 2) - 5, rect.Height / 3);
					gp.AddLine ((rect.Width / 2) - 5, rect.Height / 3, rect.Width/2,rect.Height);
					gp.AddLine ( rect.Width/2,rect.Height, rect.Width, 0);
					gp.AddLine (rect.Width, 0, 0, 0);

				}
				break;
			case 4:
				{
					gp.AddLine (rect.Width, 0, (rect.Width / 2)+5, rect.Height / 3);
					gp.AddLine ((rect.Width / 2)+5, rect.Height / 3 , 0,rect.Height/2);
					gp.AddLine (0,rect.Height/2, rect.Width, rect.Height);
					gp.AddLine (rect.Width,rect.Height, rect.Width, 0);

				}
				break;
			}
			gp.CloseFigure ();

			gp.FillMode = FillMode.Winding;

			return gp;
		}

	}
}


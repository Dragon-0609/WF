using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RA
{

	public class GButton:Button{
		public string _text;
		public int Angle = 342;
		public Vector vect = new Vector ();

		public GButton(string text){
			SetStyle (ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
			SetStyle (ControlStyles.Selectable, false);
			Size = new Size (65, 30);
			_text = text;
			FlatStyle = FlatStyle.Flat;
			FlatAppearance.BorderSize = 0;
			Text = "";
			Font = new Font (DefaultFont.FontFamily, 8);
			TextAlign = ContentAlignment.MiddleLeft;
			this.Paint += (object sender, PaintEventArgs e) => {
				Graphics g = e.Graphics;
				//		g.TranslateTransform (10, 0);
				g.TranslateTransform(vect.X,vect.Y);
				g.RotateTransform(Angle);
				g.DrawString (_text, new Font(DefaultFont.FontFamily,9), new SolidBrush(ForeColor), 0, 15
				);
			};
			Region = new Region (CreateRoundedRectangle (ClientRectangle, 1, 0));
		}

		public void SetMode(int mode){
			switch (mode) {
			case 0:
				{
					Region = null;
				}
				break;
			case 1:
				{
					Region = new Region (CreateRoundedRectangle (ClientRectangle, 1, 0));
				}
				break;
			}
		}

		public static GraphicsPath CreateRoundedRectangle(RectangleF rect,int mode,int offset)
		{

			GraphicsPath gp = new GraphicsPath();
			if (offset == 0) {
				offset = 20;
			}
			switch (mode) {
			case 1:
				{
					gp.AddLine (0, rect.Height, 0, offset/1.5f);
					gp.AddLine (0, offset/1.5f, rect.Width / 2, (offset / 2)-(offset/3));
					gp.AddLine (rect.Width / 2, (offset / 2)-(offset/3) , rect.Width, 0);
					gp.AddLine (rect.Width, 0, rect.Width, offset / 3);
					gp.AddLine (rect.Width, offset / 3, rect.Width / 2, offset + offset / 6);
					gp.AddLine (rect.Width / 2, offset + offset / 6, 0, rect.Height);

				}
				break;
			case 2:
				{

					gp.AddLine (0, 0, rect.Width, 0);
					gp.AddLine (rect.Width, 0, rect.Width, rect.Height - offset);
					gp.AddLine (rect.Width, rect.Height - offset, rect.Width - offset, rect.Height);
					gp.AddLine (rect.Width - offset, rect.Height, 0, rect.Height);

				}
				break;
			case 3:
				{
					gp.AddLine (0, rect.Height, offset, 0);
					gp.AddLine (offset, 0, rect.Width, 0);
					gp.AddLine (rect.Width, 0, rect.Width, rect.Height - offset);
					gp.AddLine (rect.Width, rect.Height - offset, rect.Width - offset, rect.Height);
					gp.AddLine (rect.Width - offset, rect.Height, 0, rect.Height);
				}
				break;
			}


			gp.CloseFigure();

			gp.FillMode=FillMode.Winding;

			return gp;
		}
	}

}


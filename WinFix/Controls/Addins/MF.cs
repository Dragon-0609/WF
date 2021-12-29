using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace WF_PRO
{
	public delegate void Changes(object sender,EventArgs e);
	public class MAddin
	{
		public Form M;
		public Panel DPal;
		public Panel pl;
		public PictureBox PB;
		public GButton G_R,G_G,G_C,G_D,G_M;
		public G2Button G_H, G_O;
		public Point LastLoc;
		public bool IsU;
		public int CurrentRot;
		public event Changes ChangeDock;
		public Color DockColor { get { return PB.BackColor; } set { PB.BackColor = value; } }
		public MAddin (Form m)
		{
			M = m;
			Init ();
		}

		public void Init(){
			IsU = false;
			M.ClientSize = new Size (300, 300);
			M.MinimumSize = M.Size;
			CurrentRot = 3;
			LastLoc = new Point (20, 260);

			PB = new PictureBox ();

			PB.BackColor = Color.FromArgb (255, 120, 0, 0);
			PB.Location = new Point (220,0);
			PB.Size = new Size (80, 300);
			PB.Visible = false;
			M.Controls.Add (PB);

			DPal = new Panel ();
			DPal.Size = new Size (80, 260);
			DPal.Location = new Point (220, 20);
			DPal.BackColor = Color.Gray;
			DPal.BorderStyle = BorderStyle.None;
			DPal.AccessibleName = "DPal";

			pl = new Panel ();
			pl.Size = new Size (20, 260);
			pl.Location = new Point (0, 0);
			pl.BackColor = Color.Black;
			pl.AccessibleName = "pl";
			pl.MouseMove+= (object sender, MouseEventArgs e) => {
				if(e.Button==MouseButtons.Left)
				{
					int X=e.X+pl.Location.X+DPal.Location.X;
					int Y=e.Y+pl.Location.Y+DPal.Location.Y;
					LastLoc=new Point(X,Y);
					if(!IsU)
						IsU=true;
					CheckState();
				}
			};
			pl.MouseLeave+= (object sender, EventArgs e) => {
				if(IsU)
				{
					ChangeLoc();
					PB.Visible=false;
					IsU=false;
				}
			};

			G_R = new GButton ();
			G_R.BackColor = Color.FromArgb (40, 40, 40);
			G_R.ForeColor = Color.White;
			G_R.Text="R";
			G_G = new GButton ();
			G_G.BackColor = Color.FromArgb (40, 40, 40);
			G_G.ForeColor = Color.White;
			G_G.Text="G";
			G_C = new GButton ();
			G_C.BackColor = Color.FromArgb (40, 40, 40);
			G_C.ForeColor = Color.White;
			G_C.Text="C";
			G_D = new GButton ();
			G_D.BackColor = Color.FromArgb (40, 40, 40);
			G_D.ForeColor = Color.White;
			G_D.Text="D";
			G_M = new GButton ();
			G_M.BackColor = Color.FromArgb (40, 40, 40);
			G_M.ForeColor = Color.White;
			G_M.Text="M";

			G_H = new G2Button ();
			G_H.BackColor = Color.FromArgb (40, 40, 40);
			G_H.ForeColor = Color.White;
			G_H.TX="?";

			G_O = new G2Button ();
			G_O.BackColor = Color.FromArgb (40, 40, 40);
			G_O.ForeColor = Color.White;
			G_O.TX="O";


			DPal.Controls.Add (pl);
			DPal.Controls.AddRange (new Control[]{ G_R, G_G, G_C, G_D, G_M, G_H, G_O });

			ChangeLoc (CurrentRot);

			M.Controls.Add (DPal);
			M.Resize+= (object sender, EventArgs e) => {
				ChangeLoc (CurrentRot);
			};

		}

		private void OnChanged(){
			if (ChangeDock != null)
				ChangeDock (this,null);			
		}

		public static void Main(){
	//		Application.EnableVisualStyles ();
	//		MAddin D = new MAddin ();
	//		Application.Run (MAddin.M);
		}

		public void CheckState(){
			int wid = M.ClientSize.Width;
			int hei = M.ClientSize.Height;
			bool can = false;
			if (LastLoc.X < 80 && LastLoc.Y >= 80 && hei - LastLoc.Y >= 80) {
				PB.Location = new Point (0, 0);
				PB.Size = new Size (80, hei );
				can = true;
			}
			if (LastLoc.Y < 80 && wid - LastLoc.X > 80 && LastLoc.X > 80) {
				PB.Location = new Point (0, 0);
				PB.Size = new Size (wid , 80);
				can = true;
			}
			if (wid - LastLoc.X < 80 && LastLoc.Y >= 80 && hei - LastLoc.Y >= 80) {
				PB.Location = new Point (wid - 80, 0);
				PB.Size = new Size (80, hei);
				can = true;
			}
			if (hei - LastLoc.Y < 80 && wid - LastLoc.X > 80 && LastLoc.X > 80) {
				PB.Location = new Point (0, hei - 80);
				PB.Size = new Size (wid , 80);
				can = true;
			}
			PB.Visible = can;
		}

		public void ChangeRot(int rotat){
			switch (rotat) {
			case 1:
				{
					DPal.Controls [0].Location = new Point (60, 0);
					DPal.Controls [0].Size = new Size (20, DPal.Size.Height);
				}
				break;
			case 2:
				{
					DPal.Controls [0].Location = new Point (0, 60);
					DPal.Controls [0].Size = new Size (DPal.Size.Width,20);
				}
				break;
			case 3:
				{
					DPal.Controls [0].Location = new Point (0, 0);
					DPal.Controls [0].Size = new Size (20, DPal.Size.Height);
				}
				break;
			case 4:
				{
					DPal.Controls [0].Location = new Point (0, 0);
					DPal.Controls [0].Size = new Size (DPal.Size.Width,20);
				}
				break;
			}
		}

		public void CheckReg(int rotat){
			DPal.Region = new Region (CreateReg (DPal.ClientRectangle, rotat));
			ChangeLocs (rotat);
			ChangeStyles (rotat);
			CurrentRot = rotat;
			OnChanged ();
		}

		public void ChangeStyles(int rotat){
			DPal.Controls [0].Region = new Region (CreateRegToCon (DPal.Controls [0].ClientRectangle, rotat));
			((GButton)DPal.Controls [1]).ChangeStyle (rotat);
			((GButton)DPal.Controls [2]).ChangeStyle (rotat);
			((GButton)DPal.Controls [3]).ChangeStyle (rotat);
			((GButton)DPal.Controls [4]).ChangeStyle (rotat);
			((GButton)DPal.Controls [5]).ChangeStyle (rotat);
				G_H.ChangeStyle (rotat);
			switch (rotat) {
			case 1:	{	G_O.ChangeStyle (3);	}	break;
			case 2:	{	G_O.ChangeStyle (5);	}	break;
			case 3:	{	G_O.ChangeStyle (1);	}	break;
			case 4:	{	G_O.ChangeStyle (6);	}	break;	}
				
		}

		public void ChangeLocs(int rotat){
			switch (rotat) {
			case 1:
				{
					
					DPal.Controls [1].Location = new Point (15, 20);
					if (DPal.Size.Height < 500) {
						int cur = 20;
						int next = Convert.ToInt16 ((DPal.ClientSize.Height - 40) / 4.8f);
						cur += next;
						DPal.Controls [2].Location = new Point (15, cur);
						cur += next;
						DPal.Controls [3].Location = new Point (15, cur);
						cur += next;
						DPal.Controls [4].Location = new Point (15, cur);
						cur += next;
						DPal.Controls [5].Location = new Point (15, cur);
					} else {
						DPal.Controls [2].Location = new Point (15, 100);
						DPal.Controls [3].Location = new Point (15, 180);
						DPal.Controls [4].Location = new Point (15, 260);
						DPal.Controls [5].Location = new Point (15, 340);
					}
					DPal.Controls [6].Location = new Point (50, DPal.ClientSize.Height - 45);
					DPal.Controls [7].Location = new Point (0, DPal.ClientSize.Height - 45);
					((GButton)DPal.Controls [1]).TextAlign = ContentAlignment.TopCenter;
					((GButton)DPal.Controls [2]).TextAlign = ContentAlignment.TopCenter;
					((GButton)DPal.Controls [3]).TextAlign = ContentAlignment.TopCenter;
					((GButton)DPal.Controls [4]).TextAlign = ContentAlignment.TopCenter;
					((GButton)DPal.Controls [5]).TextAlign = ContentAlignment.TopCenter;
				}
				break;
			case 2:
				{
					DPal.Controls [1].Location = new Point (20, 15);
					if (DPal.Size.Width < 500) {
						int cur = 20;
						int next = Convert.ToInt16 ((DPal.ClientSize.Width - 40) / 4.8f);
						cur += next;
						DPal.Controls [2].Location = new Point (cur, 15);
						cur += next;
						DPal.Controls [3].Location = new Point (cur, 15);
						cur += next;
						DPal.Controls [4].Location = new Point (cur, 15);
						cur += next;
						DPal.Controls [5].Location = new Point (cur, 15);
					} else {
						DPal.Controls [2].Location = new Point (100, 15);
						DPal.Controls [3].Location = new Point (180, 15);
						DPal.Controls [4].Location = new Point (260, 15);
						DPal.Controls [5].Location = new Point (340, 15);
					}
					DPal.Controls [6].Location = new Point (DPal.ClientSize.Width-45, DPal.ClientSize.Height - 30);
					DPal.Controls [7].Location = new Point (DPal.ClientSize.Width-45, 0);
					G_H.TextAlign = ContentAlignment.BottomLeft;
					((GButton)DPal.Controls [1]).TextAlign = ContentAlignment.MiddleLeft;
					((GButton)DPal.Controls [2]).TextAlign = ContentAlignment.MiddleLeft;
					((GButton)DPal.Controls [3]).TextAlign = ContentAlignment.MiddleLeft;
					((GButton)DPal.Controls [4]).TextAlign = ContentAlignment.MiddleLeft;
					((GButton)DPal.Controls [5]).TextAlign = ContentAlignment.MiddleLeft;
				}
				break;
			case 3:
				{
					DPal.Controls [1].Location = new Point (25, 20);
					if (DPal.Size.Height < 500) {
						int cur = 20;
						int next = Convert.ToInt16 ((DPal.ClientSize.Height - 40) / 4.8f);
						cur += next;
						DPal.Controls [2].Location = new Point (25, cur);
						cur += next;
						DPal.Controls [3].Location = new Point (25, cur);
						cur += next;
						DPal.Controls [4].Location = new Point (25, cur);
						cur += next;
						DPal.Controls [5].Location = new Point (25, cur);
					} else {
						DPal.Controls [2].Location = new Point (25, 100);
						DPal.Controls [3].Location = new Point (25, 180);
						DPal.Controls [4].Location = new Point (25, 260);
						DPal.Controls [5].Location = new Point (25, 340);
					}
					DPal.Controls [6].Location = new Point (10, DPal.ClientSize.Height - 45);
					DPal.Controls [7].Location = new Point (60, DPal.ClientSize.Height - 45);
					((GButton)DPal.Controls [1]).TextAlign = ContentAlignment.TopCenter;
					((GButton)DPal.Controls [2]).TextAlign = ContentAlignment.TopCenter;
					((GButton)DPal.Controls [3]).TextAlign = ContentAlignment.TopCenter;
					((GButton)DPal.Controls [4]).TextAlign = ContentAlignment.TopCenter;
					((GButton)DPal.Controls [5]).TextAlign = ContentAlignment.TopCenter;
				}
				break;
			case 4:
				{
					int cur = DPal.Size.Width-60;
					DPal.Controls [1].Location = new Point (DPal.Size.Width-60, 25);
					if (DPal.Size.Width < 500) {
						int next = Convert.ToInt16 ((DPal.ClientSize.Width - 40) / 4.8f);
						cur -= next;
						DPal.Controls [2].Location = new Point (cur, 25);
						cur -= next;
						DPal.Controls [3].Location = new Point (cur, 25);
						cur -= next;
						DPal.Controls [4].Location = new Point (cur, 25);
						cur -= next;
						DPal.Controls [5].Location = new Point (cur, 25);
					} else {
						DPal.Controls [2].Location = new Point (DPal.Size.Width-140, 25);
						DPal.Controls [3].Location = new Point (DPal.Size.Width-220, 25);
						DPal.Controls [4].Location = new Point (DPal.Size.Width-300, 25);
						DPal.Controls [5].Location = new Point (DPal.Size.Width-380, 25);
					}
					DPal.Controls [6].Location = new Point (5, 10);
					DPal.Controls [7].Location = new Point (5, DPal.ClientSize.Height-20);
					((GButton)DPal.Controls [1]).TextAlign = ContentAlignment.MiddleRight;
					((GButton)DPal.Controls [2]).TextAlign = ContentAlignment.MiddleRight;
					((GButton)DPal.Controls [3]).TextAlign = ContentAlignment.MiddleRight;
					((GButton)DPal.Controls [4]).TextAlign = ContentAlignment.MiddleRight;
					((GButton)DPal.Controls [5]).TextAlign = ContentAlignment.MiddleRight;
				}
				break;
			}
		}

		public void ChangeLoc(){
			int wid = M.ClientSize.Width;
			int hei = M.ClientSize.Height;
			if (LastLoc.X < 80 && LastLoc.Y >= 80 && hei - LastLoc.Y >= 80) {
				DPal.Location = new Point (0, 20);
				DPal.Size = new Size (80, hei - 40);
				ChangeRot (1);
				CheckReg (1);
		//		CurrentRot = 1;
			}
			if (LastLoc.Y < 80 && wid - LastLoc.X > 80 && LastLoc.X > 80) {
				DPal.Location = new Point (20, 0);
				DPal.Size = new Size (wid - 40, 80);
				ChangeRot (2);
				CheckReg (2);
		//		CurrentRot = 2;
			}
			if (wid - LastLoc.X < 80 && LastLoc.Y >= 80 && hei - LastLoc.Y >= 80) {
				DPal.Location = new Point (wid - 80, 20);
				DPal.Size = new Size (80, hei - 40);
				ChangeRot (3);
				CheckReg (3);
		//		CurrentRot = 3;
			}
			if (hei - LastLoc.Y < 80 && wid - LastLoc.X > 80 && LastLoc.X > 80) {
				DPal.Location = new Point (20, hei - 80);
				DPal.Size = new Size (wid - 40, 80);
				ChangeRot (4);
				CheckReg (4);
		//		CurrentRot = 4;
			}
		}

		public void ChangeLoc(int rotat){
			if (M.WindowState != FormWindowState.Minimized) {
				int wid = M.ClientSize.Width;
				int hei = M.ClientSize.Height;
				switch (rotat) {
				case 1:
					{
						DPal.Location = new Point (0, 20);
						DPal.Size = new Size (80, hei - 40);

					}
					break;
				case 2:
					{
						DPal.Location = new Point (20, 0);
						DPal.Size = new Size (wid - 40, 80);
					}
					break;
				case 3:
					{
						DPal.Location = new Point (wid - 80, 20);
						DPal.Size = new Size (80, hei - 40);
					}
					break;
				case 4:
					{
						DPal.Location = new Point (20, hei - 80);
						DPal.Size = new Size (wid - 40, 80);
					}
					break;
				}

				ChangeRot (rotat);
				CheckReg (rotat);
			}
		}

		public static GraphicsPath CreateReg(Rectangle rect,int mode)
		{
			GraphicsPath gp = new GraphicsPath ();
			switch (mode) {
			case 1:
				{
					gp.AddLine (0, 0, rect.Width, 0);
					gp.AddLine (rect.Width, 0, rect.Width - 10, 20);
					gp.AddLine (rect.Width - 10, 20, rect.Width - 10, rect.Height - 20);
					gp.AddLine (rect.Width - 10, rect.Height - 20, rect.Width, rect.Height);
					gp.AddLine (rect.Width, rect.Height, 0, rect.Height);
					gp.AddLine (0, rect.Height, 0, 0);
				}
				break;

			case 2:
				{
					gp.AddLine (0, 0, rect.Width, 0);
					gp.AddLine (rect.Width, 0, rect.Width , rect.Height);
					gp.AddLine (rect.Width , rect.Height,rect.Width-20,rect.Height-10);
					gp.AddLine (rect.Width-20,rect.Height-10,20,rect.Height-10);
					gp.AddLine (20, rect.Height - 10, 0, rect.Height);
					gp.AddLine (0, rect.Height, 0, 0);

				}
				break;
			case 3:
				{
					gp.AddLine (rect.Width, 0, 0, 0);
					gp.AddLine (0, 0, 10, 20);
					gp.AddLine (10, 20, 10, rect.Height - 20);
					gp.AddLine (10, rect.Height - 20, 0, rect.Height);
					gp.AddLine (0, rect.Height, rect.Width, rect.Height);
					gp.AddLine (rect.Width, rect.Height, rect.Width, 0);

				}
				break;
			case 4:
				{
					gp.AddLine (0, rect.Height, 0, 0);
					gp.AddLine (0, 0, 20 , 10);
					gp.AddLine (20 , 10,rect.Width-20,10);
					gp.AddLine (rect.Width-20,10,rect.Width,0);
					gp.AddLine (rect.Width, 0, rect.Width, rect.Height);
					gp.AddLine (rect.Width, rect.Height, 0, rect.Height);

				}
				break;
			}
			gp.CloseFigure ();

			gp.FillMode = FillMode.Winding;

			return gp;
		}

		public static GraphicsPath CreateRegToCon(Rectangle rect,int mode)
		{
			GraphicsPath gp = new GraphicsPath ();
			switch (mode) {
			case 1:
				{
					gp.AddLine (rect.Width, 0, rect.Width - 20, 40);
					gp.AddLine (rect.Width - 20, 40, rect.Width - 20, rect.Height - 40);
					gp.AddLine (rect.Width - 20, rect.Height - 40, rect.Width, rect.Height);
				}
				break;
			case 2:
				{
					gp.AddLine (rect.Width , rect.Height,rect.Width-40,rect.Height-20);
					gp.AddLine (rect.Width-40,rect.Height-20,40,rect.Height-20);
					gp.AddLine (40, rect.Height - 20, 0, rect.Height);
					gp.AddLine (0, rect.Height, rect.Width, rect.Height);

				}
				break;
			case 3:
				{
					gp.AddLine (0, 0, 20, 40);
					gp.AddLine (20, 40, 20, rect.Height - 40);
					gp.AddLine (20, rect.Height - 40, 0, rect.Height);

				}
				break;
			case 4:
				{
					gp.AddLine (rect.Width , 0,rect.Width-40,20);
					gp.AddLine (rect.Width-40,20,40,20);
					gp.AddLine (40, 20, 0, 0);
					gp.AddLine (0, 0, rect.Width, 0);

				}
				break;
			}
			gp.CloseFigure ();

			gp.FillMode = FillMode.Winding;

			return gp;
		}

	}
}


using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace RA
{
	public class Li_P:Panel{

		public static Size Default = new Size (200, 20);

		public Button ActiveDeactive;
		public Label Texts;
		public PictureBox State;
		public bool CanState;
		public bool AC;

		public Li_P(string text,bool CanUse){
			Size = new Size (200, 20);
			BackColor = Color.Gray;
			//		Region = new Region (CreateRoundedRectangle (ClientRectangle, 1));
			Region = new Region (CreateRoundedRectangle (ClientRectangle, 3,0));

			CanState = CanUse;

			Texts = new Label ();
			Texts.Text = text;
			Texts.Location = new Point (10, 0);
			Texts.TextAlign = ContentAlignment.MiddleCenter;
			Texts.BackColor = Color.FromArgb (0, 0, 0, 0);
			Texts.ForeColor = Color.White;

			State = new PictureBox ();
			State.Size = new Size (20, 20);
			State.Location = new Point (130, 0);
			State.BackColor = Color.FromArgb(0,255,0);
			State.Region = new Region (CreateRoundedRectangle (State.ClientRectangle, 1, 10));

			ActiveDeactive = new Button ();
			ActiveDeactive.Size = new Size (60, 20);
			ActiveDeactive.Location = new Point (140, 0);
			ActiveDeactive.Text = "Activate";
			ActiveDeactive.FlatStyle = FlatStyle.Flat;
			ActiveDeactive.FlatAppearance.BorderSize = 0;
			ActiveDeactive.BackColor = Color.FromArgb (20, 20, 20);
			ActiveDeactive.ForeColor = Color.Red;
			ActiveDeactive.Region = new Region (CreateRoundedRectangle (ActiveDeactive.ClientRectangle, 1, 10));
			ActiveDeactive.Click += OnBClick;
			if (CanState) {
				Texts.Size = new Size (110, 20);
			} else {
				Texts.Size = new Size (120, 20);
			}

			Controls.AddRange (new Control[]{ Texts, ActiveDeactive });
			if (CanState) {
				Controls.Add (State);
				AC = true;
			}

		}

		public void ChangeState(bool CanUsing){
			Controls.Clear ();
			if (CanState) {
				Texts.Size = new Size (110, 20);
			} else {
				Texts.Size = new Size (120, 20);
			}
			Controls.AddRange (new Control[]{ Texts, ActiveDeactive });
			if (CanState) {
				Controls.Add (State);
				AC = true;
			}
		}

		public void CheckState(){
			if (AC) {
				State.BackColor = Color.FromArgb(0,255,0);
			} else {
				State.BackColor = Color.FromArgb(255,0,0);
			}
		}

		public void SetMode(int mode)
		{
			if (mode == 0) {
				Region = null;
				State.Region = null;
				ActiveDeactive.Region = null;
			} else {
				Region = new Region (CreateRoundedRectangle (ClientRectangle, 3,0));
				State.Region = new Region (CreateRoundedRectangle (State.ClientRectangle, 1, 10));
				ActiveDeactive.Region = new Region (CreateRoundedRectangle (ActiveDeactive.ClientRectangle, 1, 10));
			}
		}

		public event EventHandler BClick;

		private void OnBClick(object sender,EventArgs e)
		{
			if (BClick != null)
				BClick (this, new EventArgs ());
			if (CanState) {
				if (AC) {
					AC = false;
				} else {
					AC = true;
				}
				CheckState ();
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
					gp.AddLine (0, rect.Height, offset, 0);
					gp.AddLine (offset, 0, rect.Width, 0);
					gp.AddLine (rect.Width, 0, rect.Width, rect.Height);
					gp.AddLine (rect.Width, rect.Height, 0, rect.Height);

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


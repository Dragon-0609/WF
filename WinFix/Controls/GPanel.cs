using System;
using System.Drawing;
using System.Windows.Forms;
namespace RA
{
	public class GPanel:Panel
	{
		public PictureBox icon;
		public Label text;
		public Button run;
		public bool ImgNull;
		public GPanel (string txt,EventHandler rn)
		{
			Init ();
			ImgNull = true;
			text.Text = txt;
			if(rn!=null)
			run.Click += rn;
//			icon.BackColor = Color.;
			icon.Image=GamePanel.DefualtImg;
		}
		private void Init(){
			Size = new Size (80, 120);
			text = new Label ();
			text.Location = new Point (0, 0);
			text.TextAlign = ContentAlignment.MiddleCenter;
			text.Size = new Size (80, 20);
			run = new Button ();
			run.Location = new Point (0, 100);
			run.Text = "Play";
			run.TextAlign = ContentAlignment.MiddleCenter;
			run.Size = new Size (80, 20);
			icon = new PictureBox ();
			icon.Location = new Point (0, 20);
			icon.Size = new Size (80, 80);
			icon.SizeMode = PictureBoxSizeMode.StretchImage;
			Controls.AddRange (new Control[]{ text, run, icon });
			AccessibleName = "GaPanel";
		}

		public GPanel (string txt,Image ic,EventHandler rn)
		{
			Init ();
			text.Text = txt;
			if(rn!=null)
				run.Click += rn;
//			icon.BackColor = Color.DarkGreen;
			if (ic != null) {
				ImgNull = false;
				icon.Image = ic;
			}
			else {
				ImgNull = true;
				icon.Image = GamePanel.DefualtImg;
			}
		}
	}
}


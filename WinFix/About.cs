using System;
using System.Drawing;
using System.Windows.Forms;

namespace RA
{
	public class About:Form
	{

		public MButton Back;
		public Label Dev,Des,Wr;
		public Color BackC,Fore,BackB,ForeB;
		public static int MainMode=2;
		public About ()
		{
			Visible = true;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			ClientSize = new Size (300, 400);
			MainMode = MF.MainMode;
			BackC = MF.Back;
			Fore = MF.Fore;
			BackB = MF.BackB;
			ForeB = MF.ForeB;

			BackColor = BackC;
			ForeColor = Fore;

			Init ();
			CheckMode ();
		}
			
		public void Init(){
			Back = new MButton ();
			Back.Location = new Point (ClientSize.Width - 70, ClientSize.Height - 30);
			Back.Size = new Size (60, 20);
			Back.Text = "Back";
			Back.Click+= (object sender, EventArgs e) => {
				Dispose();
			};
			Back.TextAlign = ContentAlignment.MiddleLeft;

			Back.FlatStyle = FlatStyle.Flat;
			Back.FlatAppearance.BorderSize = 0;
			Back.BackColor = BackB;
			Back.ForeColor = ForeB;
			Back.AccessibleName = "Button2";

			Dev = new Label ();
			Dev.Location = new Point (10, 10);
			Dev.Size = new Size (280, 20);
			Dev.Text = "Developed by Dragon-LV";
			Dev.AccessibleName = "Text";



			Des = new Label ();
			Des.Location = new Point (10, 30);
			Des.Size = new Size (280, 20);
			Des.Text = "Design by ***";
			Des.AccessibleName = "Text";

			Wr = new Label ();
			Wr.Location = new Point (10, 50);
			Wr.Size = new Size (280, 30);
			Wr.Text = "Writed on C#\n" +
			"Graphics on Windows Forms";
			Wr.AccessibleName = "Text";
				

			Controls.AddRange (new Control[]{ Back, Dev, Des,Wr });
		}

		public void CheckAll(){
			BackColor = BackC;
			ForeColor = Fore;


			foreach (Control c in Controls) {
				if (c.AccessibleName == "Text") {
					c.ForeColor = Fore;
					c.BackColor = BackC;
				}
				if (c.AccessibleName.Contains( "Button")) {
					c.BackColor = BackB;
					c.ForeColor = ForeB;
				}
			}

		}

		public void GetAndCheck(){
			MainMode = MF.MainMode;
			CheckMode ();
		}

		new public void Show(){
			GetAndCheck ();
			base.Show ();
		}

		public void CheckMode(){
			if (MainMode == 1) {
				Region = null;
			} else {
				Region = new Region (Options.CreateRoundedRectangle (ClientRectangle, 1));
			}

			try{
				for(int i=0;i<Controls.Count;i++)
				{
					try
					{
						if(Controls[i].AccessibleName.Contains("Button")){
							Control c=Controls[i];
							if(MainMode==1)
							{
								c.Region=null;
							}else{
								if(c.AccessibleName.Length>6)
								{
									string tp=c.AccessibleName.Substring(6);
									int md=int.Parse(tp);
									c.Region= new Region (Options.CreateRoundedRectangle (c.ClientRectangle, md));
								}else
								{
									//			c.Region= new Region (CreateRoundedRectangle (c.ClientRectangle, md));
								}}
						}
					}
					catch{

					}
				}
			}catch{

			}
		}

	}
}


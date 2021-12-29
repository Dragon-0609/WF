using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace RA
{
	public class OptimizedPanel:Panel{
		public OptimizedPanel(){
			SetStyle (ControlStyles.OptimizedDoubleBuffer, true);
		}
	}

	public class MainEditor:Form
	{
		public OptimizedPanel EditorPanel;
		public Panel EdiP,P_P;
		public Li_P Test_Panel;
		public Button Finish,Test_Button,Save_Button,Open_Button; 
		public bool LineUsing;
		public List <Vector> vector,vector_new;
		public RichTextBox RText;
		public SerContract serialize;
		public Label RTLabel;
		public Dropdown DropT;
		public string CurrentName;
		public DType CurrenType;
		public int current;
		public string CurrentN;
		public SaveFileDialog sv;
		public OpenFileDialog oe;
		public List <GraphicsPath> gpath;
		public MainEditor ()
		{
			ClientSize = new Size (320, 300);
			Visible = true;
			FormBorderStyle = FormBorderStyle.Fixed3D;
			Text = "Visual Style Editor";

			RText = new RichTextBox ();
			RText.Location = new Point (160, 100);
			RText.Size = new Size (60, 20);
			RText.BorderStyle = BorderStyle.None;
			RText.Text = "Name...";
			RText.Multiline = false;
			CurrentName = "Sample";
			RText.TextChanged += (object sender, EventArgs e) => {
				CurrentName = RText.Text;
			};

	//		serialize = new SerContract ();

			gpath = new List<GraphicsPath> { null, null, null, null };

			RTLabel = new Label ();
			RTLabel.Location = new Point (90, 100);
			RTLabel.Size = new Size (60, 20);
			RTLabel.FlatStyle = FlatStyle.Flat;
			RTLabel.BorderStyle = BorderStyle.None;
			RTLabel.TextAlign = ContentAlignment.MiddleRight;
			RTLabel.Text = "Name:";

			DropT = new Dropdown ();
			DropT.Location = new Point (90, 130);
			DropT.DropDownStyle = ComboBoxStyle.DropDownList;
			DropT.FlatStyle = FlatStyle.Popup;
			DropT.Items.AddRange (new object[]{ "Button", "Panel Main", "Panel Button", "Panel Activated Region" });
			DropT.SelectedIndex = 0;
			DropT.Enabled = false;
			CurrenType = DType.Button;
			DropT.SelectedIndexChanged += (object sender, EventArgs e) => {
				switch (DropT.SelectedIndex) {
				case 0:
					{
						CurrenType = DType.Button;
					}
					break;
				case 1:
					{
						CurrenType = DType.PanelMain;
					}
					break;
				case 2:
					{
						CurrenType = DType.PanelBtton;
					}
					break;
				case 3:
					{
						CurrenType = DType.PanelActiv;
					}
					break;
				}
			};

			Save_Button = new Button ();
			Save_Button.Location = new Point (20, 130);
			Save_Button.Size = new Size (60, 20);
			Save_Button.Text="Save";
	/*		Save_Button.Click += (object sender, EventArgs e) => {
				if (sv.ShowDialog () == DialogResult.OK) {
					Console.WriteLine (sv.FileName);
					Control c = null;
					if (Test_Button.Visible)
						c = Test_Button;
					if (Test_Panel.Visible)
						c = Test_Panel;
				
					GraphicsPath gpa = null;

					switch (CurrenType) {
					case DType.Button:
						{
							gpa = gpath [0];
						}
						break;

					case DType.PanelMain:
						{
							gpa = gpath [1];
						}
						break;

					case DType.PanelBtton:
						{
							gpa = gpath [2];
						}
						break;

					case DType.PanelActiv:
						{
							gpa = gpath [3];
						}
						break;

					}
			

					JsTest.Write (new DRegion (Name,new SGraphicsPath(gpa), CurrenType), sv.FileName);
				}
			};
*/
			Save_Button.Click += SaveFile_Click;
			Open_Button = new Button ();
			Open_Button.Location = new Point (20, 160);
			Open_Button.Size = new Size (60, 20);
			Open_Button.Text="Open";
			Open_Button.Click += OpenFile_Click;

			sv = new SaveFileDialog ();
			sv.Filter = "Winfix Region(*.wr)|*.wr";

			oe = new OpenFileDialog ();
			oe.Filter = "Winfix Region(*.wr)|*.wr";
			oe.Multiselect = false;

			current = 0;
			Finish = new Button ();
			Finish.Text="Finish";
			Finish.Location = new Point (20, 100);
			Finish.Size = new Size (60, 20);
			Finish.Click += Finish_Click;

			Test_Button = new Button ();
			Test_Button.Text="Test";
			Test_Button.Location = new Point (20, 70);
			Test_Button.Size = new Size (60, 20);
			Test_Button.FlatStyle = FlatStyle.Flat;
			Test_Button.FlatAppearance.BorderSize = 0;
			Test_Button.BackColor = Color.Black;
			Test_Button.ForeColor = Color.White;

			Test_Panel = new Li_P ("Test", true);
			Test_Panel.Location = new Point (20, 70);
			Test_Panel.SetMode (0);

			EditorPanel = new OptimizedPanel ();
			EditorPanel.Location = new Point (20, 20);
			EditorPanel.Size = Test_Button.Size;
			EditorPanel.BackColor = Color.Red;
			EditorPanel.MouseMove += Pan_Moving;

			EdiP = new Panel ();
			EdiP.Location = new Point (EditorPanel.Location.X - 10, EditorPanel.Location.Y - 10);
			EdiP.Size = new Size (EditorPanel.Size.Width + 20, EditorPanel.Size.Height + 20);
			EdiP.BackColor = Color.FromArgb(50,50,50);
			EdiP.MouseMove += EPan_Moving;

			P_P = new Panel ();
			P_P.Location = new Point (240, 10);
			P_P.Size = new Size (70, 260);
			P_P.BackColor = Color.FromArgb (0, 0, 0, 0);

			P_Pal pal = new P_Pal ("Button", P_Select);
			pal.Location = new Point (0, 10);
			pal.ForeColor = Color.White;
			pal.BackColor = Color.Gray;
			pal.AccessibleName="But";

			P_Pal panl = new P_Pal ("Panel", P_Select);
			panl.Location = new Point (0, 40);
			panl.ForeColor = Color.White;
			panl.BackColor = Color.Gray;
			panl.AccessibleName = "Pan";

			P_Pal panlb = new P_Pal ("Panel Button", P_Select);
			panlb.Location = new Point (0, 70);
			panlb.ForeColor = Color.White;
			panlb.BackColor = Color.Gray;
			panlb.AccessibleName="PanB";

			P_Pal panlr = new P_Pal ("Panel Activated Region", P_Select);
			panlr.Location = new Point (0, 100);
			panlr.ForeColor = Color.White;
			panlr.BackColor = Color.Gray;
			panlr.AccessibleName = "PanR";

			P_P.Controls.AddRange (new Control[]{ pal, panl,panlb,panlr });

			CurrentN="But";
			Test_Panel.Visible = false;

			vector = new List<Vector> ();
			vector_new = new List<Vector> ();
			LineUsing = false;
			Controls.AddRange (new Control[]{ EditorPanel, Finish, Test_Button, P_P, Test_Panel,EdiP,RText,RTLabel ,DropT,Save_Button,Open_Button});
			SetStyle (ControlStyles.OptimizedDoubleBuffer, true);
		}

		public void Pan_Moving(object sender,MouseEventArgs e){
			if (e.Button == MouseButtons.Left) {
				int width = EditorPanel.Size.Width;
				int height = EditorPanel.Size.Height;
				if (!LineUsing) {
					int x = 0, y = 0;
						if (e.X > width)
						x = width;
					else if (e.X < 0)
						x = 0;
					else
						x = e.X;
					if (e.Y > height)
						y = height;
					else if (e.Y < 0)
						y = 0;
					else
						y = e.Y;
					vector.Add( new Vector (x, y));
					vector_new.Add (new Vector (x, y));
					EditorPanel.Paint+= (object senders, PaintEventArgs es) => 
					{
						for(int i=0;i<vector.Count;i++)
						{
						es.Graphics.DrawLine(Pens.Black,vector[i].X,vector[i].Y,vector_new[i].X,vector_new[i].Y);
							if(current>=1)
							{
								es.Graphics.FillPolygon(Brushes.Blue,ConvertVector(vector,vector_new));
							}
						}

					};
					LineUsing = true;
				} else {
					int x = 0, y = 0;
					if (e.X > width)
						x = width;
					else if (e.X < 0)
						x = 0;
					else
						x = e.X;
					
					if (e.Y > height)
						y = height;
					else if (e.Y < 0)
						y = 0;
					else
						y = e.Y;
					try{
					vector_new[current] = new Vector (x, y);
					} catch{
						current -= 1;
			//			Console.WriteLine ("Error:" + vector.Count + " " + vector_new.Count + " " + current);
					}
					EditorPanel.Refresh ();
				}
			} else {
				if (LineUsing) {
					current += 1;
					LineUsing = false;
				}
			}
		}

		public void EPan_Moving(object sender,MouseEventArgs e){
			Pan_Moving (sender, new MouseEventArgs (e.Button, e.Clicks, e.X - 10, e.Y - 10, e.Delta));
		}

		public void OpenRegion(object sender,EventArgs e){
			if (oe.ShowDialog () == DialogResult.OK) {
				DRegion Reg = (DRegion)JsTest.Read (oe.FileName);
				GraphicsPath gp = Reg.Main;
		/*		switch (Reg.type) {
				case DType.Button:
					{
						Test_Button.Region = new Region (gp);
					}
					break;
				case DType.PanelMain:
					{
						Test_Panel.Region = new Region (gp);
					}
					break;
				case DType.PanelBtton:
					{

					}
					break;
				case DType.PanelActiv:
					{

					}
					break;
				}*/
			}

		}

		private void OpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog { Filter = "Winfix Region|*.wr" };
			if (ofd.ShowDialog (this) == DialogResult.OK) {
				var dr = new Dreg ();
				using (FileStream fs = File.OpenRead (ofd.FileName)) {
					//         elements = (Elements)new BinaryFormatter().Deserialize(fs);
					//           drawPanel1.Build(elements);
					dr = (Dreg)new BinaryFormatter ().Deserialize (fs);
					Test_Button.Region = new Region (dr.Path);
				}
			
				switch (dr.type) {
				case DType.Button:
					{
						Test_Button.Region = new Region (dr.Path);
					}
					break;
				case DType.PanelMain:
					{
						Test_Panel.Region = new Region (dr.Path);
					}
					break;
				case DType.PanelBtton:
					{
						Test_Panel.ActiveDeactive.Region = new Region (dr.Path);
					}
					break;
				case DType.PanelActiv:
					{
						Test_Panel.State.Region = new Region (dr.Path);
					}
					break;
				}
				EditorPanel.CreateGraphics ();
				EditorPanel.Paint+= (object senders, PaintEventArgs es) => 
				{
					es.Graphics.FillPolygon(Brushes.Blue,dr.Path.PathPoints);
				};
				EditorPanel.Refresh ();
			}
			//     DataChange(element.CurrentStrength, element.Voltage, element.Resistance);
		}

		private void SaveFile_Click(object sender, EventArgs e)
		{
			SaveFileDialog sfd = new SaveFileDialog { Filter = "Winfix Region|*.wr" };
			if (sfd.ShowDialog(this) == DialogResult.OK)
				using (FileStream fs = File.Create(sfd.FileName))
					//             new BinaryFormatter().Serialize(fs, elements);
				{
					Dreg dr = new Dreg ();
					Control c = null;
					if (Test_Button.Visible)
						c = Test_Button;
					if (Test_Panel.Visible)
						c = Test_Panel;

					GraphicsPath gpa = null;

					switch (CurrenType) {
					case DType.Button:
						{
							gpa = gpath [0];
						}
						break;

					case DType.PanelMain:
						{
							gpa = gpath [1];
						}
						break;

					case DType.PanelBtton:
						{
							gpa = gpath [2];
						}
						break;

					case DType.PanelActiv:
						{
							gpa = gpath [3];
						}
						break;
					}

					dr.Path = gpa;
					dr.type = CurrenType;
					new BinaryFormatter().Serialize(fs, dr);
				}
		}

		public static GraphicsPath CreateRoundedRectangle(RectangleF rect,Point[] points)
		{
			GraphicsPath gp = new GraphicsPath ();

			gp.AddLines (points);

			gp.CloseFigure ();

			gp.FillMode = FillMode.Winding;

			return gp;
		}

		public void Finish_Click(object sender,EventArgs e)
		{
			if (current >= 2) {
				Point[] points = ConvertVector (vector, vector_new);
				switch (CurrentN) {
				case "But":
					{
						
						gpath[0]=CreateRoundedRectangle (Test_Button.ClientRectangle, points);
						Test_Button.Region = new Region (gpath[0]);

					}
					break;
				case "Pan":
					{
						gpath[1]=CreateRoundedRectangle (Test_Panel.ClientRectangle, points);
						Test_Panel.Region = new Region (gpath[1]);
					}
					break;
				case "PanB":
					{

						gpath[2]=CreateRoundedRectangle (Test_Panel.ActiveDeactive.ClientRectangle, points);
						Test_Panel.ActiveDeactive.Region = new Region (gpath[2]);

					}
					break;
				case "PanR":
					{
						gpath[3]=CreateRoundedRectangle (Test_Panel.State.ClientRectangle, points);
						Test_Panel.State.Region = new Region (gpath[3]);
					}
					break;
				}

				current = 0;
				EditorPanel.CreateGraphics ();
				vector = new List<Vector> ();
				vector_new = new List<Vector> ();
			}
		}

		public void P_Select(object sender,EventArgs e)
		{
			Control c = ((Control)sender).Parent;
			current = 0;
			EditorPanel.CreateGraphics ();
			vector = new List<Vector> ();
			vector_new = new List<Vector> ();
			CurrentN = c.AccessibleName;
			Test_Button.Visible = false;
			Test_Panel.Visible = false;
			switch (c.AccessibleName) {
			case "But":
				{
					EditorPanel.Size = Test_Button.Size;
					Test_Button.Visible = true;
					DropT.SelectedIndex = 0;
				}
				break;
			case "Pan":
				{
					EditorPanel.Size = Test_Panel.Size;
					Test_Panel.Visible = true;
					DropT.SelectedIndex = 1;
				}
				break;
			case "PanB":
				{
					EditorPanel.Size = Test_Panel.ActiveDeactive.Size;
					Test_Panel.Visible = true;
					DropT.SelectedIndex = 2;
				}
				break;
			case "PanR":
				{
					EditorPanel.Size = Test_Panel.State.Size;
					Test_Panel.Visible = true;
					DropT.SelectedIndex = 3;
				}
				break;
			}
			EditorPanel.Refresh ();
			EdiP.Location = new Point (EditorPanel.Location.X - 10, EditorPanel.Location.Y - 10);
			EdiP.Size = new Size (EditorPanel.Size.Width + 20, EditorPanel.Size.Height + 20);
		}

		public Point[] ConvertVector(List<Vector> vectors,List<Vector>vectors_new)
		{
			Point[] p = new Point[vectors.Count*2];
			int iw = 0;
			for (int i = 0; i < p.Length; i++) {
				p [i] = new Point (vectors [iw].X, vectors [iw].Y);
				i += 1;
				p [i] = new Point (vectors_new [iw].X, vectors_new [iw].Y);
				iw += 1;
			}
			return p;
		}
		[STAThread]
		public static void Main(){
			Application.EnableVisualStyles ();
			Application.Run (new MainEditor ());
		//	Point p=new Point(10,10);
		//	Point pw = new Point (20, 20);

		//	Console.WriteLine (p > pw);
		}
	}
}


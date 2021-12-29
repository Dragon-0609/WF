using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
namespace RA
{
	public class Options : Form
	{
		public MButton Back;
		public MButton Save;
		public MButton Colors,vp,vm,vx,vy,C_C1,C_C2,C_C3,C_C4,C_C5,C_C6;
		public Label C_L1,C_L2,C_L3,C_L4,C_L5,C_L6;
		public Color BackC, ForeC,ForeB,BackB,BackP,ForeP,ArrowColor,PathColor,MBack,DVBack;
		public Dropdown Drop,DS,DM;
		public Bitmap Arrow,Pan;
		public Panel Col,Oth;
		public Panel Cls,VS,OtC,SCol;
		public PictureBox CCol,CArrow;
		public Control CurrentC,CurrentI;
		public Label CTex,CSh,CSy,CSM;
		public LiScrool li,ALi;
		public PictureBox AnP;
		public MF Par;
		public int MainMode,Angle,AdvancedMode;
		private int SvS;
		public Vector vec;
		public Options (MF par)
		{
			Visible = true;
			MainMode = MF.MainMode;
			Angle = MF.Angle;
			AdvancedMode = MF.AdvancedMode;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			ControlBox = false;
			ClientSize = new Size (400, 400);   
		
			     
			Init ();
			Par = par;     
			CheckMode ();
		

		}

		public void GetAndCheck(){
			MainMode = MF.MainMode;
			AdvancedMode = MF.AdvancedMode;
			Angle = MF.Angle;
			if(Angle>=0&&Angle<=360)
			ALi.Value = Angle;
			CheckMode ();
			Check_Advanced ();
		}

		public void CheckMode(){
			try {
				if (MainMode == 1) {
					Text = @"                                                        Options";
					Region = new Region (CreateRoundedRectangle (ClientRectangle, 1));
				} else {
					Text = "Options";
					Region = null;
				}
			} catch {

			}
			try {
				for (int i = 0; i < Controls.Count; i++) {
					try {
						if (Controls [i].AccessibleName.Contains ("Button")) {
							Control c = Controls [i];
							if (MainMode == 0) {
								c.Region = null;
							} else {
								if (c.AccessibleName.Length > 6) {
									string tp = c.AccessibleName.Substring (6);
									int md = int.Parse (tp);
									c.Region = new Region (CreateRoundedRectangle (c.ClientRectangle, md));
								} else {
									//			c.Region= new Region (CreateRoundedRectangle (c.ClientRectangle, md));
								}
							}
						}
					} catch {

					}
				}
			} catch {

			}

			try {
				for (int i = 0; i < Col.Controls.Count; i++) {
					try {
						if (Col.Controls [i].AccessibleName.Contains ("Button")) {
							Control c = Col.Controls [i];
							if (MainMode == 0) {
								c.Region = null;
							} else {
								if (c.AccessibleName.Length > 6) {
									string tp = c.AccessibleName.Substring (6);
									int md = int.Parse (tp);
									c.Region = new Region (CreateRoundedRectangle (c.ClientRectangle, md));
								} else {
									//			c.Region= new Region (CreateRoundedRectangle (c.ClientRectangle, md));
								}
							}
						}

					} catch {

					}
				}
			} catch {

			}
			try {
				for (int i = 0; i < Oth.Controls.Count; i++) {
					try {
						if (Oth.Controls [i].AccessibleName.Contains ("Button")) {
							Control c = Oth.Controls [i];
							if (MainMode == 0) {
								c.Region = null;
							} else {
								if (c.AccessibleName.Length > 6) {
									string tp = c.AccessibleName.Substring (6);
									int md = int.Parse (tp);
									c.Region = new Region (CreateRoundedRectangle (c.ClientRectangle, md));
								} else {
									//			c.Region= new Region (CreateRoundedRectangle (c.ClientRectangle, md));
								}
							}
						}

					} catch {

					}
				}
			} catch {

			}
			try {
				if(MainMode==1){
				Back.Region = new Region (CreateRoundedRectangle (Back.ClientRectangle, 2));
				Save.Region = new Region (CreateRoundedRectangle (Back.ClientRectangle, 3));
				}else{
					Back.Region=null;
					Save.Region=null;
				}
			} catch {

			}

		}

		new public void Show(){
			GetAndCheck ();
			base.Show ();
		}

		public void Init(){
			BackC = MF.Back;
			ForeC = MF.Fore;
			BackB = MF.BackB;
			ForeB = MF.ForeB;
			BackP = MF.BackP;
			ForeP = MF.ForeP;
			MBack = MF.MBack;
			DVBack = MF.DVBack;
			ArrowColor = MF.ArrowColor;
			PathColor = MF.PathColor;
			vec = MF.vec;
			Back = new MButton ();
			Back.Location = new Point (ClientSize.Width - 70, ClientSize.Height - 30);
			Back.Size = new Size (60, 20);
			Back.Text = "Back";
			Back.Click+= (object sender, EventArgs e) => {
				Par.CheckModes();
				Dispose ();
			};
			Back.TextAlign = ContentAlignment.MiddleLeft;

			Back.FlatStyle = FlatStyle.Flat;
			Back.FlatAppearance.BorderSize = 0;
			Back.BackColor = BackB;
			Back.AccessibleName = "Button2";

			Save = new MButton ();
			Save.Location = new Point (ClientSize.Width - 140, ClientSize.Height - 30);
			Save.Size = new Size (60, 20);
			Save.Text = "Save";
			Save.TextAlign = ContentAlignment.MiddleRight;
			Save.Click+= (object sender, EventArgs e) => {
				Saving();
			};

			Save.FlatStyle = FlatStyle.Flat;
			Save.FlatAppearance.BorderSize = 0;
			Save.BackColor = BackB;
			Save.AccessibleName = "Button3";

			Colors = new MButton ();
			Colors.Location = new Point (20, 30);
			Colors.Size = new Size (80, 20);
			Colors.Text = "Color";
			Colors.TextAlign = ContentAlignment.MiddleCenter;
			Colors.Click+= (object sender, EventArgs e) => {
				Controls.Clear();
				Controls.Add(VS);
				Controls.Add(Col);
			};

			Colors.FlatStyle = FlatStyle.Flat;
			Colors.FlatAppearance.BorderSize = 0;
			Colors.BackColor = BackB;
			Colors.AccessibleName = "Button5";

			Controls.AddRange (new Control[]{ Back,Save,Colors});

			BackColor = BackC;
			ForeColor = ForeC;
			for (int i = 0; i < Controls.Count; i++) {
				try {
					
					if(Controls[i].AccessibleName.Contains("Button")){
						Controls[i].BackColor=BackB;
						Controls[i].ForeColor=ForeB;
					}else {
						Controls[i].ForeColor=ForeC;
					}
				} catch {

				}
			}

			InCo ();
			InOt ();


		}

		public void InCo(){

			Col = new Panel ();
			Col.Dock = DockStyle.Fill;

			#region All

			Drop = new Dropdown ();
			Drop.DropDownStyle = ComboBoxStyle.DropDownList;
			Drop.Items.AddRange (new object[]{ "Windows Standart", "DaZe" });
			Drop.SelectedIndex = 1;
			Drop.FlatStyle = FlatStyle.Flat;
			Drop.BackColor = BackB;
			Drop.ForeColor = ForeB;
			Drop.FormattingEnabled = false;
			Drop.SelectedIndexChanged += Dropdown_Change;
			Drop.AccessibleName = "Button";

			//		Drop.Size = new Size (100, 20);
			Drop.Location = new Point (20, 240);

			DS = new Dropdown ();
			DS.DropDownStyle = ComboBoxStyle.DropDownList;
			DS.Items.AddRange (new object[]{ "Windows Standart", "DaZe" });
			DS.SelectedIndex = MainMode;
			DS.FlatStyle = FlatStyle.Flat;
			DS.BackColor = BackB;
			DS.ForeColor = ForeB;
			DS.FormattingEnabled = false;
			DS.SelectedIndexChanged += Dropdown_DSChange;
			DS.AccessibleName = "Button";

			//		Drop.Size = new Size (100, 20);
			DS.Location = new Point (20, 300);

			DM = new Dropdown ();
			DM.DropDownStyle = ComboBoxStyle.DropDownList;
			DM.Items.AddRange (new object[]{ "Standart", "Advanced", "For Full Custom" });
			DM.SelectedIndex = AdvancedMode;
			DM.FlatStyle = FlatStyle.Flat;
			DM.BackColor = BackB;
			DM.ForeColor = ForeB;
			DM.FormattingEnabled = false;
			DM.SelectedIndexChanged += Dropdown_DMChange;
			DM.AccessibleName = "Button";

			//		Drop.Size = new Size (100, 20);
			DM.Location = new Point (200, 300);

			MButton Bak = GetBackButton ();

			MButton Nex = GetNextButton (1);
			Nex.Name="NextB";

			CSM = new Label ();
			CSM.Text = "Current\nMode";
			CSM.Size = new Size (80, 30);
			CSM.Location = new Point (202, 270);
			CSM.TextAlign = ContentAlignment.MiddleLeft;
			CSM.ForeColor = ForeC;
			CSM.AccessibleName = "Label";

			#endregion

			#region Advanced and Full

			Cls = new Panel ();
			Cls.Size = new Size (200, 200);
			Cls.Location = new Point (180, 10);
			Cls.BackColor = Color.FromArgb (0, 0, 0, 0);

			VS = new Panel ();
			VS.Size = new Size (30, 220);
			VS.Location = new Point (360, 0);
			VS.BackColor = Color.FromArgb (0, 0, 0, 0);

			P_Pal P_Back = new P_Pal ("Background Color", GetItem_Col);
			P_Back.Location = new Point (0, 0);
			P_Back.Name = "Back";

			P_Pal P_Fore = new P_Pal ("Foreground Color", GetItem_Col);
			P_Fore.Location = new Point (0, 30);
			P_Fore.Name = "Fore";

			P_Pal P_ButBack = new P_Pal ("Button Background Color", GetItem_Col);
			P_ButBack.Location = new Point (0, 60);
			P_ButBack.Name = "BBack";

			P_Pal P_ButFore = new P_Pal ("Button Foreground Color", GetItem_Col);
			P_ButFore.Location = new Point (0, 90);
			P_ButFore.Name = "BFore";

			P_Pal P_PanBack = new P_Pal ("Panel Item Background Color", GetItem_Col);
			P_PanBack.Location = new Point (0, 120);
			P_PanBack.Name = "PBack";

			P_Pal P_PanFore = new P_Pal ("Panel Foreground Color", GetItem_Col);
			P_PanFore.Location = new Point (0, 150);
			P_PanFore.Name = "PFore";

			P_Pal P_MBack = new P_Pal ("Move Background Color", GetItem_Col);
			P_MBack.Location = new Point (0, 180);
			P_MBack.Name = "MBack";

			P_Pal P_DVBack = new P_Pal ("Dock Background Color", GetItem_Col);
			P_DVBack.Location = new Point (0, 210);
			P_DVBack.Name = "DVBack";

			P_Pal P_Arrow = new P_Pal ("Arrow Color", GetItem_Col);
			P_Arrow.Location = new Point (0, 240);
			P_Arrow.Name = "Arrow";

			P_Pal P_Path = new P_Pal ("Arrow Path Color", GetItem_Col);
			P_Path.Location = new Point (0, 270);
			P_Path.Name = "Path";

			Cls.Controls.AddRange (new Control[] {
				P_Back,
				P_Fore,
				P_ButBack,
				P_ButFore,
				P_PanBack,
				P_PanFore,
				P_MBack,
				P_DVBack,
				P_Arrow,
				P_Path
			});

			CCol = new PictureBox ();
			CCol.Size = new Size (40, 40);
			CCol.Location = new Point (20, 40);
			CCol.BackColor = BackC;
			CCol.BorderStyle = BorderStyle.FixedSingle;
			CurrentC = P_Back;
			CCol.Click += SelectColor;

			Arrow = new Bitmap (60, 60);
			ArrowDraw (Graphics.FromImage (Arrow));

			Pan = new Bitmap (350, 30);
			DrawR (Graphics.FromImage (Pan), Pan.Size);

			CArrow = new PictureBox ();
			CArrow.Size = new Size (10, 40);
			CArrow.Location = new Point (70, 40);
			CArrow.BackColor = Color.FromArgb (0, 0, 0, 0);
			CArrow.Visible = false;
			CArrow.Image = Arrow;
			CArrow.SizeMode = PictureBoxSizeMode.StretchImage;

			CTex = new Label ();
			CTex.Text = "Current\nColor";
			CTex.Size = new Size (60, 30);
			CTex.Location = new Point (20, 10);
			CTex.TextAlign = ContentAlignment.MiddleLeft;
			CTex.ForeColor = ForeC;
			CTex.AccessibleName = "Label";

			CSh = new Label ();
			CSh.Text = "Current\nColor Scheme";
			CSh.Size = new Size (80, 30);
			CSh.Location = new Point (20, 210);
			CSh.TextAlign = ContentAlignment.MiddleLeft;
			CSh.ForeColor = ForeC;
			CSh.AccessibleName = "Label";

			CSy = new Label ();
			CSy.Text = "Current\nStyle";
			CSy.Size = new Size (80, 30);
			CSy.Location = new Point (22, 270);
			CSy.TextAlign = ContentAlignment.MiddleLeft;
			CSy.ForeColor = ForeC;
			CSy.AccessibleName = "Label";

			Cls.AutoScroll = true;

			Cls.VerticalScroll.Enabled = true;

			Cls.VerticalScroll.Visible = true;

			#region LiScoll 

			li = new LiScrool ();
			li.Location = new Point (0, 20);
			li.Visible = true;
			li.Size = new Size (15, 150);
			li.Orientation = ScrollOrientation.VerticalScroll;
			li.BorderColor = Color.FromArgb (255, 120, 255);
			li.ArrowColor = ArrowColor;
			li.ThumbSize = 30;
			li.BackColor = Color.FromArgb (0, 0, 0, 0);
			li.Maximum = Cls.VerticalScroll.Maximum - Cls.VerticalScroll.LargeChange;

			li.Scroll += (object sender, ScrollEventArgs e) => {
				Cls.VerticalScroll.Value = li.Value;
				//		Console.WriteLine("L:" + MP.VerticalScroll.LargeChange+" H:"+MP.Height);
				//			Console.WriteLine(" V:"+MP.VerticalScroll.Value+" LV:"+l.Value);

				li.Maximum = Cls.VerticalScroll.Maximum - Cls.VerticalScroll.LargeChange;
			};


			VS.Controls.Add (li);

			li.Maximum = Cls.VerticalScroll.Maximum - Cls.VerticalScroll.LargeChange;
			li.Visible = Cls.VerticalScroll.Visible;

			#endregion


			Cls.MouseWheel += (object sender, MouseEventArgs e) => {
				li.MouseScrollWhell (e);
			};

			#endregion

			#region Standart

			SCol = new Panel ();
			SCol.Location = new Point (20, 20);
			SCol.BackColor = Color.FromArgb (0, 0, 0, 0);
			SCol.Size = new Size (360, 200);

			C_C1 = GetStandartButton (new Point (0, 0), new Size (100, 60), "", "B1", SelectColor, ContentAlignment.MiddleLeft, "Button", BackC);
			C_C2 = GetStandartButton (new Point (130, 0), new Size (100, 60), "", "B2", SelectColor, ContentAlignment.MiddleLeft, "Button", BackB);
			C_C3 = GetStandartButton (new Point (260, 0), new Size (100, 60), "", "B3", SelectColor, ContentAlignment.MiddleLeft, "Button", BackP);
			C_C4 = GetStandartButton (new Point (0, 90), new Size (100, 60), "", "F1", SelectColor, ContentAlignment.MiddleLeft, "Button", ForeC);
			C_C5 = GetStandartButton (new Point (130, 90), new Size (100, 60), "", "F2", SelectColor, ContentAlignment.MiddleLeft, "Button", ForeB);
			C_C6 = GetStandartButton (new Point (260, 90), new Size (100, 60), "", "F3", SelectColor, ContentAlignment.MiddleLeft, "Button", ForeP);

			C_L1 = GetStandartLabel (new Point (0, 60), new Size (100, 20), "Background 1", ContentAlignment.MiddleCenter, "Label", Color.FromArgb (0, 0, 0, 0));
			C_L2 = GetStandartLabel (new Point (130, 60), new Size (100, 20), "Background 2", ContentAlignment.MiddleCenter, "Label", Color.FromArgb (0, 0, 0, 0));
			C_L3 = GetStandartLabel (new Point (260, 60), new Size (100, 20), "Background 3", ContentAlignment.MiddleCenter, "Label", Color.FromArgb (0, 0, 0, 0));
			C_L4 = GetStandartLabel (new Point (0, 150), new Size (100, 20), "Foreground 1", ContentAlignment.MiddleCenter, "Label", Color.FromArgb (0, 0, 0, 0));
			C_L5 = GetStandartLabel (new Point (130, 150), new Size (100, 20), "Foreground 2", ContentAlignment.MiddleCenter, "Label", Color.FromArgb (0, 0, 0, 0));
			C_L6 = GetStandartLabel (new Point (260, 150), new Size (100, 20), "Foreground 3", ContentAlignment.MiddleCenter, "Label", Color.FromArgb (0, 0, 0, 0));

			SCol.Controls.AddRange (new Control[]{ C_C1, C_C2, C_C3, C_C4, C_C5, C_C6 });
			SCol.Controls.AddRange (new Control[]{ C_L1, C_L2, C_L3, C_L4, C_L5, C_L6 });
			#endregion

			Col.Controls.AddRange (new Control[]{ Cls, CCol, CTex, CSh, CSy, CArrow, Drop, DS, DM, CSM, SCol });
			Col.Controls.AddRange (new Control[]{ Bak, Nex });

		}

		public void InOt(){
			Oth = new Panel ();
			Oth.Dock = DockStyle.Fill;
			MButton Bak = GetBackButton ();

			#region AnP

			AnP=new PictureBox();
			AnP.Size=new Size(100,100);
			AnP.Location=new Point(40,60);
			AnP.Paint+= (object sender, PaintEventArgs e) => {
				Graphics g = e.Graphics;
				g.DrawRectangle(new Pen(ForeC,1),new Rectangle(0,0,65,30));
				g.TranslateTransform (vec.X, vec.Y);
				g.RotateTransform(Angle);
				g.DrawString ("Test", new Font(DefaultFont.FontFamily,9), new SolidBrush(ForeColor), 0, 15
				);
			};
			AnP.BorderStyle=BorderStyle.FixedSingle;
			#endregion

			#region ANLiScoll 

			ALi = new LiScrool ();
			ALi.Location = new Point (20, 40);
			ALi.Visible = true;
			ALi.Size = new Size (180, 15);
			ALi.Orientation = ScrollOrientation.HorizontalScroll;
			ALi.BorderColor = Color.FromArgb(255,120,255);
			ALi.ArrowColor = ArrowColor;
			ALi.ThumbSize = 30;
			ALi.BackColor=Color.FromArgb(0,0,0,0);

			ALi.Scroll+= (object sender, ScrollEventArgs e) => {
				Angle=ALi.Value;
				AnP.Refresh();
			};
			ALi.ReDrawArrow();
			ALi.Maximum=360;


			#endregion

			#region +-XY

			vp = new MButton ();
			vp.Text="+";
			vp.Size = new Size (20, 20);
			vp.Location = new Point (150, 60);
			vp.ForeColor = ForeB;
			vp.BackColor = BackB;
			vp.AccessibleName = "Button";
			vp.Click+= (object sender, EventArgs e) => {
				vec.Add(5,IsX());
				AnP.Refresh();
     			};

			vm = new MButton ();
			vm.Text="-";
			vm.Size = new Size (20, 20);
			vm.Location = new Point (180, 60);
			vm.ForeColor = ForeB;
			vm.BackColor = BackB;
			vm.AccessibleName = "Button";
			vm.Click+= (object sender, EventArgs e) => {
				vec.Add(-5,IsX());
				AnP.Refresh();
			};

			vx = new MButton ();
			vx.Text="X";
			vx.Size = new Size (20, 20);
			vx.Location = new Point (150, 90);
			vx.ForeColor = ForeB;
			vx.BackColor = BackB;
			vx.AccessibleName = "Button";
			vx.Click += (object sender, EventArgs e) => {
				SvS=0;
				CheckV();
			};

			vy = new MButton ();
			vy.Text="Y";
			vy.Size = new Size (20, 20);
			vy.Location = new Point (180, 90);
			vy.ForeColor = ForeB;
			vy.BackColor = BackB;
			vy.AccessibleName = "Button";
			vy.Click+= (object sender, EventArgs e) => {
				SvS=1;
				CheckV();
			};
			CheckV ();

			#endregion

			MButton Nex = GetPrevButton (2);


			OtC = new Panel ();
			OtC.Size = new Size (170, 200);
			OtC.Location = new Point (210, 10);
			OtC.BackColor = Color.FromArgb (0, 0, 0, 0);

			P_Pal T_Or = new P_Pal ("Text Orientation", GetItem_Oth);
			T_Or.Location = new Point (0, 0);
			T_Or.Name="Orien";

			OtC.Controls.Add (T_Or);

			Oth.Controls.AddRange (new Control[]{ Bak,Nex,AnP, ALi ,vp,vm,vx,vy,OtC});

		}

		public void Check_Advanced(){
			Cls.Visible = false;
			VS.Visible = false;
			CCol.Visible = false;
			CTex.Visible = false;
			SCol.Visible = false;
			for (int i = 0; i < Col.Controls.Count; i++) {
				if (Col.Controls [i].Name == "NextB") {
					Col.Controls [i].Visible = false;
				}
			}
			switch (AdvancedMode) {
			case (int)AdvancedModes.Standart:
				{
					SCol.Visible = true;
				}
				break;
			case (int)AdvancedModes.Advanced:
				{
					Cls.Visible = true;
					VS.Visible = true;
					CCol.Visible = true;
					CTex.Visible = true;
					for (int i = 0; i < Col.Controls.Count; i++) {
						if (Col.Controls [i].Name == "NextB") {
							Col.Controls [i].Visible = true;
						}
					}
				}
				break;
			case (int)AdvancedModes.ForFullCustom:
				{
					for (int i = 0; i < Col.Controls.Count; i++) {
						if (Col.Controls [i].Name == "NextB") {
							Col.Controls [i].Visible = true;
						}
					}
				}
				break;
			}
		}

		public void SelectColor(object sender,EventArgs e)
		{
			switch (AdvancedMode) {
			case 0:
				{
					Control s = sender as Control;
			//		Console.WriteLine ("Test");
					Color C = Color.Empty;
					switch (s.Name) {
					case "B1":
						{
							C = BackC;
						}
						break;
					case "B2":
						{
							C = BackB;
						}
						break;
					case "B3":
						{
							C = BackP;
						}
						break;
					case "F1":
						{
							C = ForeC;
						}
						break;
					case "F2":
						{
							C = ForeB;
						}
						break;
					case "F3":
						{
							C = ForeP;
						}
						break;
					}
					Color Cl = Dragon.ColorEd.GetColor (C, 0);
			//		Console.WriteLine ("Test1");
					if (Cl != C) {
			//			Console.WriteLine ("Test2");
						s.BackColor = Cl;
						switch (s.Name) {
						case "B1":
							{
								BackC = Cl;
							}
							break;
						case "B2":
							{
								BackB = Cl;
							}
							break;
						case "B3":
							{
								BackP = Cl;
							}
							break;
						case "F1":
							{
								ForeC = Cl;
							}
							break;
						case "F2":
							{
								ForeB = Cl;
							}
							break;
						case "F3":
							{
								ForeP = Cl;
							}
							break;
						}
					}
				}
				break;
			case 1:
				{
					Color Cl = Dragon.ColorEd.GetColor (CCol.BackColor, 0);
					if (Cl != CCol.BackColor) {
						CCol.BackColor = Cl;
						if (CurrentC != null) {

							//		Console.WriteLine (CurrentC.Name);
							switch (CurrentC.Name) {
							case "Back":
								{
									BackC = CCol.BackColor;
								}
								break;
							case "Fore":
								{
									ForeC = CCol.BackColor;
								}
								break;

							case "BBack":
								{
									BackB = CCol.BackColor;
								}
								break;
							case "BFore":
								{
									ForeB = CCol.BackColor;
								}
								break;
							case "PBack":
								{
									BackP = CCol.BackColor;
								}
								break;
							case "PFore":
								{
									ForeP = CCol.BackColor;
								}
								break;
							case "Arrow":
								{
									ArrowColor = CCol.BackColor;
									Arrow = new Bitmap (60, 60);
									ArrowDraw (Graphics.FromImage (Arrow));
									CArrow.Image = Arrow;
								}
								break;
							case "Path":
								{
									PathColor = CCol.BackColor;
									Arrow = new Bitmap (60, 60);
									ArrowDraw (Graphics.FromImage (Arrow));
									CArrow.Image = Arrow;
								}
								break;
							case "MBack":
								{
									MBack = CCol.BackColor;
									Pan = new Bitmap (350, 30);
									DrawR (Graphics.FromImage (Pan), Pan.Size);
									CArrow.Image = Pan;
								}
								break;
							case "DVBack":
								{
									DVBack = CCol.BackColor;
								}
								break;

							}
						}


					}
				}
				break;
			case 2:
				{

				}
				break;
			}
			CheckAll ();
			SetColors ();
		}

		public void SetColors(){
			switch (AdvancedMode) {
			case 0:
				{
					MBack = BackB;
					DVBack = BackB;
					ArrowColor=ForeB;
					PathColor = BackB;
				}
				break;
			case 1:
				{

				}
				break;
			case 2:
				{

				}
				break;
			}
		}

		public MButton GetBackButton(){
			MButton Bak = new MButton ();
			Bak.Location = new Point (ClientSize.Width - 70, ClientSize.Height - 30);
			Bak.Size = new Size (60, 20);
			Bak.Text = "Back";
			Bak.Click += BackToOpt;
			Bak.TextAlign = ContentAlignment.MiddleLeft;

			Bak.FlatStyle = FlatStyle.Flat;
			Bak.FlatAppearance.BorderSize = 0;
			Bak.BackColor = BackB;
			Bak.ForeColor = ForeC;
			Bak.AccessibleName = "Button2";
			return Bak;
		}

		public MButton GetStandartButton(Point locat,Size size,string text,string name,EventHandler e,ContentAlignment align,string accesname,Color BC){
			MButton Bak = new MButton ();
			Bak.Location = locat;
			Bak.Size = size;
			Bak.Text = text;
			Bak.Click += e;
			Bak.TextAlign = align;
			Bak.Name = name;
			Bak.FlatStyle = FlatStyle.Flat;
			Bak.FlatAppearance.BorderSize = 0;
			Bak.BackColor = BC;
			Bak.ForeColor = ForeC;
			Bak.AccessibleName = accesname;
			return Bak;
		}

		public Label GetStandartLabel(Point locat,Size size,string text,ContentAlignment align,string accesname,Color BC){
			Label Bak = new Label ();
			Bak.Location = locat;
			Bak.Size = size;
			Bak.Text = text;
			Bak.TextAlign = align;

			Bak.BackColor = BC;
			Bak.ForeColor = ForeC;
			Bak.AccessibleName = accesname;
			return Bak;
		}

		public MButton GetNextButton(int loc){
			MButton Nex = new MButton ();

			Nex.Location = new Point (ClientSize.Width - 70, ClientSize.Height - 60);
			Nex.Size = new Size (60, 20);
			Nex.Text = "Next";
			Nex.TextAlign = ContentAlignment.MiddleLeft;
			Nex.Click+= (object sender, EventArgs e) => {
				Next(loc);
			};

			Nex.FlatStyle = FlatStyle.Flat;
			Nex.FlatAppearance.BorderSize = 0;
			Nex.BackColor = BackB;
			Nex.AccessibleName = "Button2";
			return Nex;
		}

		public MButton GetPrevButton(int loc){
			MButton Nex = new MButton ();

			Nex.Location = new Point (ClientSize.Width - 140, ClientSize.Height - 60);
			Nex.Size = new Size (60, 20);
			Nex.Text = "Previous";
			Nex.TextAlign = ContentAlignment.MiddleRight;
			Nex.Click+= (object sender, EventArgs e) => {
				Prev(loc);
			};

			Nex.FlatStyle = FlatStyle.Flat;
			Nex.FlatAppearance.BorderSize = 0;
			Nex.BackColor = BackB;
			Nex.AccessibleName = "Button3";
			return Nex;
		}

		public void CheckV(){
			switch (SvS) {
			case 0:
				{
					vx.Enabled = false;
					vy.Enabled = true;
				}
				break;
			case 1:
				{
					vx.Enabled = true;
					vy.Enabled = false;
				}
				break;
			}
		}

		public bool IsX(){
			if (SvS == 0)
				return true;
			else
				return false;
		}

		public void Next(int current)
		{
			switch (current) {
			case 1:
				{

					Controls.Clear();
					SvS = 0;
					if(Angle>=0&&Angle<=360)
					ALi.Value = Angle;
					CheckV ();
					Controls.Add (Oth);
				}
				break;
			case 2:
				{

				}
				break;
			}
		}

		public void Prev(int current)
		{
			switch (current) {
			case 1:
				{

				}
				break;
			case 2:
				{
					Controls.Clear();
					Controls.Add(VS);
					Controls.Add(Col);
				}
				break;
			}
		}

		public void Dropdown_Change(object sender,EventArgs e)
		{
			switch (Drop.SelectedIndex) {
			case 0:
				{

					Form f = new Form ();
					Button b = new Button ();
					BackC = f.BackColor;
					BackB = SystemColors.ButtonShadow;
					ForeB = b.ForeColor;
					b.Dispose ();
					ForeC = f.ForeColor;
					f.Dispose ();
					ForeP = SystemColors.ControlLight;
					BackP = SystemColors.WindowFrame;
					MBack = SystemColors.Desktop;
					ArrowColor = SystemColors.ScrollBar;
					PathColor = SystemColors.MenuHighlight;
					DS.SelectedIndex = 0;
				}
				break;

			case 1:
				{
					
					BackC = Color.FromArgb (10, 10, 10);
					BackP = Color.Gray;
					ForeC = Color.Red;
					ForeB = Color.Red;
					ForeP = Color.White;
					ArrowColor = Color.Red;
					MBack = Color.Black;
					PathColor = Color.FromArgb (255, 120, 255);
					BackB = Color.FromArgb (20, 20, 20);
					DS.SelectedIndex = 1;
				}
				break;
			}
			Panel P = CurrentC as Panel;
			CurrentC = null;

			Arrow=new Bitmap(60,60);
			ArrowDraw(Graphics.FromImage(Arrow));
			CArrow.Image=Arrow;
			Arrow=new Bitmap(60,60);
			ArrowDraw(Graphics.FromImage(Arrow));
			CArrow.Image=Arrow;
			Pan = new Bitmap (350, 30);
			DrawR (Graphics.FromImage(Pan), Pan.Size);
			CArrow.Image=Pan;

			GetItem_Col (P.Controls[0], null);
			CheckAll ();
		}

		public void Dropdown_DSChange(object sender,EventArgs e)
		{
			MainMode = DS.SelectedIndex ;
			if (DS.SelectedIndex  == 1) {
				Angle = 342;
				vec = new Vector ();
			}
			if (DS.SelectedIndex  == 0) {
				Angle = 0;
				vec = new Vector ();
			}
			CheckMode ();
		}

		public void Dropdown_DMChange(object sender,EventArgs e)
		{
			AdvancedMode = DM.SelectedIndex;
			Check_Advanced ();
		}

		public void BackToOpt(object sender,EventArgs e){
			Controls.Clear();
			Controls.AddRange (new Control[]{ Back,Save,Colors});
		}

		public void Saving(){
			MF.Back = BackC;
			MF.BackB = BackB;
			MF.BackP = BackP;
			MF.Fore = ForeC;
			MF.ForeB = ForeB;
			MF.ForeP = ForeP;
			MF.MBack = MBack;
			MF.ArrowColor = ArrowColor;
			MF.PathColor = PathColor;
			MF.MainMode = MainMode;
			MF.DVBack = DVBack;
			MF.Angle = Angle;
			MF.vec = vec;
			Par.CheckAll ();
			Par.CheckModes ();
			Par.CheckGameP ();
			Par.CheckGamePC ();
		//	Par.CheckVector ();
		//	Par.CheckAngle ();
			if (Par.Ab != null&&!Par.Ab.IsDisposed) {
				Par.Ab.Fore = ForeC;
				Par.Ab.BackC = BackC;
				Par.Ab.ForeB = ForeB;
				Par.Ab.BackB = BackB;
				Par.Ab.CheckAll ();
				About.MainMode = MainMode;
				Par.CheckModes ();
			}
			Dispose ();
		}

		public void ArrowDraw(Graphics e)
		{
			using (Brush brush=new SolidBrush(ArrowColor)){
				e.FillPolygon (brush, new PointF[] {
					new PointF (0, 15),
					new PointF (30, 0),
					new PointF (60, 15),
					new PointF (30, 7)
				});

				e.FillEllipse (brush, 13.5f, 16, 32, 8);

				e.FillPolygon (brush, new PointF[] {
					new PointF (0, 25),
					new PointF (30, 40),
					new PointF (60, 25),
					new PointF (30, 32)
				});
			}

			using (var pen = new Pen (PathColor)) {
				//	e.Graphics.DrawRectangle (pen, new Rectangle (0, 0, Width - 1, Height - 1));
//				e.DrawLine(pen,30,0,30,0);
				e.DrawLine (pen,30,40,30,60);
				//			e.Graphics.DrawLine (pen, Width / 2, 0, Width / 2, Height - 1);

			}
		}

		public void CheckAll(){
			try {
				for(int i=0;i< Cls.Controls.Count;i++)
				{
					P_Pal p=Cls.Controls[i] as P_Pal;
					p.BackColor=BackP;
					p.lb.ForeColor=ForeP;
				}
			}catch{

			}
			try {
				for(int i=0;i< OtC.Controls.Count;i++)
				{
					P_Pal p=OtC.Controls[i] as P_Pal;
					p.BackColor=BackP;
					p.lb.ForeColor=ForeP;
				}
			}catch{

			}
			try {
				BackColor=BackC;
				ForeColor=ForeC;
	//			Console.WriteLine(Controls.Count);
				for (int i = 0; i < Controls.Count; i++) {
					try {
						if(Controls[i].AccessibleName.Contains("Button")){
							Controls[i].BackColor=BackB;
				//			Console.WriteLine("TEst");
							Controls[i].ForeColor=ForeB;
						}else if(Controls[i].AccessibleName.Contains("Label"))
						{
							Controls[i].ForeColor=ForeC;
							Controls[i].BackColor=Color.FromArgb(0,0,0,0);
						}
						else {
							Controls[i].ForeColor=ForeC;
							Controls[i].BackColor=Color.FromArgb(0,0,0,0);
						}

					} catch {

					}
				}
				for (int i = 0; i < Col.Controls.Count; i++) {
					try {
						if(Col.Controls[i].AccessibleName.Contains("Button")){
							Col.Controls[i].BackColor=BackB;
							Col.Controls[i].ForeColor=ForeB;
						}else if(Col.Controls[i].AccessibleName.Contains("Label"))
						{
							Col.Controls[i].ForeColor=ForeC;
							Col.Controls[i].BackColor=Color.FromArgb(0,0,0,0);
						}else {
							Col.Controls[i].ForeColor=ForeC;
							Col.Controls[i].BackColor=Color.FromArgb(0,0,0,0);
						}
					} catch {

					}
				}
				for (int i = 0; i < Oth.Controls.Count; i++) {
					try {
						if(Oth.Controls[i].AccessibleName.Contains("Button")){
							Oth.Controls[i].BackColor=BackB;
							Oth.Controls[i].ForeColor=ForeB;
						}else if(Oth.Controls[i].AccessibleName.Contains("Label"))
						{
							Oth.Controls[i].ForeColor=ForeC;
							Oth.Controls[i].BackColor=Color.FromArgb(0,0,0,0);
						}else {
							Oth.Controls[i].ForeColor=ForeC;
							Oth.Controls[i].BackColor=Color.FromArgb(0,0,0,0);
						}
					} catch {

					}
				}
				Back.BackColor=BackB;
				Back.ForeColor=ForeB;
				Save.BackColor=BackB;
				Save.ForeColor=ForeB;
				Colors.BackColor=BackB;
				Colors.ForeColor=ForeB;
			}catch {

			}
			try {
				li.BorderColor=PathColor;
				li.ArrowColor=ArrowColor;
				li.ReDrawArrow();
			} catch {

			}
			try {
				if(AdvancedMode==0)
				{
					for (int i = 0; i < SCol.Controls.Count; i++) {
						try {
							if(SCol.Controls[i].AccessibleName.Contains("Button")){
								//			SCol.Controls[i].BackColor=BackB;
								//			SCol.Controls[i].ForeColor=ForeB;
							}else if(SCol.Controls[i].AccessibleName.Contains("Label"))
							{
								SCol.Controls[i].ForeColor=ForeC;
								SCol.Controls[i].BackColor=Color.FromArgb(0,0,0,0);
							}else {
								SCol.Controls[i].ForeColor=ForeC;
								SCol.Controls[i].BackColor=Color.FromArgb(0,0,0,0);
							}
						} catch {

						}
					}
					C_C1.BackColor = BackC;
					C_C2.BackColor = BackB;
					C_C3.BackColor = BackP;
					C_C4.BackColor = ForeC;
					C_C5.BackColor = ForeB;
					C_C6.BackColor = ForeP;				
				}
			}catch{

			}
		}

		public void DrawR(Graphics e,Size rect){
			e.FillPolygon (new SolidBrush (MBack), new PointF[] { new PointF (20, 0), new PointF (44, 20),
				new PointF (rect.Width - 82, 20),
				new PointF (rect.Width - 58, 0),
				new PointF (rect.Width - 38, 0),
				new PointF (rect.Width - 76, rect.Height),
				new PointF (15, rect.Height),
				new PointF (38, rect.Height),
				new PointF (0, 0)						
			});
		}

		public void GetItem_Col(object sender,EventArgs e)
		{
			Label C = sender as Label;
			Panel P = C.Parent as Panel;
			CArrow.Visible = false;
			if (CurrentC != null) {

				switch (CurrentC.Name) {
				case "Back":
					{
						BackC = CCol.BackColor;

					}
					break;
				case "Fore":
					{
						ForeC = CCol.BackColor;
					}
					break;

				case "BBack":
					{
						BackB = CCol.BackColor;
					}
					break;
				case "BFore":
					{
						ForeB = CCol.BackColor;
					}
					break;
				case "PBack":
					{
						BackP = CCol.BackColor;
					}
					break;
				case "PFore":
					{
						ForeP = CCol.BackColor;
					}
					break;
				case "Arrow":
					{
						ArrowColor = CCol.BackColor;
					}
					break;
				case "Path":
					{
						PathColor = CCol.BackColor;
					}
					break;
				case "MBack":
					{
						MBack = CCol.BackColor;
					}
					break;
				case "DVBack":
					{
						DVBack = CCol.BackColor;
					}
					break;

				}
			}
			switch (P.Name) {
			case "Back":
				{
					CCol.BackColor = BackC;
					CurrentC = P;
				}
				break;
			case "Fore":
				{
					CCol.BackColor = ForeC;
					CurrentC = P;
				}
				break;
			case "BBack":
				{
					CCol.BackColor = BackB;
					CurrentC = P;
				}
				break;
			case "BFore":
				{
					CCol.BackColor = ForeB;
					CurrentC = P;
				}
				break;
			case "PBack":
				{
					CCol.BackColor = BackP;
					CurrentC = P;
				}
				break;
			case "PFore":
				{
					CCol.BackColor = ForeP;
					CurrentC = P;
				}
				break;
			case "Arrow":
				{
					CCol.BackColor = ArrowColor;
					CurrentC = P;
					CArrow.Visible = true;
					CArrow.Size = new Size (10, 40);
					CArrow.Image = Arrow;
				}
				break;
			case "Path":
				{
					CCol.BackColor = PathColor;
					CurrentC = P;
					CArrow.Visible = true;
					CArrow.Size = new Size (10, 40);
					CArrow.Image = Arrow;
				}
				break;
			case "MBack":
				{
					CCol.BackColor = MBack;
					CArrow.Visible = true;
					CArrow.Size = new Size (80, 10);
					CArrow.Image = Pan;
					CurrentC = P;
				}
				break;
			case "DVBack":
				{
					CCol.BackColor = DVBack;
					CurrentC = P;
				}
				break;
			}

		}

		public void GetItem_Oth(object sender,EventArgs e)
		{
			Label C = sender as Label;
			Panel P = C.Parent as Panel;
			AnP.Visible = false;
			ALi.Visible = false;
			switch (P.Name) {
			case "Orien":
				{
					AnP.Visible = true;
					ALi.Visible = true;
					ALi.Value = Angle;
					CurrentI = P;
				}
				break;
			}

		}

		public static GraphicsPath CreateRoundedRectangle(RectangleF rect,int mode)
		{
			GraphicsPath gp = new GraphicsPath ();
			switch (mode) {
			case 1:
				{
					gp.AddLine (10, 30, rect.Width / 2 - 50, 30);
					gp.AddLine (rect.Width / 2 - 50, 30, rect.Width / 2 - 20, 10);//6
					gp.AddLine (rect.Width / 2 - 20, 10, rect.Width / 2 + 20, 10);//6
					gp.AddLine (rect.Width / 2 + 20, 10, rect.Width / 2 + 50, 30);//Width+10
					gp.AddLine (rect.Width / 2 + 50, 30, rect.Width + 4, 30);
					gp.AddLine (rect.Width + 4, 30, rect.Width + 4, rect.Height + 30);
					gp.AddLine (rect.Width + 4, rect.Height + 30, 0 + 10, rect.Height + 30);
					gp.AddLine (0 + 10, rect.Height + 30, 0 + 10, rect.Height + 30);
					//		gp.AddString ("Windows 10 Mode", new Font("Times New Roman",12).FontFamily, 0, 20, new PointF (20, 5), new StringFormat ());
				}
				break;
			case 2:
				{
					gp.AddLine (0, 0, rect.Width / 2 + rect.Width / 6, 0);
					gp.AddLine (rect.Width / 2 + rect.Width / 6, 0, rect.Width, rect.Height / 2 - rect.Height / 20);
					gp.AddLine (rect.Width, rect.Height / 2 - rect.Height / 20, rect.Width, rect.Height / 2 + rect.Height / 20);
					gp.AddLine (rect.Width, rect.Height / 2 + rect.Height / 20, rect.Width / 2 + rect.Width / 6, rect.Height);
					gp.AddLine (rect.Width / 2 + rect.Width / 6, rect.Height, 0, rect.Height);

				}
				break;
			case 3:
				{
					gp.AddLine (0, rect.Height / 2 - rect.Height / 20, rect.Width / 2 - rect.Width / 6, 0);//gp.AddLine (0,0, rect.Width / 2 + rect.Width / 6, 0);
					gp.AddLine (rect.Width / 2 - rect.Width / 6, 0, rect.Width, 0);
					gp.AddLine (rect.Width, 0, rect.Width, rect.Height);
					gp.AddLine (rect.Width / 2 - rect.Width / 6, rect.Height, 0, rect.Height / 2 + rect.Height / 20);


				}
				break;
			case 4:
				{
					gp.AddLine (0, rect.Height / 2 - rect.Height / 4, rect.Width / 2 - rect.Width / 4, 0);
					gp.AddLine (rect.Width / 2 - rect.Width / 4, 0, rect.Width / 2 + rect.Width / 4, 0);
					gp.AddLine (rect.Width, rect.Height / 2 - rect.Height / 4, rect.Width, rect.Height / 2 + rect.Height / 4);
					gp.AddLine (rect.Width, rect.Height / 2 + rect.Height / 4, rect.Width / 2 + rect.Width / 4, rect.Height);
					gp.AddLine (rect.Width / 2 + rect.Width / 4, rect.Height, rect.Width / 2 - rect.Width / 4, rect.Height);
					gp.AddLine (rect.Width / 2 - rect.Width / 4, rect.Height, 0, rect.Height / 2 + rect.Height / 4);

				}
				break;
			
			case 5:
				{
					gp.AddLine (0, rect.Height, rect.Width / 2 - rect.Width / 4, 0);
					gp.AddLine (rect.Width / 2 - rect.Width / 4, 0, rect.Width, 0);
					gp.AddLine (rect.Width, 0, rect.Width / 2 + rect.Width / 4, rect.Height);
					gp.AddLine (rect.Width / 2 + rect.Width / 4, rect.Height, 0, rect.Height);

				}
				break;
			}
			gp.CloseFigure ();

			gp.FillMode = FillMode.Winding;

			return gp;
		}

	}
}


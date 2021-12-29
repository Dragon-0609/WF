using Microsoft.Win32;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace RA
{
	public class MF : Form,PluginBase.IHost
	{
		public WF_PRO.MAddin MAD;
		public Panel VS;
		public FlowLayoutPanel MP;
		public GButton Gamer,Opt,Abo,Exi;
		public Options Op;
		public About Ab;
		public LiScrool l;
		public Panel P_Move;
		public Label MText;
		private Button Plus,Minus,SwImg;
		public static Color Fore,ForeB, Back,BackB,BackP,ForeP,ArrowColor,PathColor,MBack,DVBack;
		public int GridCount = 1;
		public static int MainMode,Angle,AdvancedMode;
		public static Vector vec;
		private int CurrentLoc=0;
		public GamePanel GPL;
		public PluginM plugins;
		public MF ()
		{
	//		Init ();
		}

		private void Init(){
			SetStyle (ControlStyles.DoubleBuffer, true);
			MainMode = (int)GraphicModes.DaZe;
			AdvancedMode = (int)AdvancedModes.Standart;
			CurrentLoc = 0;
			Angle = 342;
			vec = new Vector (0, 0);
			ClientSize = new Size (320, 200);
			MinimumSize = Size;
			Icon =new Icon(@"C:\Users\User\Documents\Projects\WF\Assembly\WINF.ico");
			plugins = new PluginM ();
			plugins.Search ();

			AppDomain.CurrentDomain.AssemblyResolve+= (object sender, ResolveEventArgs args) => {
				System.Reflection.Assembly ayResult=null;
				string sShortAssNm=args.Name.Split(',')[0];
				System.Reflection.Assembly[] ayAssemblies=AppDomain.CurrentDomain.GetAssemblies();
				foreach(System.Reflection.Assembly ayAssembly in ayAssemblies)
				{
					if(sShortAssNm==ayAssembly.FullName.Split(',')[0]){
						ayResult=ayAssembly;
						break;
					}
				}
				return ayResult;
			};
			MP = new FlowLayoutPanel ();
			MP.Dock = DockStyle.None;
			MP.Size = new Size (ClientSize.Width - 80, ClientSize.Height - 40);
			MP.Location = new Point (0, 40);
			MP.BackColor = Color.FromArgb (0, 0, 0, 0);

			VS = new Panel ();
			VS.Size = new Size (30, 160);
			VS.Location = new Point (220, 40);
			VS.BackColor = Color.FromArgb (0, 0, 0, 0);

			BackColor = Color.FromArgb (10, 10, 10);
			Back = BackColor;
			BackP = Color.Gray;
			Fore = Color.Red;
			ForeB = Color.Red;
			ForeP = Color.White;
			ArrowColor = Color.Red;
			MBack = Color.FromArgb (30, 30, 30);
			DVBack = Color.FromArgb (120, 0, 0);
			PathColor = Color.FromArgb (255, 120, 255);
			BackB = Color.FromArgb (30, 30, 30);
			Li_P tw1 = new Li_P ("Repair exe", false);
			tw1.Location = new Point (10, 10);

			Li_P tw2 = new Li_P ("Test2", true);
			tw2.Location = new Point (10, 40);
			tw2.AC = false;
			tw2.CheckState ();

			Li_P tw3 = new Li_P ("Test3", false);
			tw3.Location = new Point (10, 70);

			Li_P tw4 = new Li_P ("Test4", true);
			tw4.Location = new Point (10, 100);

			Li_P tw5 = new Li_P ("Test5", true);
			tw5.Location = new Point (10, 130);

			Li_P tw6 = new Li_P ("Test6", true);
			tw6.Location = new Point (10, 160);
			tw6.AC = false;
			tw6.CheckState ();

			Li_P tw7 = new Li_P ("Test7", true);
			tw7.Location = new Point (10, 190);

			Li_P tw8 = new Li_P ("Test8", true);
			tw8.Location = new Point (10, 220);

			Li_P tw9 = new Li_P ("Test9", true);
			tw9.Location = new Point (10, 250);

			Li_P tw10 = new Li_P ("Test10", true);
			tw10.Location = new Point (10, 280);
			tw10.AC = false;
			tw10.CheckState ();

			Li_P tw11 = new Li_P ("Test11", true);
			tw11.Location = new Point (10, 310);

			Li_P tw12 = new Li_P ("Test12", true);
			tw12.Location = new Point (10, 340);

			Li_P tw13 = new Li_P ("Test13", false);
			tw13.Location = new Point (10, 370);

			Li_P tw14 = new Li_P ("Test14", true);
			tw14.Location = new Point (10, 400);

			MP.AutoScroll = true;

			MP.VerticalScroll.Enabled = true;

			MP.VerticalScroll.Visible = true;

			MP.Scroll += (object sender, ScrollEventArgs e) => {
				//		Console.WriteLine(MP.VerticalScroll.Value);

			};

			#region LiScoll 

			l = new LiScrool ();
			l.Location = new Point (0, 20);
			l.Visible = true;
			l.Size = new Size (15, 110);
			l.Orientation = ScrollOrientation.VerticalScroll;
			l.BorderColor =PathColor;
			l.ArrowColor = ArrowColor;
			l.ThumbSize = 30;
			l.BackColor=Color.FromArgb(0,0,0,0);
			l.Maximum=MP.VerticalScroll.Maximum-MP.VerticalScroll.LargeChange;

			l.Scroll+= (object sender, ScrollEventArgs e) => {
				GetCurrentPanel().VerticalScroll.Value=l.Value;
				//		Console.WriteLine("L:" + MP.VerticalScroll.LargeChange+" H:"+MP.Height);
				//			Console.WriteLine(" V:"+MP.VerticalScroll.Value+" LV:"+l.Value);
				l.Maximum=GetCurrentPanel().VerticalScroll.Maximum-GetCurrentPanel().VerticalScroll.LargeChange;
			};

			#endregion

			MP.MouseWheel+= (object sender, MouseEventArgs e) => {
				l.MouseScrollWhell(e);
			};

			this.SizeChanged += (object sender, EventArgs e) => {
				ChangeSizes();
			};

			Controls.Add (VS);

			VS.Controls.Add (l);

			Controls.Add (MP);
			/*
			Gamer = new GButton ("Standart");
			Gamer.Location = new Point (250, 20);
			Gamer.BackColor = Color.FromArgb (20, 20, 20);
			Gamer.ForeColor = Color.Red;
			Gamer.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			Gamer.Click+= (object sender, EventArgs e) => {
				MainMode=0;
				Angle=0;
				TCheckOp();
				TCheckAb();
				CheckAngle();
				CheckModes();
			};
			Gamer.AccessibleName="Button";

			Opt = new GButton ("Options");
			Opt.Location = new Point (250, 80);
			Opt.BackColor = Color.FromArgb (20, 20, 20);
			Opt.ForeColor = Color.Red;
			Opt.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			Opt.Click+= (object sender, EventArgs e) => {
				if(Op==null||Op.IsDisposed){
					Op = new Options(this);
					Op.Show();
				}else {
					Op.Show();
				}
			};
			Opt.AccessibleName="Button";

			Abo = new GButton ("About");
			Abo.Location = new Point (250, 110);
			Abo.BackColor = Color.FromArgb (20, 20, 20);
			Abo.ForeColor = Color.Red;
			Abo.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			Abo.Click+= (object sender, EventArgs e) => {
				if(Ab==null||Ab.IsDisposed){
					Ab = new About();
					Ab.Show();
				}else {
					Ab.Show();
				}
			};
			Abo.AccessibleName="Button";

			Exi = new GButton ("Exit");
			Exi.Location = new Point (250, 140);
			Exi.BackColor = Color.FromArgb (20, 20, 20);
			Exi.ForeColor = Color.Red;
			Exi.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			Exi.Click+= (object sender, EventArgs e) => {
				Application.Exit();

			};
			Exi.AccessibleName="Button";

			GButton Gamers = new GButton ("DaZe");
			Gamers.Location = new Point (250, 50);
			Gamers.BackColor = Color.FromArgb (20, 20, 20);
			Gamers.ForeColor = Color.Red;
			Gamers.Anchor = AnchorStyles.Right | AnchorStyles.Top;
			Gamers.AccessibleName="Button";
			Gamers.Click+= (object sender, EventArgs e) => {
				MainMode=2;
				Angle=342;
				TCheckOp();
				TCheckAb();
				CheckAngle();
				CheckModes();
			};

			Controls.AddRange (new Control[]{ Gamer, Gamers, Opt, Abo, Exi });

*/
			MText = new Label ();
			MText.BackColor = Color.FromArgb (0, 0, 0, 0);
			MText.ForeColor = Fore;
			MText.Location = new Point (44, 0);
			MText.Font = new Font (MText.Font.FontFamily, 12);
			MText.Size = new Size (ClientSize.Width - 174, 20);
			MText.TextAlign = ContentAlignment.MiddleCenter;
			MText.Text="Winfix PRO";

			P_Move = new Panel ();
			P_Move.Location = new Point (0, 0);
			P_Move.Size = new Size (ClientSize.Width -50, 30);
			P_Move.MouseMove+= (object sender, MouseEventArgs e) => {
				HControl.Move(this.Handle,e);
			};
			P_Move.BackColor = Color.Black;
			P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 2));
			Controls.AddRange (new Control[]{P_Move,MText});

			MP.Controls.AddRange (new Control[]{ tw1, tw2, tw3, tw4, tw5, tw6, tw7, tw8, tw9, tw10, tw11, tw12, tw13, tw14 });
			CheckModes ();
	//		CheckAngle();
			Show ();
		}

		public void SetAddins(){
			MAD.G_H.Click+= (object sender, EventArgs e) => {
				if(Ab==null||Ab.IsDisposed){
					Ab = new About();
					Ab.Show();
				}else {
					Ab.Show();
				}
			};
			MAD.G_O.Click+= (object sender, EventArgs e) => {
				if(Op==null||Op.IsDisposed){
					Op = new Options(this);
					Op.Show();
				}else {
					Op.Show();
				}
			};
			MAD.ChangeDock += CheckRotation;
			MAD.G_R.Click += ToRepairMode;
			MAD.G_G.Click += ToGameMode;

		}

		public void CheckAll(){
			try {
				if (MP != null) {
					for (int i = 0; i < MP.Controls.Count; i++) {
						Li_P L = MP.Controls [i] as Li_P;
						L.BackColor = BackP;
						L.Texts.ForeColor = ForeP;
						L.ActiveDeactive.ForeColor = ForeB;
						L.ActiveDeactive.BackColor = BackB;
					}
				}

			} catch {

			}
			try {
				BackColor = Back;
				ForeColor = Fore;
				for (int i = 0; i < Controls.Count; i++) {
					if (Controls [i].AccessibleName == "Button") {
						Controls [i].BackColor = BackB;
						Controls [i].ForeColor = ForeB;
					}
				}
			} catch {

			}
			try { 
				l.BorderColor = PathColor;
				l.ArrowColor = ArrowColor;
				l.ReDrawArrow ();
			} catch {

			}
			try {
				MText.ForeColor = Fore;
				P_Move.BackColor = MBack;
			} catch {

			}
			try {
				if(MAD!=null)
				{
					MAD.DPal.BackColor=Back;
					MAD.pl.BackColor=MBack;
					MAD.DockColor=DVBack;
					for (int i = 0; i < MAD.DPal.Controls.Count; i++) {
						if (MAD.DPal.Controls [i].AccessibleName == "GButton") {
							MAD.DPal.Controls [i].BackColor = BackB;
							MAD.DPal.Controls [i].ForeColor = ForeB;
						}
					}
				}
			} catch {

			}
			try{
				CheckPLMode();
			}catch{

			}
		}

		private void ToGameMode(object sender,EventArgs e){
			if (CurrentLoc != 1) {
				CurrentLoc = 1;
				if (GPL == null) {
					GPL = new GamePanel ();
					GPL.Size = new Size (ClientSize.Width - 80, ClientSize.Height - 40);
					GPL.Location = new Point (0, 40);
					GPL.BackColor = Color.FromArgb (0, 0, 0, 0);
					GPL.AutoScroll = true;
					GPL.VerticalScroll.Enabled = true;
					GPL.VerticalScroll.Visible = true;
					if (plugins.games.Count > 0) {
						foreach (PluginBase.IGame plug in plugins.games) {
							if (plug.plugin.UseIcon) {
								try {
									PluginBase.IICon ic = (PluginBase.IICon)plug.plugin;
//									GPL.AddGame(plug.Name,((Icon)ic.iconG).ToBitmap(),null);
									GPL.AddGame (plug.plugin.Name, ic.iconG, (object senders, EventArgs es) => {
										string pt=System.IO.Path.GetDirectoryName(plug.path)+"\\";
										plug.plugin.Run (this, pt);
									});
								} catch {

								}
							} else {
								try{
									GPL.AddGame(plug.plugin.Name,(object senders,EventArgs es)=>{
										string pt=System.IO.Path.GetDirectoryName(plug.path)+"\\";
										plug.plugin.Run (this, pt);
									});
								}catch{

								}
							}
						}
					}
					if (!Controls.Contains (GPL))
						Controls.Add (GPL);

					Plus = new Button ();
					Plus.Text = "+";
					Plus.Size = new Size (15, 15);
					Plus.Font = new Font ("Consolas", 7);
					Plus.Click += Large_Game;
					Plus.Anchor = AnchorStyles.Right | AnchorStyles.Top;
					Minus = new Button ();
					Minus.Text = "-";
					Minus.Size = new Size (15, 15);
					Minus.Font = new Font ("Consolas", 7);
					Minus.Click += Small_Game;
					Minus.Anchor = AnchorStyles.Right | AnchorStyles.Top;
					SwImg = new Button ();
					SwImg.Text = "↕";
					SwImg.Size = new Size (15, 15);
					SwImg.Font = new Font ("Consolas", 9);
					SwImg.Click += Change_Img;
					SwImg.Anchor = AnchorStyles.Right | AnchorStyles.Top;
					SwImg.Location = new Point (ClientSize.Width-60, 2);
					Plus.Location = new Point (ClientSize.Width-40, 2);
					Minus.Location = new Point (ClientSize.Width-20, 2);
					Controls.Add (Plus);
					Controls.Add (Minus);
					Controls.Add (SwImg);

				}
				if (MP != null)
					MP.Visible = false;
				GPL.Visible = true;
				Plus.Visible = true;
				Minus.Visible = true;
				SwImg.Visible = true;
				if (GPL.Controls.Count != plugins.games.Count) {

				}
				CheckPLMode ();

				CheckGameP ();
				CheckGamePC ();
				l.Value = GetCurrentPanel ().VerticalScroll.Value;
				l.Maximum = GetCurrentPanel ().VerticalScroll.Maximum - GetCurrentPanel ().VerticalScroll.LargeChange;
				if (l.Maximum <= 10) {
					l.Visible = false;
				} else {
					l.Visible = true;
				}

				CheckRotation (null, null);
			}
		}

		private void CheckPLMode(){
			if (Plus != null && Plus.Visible) {
				Plus.ForeColor = ForeB;
				Plus.BackColor = BackB;
				Minus.ForeColor = ForeB;
				Minus.BackColor = BackB;
				SwImg.ForeColor = ForeB;
				SwImg.BackColor = BackB;
				if (MF.MainMode == 0) {
					if (Plus.FlatStyle != FlatStyle.Standard) {
						Plus.FlatStyle = FlatStyle.Standard;
						Minus.FlatStyle = FlatStyle.Standard;
						SwImg.FlatStyle = FlatStyle.Standard;
					}
				} else if (MF.MainMode == 1) {
					if (Plus.FlatStyle != FlatStyle.Flat) {
						Plus.FlatStyle = FlatStyle.Flat;
						Plus.FlatAppearance.BorderSize = 0;
						Minus.FlatStyle = FlatStyle.Flat;
						Minus.FlatAppearance.BorderSize = 0;
						SwImg.FlatStyle = FlatStyle.Flat;
						SwImg.FlatAppearance.BorderSize = 0;
					}
				}
			}
		}

		private void ToRepairMode(object sender,EventArgs e){
			if (CurrentLoc != 0) {
				CurrentLoc = 0;
				if (MP == null) {
					MP = new FlowLayoutPanel ();
					MP.Dock = DockStyle.None;
					MP.Size = new Size (ClientSize.Width - 80, ClientSize.Height - 40);
					MP.Location = new Point (0, 40);
					MP.BackColor = Color.FromArgb (0, 0, 0, 0);
					MP.AutoScroll = true;
					MP.VerticalScroll.Enabled = true;
					MP.VerticalScroll.Visible = true;
					if (!Controls.Contains (MP))
						Controls.Add (MP);
				}
				MP.Visible = true;
				if (GPL != null)
					GPL.Visible = false;
				if (Plus != null && Minus != null) {
					Plus.Visible = false;
					Minus.Visible = false;
					SwImg.Visible = false;
				}
				l.Value = GetCurrentPanel ().VerticalScroll.Value;
				l.Maximum = GetCurrentPanel ().VerticalScroll.Maximum - GetCurrentPanel ().VerticalScroll.LargeChange;
				if (l.Maximum <= 10) {
					l.Visible = false;
				} else {
					l.Visible = true;
				}

				CheckRotation (null, null);
			}
		}

		public void CheckGameP(){
			try{
				if(GPL!=null){
					GPL.ChangeStyle(MF.MainMode);
				}
			}catch{

			}
		}

		public void CheckGamePC(){
			try{
				if(GPL!=null){
					GPL.ChangeColors(Fore,ForeB,BackB);
				}
			}catch{

			}
		}

		private void Large_Game(object sender,EventArgs e){
			if (GPL != null)
				GPL.Large ();
		}
		private void Small_Game(object sender,EventArgs e){
			if (GPL != null)
				GPL.Tall ();
		}
		private void Change_Img(object sender,EventArgs e){
			if (GPL != null)
				GPL.ChangeImgs ();
		}

		public void CheckRotation(object sender,EventArgs e){
			switch (MAD.CurrentRot) {

			case 1:
				{
					GetCurrentPanel().Size = new Size (ClientSize.Width - 80, ClientSize.Height - 40);
					GetCurrentPanel().Location = new Point (80, 40);
					VS.Size = new Size (30, ClientSize.Height - 40);
					VS.Location = new Point (ClientSize.Width-20, 40);
					l.Location = new Point (0, 20);
					l.Size = new Size (15, ClientSize.Height - 90);
					P_Move.Location = new Point (80, 0);
					P_Move.Size = new Size (ClientSize.Width -50, 30);
					P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 2));
					MText.Location = new Point (124, 0);
					MText.Size = new Size (ClientSize.Width - 174, 20);
					if (Plus != null) {
						SwImg.Location = new Point (5, 2);
						Plus.Location = new Point (25, 2);
						Minus.Location = new Point (45, 2);
					}
				}
				break;
			case 2:
				{
					GetCurrentPanel().Size = new Size (ClientSize.Width, ClientSize.Height - 120);
					GetCurrentPanel().Location = new Point (0, 80);
					VS.Size = new Size (30, ClientSize.Height - 120);
					VS.Location = new Point (ClientSize.Width-20, 80);
					l.Location = new Point (0, 20);
					l.Size = new Size (15, ClientSize.Height - 170);
					P_Move.Location = new Point (0, ClientSize.Height - 30);
					P_Move.Size = new Size (ClientSize.Width, 30);
					P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 5));
					MText.Location = new Point (0, ClientSize.Height - 20);
					MText.Size = new Size (ClientSize.Width, 20);
					if (Plus != null) {
						SwImg.Location = new Point (2, 5);
						Plus.Location = new Point (2, 25);
						Minus.Location = new Point (2, 45);
					}
				}
				break;
			case 3:
				{
					GetCurrentPanel().Size = new Size (ClientSize.Width - 80, ClientSize.Height - 40);
					GetCurrentPanel().Location = new Point (0, 40);
					VS.Size = new Size (30, ClientSize.Height - 40);
					VS.Location = new Point (ClientSize.Width-100, 40);
					l.Location = new Point (0, 20);
					l.Size = new Size (15, ClientSize.Height - 90);
					P_Move.Location = new Point (0, 0);
					P_Move.Size = new Size (ClientSize.Width -50, 30);
					P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 2));
					MText.Location = new Point (44, 0);
					MText.Size = new Size (ClientSize.Width - 174, 20);
					if (Plus != null) {
						SwImg.Location = new Point (ClientSize.Width-60, 2);
						Plus.Location = new Point (ClientSize.Width-40, 2);
						Minus.Location = new Point (ClientSize.Width-20, 2);
					}
				}
				break;
			case 4:
				{
					GetCurrentPanel().Size = new Size (ClientSize.Width, ClientSize.Height - 120);
					GetCurrentPanel().Location = new Point (0, 40);
					VS.Size = new Size (30, ClientSize.Height - 120);
					VS.Location = new Point (ClientSize.Width-20, 40);
					l.Location = new Point (0, 20);
					l.Size = new Size (15, ClientSize.Height - 170);
					P_Move.Location = new Point (0, 0);
					P_Move.Size = new Size (ClientSize.Width, 30);
					P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 6));
					MText.Location = new Point (0, 0);
					MText.Size = new Size (ClientSize.Width, 20);
					if (Plus != null) {
						SwImg.Location = new Point (2,ClientSize.Height - 60);
						Plus.Location = new Point (2,ClientSize.Height - 40); 
						Minus.Location = new Point (2,ClientSize.Height - 20);
					}
				}
				break;
			}
			if(CurrentLoc==0)
			ChangeSizes(MP.Controls);
			CheckModes ();
		}

		public void TCheckOp(){
			if (Op != null && !Op.IsDisposed) {
				Op.GetAndCheck ();
			}
		}

		public void TCheckAb(){
			if (Ab != null && !Ab.IsDisposed) {
				Ab.GetAndCheck ();
			}
		}

		public void CheckModes(){
			try {
				if (MainMode == 1) {
					Region = new Region (CreateRoundedRectangle (this.ClientRectangle, 1));
				} else {
					Region = null;
				}
			} catch {

			}
			/*
			try {
				for (int i = 0; i < Controls.Count; i++) {
					if (Controls [i].AccessibleName == "Button") {
						((GButton)Controls [i]).SetMode (MainMode);
					}
				}
			} catch {

			}
			*/

			try {
				if (CurrentLoc == 0) {
				if (MP != null) {
					for (int i = 0; i < MP.Controls.Count; i++) {
						Li_P L = MP.Controls [i] as Li_P;
						L.SetMode (MainMode);
					}
				}
				}
			} catch {

			}
			try {
				if (MainMode == 0) {
					P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 3));
				} else {
					switch (MAD.CurrentRot) {
					case 1:
						{
							P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 2));
						}
						break;
					case 2:
						{
							P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 5));
						}
						break;
					case 3:
						{
							P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 2));
						}
						break;
					case 4:
						{
							P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 6));
						}
						break;
					}
				}
			} catch {

			}
		}
		/*
		public void CheckVector(){
			try {
				for(int i=0;i<Controls.Count;i++)
				{
					if(Controls[i].AccessibleName=="Button")
					{
						try{
							((GButton)Controls[i]).vect=vec;
							Controls[i].Refresh();
						}catch{

						}
					}
				}
			} catch {

			}
		}

		public void CheckAngle(){
			try {
				for(int i=0;i<Controls.Count;i++)
				{
					if(Controls[i].AccessibleName=="Button")
					{
						try{
							((GButton)Controls[i]).Angle=Angle;
							Controls[i].Refresh();
						}catch{

						}
					}
				}
			} catch {

			}
		}
*/
		public static GraphicsPath CreateRoundedRectangle(RectangleF rect,int mode)
		{
			GraphicsPath gp = new GraphicsPath ();
			switch (mode) {
			case 1:
				{
					gp.AddLine (0 + 6, 30, rect.Width - 50, 30);
					gp.AddLine (rect.Width - 80, 30, rect.Width - 50, 0 + 6);
					gp.AddLine (rect.Width - 50, 0 + 6, rect.Width + 10, 0 + 6);
					gp.AddLine (rect.Width + 10, 0 + 6, rect.Width + 10, rect.Height + 32);
					gp.AddLine (rect.Width + 10, rect.Height + 32, 0 + 6, rect.Height + 32);
					gp.AddLine (0 + 6, rect.Height + 32, 0 + 6, rect.Height + 32);
				}
				break;

			case 2:
				{
					gp.AddLine (20, 0, 44, 20);
					gp.AddLine (44, 20, rect.Width - 82, 20);
					gp.AddLine (rect.Width - 82, 20, rect.Width - 58, 0);
					gp.AddLine (rect.Width - 58, 0, rect.Width-38, 0);
					gp.AddLine (rect.Width-38, 0, rect.Width - 76, rect.Height);
					gp.AddLine (rect.Width - 76, rect.Height, 15, rect.Height);
					gp.AddLine (15, rect.Height, 38, rect.Height);
					gp.AddLine (38, rect.Height, 0, 0);

				}
				break;
			case 3:
				{
					gp.AddLine (20, 0, 30, 0);
					gp.AddLine (30, 0, 30, 20);
					gp.AddLine (30, 20, rect.Width - 48, 20);
					gp.AddLine (rect.Width - 48, 20, rect.Width-48, 0);
					gp.AddLine (rect.Width - 48, 0, rect.Width - 38, 0);
					gp.AddLine (rect.Width - 38, 0, rect.Width-38, rect.Height);
					gp.AddLine (rect.Width - 38, rect.Height, 20, rect.Height);
					gp.AddLine (20, rect.Height, 20, 0);

				}
				break;
			case 4:
				{
					gp.AddLine (20, 0, 30, 0);
					gp.AddLine (30, 0, 25, 20);
					gp.AddLine (30, 20, rect.Width - 43, 20);
					gp.AddLine (rect.Width - 43, 20, rect.Width - 48, 0);
					gp.AddLine (rect.Width - 48, 0, rect.Width - 38, 0);
					gp.AddLine (rect.Width - 38, 0, rect.Width - 33, rect.Height);
					gp.AddLine (rect.Width - 33, rect.Height, 15, rect.Height);
					gp.AddLine (15, rect.Height, 20, 0);

				}
				break;
			case 5:
				{
					gp.AddLine (20, rect.Height, 44,rect.Height - 20);
					gp.AddLine (44, rect.Height - 20, rect.Width - 44, rect.Height - 20);
					gp.AddLine (rect.Width - 44, rect.Height - 20, rect.Width - 20, rect.Height);
					gp.AddLine (rect.Width - 20, rect.Height, rect.Width, rect.Height);
					gp.AddLine (rect.Width, rect.Height, rect.Width - 38, 0);
					gp.AddLine (rect.Width - 38, 0, 15, 0);
					gp.AddLine (15, 0, 38, 0);
					gp.AddLine (38, 0, 0, rect.Height);

				}
				break;
			case 6:
				{
					gp.AddLine (20, 0, 44,20);
					gp.AddLine (44, 20, rect.Width - 44, 20);
					gp.AddLine (rect.Width - 44, 20, rect.Width - 20, 0);
					gp.AddLine (rect.Width - 20, 0, rect.Width, 0);
					gp.AddLine (rect.Width, 0, rect.Width - 38, rect.Height);
					gp.AddLine (rect.Width - 38, rect.Height, 15, rect.Height);
					gp.AddLine (15, rect.Height, 38, rect.Height);
					gp.AddLine (38, rect.Height, 0, 0);

				}
				break;
			//		gp.AddString ("Windows 10 Mode", new Font("Times New Roman",12).FontFamily, 0, 20, new PointF (20, 5), new StringFormat ());
			}
			gp.CloseFigure ();

			gp.FillMode = FillMode.Winding;

			return gp;
		}

		public void ChangeSizes(){
			if (WindowState != FormWindowState.Minimized) {
				switch (MAD.CurrentRot) {
				case 1:
					{
						GetCurrentPanel ().Size = new Size (ClientSize.Width - 80, ClientSize.Height - 40);
						VS.Size = new Size (30, ClientSize.Height - 40);
						VS.Location = new Point (ClientSize.Width - 20, 40);
						l.Size = new Size (15, ClientSize.Height - 90);
						P_Move.Size = new Size (ClientSize.Width - 50, 30);
						P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 2));
						MText.Size = new Size (ClientSize.Width - 174, 20);
					}
					break;
				case 2:
					{
						GetCurrentPanel ().Size = new Size (ClientSize.Width, ClientSize.Height - 120);
						VS.Size = new Size (30, ClientSize.Height - 120);
						VS.Location = new Point (ClientSize.Width - 20, 80);
						l.Size = new Size (15, ClientSize.Height - 170);
						P_Move.Size = new Size (ClientSize.Width, 30);
						P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 5));
						MText.Size = new Size (ClientSize.Width, 20);
					}
					break;
				case 3:
					{
						GetCurrentPanel ().Size = new Size (ClientSize.Width - 80, ClientSize.Height - 40);
						VS.Size = new Size (30, ClientSize.Height - 40);
						VS.Location = new Point (ClientSize.Width - 100, 40);
						l.Size = new Size (15, VS.Size.Height - 60);
						P_Move.Size = new Size (ClientSize.Width - 50, 30);
						P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 2));
						MText.Size = new Size (ClientSize.Width - 174, 20);
					}
					break;
				case 4:
					{
						GetCurrentPanel ().Size = new Size (ClientSize.Width, ClientSize.Height - 120);
						VS.Size = new Size (30, ClientSize.Height - 120);
						VS.Location = new Point (ClientSize.Width - 20, 40);
						l.Size = new Size (15, ClientSize.Height - 170);
						P_Move.Size = new Size (ClientSize.Width, 30);
						P_Move.Region = new Region (CreateRoundedRectangle (P_Move.ClientRectangle, 6));
						MText.Size = new Size (ClientSize.Width, 20);
					}
					break;
				}
				Region = new Region (CreateRoundedRectangle (this.ClientRectangle, 1));
				//		MP.VerticalScroll.Maximum=Max(MP.Controls);
				//			MP.VerticalScroll.Maximum=Max(MP.Controls);
				//			MP.VerticalScroll.LargeChange=MP.Height;
				//				Console.WriteLine("M:"+MP.VerticalScroll.Maximum+" L:"+MP.VerticalScroll.LargeChange+" TS:"+(MP.VerticalScroll.Maximum-MP.VerticalScroll.LargeChange));
				l.Maximum = GetCurrentPanel ().VerticalScroll.Maximum - GetCurrentPanel ().VerticalScroll.LargeChange;
				if (l.Maximum <= 10) {
					l.Visible = false;
				} else {
					l.Visible = true;
				}
				if (CurrentLoc == 0) {
					ChangeSizes (MP.Controls);
				}
			}
		}

		private FlowLayoutPanel GetCurrentPanel(){
			switch (CurrentLoc) {
			case 0:
				{
					return MP;
				}
				break;
			case 1:
				{
					return GPL;
				}
				break;
			}
			return null;
		}

		public void ChangeSizes(System.Windows.Forms.Control.ControlCollection con)
		{
			Region Reg=null;
			Size txWithAc = Size.Empty;
			Size txWithinAc = Size.Empty;
			Point locWithAc = Point.Empty;
			Size M = Size.Empty;
			Point AcLoc = Point.Empty;
			int count = (ClientSize.Width - 120) / 200;
			GridCount = count;
			int rot = MAD.CurrentRot;
			foreach (Control cn in con) {
				Li_P p = (Li_P)cn;
				switch (rot) {
				case 1:
				case 3:
					{
						if (M == Size.Empty) {					
							M = new Size ((ClientSize.Width - 120) / count, 20);					
						}
						p.Size = M;
						if (AcLoc == Point.Empty) {
							AcLoc = new Point (p.Size.Width - 60, 0);
						}
						p.ActiveDeactive.Location = AcLoc;
						if (Reg == null)
							Reg = new Region (Li_P.CreateRoundedRectangle (p.ClientRectangle, 3, 0));
						p.Region = Reg;

						if (p.CanState) {
							if (txWithAc == Size.Empty) {
								txWithAc = new Size (p.Size.Width - 90, 20);
							}
							p.Texts.Size = txWithAc;
							if (locWithAc == Point.Empty) {
								locWithAc = new Point (p.Size.Width - 70, 0);
							}
							p.State.Location = locWithAc;
						} else {
							if (txWithinAc == Size.Empty) {
								txWithinAc = new Size (p.Size.Width - 80, 20);
							}
							p.Texts.Size = txWithinAc;
						}
					}
					break;
				case 2:
				case 4:
					{
						if (M == Size.Empty) {					
							M = new Size ((ClientSize.Width - 40) / count, 20);					
						}
						p.Size = M;
						if (AcLoc == Point.Empty) {
							AcLoc = new Point (p.Size.Width - 60, 0);
						}
						p.ActiveDeactive.Location = AcLoc;
						if (Reg == null)
							Reg = new Region (Li_P.CreateRoundedRectangle (p.ClientRectangle, 3, 0));
						p.Region = Reg;

						if (p.CanState) {
							if (txWithAc == Size.Empty) {
								txWithAc = new Size (p.Size.Width - 90, 20);
							}
							p.Texts.Size = txWithAc;
							if (locWithAc == Point.Empty) {
								locWithAc = new Point (p.Size.Width - 70, 0);
							}
							p.State.Location = locWithAc;
						} else {
							if (txWithinAc == Size.Empty) {
								txWithinAc = new Size (p.Size.Width - 80, 20);
							}
							p.Texts.Size = txWithinAc;
						}
					}
					break;
				}
			}
		}

		public int Max(System.Windows.Forms.Control.ControlCollection con){
			int res = 0;
			foreach (Control cn in con) {
				int i = cn.Location.Y + cn.Size.Height;
				if (i > res)
					res = i;
			}
			return res;
		}

		public static void DrawFigure(Graphics g,Pen MS)
		{
			g.DrawLine (MS, 0, 0, 20, 20);
			g.DrawLine (MS, 20, 0, 0, 20);
		}

		[STAThread]
		static void Main(){
			Application.EnableVisualStyles ();
			var m = new MF ();
			m.MAD = new WF_PRO.MAddin (m);
			m.Init ();
			m.CheckAll ();
			m.SetAddins ();
			Application.Run (m.MAD.M);

	//		Application.Run(new MF());
		}

		#region Plugin
		public void GameMode(bool Active)
		{
			if (Active) {
				Visible = false;
				if (Ab != null && !Ab.IsDisposed && Ab.Visible)
					Ab.Dispose ();
				if (Op != null && !Op.IsDisposed && Op.Visible)
					Op.Dispose ();
			} else {
				Visible = true;
				CloseM.Close ();
			}
		}
		public void AddControlToMainForm(Control ctrl){

		}
		public Panel GamePanels(int index)
		{
			return GetCurrentPanel ();
		}
		#endregion

	}
}


using System;
using System.Drawing;
using System.Windows.Forms;
namespace RA
{
	public class GamePanel:FlowLayoutPanel
	{
		public static Image DefualtImg = Image.FromFile (@"C:\Users\User\Documents\Projects\WF\Assembly\ps.png");
		public static Image DefualtImg2 = Image.FromFile (@"C:\Users\User\Documents\Projects\WF\Assembly\Treetog-I-Games.png");
		private int currentimg=1;
		public GamePanel ()
		{			
		}

		public void AddGame(string text,EventHandler eh){
			GPanel G = new GPanel (text, eh);
			Controls.Add (G);
		}
		public void AddGame(string text,Image icon,EventHandler eh){
			GPanel G = new GPanel (text,icon, eh);
			Controls.Add (G);
		}
		public void ChangeStyle(int Style){
			if (Controls.Count > 0) {
				try{
					foreach(GPanel g in Controls){
						try{
							switch(Style){
							case 0:{
									g.run.FlatStyle=FlatStyle.Standard;
							}
							break;
							case 1:{
									g.run.FlatStyle=FlatStyle.Flat;
									g.run.FlatAppearance.BorderSize=0;
								}
								break;
							}
						}catch{

						}
					}
				}catch{

				}
			}
		}
		public void ChangeColors(Color TextFore,Color ButtonFore,Color ButtonBack){
			if (Controls.Count > 0) {
				try{
					foreach(GPanel g in Controls){
						try{
							g.text.ForeColor=TextFore;
							g.run.ForeColor=ButtonFore;
							g.run.BackColor=ButtonBack;
						}catch{

						}
					}
				}catch{

				}
			}
		}
		public void AddGames(GPanel[] pans){
			Controls.AddRange (pans);
		}
		public void Large(){
			if (Controls.Count > 0) {
				try{
					int width=10;
					int height=10;
					int bloc=0;
					foreach(GPanel g in Controls){
						try{
							if(width==10&&height==10)
							{
								width=g.Size.Width+10;
								height=g.Size.Width+40;
								if(width>200)
									return;
								bloc=height-20;
							}
							g.Size=new Size(width,height);
							g.text.Size=new Size(width,20);
							g.icon.Size=new Size(width,width);
							g.run.Location=new Point(0,bloc);
							g.run.Size=new Size(width,20);
						}catch{

						}
					}
				}catch{

				}
			}
		}
		public void Tall(){
			if (Controls.Count > 0) {
				try{
					int width=10;
					int height=10;
					int bloc=0;
					foreach(GPanel g in Controls){
						try{
							if(width==10&&height==10)
							{
								width=g.Size.Width-10;
								height=g.Size.Width+40;
								if(width<40)
									return;
								bloc=height-20;
							}
							g.Size=new Size(width,height);
							g.text.Size=new Size(width,20);
							g.icon.Size=new Size(width,width);
							g.run.Location=new Point(0,bloc);
							g.run.Size=new Size(width,20);
						}catch{

						}
					}
				}catch{

				}
			}
		}
		public void ChangeImgs(){
			Image img;
			if (currentimg == 1) {
				currentimg = 2;
				img = GamePanel.DefualtImg2;
			} else {
				currentimg = 1;
				img = GamePanel.DefualtImg;
			}
			if (Controls.Count > 0) {
				try{
					
					foreach(GPanel g in Controls){
						try{
							if(g.ImgNull)
							g.icon.Image=img;
						}catch{

						}
					}
				}catch{

				}
			}
			GC.Collect ();
		}
	}
}


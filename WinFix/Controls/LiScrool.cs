using System;
using System.Drawing;
using System.Windows.Forms;
namespace RA
{
	public class LiScrool:Control
	{
		private int @value;

		public int Value{
			get{ return value;}
			set{ if (this.value == value)
					return;
				this.value = value;
				Invalidate ();
				OnScroll ();
			}
		}

		private int maximum = 100;

		public int Maximum {
			get{ return maximum; }
			set {
				maximum = value;
				Invalidate ();
			}
		}

		private int thumbSize=10;
		public int ThumbSize{
			get{ return thumbSize;}
			set{ thumbSize = value;Invalidate ();}
		}

		private Color thumbColor = Color.Gray;
		public Color ThumbColor{
			get{ return thumbColor;}
			set{ thumbColor = value;Invalidate ();}
		}

		private Color borderColor = Color.Silver;
		public Color BorderColor{
			get{ return borderColor;}
			set{ borderColor = value;Invalidate ();}
		}

		private Color arrowColor = Color.Silver;
		public Color ArrowColor{
			get{ return arrowColor;}
			set{ arrowColor = value;
				Bitmap arup = new Bitmap (60, 40);
				if(Orientation==ScrollOrientation.VerticalScroll)
				ArrowDraw (1, Graphics.FromImage (arup));
				else
					ArrowDraw (3, Graphics.FromImage (arup));
				ArrowUp = arup;
				Invalidate ();}
		}

		private ScrollOrientation orientation;                 
		public ScrollOrientation Orientation{
			get{ return orientation;}
			set{ orientation = value; Invalidate (); }
		}

		private Image arrowUp;
		public Image ArrowUp{
			get{ return arrowUp;}
			set{ arrowUp = value;
				Invalidate (); }
		}

		public event ScrollEventHandler Scroll;

		public LiScrool ()
		{
			SetStyle (ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
			SetStyle (ControlStyles.SupportsTransparentBackColor, true);
			Bitmap arup = new Bitmap (60, 50);
			ArrowDraw (1, Graphics.FromImage (arup));
			ArrowUp = arup;

		}

		public void ReDrawArrow()
		{
			Bitmap arup = new Bitmap (60, 50);
			if(Orientation==ScrollOrientation.VerticalScroll)
				ArrowDraw (2, Graphics.FromImage (arup));
			else
				ArrowDraw (3, Graphics.FromImage (arup));
			ArrowUp = arup;

		}

		public virtual void ArrowDraw(int mode,Graphics e){
			switch (mode) {
			case 1:
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
				}
				break;
			case 2:
				{
					using (Brush brush=new SolidBrush(ArrowColor)){
						e.FillPolygon (brush, new PointF[] {
							new PointF (0, 19),
							new PointF (30, 0),
							new PointF (60, 19),
							new PointF (30, 9)
						});

						e.FillEllipse (brush, 13.5f, 20, 32, 10);

						e.FillPolygon (brush, new PointF[] {
							new PointF (0, 31),
							new PointF (30, 49),
							new PointF (60, 31),
							new PointF (30, 40)
						});
					}
				}
				break;
			case 3:
				{
					using (Brush brush=new SolidBrush(ArrowColor)){
						e.FillPolygon (brush, new PointF[] {
							new PointF (19, 0),	//19,0
							new PointF (0, 30),	//0,30
							new PointF (19, 60),//19,60
							new PointF (9, 30)	//9,30
						});

						e.FillEllipse (brush, 20, 13.5f, 10, 32);//20,13.5f,10,32

						e.FillPolygon (brush, new PointF[] {
							new PointF (31, 0),	//31,0
							new PointF (49, 30),//49,30
							new PointF (31, 60),//31,60
							new PointF (40, 30)	//40,30
						});
					}
				}
				break;
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) 
				MouseScroll (e);
				base.OnMouseDown (e);

		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) 
				MouseScroll (e);
			base.OnMouseMove (e);

		}

		public void MouseScrollWhell(MouseEventArgs e)
		{
			MouseScroll(new MouseEventArgs(MouseButtons.None,0,e.X,e.Y-(e.Delta),0));
		}

		private void MouseScroll(MouseEventArgs e)
		{
			int v = 0;
			switch (Orientation) {

			case ScrollOrientation.VerticalScroll:
				v = Maximum * (e.Y - thumbSize / 2) / (Height - thumbSize);// e.Y - thumSize /2
				break;

			case ScrollOrientation.HorizontalScroll:
				v = Maximum * (e.X - thumbSize / 2) / (Width - thumbSize);// e.X - thumSize /2
				break;

			}

			Value = Math.Max (0, Math.Min (Maximum, v));
	//		Console.Clear ();
	//		Console.WriteLine ("Max:" + Maximum + " V:" + v + " Value:" + value);

		}

		public virtual void OnScroll(ScrollEventType type=ScrollEventType.ThumbPosition)
		{
			if (Scroll != null)
				Scroll (this, new ScrollEventArgs (type, Value, Orientation));
		}

		protected override void OnPaint(PaintEventArgs e){
			if (Maximum <= 0)
				return;

			Rectangle thumbRect = Rectangle.Empty;
			switch (Orientation) {
			case ScrollOrientation.HorizontalScroll:
				thumbRect = new Rectangle (value * (Width - thumbSize) / Maximum, 2, thumbSize, Height - 4);
				break;
			

			case ScrollOrientation.VerticalScroll:
	//			thumbRect = new Rectangle (2, value * (Height - thumbSize) / Maximum, Width - 4, thumbSize);
				thumbRect = new Rectangle (2, value * (Height - thumbSize) / Maximum, Width - 4, thumbSize);
				break;

			}
			switch(Orientation){
			case ScrollOrientation.VerticalScroll:
				{
					using (var pen = new Pen (borderColor)) {
						//	e.Graphics.DrawRectangle (pen, new Rectangle (0, 0, Width - 1, Height - 1));
						e.Graphics.DrawLine (pen, Width / 2, 0, Width / 2, thumbRect.Y);
						e.Graphics.DrawLine (pen, Width / 2, thumbRect.Y + thumbRect.Height, Width / 2, Height - 1);
						//			e.Graphics.DrawLine (pen, Width / 2, 0, Width / 2, Height - 1);

					}
					using (var brush = new SolidBrush (thumbColor)) {
//				e.Graphics.FillEllipse (brush, thumbRect);
						e.Graphics.DrawImage (arrowUp, thumbRect);
//				e.Graphics.FillPolygon(brush,new PointF[]{new PointF(2,thumbRect.Y+thumbSize),new PointF((Width - 2)/2,thumbRect.Y),new PointF(Width - 2,thumbRect.Y+thumbSize),new PointF((Width - 2)/2,thumbSize/2)});
					}}
				break;
			case ScrollOrientation.HorizontalScroll:
				{
					using (var pen = new Pen (borderColor)) {
						//	e.Graphics.DrawRectangle (pen, new Rectangle (0, 0, Width - 1, Height - 1));
						e.Graphics.DrawLine (pen, 0, Height/2, thumbRect.X, Height/2);//Width/2,0Width/2,thumb.Rect.Y
						e.Graphics.DrawLine (pen,  thumbRect.X + thumbRect.Width,Height/2, Width - 1, Height / 2);// Width / 2, thumbRect.Y + thumbRect.Height, Width / 2, Height - 1
						//			e.Graphics.DrawLine (pen, Width / 2, 0, Width / 2, Height - 1);

					}
					using (var brush = new SolidBrush (thumbColor)) {
						//				e.Graphics.FillEllipse (brush, thumbRect);
						e.Graphics.DrawImage (arrowUp, thumbRect);
						//				e.Graphics.FillPolygon(brush,new PointF[]{new PointF(2,thumbRect.Y+thumbSize),new PointF((Width - 2)/2,thumbRect.Y),new PointF(Width - 2,thumbRect.Y+thumbSize),new PointF((Width - 2)/2,thumbSize/2)});
					}
				}
				break;
			}
		}
	}
}


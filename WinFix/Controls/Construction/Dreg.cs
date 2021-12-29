using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace RA
{   
	[Serializable]
	public class Dregs : object { }// Содержит все объекты модели
	[Serializable]
	public class Dreg
	{
		public string Name;

		public DType type;

		private SGraphicsPath path;

		public GraphicsPath Path
		{
			get { return path; }
			set { path = value; }
		}

		public Dreg(){
		}
	}
}


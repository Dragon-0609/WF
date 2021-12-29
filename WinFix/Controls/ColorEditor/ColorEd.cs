using System;
using System.Drawing;
using ColorHexagon.Demo;
using System.Windows.Forms;

namespace Dragon
{
	public static class ColorEd
	{
	//	public static Color NsQ;
		public static ColorHexagon.ColorEditor.ColorPicker CL;

		public static Color GetColor(Color prev,int lang){
			DialogResult rs;
			if (CL == null||CL.IsDisposed)
			{
				CL = new ColorHexagon.ColorEditor.ColorPicker (prev);
			} else {
				CL.ReIN (prev);
			}
			CL.UpdateText (lang);
			rs = CL.ShowDialog ();

		//	Console.WriteLine (CL.labelCurrentColor.BackColor.ToKnownColor ());
			if (rs == DialogResult.OK) {
				return CL.labelCurrentColor.BackColor;
			} else {
				return prev;
			}
		}

	}
}


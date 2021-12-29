using System;
using System.Drawing;
namespace RA
{
	[Serializable]
	public class WinSet
	{
		public int MainMode,Angle,Style,AdvancedMode;
		public Vector vec;
		public Color Fore,ForeB, Back,BackB,BackP,ForeP,ArrowColor,PathColor,MBack;
		public WinSet (){
			Angle = 0;
			vec = new Vector (0, 0);
			Style = 0;
			AdvancedMode = 0;
			Back = Color.FromArgb (10, 10, 10);
			BackP = Color.Gray;
			Fore = Color.Red;
			ForeB = Color.Red;
			ForeP = Color.White;
			ArrowColor = Color.Red;
			MBack = Color.Black;
			PathColor = Color.FromArgb (255, 120, 255);
			BackB = Color.FromArgb (20, 20, 20);
		}
		public WinSet (int angle){
			Angle = angle;
			vec = new Vector (0, 0);
			Style = 0;
			AdvancedMode = 0;
			Back = Color.FromArgb (10, 10, 10);
			BackP = Color.Gray;
			Fore = Color.Red;
			ForeB = Color.Red;
			ForeP = Color.White;
			ArrowColor = Color.Red;
			MBack = Color.Black;
			PathColor = Color.FromArgb (255, 120, 255);
			BackB = Color.FromArgb (20, 20, 20);
		}
		public WinSet (Vector Vec){
			Angle = 0;
			vec = Vec;
			Style = 0;
			AdvancedMode = 0;
			Back = Color.FromArgb (10, 10, 10);
			BackP = Color.Gray;
			Fore = Color.Red;
			ForeB = Color.Red;
			ForeP = Color.White;
			ArrowColor = Color.Red;
			MBack = Color.Black;
			PathColor = Color.FromArgb (255, 120, 255);
			BackB = Color.FromArgb (20, 20, 20);
		}
		public WinSet (int angle, Vector Vec){
			Angle = angle;
			vec = Vec;
			Style = 0;
			AdvancedMode = 0;
			Back = Color.FromArgb (10, 10, 10);
			BackP = Color.Gray;
			Fore = Color.Red;
			ForeB = Color.Red;
			ForeP = Color.White;
			ArrowColor = Color.Red;
			MBack = Color.Black;
			PathColor = Color.FromArgb (255, 120, 255);
			BackB = Color.FromArgb (20, 20, 20);
		}
		public WinSet (int angle, Vector Vec,int style){
			Angle = angle;
			vec = Vec;
			Style = style;
			AdvancedMode = 0;
			Back = Color.FromArgb (10, 10, 10);
			BackP = Color.Gray;
			Fore = Color.Red;
			ForeB = Color.Red;
			ForeP = Color.White;
			ArrowColor = Color.Red;
			MBack = Color.Black;
			PathColor = Color.FromArgb (255, 120, 255);
			BackB = Color.FromArgb (20, 20, 20);
		}
		public WinSet (int angle, Vector Vec,int style,int advanced){
			Angle = angle;
			vec = Vec;
			Style = style;
			AdvancedMode = advanced;
			Back = Color.FromArgb (10, 10, 10);
			BackP = Color.Gray;
			Fore = Color.Red;
			ForeB = Color.Red;
			ForeP = Color.White;
			ArrowColor = Color.Red;
			MBack = Color.Black;
			PathColor = Color.FromArgb (255, 120, 255);
			BackB = Color.FromArgb (20, 20, 20);
		}
		public WinSet (Color back, Color backP, Color fore, Color foreP, Color foreB, Color backB, Color arrowColor, Color mBack, Color pathColor){
			Angle = 0;
			vec = new Vector (0, 0);
			Style = 0;
			AdvancedMode = 0;
			Back = back;
			BackP = backP;
			Fore = fore;
			ForeB = foreB;
			ForeP = foreP;
			ArrowColor = arrowColor;
			MBack = mBack;
			PathColor = pathColor;
			BackB = backB;
		}
		public WinSet (int angle, Vector Vec, Color back, Color fore, Color backP, Color foreP, Color backB, Color foreB, Color arrowColor, Color mBack, Color pathColor){
			Angle = angle;
			vec = Vec;
			Style = 0;
			AdvancedMode = 0;
			Back = back;
			BackP = backP;
			Fore = fore;
			ForeB = foreB;
			ForeP = foreP;
			ArrowColor = arrowColor;
			MBack = mBack;
			PathColor = pathColor;
			BackB = backB;
		}
		public WinSet (int angle, Vector Vec, int style, Color back, Color fore, Color backP, Color foreP, Color backB, Color foreB, Color arrowColor, Color mBack, Color pathColor){
			Angle = angle;
			vec = Vec;
			Style = style;
			AdvancedMode = 0;
			Back = back;
			BackP = backP;
			Fore = fore;
			ForeB = foreB;
			ForeP = foreP;
			ArrowColor = arrowColor;
			MBack = mBack;
			PathColor = pathColor;
			BackB = backB;
		}
		public WinSet (int angle, Vector Vec, int style, int advanced, Color back, Color fore, Color backP, Color foreP, Color backB, Color foreB, Color arrowColor, Color mBack, Color pathColor){
			Angle = angle;
			vec = Vec;
			Style = style;
			AdvancedMode = advanced;
			Back = back;
			BackP = backP;
			Fore = fore;
			ForeB = foreB;
			ForeP = foreP;
			ArrowColor = arrowColor;
			MBack = mBack;
			PathColor = pathColor;
			BackB = backB;
		}
	}
}


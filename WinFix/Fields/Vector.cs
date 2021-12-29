using System;

namespace RA
{
	[Serializable]
	public class Vector{
		public int X;
		public int Y;

		public Vector(){
			X = 0;
			Y = 0;
		}

		public Vector(int x,int y){
			X = x;
			Y = y;
		}

		public void Add(int val,bool x)
		{
			if (x) {
				X += val;
			} else {
				Y += val;
			}
		}

	}
}


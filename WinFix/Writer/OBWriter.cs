using System;
using System.IO;
namespace RA
{
	public class OBWriter
	{
		[STAThread]
		public static void Main(){
			TextWriter tx=new StreamWriter("D:\\Test.txt");
			TMS t = new TMS ("Test", 20);
			tx.Write ((object)t);
	//		Console.WriteLine (()+"");
		}



	}
	[Serializable]
	public class TMS{
		public string Name;
		public int Value;

		public TMS(string name,int value){
			Name = name;
			Value = value;
		}
	}
}


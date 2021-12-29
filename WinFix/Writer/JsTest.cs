using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
namespace RA
{
	[Serializable]
	public class JsTest
	{
		public static void Write(object obj,string path)
		{
//			System.Runtime.Serialization.Formatters.Soap.SoapFormatter formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter ();
					BinaryFormatter formatter = new BinaryFormatter(); 
			using (FileStream fs = new FileStream (path, FileMode.Append, FileAccess.Write)) {
				formatter.Serialize (fs, obj);
			}
		}

		public static object Read(string path)
		{
//			System.Runtime.Serialization.Formatters.Soap.SoapFormatter formatter = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter ();
			BinaryFormatter formatter = new BinaryFormatter(); 
			using (FileStream fs = new FileStream(path, FileMode.Open,FileAccess.Read))
			{
				return formatter.Deserialize(fs);
			}
		}

		public static void Main ()
		{
			
			WinSet W = new WinSet ();

			BinaryFormatter formatter = new BinaryFormatter(); 
			try {
				WinSet s = (WinSet) Read("D:\\mbase.dat");
		//		Console.WriteLine(s.MainMode+" "+s.Back.R);
			}catch{
				Write (W, "D:\\mbase.dat");
			}
		}
	}
}


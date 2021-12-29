using System;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
namespace RA
{
	[Serializable]
	public class DRegion
	{
	//	public string Name;

		public SGraphicsPath Main;
	//	public DType type;

		public DRegion (string name,SGraphicsPath region,DType tip)
		{
	//		Name = name;
			Main = region;
	//		type = tip;
		}
	}
}


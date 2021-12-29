using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace RA
{
	[DataContract]
	public class FormularOptionsList
	{   
		[DataMember]
		public List<FormularOptions> lst;
	}
	[DataContract]
	public class FormularOptions
	{       
		[DataMember]
		public string Name;
		[DataMember]
		public FormularShtatnost shtatnost;
		[DataMember]
		public List<FormularObjects> lst;
		[DataMember]
		public List<FormularDolg> lstDolg;
		public override string ToString()
		{
			return Name;
		}
	}
	[DataContract]
	public class FormularShtatnost
	{
		[DataMember]
		public List<int> CommonShtatnost;
		[DataMember]
		public List<int> LeadersShtatnost;
	}
	[DataContract]
	public class FormularDolg
	{
		[DataMember]
		public int b1;
		[DataMember]
		public string Name;
		public FormularDolg(int b1, string Name)
		{
			this.b1 = b1;
			this.Name = Name;
		}

	}
	[DataContract]
	public class FormularObjects
	{
		[DataMember]
	//	public FormularType type;
//		[DataMember]
		public int id;
		[DataMember]
		public string Name;       
		public FormularObjects( int id,string Name)
		{
		//	this.type = type;
			this.id = id;
			this.Name = Name;
		}
		public FormularObjects( int id)
		{
		//	this.type = type;
			this.id = id;
			this.Name = string.Empty;
		}
	}

}


using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace RA
{
	public class SerContract : Newtonsoft.Json.Serialization.DefaultContractResolver
	{
			protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
			{
			
				var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
					.Select(p => base.CreateProperty(p, memberSerialization))
					.Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
						.Select(f => base.CreateProperty(f, memberSerialization)))
					.ToList();
				props.ForEach(p => { p.Writable = true; p.Readable = true; });


	return props;
			}
			
		public object Serialize(object obj)
		{

			var settings = new JsonSerializerSettings () { ContractResolver = new SerContract () };
			var json = JsonConvert.SerializeObject (obj, settings);

			return (object)json;
		}
	}
}


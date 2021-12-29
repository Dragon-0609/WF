using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
namespace RA
{
	public static class Json
	{
		public static T CastTo<T>(this Object x, T typeHolder)
		{
			try
			{
				return (T)x;
			}
			catch
			{
				return default(T);
			}
		}
		public static byte[] SerializeToByteArray<T>(this T obj)
		{
			if (obj == null)
				return new byte[0];
			BinaryFormatter bf = new BinaryFormatter();
			using (MemoryStream ms = new MemoryStream())
			{
				bf.Serialize(ms, obj);
				return ms.ToArray();
			}
		}
		public static T DeserializeByteArrayToObject<T>(this byte[] arrBytes)
		{
			if (arrBytes == null || arrBytes.Length == 0)
				return default(T);
			using (MemoryStream memStream = new MemoryStream())
			{
				BinaryFormatter binForm = new BinaryFormatter();
				memStream.Write(arrBytes, 0, arrBytes.Length);
				memStream.Seek(0, SeekOrigin.Begin);
				T obj = (T)binForm.Deserialize(memStream);
				return obj;
			}
		}
		public static string Serialize<T>(this T value)
		{
			if (value == null)
			{
				throw new ArgumentException("value");
			}
			using (MemoryStream ms = new MemoryStream())
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(value.GetType());
				serializer.WriteObject(ms, value);
				ms.Position = 0;
				StreamReader sr = new StreamReader(ms);
				return sr.ReadToEnd();
			}
		}
		public static T Deserialize<T>(this string json)
		{
			if (string.IsNullOrEmpty(json))
				return Activator.CreateInstance<T>();
			T obj = Activator.CreateInstance<T>();
			using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
	//			try
	//			{
					obj = (T)serializer.ReadObject(ms);
	//			}
	//			catch (Exception ex)
	//			{
	//				throw ex;
	//			}
				ms.Close();
			}
			return obj;
		}

		public static string Serialize(PointF[] value)
		{
			if (value == null)
			{
				throw new ArgumentException("value");
			}
			using (MemoryStream ms = new MemoryStream())
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(value.GetType());
				serializer.WriteObject(ms, value);
				ms.Position = 0;
				StreamReader sr = new StreamReader(ms);
				return sr.ReadToEnd();
			}
		}
		public static PointF[] Deserialize(this string json)
		{
			if (string.IsNullOrEmpty(json))
				return Activator.CreateInstance<PointF[]>();
			PointF[] obj = Activator.CreateInstance<PointF[]>();
			using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
				//			try
				//			{
				obj = (PointF[])serializer.ReadObject(ms);
				//			}
				//			catch (Exception ex)
				//			{
				//				throw ex;
				//			}
				ms.Close();
			}
			return obj;
		}
	}

}


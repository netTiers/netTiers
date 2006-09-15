using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace netTiers.PetShop
{
	/// <summary>
	/// Attach this to every property that should be 
	/// displayed in the designer.
	/// </summary>
	[AttributeUsage (AttributeTargets.Property)]
	public sealed class BindableAttribute : System.Attribute
	{
		/// <summary>
		/// Intitialize a new instance of the BindableAttribute class.
		/// </summary>
		public BindableAttribute() {}
	}
	
	/// <summary>
	/// This classes contains utilities functions for the <see cref="IEntity"/> instances and collections.
	/// </summary>
	/// <remarks>All methods static</remarks>
	public sealed class EntityHelper
	{
		private EntityHelper()
		{
			//All methods static
		}

		#region SerializeBinary 

		/// <summary>
		/// Serializes the entity to binary.
		/// </summary>
		/// <param name="entity">The Entity to serialize.</param>
		/// <value>A byte array that contains the serialized entity.</value>
		public static byte[] SerializeBinary(IEntity entity)
		{
			MemoryStream ms = new MemoryStream();
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(ms, entity);
			return ms.ToArray();
		}

		/// <summary>
		/// Serializes the entity collection to binary.
		/// </summary>
		/// <param name="entityCollection">The Entity collection to serialize.</param>
		/// <value>A byte array that contains the serialized entity.</value>
		public static byte[] SerializeBinary(CollectionBase entityCollection)
		{
			MemoryStream ms = new MemoryStream();
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(ms, entityCollection);
			return ms.ToArray();			
		}
		
		/// <summary>
		/// Serializes the entity to binary and puts the data into a file.
		/// </summary>
		/// <param name="entity">The Entity to serialize.</param>
		/// <param name="path">The Path to the destination file.</param>
		public static void SerializeBinary(IEntity entity, string path)
		{
			FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, entity);
			fs.Close();
		}
		
		/// <summary>
		/// Serializes the entity collection to binary and puts the data into a file.
		/// </summary>
		/// <param name="entityCollection">The Entity collection to serialize.</param>
		/// <param name="path">The Path to the destination file.</param>
		public static void SerializeBinary(CollectionBase entityCollection, string path)
		{
			FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(fs, entityCollection);
			fs.Close();
		}

		#endregion

		#region SerializeXml 
		
		/// <summary>
		/// serialize an object to xml.
		/// </summary>
		/// <param name="item">The item to serialize.</param>
		/// <returns></returns>
		public static string XmlSerialize<T>(T item)
		{
			XmlSerializer s = new XmlSerializer(typeof(T));
			StringBuilder stringBuilder = new StringBuilder();

			StringWriter writer = new StringWriter(stringBuilder);
			s.Serialize(writer, item);
			writer.Close();

			return stringBuilder.ToString();
		}
		
		/// <summary>
		/// Serializes the entity to Xml.
		/// </summary>
		/// <param name="entity">The Entity to serialize.</param>
		/// <returns>A string that contains the serialized entity.</returns>
		public static string SerializeXml(IEntity entity)
		{
			XmlSerializer ser = new XmlSerializer(entity.GetType());
			StringBuilder sb = new StringBuilder();
			TextWriter writer = new StringWriter(sb);
			ser.Serialize(writer, entity);
			writer.Close();
			return sb.ToString();
		}
		
        /// <summary>
        /// Serializes the <see cref="T:TList{T}"/> of IEntity to XML
        /// </summary>
        /// <typeparam name="T">type to return, type must implement IEntity</typeparam>
        /// <param name="entityCollection">TList of T type to return</param>
        /// <returns>string of serialized XML</returns>
        public static string SerializeXml<T>(TList<T> entityCollection)  where T : IEntity, new()
        {
            XmlSerializer ser = new XmlSerializer(entityCollection.GetType());
            StringBuilder sb = new StringBuilder();
            TextWriter writer = new StringWriter(sb);
            ser.Serialize(writer, entityCollection);
            writer.Close();
            return sb.ToString();
        }

		/// <summary>
		/// Serializes the entity to xml and puts the data into a file.
		/// </summary>
		/// <param name="entity">The Entity to serialize.</param>
		/// <param name="path">The Path to the destination file.</param>
		public static void SerializeXml(IEntity entity, string path)
		{
			XmlSerializer ser = new XmlSerializer(entity.GetType());
			StreamWriter sw = new StreamWriter(path);
			ser.Serialize(sw, entity);
			sw.Close();
		}
		
		/// <summary>
		/// Serializes the entity collection to xml and puts the data into a file.
		/// </summary>
		/// <param name="entityCollection">The Entity collection to serialize.</param>
		/// <param name="path">The Path to the destination file.</param>
		public static void SerializeXml<T>(TList<T> entityCollection, string path) where T : IEntity, new()
		{
			XmlSerializer ser = new XmlSerializer(entityCollection.GetType());
			StreamWriter sw = new StreamWriter(path);
			ser.Serialize(sw, entityCollection);
			sw.Close();
		}
		
		#region CollectionBase SerializeXML Methods OBSOLETE
        /// <summary>
		/// Serializes the entity collection to xml.
		/// </summary>
		/// <param name="entityCollection">The Entity collection to serialize.</param>
		/// <returns>A string that contains the serialized entity.</returns>
		[Obsolete]
		public static string SerializeXml(CollectionBase entityCollection)
		{
			XmlSerializer ser = new XmlSerializer(entityCollection.GetType());
			StringBuilder sb = new StringBuilder();
			TextWriter writer = new StringWriter(sb);
			ser.Serialize(writer, entityCollection);
			writer.Close();
			return sb.ToString();
		}

        /// <summary>
        /// Serializes the entity collection to xml and puts the data into a file.
        /// </summary>
        /// <param name="entityCollection">The Entity collection to serialize.</param>
        /// <param name="path">The Path to the destination file.</param>
		[Obsolete]
        public static void SerializeXml(CollectionBase entityCollection, string path)
        {
            XmlSerializer ser = new XmlSerializer(entityCollection.GetType());
            StreamWriter sw = new StreamWriter(path);
            ser.Serialize(sw, entityCollection);
            sw.Close();
        }
        #endregion 
		#endregion 

		#region Deserialize Binary
		
		/// <summary>
		/// Deserializes the binary data to an object instance.
		/// </summary>
		/// <param name="bytes">The byte array that contains binary serialized datas.</param>
		/// <returns>The deserialized instance</returns>
		public static object DeserializeBinary(byte[] bytes)
		{
			MemoryStream ms = new MemoryStream(bytes);
			BinaryFormatter bf = new BinaryFormatter();
			return bf.Deserialize(ms);
		}
		#endregion

		#region DeserializeXml

		/// <summary>
		/// deserialize an xml string into an object.
		/// </summary>
		/// <param name="xmlData">The XML data.</param>
		/// <returns></returns>
		public static T XmlDeserialize<T>(string xmlData)
		{
			XmlSerializer s = new XmlSerializer(typeof(T));
			TextReader reader = new StringReader(xmlData);
			T entity = (T)s.Deserialize(reader);
			reader.Close();
			return entity;
		}

        /// <summary>
        /// Deserialize an Entity from an xml string to T
        /// </summary>
        /// <typeparam name="T">T where T : IEntity</typeparam>
		/// <param name="data">string of serialized xml</param>
        /// <returns>T where T : IEntity</returns>
        public static T DeserializeEntityXml<T>(string data) where T : IEntity
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader reader = new StringReader(data);
            T toReturn;
            toReturn = (T)serializer.Deserialize(reader) ;
            reader.Close();
            return toReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"><see cref="T:TList{T}"/> where T : IEntity, new()</typeparam>
        /// <param name="data">string of serialized TList of T xml</param>
        /// <returns><see cref="T:TList{T}"/> where T : IEntity, new()</returns>
        public static TList<T> DeserializeListXml<T>(string data) where T : IEntity, new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TList<T>));
            TextReader reader = new StringReader(data);
            TList<T> toReturn;
            toReturn = (TList<T>)serializer.Deserialize(reader);
            reader.Close();
            return toReturn;
        }

		/// <summary>
		/// Deserializes the XML string to an instance of the specified type.
		/// </summary>
		/// <param name="root">The name of the root node.</param>
		/// <param name="type">The targeted Type.</param>
		/// <param name="reader">The xmlReader instance that point to the xml data.</param>
		/// <returns>An instance of the Type class.</returns>		
		public static object DeserializeXml(string root, Type type, XmlReader reader)
		{
			XmlRootAttribute xmlRoot = new XmlRootAttribute();
			xmlRoot.ElementName = root;
			XmlSerializer serializer = new XmlSerializer(type, xmlRoot);
			object obj = serializer.Deserialize(reader);
			return obj;
		}
		
		#region DeserializeXml Obsolete
		/// <summary>
		/// Deserializes the XML string to an instance of the specified type.  
		/// Only works with Types that implement IEntity.
		/// </summary>
		/// <param name="data">The xml string to deserialize.</param>
		/// <param name="type">The targeted Type.</param>
		/// <returns>An instance of the Type class.</returns>
		[Obsolete]
		public static object DeserializeXml(string data, Type type)
		{
			XmlSerializer serializer = new XmlSerializer(type);
			IEntity toReturn;
			TextReader reader = new StringReader(data);
			toReturn = (IEntity)serializer.Deserialize(reader);
			reader.Close();
			return toReturn;
		}
		#endregion
		
		#endregion

		#region GetByteLength 

		/// <summary>
		/// Gets the byte length of the specified object.
		/// </summary>
		/// <param name="obj">The object we want the length.</param>
		/// <returns>The byte length of the object.</returns>
		public static long GetByteLength(object obj)
		{
			MemoryStream ms = new MemoryStream();
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(ms, obj);
			return ms.Length;
		}

		#endregion
		
		#region Dynamic ToString Implementation through Reflection
		/// <summary>
		/// Give a string representation of a object, with use of reflection.
		/// </summary>
		/// <param name="o">O.</param>
		/// <returns></returns>
		public static string ToString(Object o)
		{
			StringBuilder sb = new StringBuilder();
			Type t = o.GetType();

			PropertyInfo[] pi = t.GetProperties();

			sb.Append("Properties for: " + o.GetType().Name + Environment.NewLine);
			foreach (PropertyInfo i in pi)
			{
				try
				{
					sb.Append("\t" + i.Name + "(" + i.PropertyType.ToString() + "): ");
					if (null != i.GetValue(o, null))
					{
						sb.Append(i.GetValue(o, null).ToString());
					}

				}
				catch
				{
				}
				sb.Append(Environment.NewLine);

			}

			FieldInfo[] fi = t.GetFields();

			foreach (FieldInfo i in fi)
			{
				try
				{
					sb.Append("\t" + i.Name + "(" + i.FieldType.ToString() + "): ");
					if (null != i.GetValue(o))
					{
						sb.Append(i.GetValue(o).ToString());
					}

				}
				catch
				{
				}
				sb.Append(Environment.NewLine);

			}

			return sb.ToString();
		}
		#endregion 
		
		#region AreObjectsEqual, OBSOLETE
		/*
		Actually this function crashes in some case. need to fix it.
		/// <summary>
		/// Ares the objects equal (CREDIT To OSI ADAPDEV FRAMEWORK).
		/// </summary>
		/// <param name="o1">first object to compare.</param>
		/// <param name="o2">second object to compare.</param>
		/// <returns></returns>
		public static bool AreObjectsEqual(Object o1, Object o2)
		{
			Type t1 = o1.GetType();
			Type t2 = o2.GetType();

			PropertyInfo[] pi1 = t1.GetProperties();
			PropertyInfo[] pi2 = t2.GetProperties();

			for (int i = 0; i < pi1.Length; i++)
			{
				try
				{
					PropertyInfo i1 = pi1[i];
					PropertyInfo i2 = pi2[i];

					if (!i1.GetValue(o1, null).Equals(null) && !i2.GetValue(o2, null).Equals(null))
					{
						if (!i1.GetValue(o1, null).Equals(i2.GetValue(o2, null)))
						{
							return false;
						}
					}
				}
				catch (Exception)
				{
					throw;
				}
			}

			FieldInfo[] fi1 = t1.GetFields();
			FieldInfo[] fi2 = t2.GetFields();

			for (int i = 0; i < fi1.Length; i++)
			{
				try
				{
					FieldInfo i1 = fi1[i];
					FieldInfo i2 = fi2[i];

					if (!i1.GetValue(o1).Equals(null) && !i2.GetValue(o2).Equals(null))
					{
						if (!i1.GetValue(o1).Equals(i2.GetValue(o2)))
						{
							return false;
						}
					}
				}
				catch (Exception)
				{
					throw;
				}
			}

			return true;
		}
		*/
		#endregion 
	}
}

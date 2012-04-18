﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using Insight.Database.CodeGenerator;

namespace Insight.Database
{
	/// <summary>
	/// Extension methods for object mapping.
	/// </summary>
	public static class DBReaderExtensions
	{
		#region ToList Methods
		/// <summary>
		/// Converts an IDataReader to a list of objects.
		/// </summary>
		/// <param name="reader">The data reader.</param>
		/// <returns>A list of objects.</returns>
		public static List<FastExpando> ToList(this IDataReader reader)
		{
			return reader.AsEnumerable().ToList();
		}

		/// <summary>
		/// Converts an IDataReader to a list of objects.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <returns>A list of objects.</returns>
		public static List<T> ToList<T>(this IDataReader reader)
		{
			return reader.AsEnumerable<T>().ToList();
		}

		/// <summary>
		/// Converts an IDataReader to a list of objects.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <typeparam name="TSub1">The expected type of sub object 1.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <returns>A list of objects.</returns>
		public static List<T> ToList<T, TSub1>(this IDataReader reader)
		{
			return reader.AsEnumerable<T, TSub1>().ToList();
		}

		/// <summary>
		/// Converts an IDataReader to a list of objects.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <typeparam name="TSub1">The expected type of sub object 1.</typeparam>
		/// <typeparam name="TSub2">The expected type of sub object 2.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <returns>A list of objects.</returns>
		public static List<T> ToList<T, TSub1, TSub2>(this IDataReader reader)
		{
			return reader.AsEnumerable<T, TSub1, TSub2>().ToList();
		}

		/// <summary>
		/// Converts an IDataReader to a list of objects.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <typeparam name="TSub1">The expected type of sub object 1.</typeparam>
		/// <typeparam name="TSub2">The expected type of sub object 2.</typeparam>
		/// <typeparam name="TSub3">The expected type of sub object 3.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <returns>A list of objects.</returns>
		public static List<T> ToList<T, TSub1, TSub2, TSub3>(this IDataReader reader)
		{
			return reader.AsEnumerable<T, TSub1, TSub2, TSub3>().ToList();
		}

		/// <summary>
		/// Converts an IDataReader to a list of objects.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <typeparam name="TSub1">The expected type of sub object 1.</typeparam>
		/// <typeparam name="TSub2">The expected type of sub object 2.</typeparam>
		/// <typeparam name="TSub3">The expected type of sub object 3.</typeparam>
		/// <typeparam name="TSub4">The expected type of sub object 4.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <returns>A list of objects.</returns>
		public static List<T> ToList<T, TSub1, TSub2, TSub3, TSub4>(this IDataReader reader)
		{
			return reader.AsEnumerable<T, TSub1, TSub2, TSub3, TSub4>().ToList();
		}

		/// <summary>
		/// Converts an IDataReader to a list of objects.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <typeparam name="TSub1">The expected type of sub object 1.</typeparam>
		/// <typeparam name="TSub2">The expected type of sub object 2.</typeparam>
		/// <typeparam name="TSub3">The expected type of sub object 3.</typeparam>
		/// <typeparam name="TSub4">The expected type of sub object 4.</typeparam>
		/// <typeparam name="TSub5">The expected type of sub object 5.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <returns>A list of objects.</returns>
		public static List<T> ToList<T, TSub1, TSub2, TSub3, TSub4, TSub5>(this IDataReader reader)
		{
			return reader.AsEnumerable<T, TSub1, TSub2, TSub3, TSub4, TSub5>().ToList();
		}
		#endregion

		#region AsEnumerable Methods
		/// <summary>
		/// Converts an IDataReader to an enumerable. The reader is closed after all records are read.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <returns>An enumerable over the return results.</returns>
		/// <remarks>
		/// If you use this method and are relying on CommandBehavior.CloseConnection to close the connection, note that if all of the records are not read
		/// (due to an exception or otherwise), then the connection will leak until GC is run. Your code is responsible for closing the connection.
		/// </remarks>
		public static IEnumerable<FastExpando> AsEnumerable(this IDataReader reader)
		{
			var mapper = DbReaderDeserializer<FastExpando>.GetDeserializer(reader);
			return reader.AsEnumerable(mapper);
		}

		/// <summary>
		/// Converts an IDataReader to an enumerable. The reader is closed after all records are read.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <returns>An enumerable over the return results.</returns>
		/// <remarks>
		/// If you use this method and are relying on CommandBehavior.CloseConnection to close the connection, note that if all of the records are not read
		/// (due to an exception or otherwise), then the connection will leak until GC is run. Your code is responsible for closing the connection.
		/// </remarks>
		public static IEnumerable<T> AsEnumerable<T>(this IDataReader reader)
		{
			var mapper = DbReaderDeserializer<T>.GetDeserializer(reader);
			return reader.AsEnumerable(mapper);
		}

		/// <summary>
		/// Converts an IDataReader to an enumerable. The reader is closed after all records are read.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <typeparam name="TSub1">The expected type of sub object 1.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <param name="callback">A callback for custom sub-object mapping.</param>
		/// <param name="idColumns">A list of names of columns that identify the start of a new type.</param>
		/// <returns>An enumerable over the return results.</returns>
		/// <remarks>
		/// If you use this method and are relying on CommandBehavior.CloseConnection to close the connection, note that if all of the records are not read
		/// (due to an exception or otherwise), then the connection will leak until GC is run. Your code is responsible for closing the connection.
		/// </remarks>
		public static IEnumerable<T> AsEnumerable<T, TSub1>(
			this IDataReader reader,
			Action<T, TSub1> callback = null,
			Dictionary<Type, string> idColumns = null)
		{
			// get the class deserializer
			var mapper = DbReaderDeserializer<T, TSub1, NoClass, NoClass, NoClass, NoClass>.GetDeserializer(reader, callback != null, idColumns);
			return reader.AsEnumerable(r => mapper(r, (t, t1, t2, t3, t4, t5) => callback(t, t1)));
		}

		/// <summary>
		/// Converts an IDataReader to an enumerable. The reader is closed after all records are read.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <typeparam name="TSub1">The expected type of sub object 1.</typeparam>
		/// <typeparam name="TSub2">The expected type of sub object 2.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <param name="callback">A callback for custom sub-object mapping.</param>
		/// <param name="idColumns">A list of names of columns that identify the start of a new type.</param>
		/// <returns>An enumerable over the return results.</returns>
		/// <remarks>
		/// If you use this method and are relying on CommandBehavior.CloseConnection to close the connection, note that if all of the records are not read
		/// (due to an exception or otherwise), then the connection will leak until GC is run. Your code is responsible for closing the connection.
		/// </remarks>
		public static IEnumerable<T> AsEnumerable<T, TSub1, TSub2>(
			this IDataReader reader,
			Action<T, TSub1, TSub2> callback = null,
			Dictionary<Type, string> idColumns = null)
		{
			// get the class deserializer
			var mapper = DbReaderDeserializer<T, TSub1, TSub2, NoClass, NoClass, NoClass>.GetDeserializer(reader, callback != null, idColumns);
			return reader.AsEnumerable(r => mapper(r, (t, t1, t2, t3, t4, t5) => callback(t, t1, t2)));
		}

		/// <summary>
		/// Converts an IDataReader to an enumerable. The reader is closed after all records are read.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <typeparam name="TSub1">The expected type of sub object 1.</typeparam>
		/// <typeparam name="TSub2">The expected type of sub object 2.</typeparam>
		/// <typeparam name="TSub3">The expected type of sub object 3.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <param name="callback">A callback for custom sub-object mapping.</param>
		/// <param name="idColumns">A list of names of columns that identify the start of a new type.</param>
		/// <returns>An enumerable over the return results.</returns>
		/// <remarks>
		/// If you use this method and are relying on CommandBehavior.CloseConnection to close the connection, note that if all of the records are not read
		/// (due to an exception or otherwise), then the connection will leak until GC is run. Your code is responsible for closing the connection.
		/// </remarks>
		public static IEnumerable<T> AsEnumerable<T, TSub1, TSub2, TSub3>(
			this IDataReader reader,
			Action<T, TSub1, TSub2, TSub3> callback = null,
			Dictionary<Type, string> idColumns = null)
		{
			// get the class deserializer
			var mapper = DbReaderDeserializer<T, TSub1, TSub2, TSub3, NoClass, NoClass>.GetDeserializer(reader, callback != null, idColumns);
			return reader.AsEnumerable(r => mapper(r, (t, t1, t2, t3, t4, t5) => callback(t, t1, t2, t3)));
		}

		/// <summary>
		/// Converts an IDataReader to an enumerable. The reader is closed after all records are read.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <typeparam name="TSub1">The expected type of sub object 1.</typeparam>
		/// <typeparam name="TSub2">The expected type of sub object 2.</typeparam>
		/// <typeparam name="TSub3">The expected type of sub object 3.</typeparam>
		/// <typeparam name="TSub4">The expected type of sub object 4.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <param name="callback">A callback for custom sub-object mapping.</param>
		/// <param name="idColumns">A list of names of columns that identify the start of a new type.</param>
		/// <returns>An enumerable over the return results.</returns>
		/// <remarks>
		/// If you use this method and are relying on CommandBehavior.CloseConnection to close the connection, note that if all of the records are not read
		/// (due to an exception or otherwise), then the connection will leak until GC is run. Your code is responsible for closing the connection.
		/// </remarks>
		public static IEnumerable<T> AsEnumerable<T, TSub1, TSub2, TSub3, TSub4>(
			this IDataReader reader,
			Action<T, TSub1, TSub2, TSub3, TSub4> callback = null,
			Dictionary<Type, string> idColumns = null)
		{
			// get the class deserializer
			var mapper = DbReaderDeserializer<T, TSub1, TSub2, TSub3, TSub4, NoClass>.GetDeserializer(reader, callback != null, idColumns);
			return reader.AsEnumerable(r => mapper(r, (t, t1, t2, t3, t4, t5) => callback(t, t1, t2, t3, t4)));
		}

		/// <summary>
		/// Converts an IDataReader to an enumerable. The reader is closed after all records are read.
		/// </summary>
		/// <typeparam name="T">The expected type of the object.</typeparam>
		/// <typeparam name="TSub1">The expected type of sub object 1.</typeparam>
		/// <typeparam name="TSub2">The expected type of sub object 2.</typeparam>
		/// <typeparam name="TSub3">The expected type of sub object 3.</typeparam>
		/// <typeparam name="TSub4">The expected type of sub object 4.</typeparam>
		/// <typeparam name="TSub5">The expected type of sub object 5.</typeparam>
		/// <param name="reader">The data reader.</param>
		/// <param name="callback">A callback for custom sub-object mapping.</param>
		/// <param name="idColumns">A list of names of columns that identify the start of a new type.</param>
		/// <returns>An enumerable over the return results.</returns>
		/// <remarks>
		/// If you use this method and are relying on CommandBehavior.CloseConnection to close the connection, note that if all of the records are not read
		/// (due to an exception or otherwise), then the connection will leak until GC is run. Your code is responsible for closing the connection.
		/// </remarks>
		public static IEnumerable<T> AsEnumerable<T, TSub1, TSub2, TSub3, TSub4, TSub5>(
			this IDataReader reader,
			Action<T, TSub1, TSub2, TSub3, TSub4, TSub5> callback = null,
			Dictionary<Type, string> idColumns = null)
		{
			// get the class deserializer
			var mapper = DbReaderDeserializer<T, TSub1, TSub2, TSub3, TSub4, TSub5>.GetDeserializer(reader, callback != null, idColumns);

			return reader.AsEnumerable(r => mapper(r, callback));
		}

		/// <summary>
		/// Read a data reader and map the objects as they are read.
		/// </summary>
		/// <typeparam name="T">The type of object to return.</typeparam>
		/// <param name="reader">The reader to read.</param>
		/// <param name="mapper">The mapper to use.</param>
		/// <returns>An enumerable for the type.</returns>
		private static IEnumerable<T> AsEnumerable<T>(this IDataReader reader, Func<IDataReader, T> mapper)
		{
			// read in all of the objects from the reader
			while (reader.Read())
				yield return mapper(reader);

			// if there are no results left, then clean up the reader
			if (!reader.NextResult())
				reader.Dispose();
		}
		#endregion
	}
}
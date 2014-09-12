﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Database.Mapping
{
	/// <summary>
	/// Maps a column to a field.
	/// </summary>
	public interface IColumnMapper : IMapper
	{
		/// <summary>
		/// Returns the name of the field on the given type that maps to the specified parameter.
		/// </summary>
		/// <param name="type">The type to test.</param>
		/// <param name="reader">The reader being parsed.</param>
		/// <param name="column">The index of the column being mapped.</param>
		/// <returns>The name of the field on type, or null to allow other mappers to handle the parameter.</returns>
		/// <remarks>To prevent other mappers from handling a parameter, return a non-null value that does not map to a field on the type.</remarks>
		string MapColumn(Type type, IDataReader reader, int column);
	}
}

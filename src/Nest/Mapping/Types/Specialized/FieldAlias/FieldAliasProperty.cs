using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace Nest
{
	/// <summary>
	/// An alias mapping defines an alternate name for a field in the index. The alias can be used in place
	/// of the target field in search requests, and selected other APIs like field capabilities.
	/// </summary>
	[JsonObject(MemberSerialization.OptIn)]
	public interface IFieldAliasProperty : IProperty
	{
		/// <summary> The full path to alias </summary>
		[JsonProperty("path")]
		Field Path { get; set; }
	}

	/// <inheritdoc cref="IFieldAliasProperty.Path" />
	[DebuggerDisplay("{DebugDisplay}")]
	public class FieldAliasProperty : PropertyBase, IFieldAliasProperty
	{
		public FieldAliasProperty() : base(FieldType.Alias) { }

		/// <inheritdoc cref="IFieldAliasProperty.Path" />
		public Field Path { get; set; }
	}

	/// <inheritdoc cref="IFieldAliasProperty.Path" />
	[DebuggerDisplay("{DebugDisplay}")]
	public class FieldAliasPropertyDescriptor<T>
		: PropertyDescriptorBase<FieldAliasPropertyDescriptor<T>, IFieldAliasProperty, T>, IFieldAliasProperty
		where T : class
	{
		Field IFieldAliasProperty.Path { get; set; }

		public FieldAliasPropertyDescriptor() : base(FieldType.Alias) { }

		/// <inheritdoc cref="IFieldAliasProperty.Path" />
		public FieldAliasPropertyDescriptor<T> Path(Expression<Func<T, object>> field) => Assign(a => a.Path = field);

		/// <inheritdoc cref="IFieldAliasProperty.Path" />
		public FieldAliasPropertyDescriptor<T> Path(Field field) => Assign(a => a.Path = field);

	}
}

using System;

namespace Strongly
{
    /// <summary>
    /// Place on partial structs to make the type a strongly-typed ID
    /// </summary>
    [AttributeUsage(AttributeTargets.Struct)]
    [System.Diagnostics.Conditional("STRONGLY_TYPED_USAGES")]
    public sealed class StronglyAttribute : Attribute
    {
        /// <summary>
        /// Make the struct a strongly typed ID
        /// </summary>
        /// <param name="backingType">The <see cref="Type"/> to use to store the strongly-typed ID value.
        /// If not set, uses <see cref="StronglyDefaultsAttribute.BackingType"/>, which defaults to <see cref="StronglyType.Guid"/></param>
        /// <param name="converters">Converters to create for serializing/deserializing the strongly-typed ID value.
        /// If not set, uses <see cref="StronglyDefaultsAttribute.Converters"/>, which defaults to <see cref="StronglyConverter.NewtonsoftJson"/>
        /// and <see cref="StronglyConverter.TypeConverter"/></param>
        /// <param name="implementations">Interfaces and patterns the strongly typed id should implement
        /// If not set, uses <see cref="StronglyDefaultsAttribute.Implementations"/>, which defaults to <see cref="StronglyImplementations.IEquatable"/>
        /// and <see cref="StronglyImplementations.IComparable"/></param>
        public StronglyAttribute(
            StronglyType backingType = StronglyType.Default,
            StronglyConverter converters = StronglyConverter.Default,
            StronglyImplementations implementations = StronglyImplementations.Default)
        {
            BackingType = backingType;
            Converters = converters;
            Implementations = implementations;
        }

        /// <summary>
        /// The <see cref="Type"/> to use to store the strongly-typed ID value
        /// </summary>
        public StronglyType BackingType { get; }

        /// <summary>
        /// JSON library used to serialize/deserialize strongly-typed ID value
        /// </summary>
        public StronglyConverter Converters { get; }

        /// <summary>
        /// Interfaces and patterns the strongly typed id should implement
        /// </summary>
        public StronglyImplementations Implementations { get; }
    }
}
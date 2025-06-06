using System;
using System.ComponentModel;
using System.Globalization;

namespace UniversalUI.Converters;

public class TypeConverterBase : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) => sourceType == typeof(string);

    public string GetValueAsString(object valueObject)
    {
        if (valueObject is not string value)
            throw new InvalidOperationException($"Cannot convert from type {valueObject?.GetType()}");

        return value;
    }

    public override bool CanConvertTo(ITypeDescriptorContext? context, Type destinationType) => false;

    public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo culture, object value, Type destinationType) =>
        throw new InvalidOperationException($"ConvertTo isn't currently supported");
}

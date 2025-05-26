using System.ComponentModel;
using System.Globalization;

namespace UniversalUI.Converters;

public class ColorConverter : TypeConverterBase
{
    public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object valueObject) =>
        ConvertFromString(GetValueAsString(valueObject));

    public new static Color ConvertFromString(string value) =>
        Colors.Parse(value);
}

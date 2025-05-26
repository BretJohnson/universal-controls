using System.ComponentModel;
using System.Globalization;

namespace UniversalUI.Converters;

public class ColorTypeConverter : TypeConverterBase
{
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object? valueObject) =>
        Colors.Parse(GetValueAsString(valueObject));
}

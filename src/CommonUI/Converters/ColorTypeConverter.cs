using System.ComponentModel;
using System.Globalization;

namespace CommonUI.Converters;

public class ColorTypeConverter : TypeConverterBase
{
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object valueObject) =>
        ColorConverter.Parse(GetValueAsString(valueObject));
}

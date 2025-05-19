using System.ComponentModel;
using System.Globalization;

namespace AnywhereUI.Converters;

public class SizeTypeConverter : TypeConverterBase
{
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object valueObject) =>
        SizeConverter.ConvertFromString(GetValueAsString(valueObject));
}

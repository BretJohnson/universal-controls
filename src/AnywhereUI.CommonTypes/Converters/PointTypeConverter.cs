using System.ComponentModel;
using System.Globalization;

namespace AnywhereUI.Converters;

public class PointTypeConverter : TypeConverterBase
{
    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object valueObject) =>
        PointConverter.ConvertFromString(GetValueAsString(valueObject));
}

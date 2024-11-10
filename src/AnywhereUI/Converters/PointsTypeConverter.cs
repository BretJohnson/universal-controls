using System.ComponentModel;
using System.Globalization;

namespace AnywhereControls.Converters
{
    public class PointsTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object valueObject) =>
            PointsConverter.ConvertFromString(GetValueAsString(valueObject));
    }
}

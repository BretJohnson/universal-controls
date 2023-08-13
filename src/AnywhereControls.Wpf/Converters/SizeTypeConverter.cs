using System.ComponentModel;
using System.Globalization;
using AnywhereControls.Converters;

namespace AnywhereControls.Wpf.Converters
{
    public class SizeTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object valueObject)
        {
            return new SizeWpf(SizeConverter.ConvertFromString(GetValueAsString(valueObject)));
        }
    }
}

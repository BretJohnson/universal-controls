using System.ComponentModel;
using System.Globalization;
using AnywhereControls.Converters;

namespace AnywhereControls.Wpf.Converters
{
    public class ColorTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object valueObject)
        {
            return new ColorWpf(ColorConverter.Parse(GetValueAsString(valueObject)));
        }
    }
}

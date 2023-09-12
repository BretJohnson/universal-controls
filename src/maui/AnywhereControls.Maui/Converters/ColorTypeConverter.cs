using System.ComponentModel;
using System.Globalization;
using AnywhereControls.Converters;

namespace AnywhereControls.Maui.Converters
{
    public class ColorTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object valueObject)
        {
            return new ColorMaui(ColorConverter.ConvertFromString(GetValueAsString(valueObject)));
        }
    }
}

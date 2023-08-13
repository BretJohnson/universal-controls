using System.ComponentModel;
using System.Globalization;
using Microsoft.StandardUI.Converters;

namespace Microsoft.StandardUI.Maui.Converters
{
    public class ColorTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object valueObject)
        {
            return new ColorMaui(ColorConverter.ConvertFromString(GetValueAsString(valueObject)));
        }
    }
}

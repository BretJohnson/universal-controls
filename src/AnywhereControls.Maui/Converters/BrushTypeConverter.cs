using System.ComponentModel;
using System.Globalization;
using Microsoft.StandardUI.Converters;
using Microsoft.StandardUI.Maui.Media;

namespace Microsoft.StandardUI.Maui.Converters
{
    public class BrushTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object valueObject) =>
            new SolidColorBrush
            {
                Color = new ColorMaui(ColorConverter.ConvertFromString(GetValueAsString(valueObject)))
            };
    }
}

using System.ComponentModel;
using System.Globalization;
using AnywhereControls.Converters;
using AnywhereControls.Maui.Media;

namespace AnywhereControls.Maui.Converters
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

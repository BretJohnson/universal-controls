using System.ComponentModel;
using System.Globalization;
using AnywhereUI.Converters;
using AnywhereUI.Maui.Media;

namespace AnywhereUI.Maui.Converters
{
    public class BrushTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object valueObject) =>
            new SolidColorBrush
            {
                Color = ColorConverter.ConvertFromString(GetValueAsString(valueObject))
            };
    }
}

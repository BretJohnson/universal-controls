using System.ComponentModel;
using System.Globalization;
using AnywhereUI.Wpf.Media;
using AnywhereUI.Converters;

namespace AnywhereUI.Wpf.Converters
{
    public class BrushTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo culture, object valueObject) =>
            new SolidColorBrush
            {
                Color = ColorConverter.ConvertFromString(GetValueAsString(valueObject))
            };
    }
}

using System.ComponentModel;
using System.Globalization;
using AnywhereControls.Wpf.Media;
using AnywhereControls.Converters;

namespace AnywhereControls.Wpf.Converters
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

using System.ComponentModel;
using System.Globalization;
using UniversalUI.Converters;
using UniversalUI.Maui.Media;

namespace UniversalUI.Maui.Converters
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

using System.ComponentModel;
using System.Globalization;
using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Wpf.Media;

namespace Microsoft.StandardUI.Wpf.Converters
{
    public class BrushTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object valueObject)
        {
            return new SolidColorBrush
            {
                Color = Color.Parse(GetValueAsString(valueObject))
            };
        }
    }
}

using System.ComponentModel;
using System.Globalization;
using Microsoft.Maui.Graphics;

namespace AnywhereControls.Wpf.Converters
{
    public class ColorTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object valueObject)
        {
            return new ColorWpf(Color.Parse(GetValueAsString(valueObject)));
        }
    }
}

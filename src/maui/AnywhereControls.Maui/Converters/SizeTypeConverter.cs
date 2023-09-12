using System.ComponentModel;
using System.Globalization;
using AnywhereControls.Converters;

namespace AnywhereControls.Maui.Converters
{
    public class SizeTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object valueObject)
        {
            return new SizeMaui(SizeConverter.ConvertFromString(GetValueAsString(valueObject)));
        }
    }
}

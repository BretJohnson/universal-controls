using System.ComponentModel;
using System.Globalization;
using UniversalUI.Converters;

namespace UniversalUI.Wpf.Converters
{
    public class GeometryTypeConverter : TypeConverterBase
    {
        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo culture, object valueObject)
        {
            ///return PathConverter.ParsePathGeometry(GetValueAsString(valueObject), GeometryFactory.Instance);
            return "";
        }
    }
}

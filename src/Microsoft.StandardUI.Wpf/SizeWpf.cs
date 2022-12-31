using System.ComponentModel;
using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Wpf.Converters;

namespace Microsoft.StandardUI.Wpf
{
    [TypeConverter(typeof(SizeTypeConverter))]
    public struct SizeWpf
    {
        public static readonly SizeWpf Default = new SizeWpf(default(Size));


        public Size Size { get; }

        public SizeWpf(Size size)
        {
            Size = size;
        }
    }
}

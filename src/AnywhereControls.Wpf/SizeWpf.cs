using System.ComponentModel;
using CommonUI;
using AnywhereControls.Wpf.Converters;

namespace AnywhereControls.Wpf
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

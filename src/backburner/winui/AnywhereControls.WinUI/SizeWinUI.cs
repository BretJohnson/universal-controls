namespace AnywhereControls.WinUI
{
    //[TypeConverter(typeof(SizeTypeConverter))]
    public struct SizeWinUI
    {
        public static readonly SizeWinUI Default = new SizeWinUI(Size.Default);


        public Size Size { get; }

        public SizeWinUI(Size size)
        {
            Size = size;
        }
    }
}

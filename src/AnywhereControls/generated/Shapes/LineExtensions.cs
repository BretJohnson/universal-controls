// This file is generated from ILine.cs. Update the source file to change its contents.

namespace Microsoft.StandardUI.Shapes
{
    public static class LineExtensions
    {
        public static T X1<T>(this T line, double value) where T : ILine
        {
            line.X1 = value;
            return line;
        }
        
        public static T Y1<T>(this T line, double value) where T : ILine
        {
            line.Y1 = value;
            return line;
        }
        
        public static T X2<T>(this T line, double value) where T : ILine
        {
            line.X2 = value;
            return line;
        }
        
        public static T Y2<T>(this T line, double value) where T : ILine
        {
            line.Y2 = value;
            return line;
        }
    }
}

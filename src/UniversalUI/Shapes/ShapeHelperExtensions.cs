using static UniversalUI.UniversalUIStatics;

namespace UniversalUI.Shapes
{
    public static class ShapeHelperExtensions
    {
        public static T Fill<T>(this T shape, Color color) where T : IShape =>
            shape.Fill(SolidColorBrush(color));

        public static T Stroke<T>(this T shape, Color color) where T : IShape =>
            shape.Stroke(SolidColorBrush(color));
    }
}

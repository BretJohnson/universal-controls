using CommonUI;

namespace AnywhereControls.Wpf
{
    public static class RectExtensions
    {
        public static System.Windows.Rect ToWpfRect(this Rect rect) => new System.Windows.Rect(rect.X, rect.Y, rect.Width, rect.Height);

        public static Rect ToStandardUIRect(this System.Windows.Rect rect) => new Rect(rect.X, rect.Y, rect.Width, rect.Height);
    }
}

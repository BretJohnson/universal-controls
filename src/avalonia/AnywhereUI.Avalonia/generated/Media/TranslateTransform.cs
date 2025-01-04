// This file is generated from ITranslateTransform.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Media
{
    public class TranslateTransform : Transform, ITranslateTransform
    {
        public static readonly Avalonia.StyledProperty<double> XProperty = AvaloniaProperty.Register<TranslateTransform, double>(nameof(X), 0.0);
        public static readonly Avalonia.StyledProperty<double> YProperty = AvaloniaProperty.Register<TranslateTransform, double>(nameof(Y), 0.0);
        
        public double X
        {
            get => (double) GetValue(XProperty);
            set => SetValue(XProperty, value);
        }
        
        public double Y
        {
            get => (double) GetValue(YProperty);
            set => SetValue(YProperty, value);
        }
    }
}

// This file is generated from ITranslateTransform.cs. Update the source file to change its contents.

using AnywhereControls.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Media
{
    public class TranslateTransform : Transform, ITranslateTransform
    {
        public static readonly DependencyProperty XProperty = PropertyUtils.Register(nameof(X), typeof(double), typeof(TranslateTransform), 0.0);
        public static readonly DependencyProperty YProperty = PropertyUtils.Register(nameof(Y), typeof(double), typeof(TranslateTransform), 0.0);
        
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

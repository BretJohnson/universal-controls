// This file is generated from IScaleTransform.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.WinForms.Media
{
    public class ScaleTransform : Transform, IScaleTransform
    {
        public static readonly UIProperty CenterXProperty = new UIProperty(nameof(CenterX), 0.0);
        public static readonly UIProperty CenterYProperty = new UIProperty(nameof(CenterY), 0.0);
        public static readonly UIProperty ScaleXProperty = new UIProperty(nameof(ScaleX), 1.0);
        public static readonly UIProperty ScaleYProperty = new UIProperty(nameof(ScaleY), 1.0);
        
        public double CenterX
        {
            get => (double) GetNonNullValue(CenterXProperty);
            set => SetValue(CenterXProperty, value);
        }
        
        public double CenterY
        {
            get => (double) GetNonNullValue(CenterYProperty);
            set => SetValue(CenterYProperty, value);
        }
        
        public double ScaleX
        {
            get => (double) GetNonNullValue(ScaleXProperty);
            set => SetValue(ScaleXProperty, value);
        }
        
        public double ScaleY
        {
            get => (double) GetNonNullValue(ScaleYProperty);
            set => SetValue(ScaleYProperty, value);
        }
    }
}

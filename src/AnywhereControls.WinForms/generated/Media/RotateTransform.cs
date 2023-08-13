// This file is generated from IRotateTransform.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.WinForms.Media
{
    public class RotateTransform : Transform, IRotateTransform
    {
        public static readonly UIProperty AngleProperty = new UIProperty(nameof(Angle), 0.0);
        public static readonly UIProperty CenterXProperty = new UIProperty(nameof(CenterX), 0.0);
        public static readonly UIProperty CenterYProperty = new UIProperty(nameof(CenterY), 0.0);
        
        public double Angle
        {
            get => (double) GetNonNullValue(AngleProperty);
            set => SetValue(AngleProperty, value);
        }
        
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
    }
}

// This file is generated from IGradientStop.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using UniversalUI.Media;

namespace AnywhereControls.Blazor.Media
{
    public class GradientStop : StandardUIObject, IGradientStop
    {
        public static readonly UIProperty ColorProperty = new UIProperty(nameof(Color), Colors.Transparent);
        public static readonly UIProperty OffsetProperty = new UIProperty(nameof(Offset), 0.0);
        
        [Parameter]
        public Color Color
        {
            get => (Color) GetNonNullValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
        
        [Parameter]
        public double Offset
        {
            get => (double) GetNonNullValue(OffsetProperty);
            set => SetValue(OffsetProperty, value);
        }
    }
}

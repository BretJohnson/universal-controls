// This file is generated from ISolidColorBrush.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using UniversalUI.Media;

namespace AnywhereControls.Blazor.Media
{
    public class SolidColorBrush : Brush, ISolidColorBrush
    {
        public static readonly UIProperty ColorProperty = new UIProperty(nameof(Color), Colors.Transparent);
        
        [Parameter]
        public Color Color
        {
            get => (Color) GetNonNullValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
    }
}

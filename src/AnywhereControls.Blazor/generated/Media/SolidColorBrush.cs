// This file is generated from ISolidColorBrush.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using CommonUI;
using Microsoft.AspNetCore.Components;
using AnywhereControls.Media;

namespace AnywhereControls.Blazor.Media
{
    public class SolidColorBrush : Brush, ISolidColorBrush
    {
        public static readonly UIProperty ColorProperty = new UIProperty(nameof(Color), null);
        
        [Parameter]
        public Color Color
        {
            get => (Color) GetNonNullValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }
    }
}

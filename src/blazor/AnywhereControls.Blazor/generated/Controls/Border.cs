// This file is generated from IBorder.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using UniversalUI.Media;
using UniversalUI.Blazor.Media;
using Microsoft.AspNetCore.Components;
using UniversalUI.Controls;

namespace AnywhereControls.Blazor.Controls
{
    public class Border : BuiltInUIElement, IBorder
    {
        public static readonly UIProperty BackgroundProperty = new UIProperty(nameof(Background), null);
        public static readonly UIProperty BackgroundSizingProperty = new UIProperty(nameof(BackgroundSizing), BackgroundSizing.InnerBorderEdge);
        public static readonly UIProperty BorderBrushProperty = new UIProperty(nameof(BorderBrush), null);
        public static readonly UIProperty BorderThicknessProperty = new UIProperty(nameof(BorderThickness), Thickness.Default);
        public static readonly UIProperty ChildProperty = new UIProperty(nameof(Child), null);
        public static readonly UIProperty CornerRadiusProperty = new UIProperty(nameof(CornerRadius), CornerRadius.Default);
        public static readonly UIProperty PaddingProperty = new UIProperty(nameof(Padding), Thickness.Default);
        
        [Parameter]
        public IBrush Background
        {
            get => (Brush) GetNonNullValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }
        
        [Parameter]
        public BackgroundSizing BackgroundSizing
        {
            get => (BackgroundSizing) GetNonNullValue(BackgroundSizingProperty);
            set => SetValue(BackgroundSizingProperty, value);
        }
        
        [Parameter]
        public IBrush BorderBrush
        {
            get => (Brush) GetNonNullValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }
        
        [Parameter]
        public Thickness BorderThickness
        {
            get => (Thickness) GetNonNullValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }
        
        [Parameter]
        public IUIElement Child
        {
            get => (BuiltInUIElement) GetNonNullValue(ChildProperty);
            set => SetValue(ChildProperty, value);
        }
        
        [Parameter]
        public CornerRadius CornerRadius
        {
            get => (CornerRadius) GetNonNullValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        
        [Parameter]
        public Thickness Padding
        {
            get => (Thickness) GetNonNullValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }
    }
}

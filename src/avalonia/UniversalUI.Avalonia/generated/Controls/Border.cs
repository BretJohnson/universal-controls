// This file is generated from IBorder.cs. Update the source file to change its contents.

using UniversalUI;
using UniversalUI.Media;
using AnywhereUIAvalonia.Media;
using UniversalUI.Controls;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Controls
{
    public class Border : BuiltInUIElement, IBorder
    {
        public static readonly Avalonia.StyledProperty<Brush> BackgroundProperty = AvaloniaProperty.Register<Border, Brush>(nameof(Background), null);
        public static readonly Avalonia.StyledProperty<BackgroundSizing> BackgroundSizingProperty = AvaloniaProperty.Register<Border, BackgroundSizing>(nameof(BackgroundSizing), BackgroundSizing.InnerBorderEdge);
        public static readonly Avalonia.StyledProperty<Brush> BorderBrushProperty = AvaloniaProperty.Register<Border, Brush>(nameof(BorderBrush), null);
        public static readonly Avalonia.StyledProperty<Thickness> BorderThicknessProperty = AvaloniaProperty.Register<Border, Thickness>(nameof(BorderThickness), Thickness.Default);
        public static readonly Avalonia.StyledProperty<BuiltInUIElement> ChildProperty = AvaloniaProperty.Register<Border, BuiltInUIElement>(nameof(Child), null);
        public static readonly Avalonia.StyledProperty<CornerRadius> CornerRadiusProperty = AvaloniaProperty.Register<Border, CornerRadius>(nameof(CornerRadius), CornerRadius.Default);
        public static readonly Avalonia.StyledProperty<Thickness> PaddingProperty = AvaloniaProperty.Register<Border, Thickness>(nameof(Padding), Thickness.Default);
        
        public Brush Background
        {
            get => (Brush) GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }
        IBrush IBorder.Background
        {
            get => Background;
            set => Background = (Brush) value;
        }
        
        public BackgroundSizing BackgroundSizing
        {
            get => (BackgroundSizing) GetValue(BackgroundSizingProperty);
            set => SetValue(BackgroundSizingProperty, value);
        }
        
        public Brush BorderBrush
        {
            get => (Brush) GetValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }
        IBrush IBorder.BorderBrush
        {
            get => BorderBrush;
            set => BorderBrush = (Brush) value;
        }
        
        public Thickness BorderThickness
        {
            get => (Thickness) GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }
        
        public BuiltInUIElement Child
        {
            get => (BuiltInUIElement) GetValue(ChildProperty);
            set => SetValue(ChildProperty, value);
        }
        IUIElement IBorder.Child
        {
            get => Child;
            set => Child = (BuiltInUIElement) value;
        }
        
        public CornerRadius CornerRadius
        {
            get => (CornerRadius) GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        
        public Thickness Padding
        {
            get => (Thickness) GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }
    }
}

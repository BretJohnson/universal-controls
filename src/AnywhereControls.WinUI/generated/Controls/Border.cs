// This file is generated from IBorder.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.WinUI.Media;
using Microsoft.StandardUI.Controls;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace Microsoft.StandardUI.WinUI.Controls
{
    public class Border : BuiltInUIElement, IBorder
    {
        public static readonly DependencyProperty BackgroundProperty = PropertyUtils.Register(nameof(Background), typeof(Brush), typeof(Border), null);
        public static readonly DependencyProperty BackgroundSizingProperty = PropertyUtils.Register(nameof(BackgroundSizing), typeof(BackgroundSizing), typeof(Border), BackgroundSizing.InnerBorderEdge);
        public static readonly DependencyProperty BorderBrushProperty = PropertyUtils.Register(nameof(BorderBrush), typeof(Brush), typeof(Border), null);
        public static readonly DependencyProperty BorderThicknessProperty = PropertyUtils.Register(nameof(BorderThickness), typeof(Thickness), typeof(Border), Thickness.Default);
        public static readonly DependencyProperty ChildProperty = PropertyUtils.Register(nameof(Child), typeof(BuiltInUIElement), typeof(Border), null);
        public static readonly DependencyProperty CornerRadiusProperty = PropertyUtils.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(Border), CornerRadius.Default);
        public static readonly DependencyProperty PaddingProperty = PropertyUtils.Register(nameof(Padding), typeof(Thickness), typeof(Border), Thickness.Default);
        
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

// This file is generated from IGradientBrush.cs. Update the source file to change its contents.

using UniversalUI;
using UniversalUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class GradientBrush : Brush, IGradientBrush
    {
        public static readonly Avalonia.StyledProperty<UICollection<IGradientStop>> GradientStopsProperty = AvaloniaProperty.Register<GradientBrush, UICollection<IGradientStop>>(nameof(GradientStops), null);
        public static readonly Avalonia.StyledProperty<BrushMappingMode> MappingModeProperty = AvaloniaProperty.Register<GradientBrush, BrushMappingMode>(nameof(MappingMode), BrushMappingMode.RelativeToBoundingBox);
        public static readonly Avalonia.StyledProperty<GradientSpreadMethod> SpreadMethodProperty = AvaloniaProperty.Register<GradientBrush, GradientSpreadMethod>(nameof(SpreadMethod), GradientSpreadMethod.Pad);
        
        private UICollection<IGradientStop> _gradientStops;
        
        public GradientBrush()
        {
            _gradientStops = new UICollection<IGradientStop>(this);
            SetValue(GradientStopsProperty, _gradientStops);
        }
        
        public UICollection<IGradientStop> GradientStops => _gradientStops;
        IUICollection<IGradientStop> IGradientBrush.GradientStops => GradientStops;
        
        public BrushMappingMode MappingMode
        {
            get => (BrushMappingMode) GetValue(MappingModeProperty);
            set => SetValue(MappingModeProperty, value);
        }
        
        public GradientSpreadMethod SpreadMethod
        {
            get => (GradientSpreadMethod) GetValue(SpreadMethodProperty);
            set => SetValue(SpreadMethodProperty, value);
        }
    }
}

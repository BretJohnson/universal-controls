// This file is generated from IGradientBrush.cs. Update the source file to change its contents.

using UniversalUI.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Media
{
    public class GradientBrush : Brush, IGradientBrush
    {
        public static readonly DependencyProperty GradientStopsProperty = PropertyUtils.Register(nameof(GradientStops), typeof(UICollection<IGradientStop>), typeof(GradientBrush), null);
        public static readonly DependencyProperty MappingModeProperty = PropertyUtils.Register(nameof(MappingMode), typeof(BrushMappingMode), typeof(GradientBrush), BrushMappingMode.RelativeToBoundingBox);
        public static readonly DependencyProperty SpreadMethodProperty = PropertyUtils.Register(nameof(SpreadMethod), typeof(GradientSpreadMethod), typeof(GradientBrush), GradientSpreadMethod.Pad);
        
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

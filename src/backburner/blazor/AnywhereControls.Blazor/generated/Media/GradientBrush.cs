// This file is generated from IGradientBrush.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using UniversalUI.Media;
using Microsoft.AspNetCore.Components;

namespace AnywhereControls.Blazor.Media
{
    public class GradientBrush : Brush, IGradientBrush
    {
        public static readonly UIProperty GradientStopsProperty = new UIProperty(nameof(GradientStops), null, readOnly:true);
        public static readonly UIProperty MappingModeProperty = new UIProperty(nameof(MappingMode), BrushMappingMode.RelativeToBoundingBox);
        public static readonly UIProperty SpreadMethodProperty = new UIProperty(nameof(SpreadMethod), GradientSpreadMethod.Pad);
        
        private UICollection<IGradientStop> _gradientStops;
        
        public GradientBrush()
        {
            _gradientStops = new UICollection<IGradientStop>(this);
            SetValue(GradientStopsProperty, _gradientStops);
        }
        
        public IUICollection<IGradientStop> GradientStops => (UICollection<IGradientStop>) GetNonNullValue(GradientStopsProperty);
        
        [Parameter]
        public BrushMappingMode MappingMode
        {
            get => (BrushMappingMode) GetNonNullValue(MappingModeProperty);
            set => SetValue(MappingModeProperty, value);
        }
        
        [Parameter]
        public GradientSpreadMethod SpreadMethod
        {
            get => (GradientSpreadMethod) GetNonNullValue(SpreadMethodProperty);
            set => SetValue(SpreadMethodProperty, value);
        }
    }
}

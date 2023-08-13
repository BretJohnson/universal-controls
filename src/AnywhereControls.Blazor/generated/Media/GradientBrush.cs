// This file is generated from IGradientBrush.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.StandardUI.Media;
using Microsoft.AspNetCore.Components;

namespace Microsoft.StandardUI.Blazor.Media
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

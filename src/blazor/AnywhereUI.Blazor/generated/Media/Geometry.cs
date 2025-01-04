// This file is generated from IGeometry.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using AnywhereUI.Media;
using Microsoft.AspNetCore.Components;

namespace AnywhereUI.Blazor.Media
{
    public class Geometry : UIObject, IGeometry
    {
        public static readonly UIProperty StandardFlatteningToleranceProperty = new UIProperty(nameof(StandardFlatteningTolerance), 0.25);
        public static readonly UIProperty TransformProperty = new UIProperty(nameof(Transform), null);
        
        [Parameter]
        public double StandardFlatteningTolerance
        {
            get => (double) GetNonNullValue(StandardFlatteningToleranceProperty);
            set => SetValue(StandardFlatteningToleranceProperty, value);
        }
        
        [Parameter]
        public ITransform Transform
        {
            get => (Transform) GetNonNullValue(TransformProperty);
            set => SetValue(TransformProperty, value);
        }
    }
}

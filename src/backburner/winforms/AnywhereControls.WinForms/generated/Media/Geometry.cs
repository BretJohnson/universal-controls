// This file is generated from IGeometry.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using UniversalUI.Media;

namespace AnywhereControls.WinForms.Media
{
    public class Geometry : StandardUIObject, IGeometry
    {
        public static readonly UIProperty StandardFlatteningToleranceProperty = new UIProperty(nameof(StandardFlatteningTolerance), 0.25);
        public static readonly UIProperty TransformProperty = new UIProperty(nameof(Transform), null);
        
        public double StandardFlatteningTolerance
        {
            get => (double) GetNonNullValue(StandardFlatteningToleranceProperty);
            set => SetValue(StandardFlatteningToleranceProperty, value);
        }
        
        public ITransform Transform
        {
            get => (Transform) GetNonNullValue(TransformProperty);
            set => SetValue(TransformProperty, value);
        }
    }
}

// This file is generated from IGeometry.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class Geometry : UIObject, IGeometry
    {
        public static readonly Avalonia.StyledProperty<double> StandardFlatteningToleranceProperty = AvaloniaProperty.Register<Geometry, double>(nameof(StandardFlatteningTolerance), 0.25);
        public static readonly Avalonia.StyledProperty<Transform> TransformProperty = AvaloniaProperty.Register<Geometry, Transform>(nameof(Transform), null);
        
        public double StandardFlatteningTolerance
        {
            get => (double) GetValue(StandardFlatteningToleranceProperty);
            set => SetValue(StandardFlatteningToleranceProperty, value);
        }
        
        public Transform Transform
        {
            get => (Transform) GetValue(TransformProperty);
            set => SetValue(TransformProperty, value);
        }
        ITransform IGeometry.Transform
        {
            get => Transform;
            set => Transform = (Transform) value;
        }
    }
}

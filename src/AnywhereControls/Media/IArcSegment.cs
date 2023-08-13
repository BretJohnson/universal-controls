using System.ComponentModel;
using Microsoft.Maui.Graphics;

namespace AnywhereControls.Media
{
    [UIModelObject]
    public interface IArcSegment : IPathSegment
    {
        Point Point { get; set; }

        Size Size { get; set; }

        [DefaultValue(0.0)]
        double RotationAngle { get; set; }

        [DefaultValue(false)]
        bool IsLargeArc { get; set; }

        [DefaultValue(SweepDirection.Counterclockwise)]
        SweepDirection SweepDirection { get; set; }
    }
}

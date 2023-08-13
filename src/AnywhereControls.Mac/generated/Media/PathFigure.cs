// This file is generated from IPathFigure.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using Microsoft.Maui.Graphics;
using AnywhereControls.Media;

namespace AnywhereControls.Mac.Media
{
    public class PathFigure : StandardUIObject, IPathFigure
    {
        public static readonly UIProperty SegmentsProperty = new UIProperty(nameof(Segments), null, readOnly:true);
        public static readonly UIProperty StartPointProperty = new UIProperty(nameof(StartPoint), default(Point));
        public static readonly UIProperty IsClosedProperty = new UIProperty(nameof(IsClosed), false);
        public static readonly UIProperty IsFilledProperty = new UIProperty(nameof(IsFilled), true);
        
        private UICollection<IPathSegment> _segments;
        
        public PathFigure()
        {
            _segments = new UICollection<IPathSegment>(this);
            SetValue(SegmentsProperty, _segments);
        }
        
        public IUICollection<IPathSegment> Segments => (UICollection<IPathSegment>) GetNonNullValue(SegmentsProperty);
        
        public Point StartPoint
        {
            get => (Point) GetNonNullValue(StartPointProperty);
            set => SetValue(StartPointProperty, value);
        }
        
        public bool IsClosed
        {
            get => (bool) GetNonNullValue(IsClosedProperty);
            set => SetValue(IsClosedProperty, value);
        }
        
        public bool IsFilled
        {
            get => (bool) GetNonNullValue(IsFilledProperty);
            set => SetValue(IsFilledProperty, value);
        }
    }
}

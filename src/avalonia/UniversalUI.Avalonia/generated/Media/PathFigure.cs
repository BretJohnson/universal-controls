// This file is generated from IPathFigure.cs. Update the source file to change its contents.

using UniversalUI;
using UniversalUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class PathFigure : UIObject, IPathFigure
    {
        public static readonly Avalonia.StyledProperty<UICollection<IPathSegment>> SegmentsProperty = AvaloniaProperty.Register<PathFigure, UICollection<IPathSegment>>(nameof(Segments), null);
        public static readonly Avalonia.StyledProperty<Point> StartPointProperty = AvaloniaProperty.Register<PathFigure, Point>(nameof(StartPoint), default(Point));
        public static readonly Avalonia.StyledProperty<bool> IsClosedProperty = AvaloniaProperty.Register<PathFigure, bool>(nameof(IsClosed), false);
        public static readonly Avalonia.StyledProperty<bool> IsFilledProperty = AvaloniaProperty.Register<PathFigure, bool>(nameof(IsFilled), true);
        
        private UICollection<IPathSegment> _segments;
        
        public PathFigure()
        {
            _segments = new UICollection<IPathSegment>(this);
            SetValue(SegmentsProperty, _segments);
        }
        
        public UICollection<IPathSegment> Segments => _segments;
        IUICollection<IPathSegment> IPathFigure.Segments => Segments;
        
        public Point StartPoint
        {
            get => (Point) GetValue(StartPointProperty);
            set => SetValue(StartPointProperty, value);
        }
        
        public bool IsClosed
        {
            get => (bool) GetValue(IsClosedProperty);
            set => SetValue(IsClosedProperty, value);
        }
        
        public bool IsFilled
        {
            get => (bool) GetValue(IsFilledProperty);
            set => SetValue(IsFilledProperty, value);
        }
    }
}

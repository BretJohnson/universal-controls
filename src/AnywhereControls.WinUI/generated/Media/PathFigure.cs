// This file is generated from IPathFigure.cs. Update the source file to change its contents.

using CommonUI;
using AnywhereControls.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Media
{
    public class PathFigure : StandardUIObject, IPathFigure
    {
        public static readonly DependencyProperty SegmentsProperty = PropertyUtils.Register(nameof(Segments), typeof(UICollection<IPathSegment>), typeof(PathFigure), null);
        public static readonly DependencyProperty StartPointProperty = PropertyUtils.Register(nameof(StartPoint), typeof(PointWinUI), typeof(PathFigure), default(Point));
        public static readonly DependencyProperty IsClosedProperty = PropertyUtils.Register(nameof(IsClosed), typeof(bool), typeof(PathFigure), false);
        public static readonly DependencyProperty IsFilledProperty = PropertyUtils.Register(nameof(IsFilled), typeof(bool), typeof(PathFigure), true);
        
        private UICollection<IPathSegment> _segments;
        
        public PathFigure()
        {
            _segments = new UICollection<IPathSegment>(this);
            SetValue(SegmentsProperty, _segments);
        }
        
        public UICollection<IPathSegment> Segments => _segments;
        IUICollection<IPathSegment> IPathFigure.Segments => Segments;
        
        public PointWinUI StartPoint
        {
            get => (PointWinUI) GetValue(StartPointProperty);
            set => SetValue(StartPointProperty, value);
        }
        Point IPathFigure.StartPoint
        {
            get => StartPoint.Point;
            set => StartPoint = new PointWinUI(value);
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

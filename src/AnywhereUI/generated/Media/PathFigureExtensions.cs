// This file is generated from IPathFigure.cs. Update the source file to change its contents.

namespace AnywhereUI.Media
{
    public static class PathFigureExtensions
    {
        public static T Segments<T>(this T pathFigure, params IPathSegment[] value) where T : IPathFigure
        {
            pathFigure.Segments.Set(value);
            return pathFigure;
        }
        
        public static T StartPoint<T>(this T pathFigure, Point value) where T : IPathFigure
        {
            pathFigure.StartPoint = value;
            return pathFigure;
        }
        
        public static T IsClosed<T>(this T pathFigure, bool value) where T : IPathFigure
        {
            pathFigure.IsClosed = value;
            return pathFigure;
        }
        
        public static T IsFilled<T>(this T pathFigure, bool value) where T : IPathFigure
        {
            pathFigure.IsFilled = value;
            return pathFigure;
        }
    }
}

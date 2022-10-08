using System;
using System.Collections.Generic;
using Microsoft.StandardUI.Controls;
using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Shapes;

namespace Microsoft.StandardUI
{
    public class UnintializedStandardUIFactory : IStandardUIFactory
    {
        public static UnintializedStandardUIFactory Instance = new UnintializedStandardUIFactory();

        /*** UI Elements ***/

        public ICanvas CreateCanvas() => throw CreateInitNotCalledException();
        public ICanvasAttached CanvasAttachedInstance => throw CreateInitNotCalledException();
        public IStackPanel CreateStackPanel() => throw CreateInitNotCalledException();
        public IVerticalStack CreateVerticalStack() => throw CreateInitNotCalledException();
        public IHorizontalStack CreateHorizontalStack() => throw CreateInitNotCalledException();
        public IGrid CreateGrid() => throw CreateInitNotCalledException();
        public IRowDefinition CreateRowDefinition() => throw CreateInitNotCalledException();
        public IColumnDefinition CreateColumnDefinition() => throw CreateInitNotCalledException();
        public IGridAttached GridAttachedInstance => throw CreateInitNotCalledException();

        public IEllipse CreateEllipse() => throw CreateInitNotCalledException();
        public ILine CreateLine() => throw CreateInitNotCalledException();
        public IPath CreatePath() => throw CreateInitNotCalledException();
        public IPolygon CreatePolygon() => throw CreateInitNotCalledException();
        public IPolyline CreatePolyline() => throw CreateInitNotCalledException();
        public IRectangle CreateRectangle() => throw CreateInitNotCalledException();

        public ITextBlock CreateTextBlock() => throw CreateInitNotCalledException();

        /*** Media objects ***/

        public ISolidColorBrush CreateSolidColorBrush() => throw CreateInitNotCalledException();
        public ILinearGradientBrush CreateLinearGradientBrush() => throw CreateInitNotCalledException();
        public IRadialGradientBrush CreateRadialGradientBrush() => throw CreateInitNotCalledException();

        public ILineSegment CreateLineSegment() => throw CreateInitNotCalledException();
        public IPolyLineSegment CreatePolyLineSegment() => throw CreateInitNotCalledException();
        public IBezierSegment CreateBezierSegment() => throw CreateInitNotCalledException();
        public IPolyBezierSegment CreatePolyBezierSegment() => throw CreateInitNotCalledException();
        public IQuadraticBezierSegment CreateQuadraticBezierSegment() => throw CreateInitNotCalledException();
        public IPolyQuadraticBezierSegment CreatePolyQuadraticBezierSegment() => throw CreateInitNotCalledException();
        public IArcSegment CreateArcSegment() => throw CreateInitNotCalledException();
        public IPathGeometry CreatePathGeometry() => throw CreateInitNotCalledException();
        public IPathFigure CreatePathFigure() => throw CreateInitNotCalledException();

        private Exception CreateInitNotCalledException() => new InvalidOperationException("The Standard UI host framework hasn't been initialized: " + Environment.StackTrace);
    }
}

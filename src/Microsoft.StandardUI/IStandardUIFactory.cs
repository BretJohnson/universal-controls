using System.Collections.Generic;
using Microsoft.StandardUI.Controls;
using Microsoft.StandardUI.Media;
using Microsoft.StandardUI.Shapes;

namespace Microsoft.StandardUI
{
    public interface IStandardUIFactory
    {
        /*** UI Elements ***/

        ICanvas CreateCanvas();
        ICanvasAttached CanvasAttachedInstance { get; }
        IStackPanel CreateStackPanel();
        IVerticalStack CreateVerticalStack();
        IHorizontalStack CreateHorizontalStack();
        IGrid CreateGrid();
        IRowDefinition CreateRowDefinition();
        IColumnDefinition CreateColumnDefinition();
        IGridAttached GridAttachedInstance { get; }

        IEllipse CreateEllipse();
        ILine CreateLine();
        IPath CreatePath();
        IPolygon CreatePolygon();
        IPolyline CreatePolyline();
        IRectangle CreateRectangle();

        ITextBlock CreateTextBlock();

        /*** Media objects ***/

        ISolidColorBrush CreateSolidColorBrush();
        ILinearGradientBrush CreateLinearGradientBrush();
        IRadialGradientBrush CreateRadialGradientBrush();

        ILineSegment CreateLineSegment();
        IPolyLineSegment CreatePolyLineSegment();
        IBezierSegment CreateBezierSegment();
        IPolyBezierSegment CreatePolyBezierSegment();
        IQuadraticBezierSegment CreateQuadraticBezierSegment();
        IPolyQuadraticBezierSegment CreatePolyQuadraticBezierSegment();
        IArcSegment CreateArcSegment();
        IPathGeometry CreatePathGeometry();
        IPathFigure CreatePathFigure();
    }
}

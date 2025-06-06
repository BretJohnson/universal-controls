// This file is generated from IPathGeometry.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using UniversalUI.Media;
using Microsoft.AspNetCore.Components;

namespace AnywhereControls.Blazor.Media
{
    public class PathGeometry : Geometry, IPathGeometry
    {
        public static readonly UIProperty FiguresProperty = new UIProperty(nameof(Figures), null, readOnly:true);
        public static readonly UIProperty FillRuleProperty = new UIProperty(nameof(FillRule), FillRule.EvenOdd);
        
        private UICollection<IPathFigure> _figures;
        
        public PathGeometry()
        {
            _figures = new UICollection<IPathFigure>(this);
            SetValue(FiguresProperty, _figures);
        }
        
        public IUICollection<IPathFigure> Figures => (UICollection<IPathFigure>) GetNonNullValue(FiguresProperty);
        
        [Parameter]
        public FillRule FillRule
        {
            get => (FillRule) GetNonNullValue(FillRuleProperty);
            set => SetValue(FillRuleProperty, value);
        }
    }
}

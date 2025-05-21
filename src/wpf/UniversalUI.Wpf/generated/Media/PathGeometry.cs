// This file is generated from IPathGeometry.cs. Update the source file to change its contents.

using UniversalUI.Media;
using DependencyProperty = System.Windows.DependencyProperty;

namespace UniversalUI.Wpf.Media
{
    public class PathGeometry : Geometry, IPathGeometry
    {
        public static readonly DependencyProperty FiguresProperty = PropertyUtils.Register(nameof(Figures), typeof(UICollection<IPathFigure>), typeof(PathGeometry), null);
        public static readonly DependencyProperty FillRuleProperty = PropertyUtils.Register(nameof(FillRule), typeof(FillRule), typeof(PathGeometry), FillRule.EvenOdd);
        
        private UICollection<IPathFigure> _figures;
        
        public PathGeometry()
        {
            _figures = new UICollection<IPathFigure>(this);
            SetValue(FiguresProperty, _figures);
        }
        
        public UICollection<IPathFigure> Figures => _figures;
        IUICollection<IPathFigure> IPathGeometry.Figures => Figures;
        
        public FillRule FillRule
        {
            get => (FillRule) GetValue(FillRuleProperty);
            set => SetValue(FillRuleProperty, value);
        }
    }
}

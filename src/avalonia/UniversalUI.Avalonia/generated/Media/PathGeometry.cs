// This file is generated from IPathGeometry.cs. Update the source file to change its contents.

using UniversalUI;
using UniversalUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Media
{
    public class PathGeometry : Geometry, IPathGeometry
    {
        public static readonly Avalonia.StyledProperty<UICollection<IPathFigure>> FiguresProperty = AvaloniaProperty.Register<PathGeometry, UICollection<IPathFigure>>(nameof(Figures), null);
        public static readonly Avalonia.StyledProperty<FillRule> FillRuleProperty = AvaloniaProperty.Register<PathGeometry, FillRule>(nameof(FillRule), FillRule.EvenOdd);
        
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

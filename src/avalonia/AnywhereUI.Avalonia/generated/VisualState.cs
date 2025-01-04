// This file is generated from IVisualState.cs. Update the source file to change its contents.

using AnywhereUI;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia
{
    public class VisualState : UIObject, IVisualState
    {
        public static readonly Avalonia.StyledProperty<string> NameProperty = AvaloniaProperty.Register<VisualState, string>(nameof(Name), "");
        public static readonly Avalonia.StyledProperty<UICollection<ISetter>> SettersProperty = AvaloniaProperty.Register<VisualState, UICollection<ISetter>>(nameof(Setters), null);
        
        private UICollection<ISetter> _setters;
        
        public VisualState()
        {
            _setters = new UICollection<ISetter>(this);
            SetValue(SettersProperty, _setters);
        }
        
        public string Name => (string) GetValue(NameProperty);
        
        public UICollection<ISetter> Setters => _setters;
        IUICollection<ISetter> IVisualState.Setters => Setters;
    }
}

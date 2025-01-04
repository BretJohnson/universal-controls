// This file is generated from IVisualStateGroup.cs. Update the source file to change its contents.

using AnywhereUI;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia
{
    public class VisualStateGroup : UIObject, IVisualStateGroup
    {
        public static readonly Avalonia.StyledProperty<VisualState> CurrentStateProperty = AvaloniaProperty.Register<VisualStateGroup, VisualState>(nameof(CurrentState), null);
        public static readonly Avalonia.StyledProperty<string> NameProperty = AvaloniaProperty.Register<VisualStateGroup, string>(nameof(Name), "");
        public static readonly Avalonia.StyledProperty<UICollection<IVisualState>> StatesProperty = AvaloniaProperty.Register<VisualStateGroup, UICollection<IVisualState>>(nameof(States), null);
        
        private UICollection<IVisualState> _states;
        
        public VisualStateGroup()
        {
            _states = new UICollection<IVisualState>(this);
            SetValue(StatesProperty, _states);
        }
        
        public VisualState CurrentState => (VisualState) GetValue(CurrentStateProperty);
        IVisualState IVisualStateGroup.CurrentState => CurrentState;
        
        public string Name => (string) GetValue(NameProperty);
        
        public UICollection<IVisualState> States => _states;
        IUICollection<IVisualState> IVisualStateGroup.States => States;
    }
}

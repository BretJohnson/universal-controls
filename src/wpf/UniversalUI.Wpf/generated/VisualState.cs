// This file is generated from IVisualState.cs. Update the source file to change its contents.

using DependencyProperty = System.Windows.DependencyProperty;

namespace UniversalUI.Wpf
{
    public class VisualState : UIObject, IVisualState
    {
        public static readonly DependencyProperty NameProperty = PropertyUtils.Register(nameof(Name), typeof(string), typeof(VisualState), "");
        public static readonly DependencyProperty SettersProperty = PropertyUtils.Register(nameof(Setters), typeof(UICollection<ISetter>), typeof(VisualState), null);
        
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

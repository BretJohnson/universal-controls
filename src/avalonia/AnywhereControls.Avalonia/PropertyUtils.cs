using Avalonia.Controls;
using Avalonia;

namespace AnywhereControlsAvalonia
{
    public static class PropertyUtils
    {
        public static StyledProperty<TValue> Register<TOwner, TValue>(string propertyName, TValue defaultValue) where TOwner : AvaloniaObject
            => AvaloniaProperty.Register<TOwner, TValue>(propertyName, defaultValue);

        public static StyledProperty<TValue> RegisterAttached<TOwner, TValue>(string propertyName, TValue defaultValue)
            => AvaloniaProperty.RegisterAttached<TOwner, Control, TValue>(propertyName, defaultValue);
    }
}

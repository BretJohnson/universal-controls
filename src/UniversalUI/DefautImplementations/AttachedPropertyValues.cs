using System.Runtime.CompilerServices;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace UniversalUI.DefaultImplementations
{
    public class AttachedPropertyValues
    {
        private readonly AttachedUIProperty _property;

#pragma warning disable CS0649 // Field is never assigned to, and will always have its default value null
        private readonly ConditionalWeakTable<object, object?> _objectToValue;
#pragma warning restore CS0649 

        public AttachedPropertyValues(AttachedUIProperty property)
        {
            _property = property;
        }

        public object? GetValue(object obj)
        {
            if (!_objectToValue.TryGetValue(obj, out object? value))
                return _property.DefaultValue;
            return value;
        }

        public object? ReadLocalValue(object obj)
        {
            if (!_objectToValue.TryGetValue(obj, out object? value))
                return UnsetValue.Instance;
            return value;
        }

        public void SetValue(object obj, object? value)
        {
            // Do a Remove/Add as the AddOrUpdate method is only available in .NET Core and above
            _objectToValue.Remove(obj);
            _objectToValue.Add(obj, value);
        }

        public void ClearValue(object obj)
        {
            _objectToValue.Remove(obj);
        }
    }
}

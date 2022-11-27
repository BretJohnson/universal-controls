using System;
using System.Reflection;

namespace Microsoft.ComponentModelEx.Tooling
{
    public class UIExample
    {
        private string? _description;
        private MethodInfo _methodInfo;

        public UIExample(string? description, MethodInfo methodInfo)
        {
            _description = description;
            _methodInfo = methodInfo;
        }

        public UIExample(UIExampleAttribute uiExampleAttribute, MethodInfo methodInfo)
        {
            _description = uiExampleAttribute.Description;
            _methodInfo = methodInfo;
        }

        public object Create()
        {
            if (_methodInfo.GetParameters().Length != 0)
                throw new InvalidOperationException($"Examples that take parameters aren't yet supported: {GetMethodDisplayName()}");

            return _methodInfo.Invoke(null, null);
        }

        /// <summary>
        /// Get a user friendly display name for the example method, suitable for error
        /// messages.
        /// </summary>
        /// <returns>user friendly name of example method</returns>
        public string GetMethodDisplayName()
        {
            return $"{_methodInfo.DeclaringType.Name}.{_methodInfo.Name}";
        }

        public string? Description => _description;

        public MethodInfo MethodInfo => _methodInfo;
    }
}

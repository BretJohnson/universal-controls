using System;

namespace AnywhereControls
{
    public static class HostEnvironment
    {
        public static IHostFramework HostFramework { get; private set; } = UnintializedHostFramework.Instance;
        public static bool IsInitialized { get; private set; }

        public static void Init(IHostFramework hostFramework)
        {
            if (!object.ReferenceEquals(HostFramework, UnintializedHostFramework.Instance))
                throw new InvalidOperationException($"HostEnvironment.Init already called. Current host framework is of type {HostFramework.GetType()}");

            HostFramework = hostFramework;

            Factory = hostFramework.Factory;

            IsInitialized = true;
        }

        public static IVisualFramework VisualFramework => HostFramework.VisualFramework;

        /// <summary>
        /// Cache the factory here as that's slightly more efficient than always fetching it on demand.
        /// </summary>
        public static IAnywhereControlsUIFactory Factory { get; private set; } = new UnintializedAnywhereControlsUIFactory();
    }
}

namespace AnywhereControls
{
    public class UnsetValue
    {
        private UnsetValue()
        {
        }

        /// <summary>
        /// This is a sentinal value, returned (instead of null) from ReadLocalValue when
        /// a property doesn't exist.
        /// </summary>
        public static object Instance = new UnsetValue();
    }

    public interface IUIProperty
    {
    }
}

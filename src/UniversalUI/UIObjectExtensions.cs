namespace AnywhereUI
{
    public static class UIObjectExtensions
    {
        public static T Assign<T>(this T uiObject, out T variable) where T : IUIObject
        {
            variable = uiObject;
            return uiObject;
        }
    }
}

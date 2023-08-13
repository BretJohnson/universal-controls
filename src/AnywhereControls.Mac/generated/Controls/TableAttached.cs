// This file is generated from ITable.cs. Update the source file to change its contents.

using AnywhereControls.Controls;

namespace AnywhereControls.Mac.Controls
{
    public class TableAttached : ITableAttached
    {
        public static TableAttached Instance = new TableAttached();
        
        public int GetRowSpan(IUIElement element) => Table.GetRowSpan((StandardUIElement) element);
        public void SetRowSpan(IUIElement element, int value) => Table.SetRowSpan((StandardUIElement) element, value);
        
        public int GetColumnSpan(IUIElement element) => Table.GetColumnSpan((StandardUIElement) element);
        public void SetColumnSpan(IUIElement element, int value) => Table.SetColumnSpan((StandardUIElement) element, value);
    }
}

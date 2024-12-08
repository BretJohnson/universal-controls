// This file is generated from IGrid.cs. Update the source file to change its contents.

using AnywhereUI.Controls;

namespace AnywhereControls.Mac.Controls
{
    public class GridAttached : IGridAttached
    {
        public static GridAttached Instance = new GridAttached();
        
        public int GetRow(IUIElement element) => Grid.GetRow((StandardUIElement) element);
        public void SetRow(IUIElement element, int value) => Grid.SetRow((StandardUIElement) element, value);
        
        public int GetColumn(IUIElement element) => Grid.GetColumn((StandardUIElement) element);
        public void SetColumn(IUIElement element, int value) => Grid.SetColumn((StandardUIElement) element, value);
        
        public int GetRowSpan(IUIElement element) => Grid.GetRowSpan((StandardUIElement) element);
        public void SetRowSpan(IUIElement element, int value) => Grid.SetRowSpan((StandardUIElement) element, value);
        
        public int GetColumnSpan(IUIElement element) => Grid.GetColumnSpan((StandardUIElement) element);
        public void SetColumnSpan(IUIElement element, int value) => Grid.SetColumnSpan((StandardUIElement) element, value);
    }
}

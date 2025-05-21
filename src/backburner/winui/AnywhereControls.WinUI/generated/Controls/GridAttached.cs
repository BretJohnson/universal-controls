// This file is generated from IGrid.cs. Update the source file to change its contents.

using UniversalUI.Controls;

namespace AnywhereControls.WinUI.Controls
{
    public class GridAttached : IGridAttached
    {
        public static GridAttached Instance = new GridAttached();
        
        public int GetRow(IUIElement element) => Grid.GetRow(element.ToFrameworkElement());
        public void SetRow(IUIElement element, int value) => Grid.SetRow(element.ToFrameworkElement(), value);
        
        public int GetColumn(IUIElement element) => Grid.GetColumn(element.ToFrameworkElement());
        public void SetColumn(IUIElement element, int value) => Grid.SetColumn(element.ToFrameworkElement(), value);
        
        public int GetRowSpan(IUIElement element) => Grid.GetRowSpan(element.ToFrameworkElement());
        public void SetRowSpan(IUIElement element, int value) => Grid.SetRowSpan(element.ToFrameworkElement(), value);
        
        public int GetColumnSpan(IUIElement element) => Grid.GetColumnSpan(element.ToFrameworkElement());
        public void SetColumnSpan(IUIElement element, int value) => Grid.SetColumnSpan(element.ToFrameworkElement(), value);
    }
}

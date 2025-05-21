// This file is generated from IGrid.cs. Update the source file to change its contents.

using UniversalUI.Controls;

namespace UniversalUI.Wpf.Controls
{
    public class GridAttached : IGridAttached
    {
        public static GridAttached Instance = new GridAttached();
        
        public int GetRow(IUIElement element) => Grid.GetRow(element.ToWpfUIElement());
        public void SetRow(IUIElement element, int value) => Grid.SetRow(element.ToWpfUIElement(), value);
        
        public int GetColumn(IUIElement element) => Grid.GetColumn(element.ToWpfUIElement());
        public void SetColumn(IUIElement element, int value) => Grid.SetColumn(element.ToWpfUIElement(), value);
        
        public int GetRowSpan(IUIElement element) => Grid.GetRowSpan(element.ToWpfUIElement());
        public void SetRowSpan(IUIElement element, int value) => Grid.SetRowSpan(element.ToWpfUIElement(), value);
        
        public int GetColumnSpan(IUIElement element) => Grid.GetColumnSpan(element.ToWpfUIElement());
        public void SetColumnSpan(IUIElement element, int value) => Grid.SetColumnSpan(element.ToWpfUIElement(), value);
    }
}

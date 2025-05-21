// This file is generated from IGrid.cs. Update the source file to change its contents.

using UniversalUI.Controls;
using UniversalUI;

namespace AnywhereControlsAvalonia.Controls
{
    public class GridAttached : IGridAttached
    {
        public static GridAttached Instance = new GridAttached();
        
        public int GetRow(IUIElement element) => Grid.GetRow(element.ToAvaloniaControl());
        public void SetRow(IUIElement element, int value) => Grid.SetRow(element.ToAvaloniaControl(), value);
        
        public int GetColumn(IUIElement element) => Grid.GetColumn(element.ToAvaloniaControl());
        public void SetColumn(IUIElement element, int value) => Grid.SetColumn(element.ToAvaloniaControl(), value);
        
        public int GetRowSpan(IUIElement element) => Grid.GetRowSpan(element.ToAvaloniaControl());
        public void SetRowSpan(IUIElement element, int value) => Grid.SetRowSpan(element.ToAvaloniaControl(), value);
        
        public int GetColumnSpan(IUIElement element) => Grid.GetColumnSpan(element.ToAvaloniaControl());
        public void SetColumnSpan(IUIElement element, int value) => Grid.SetColumnSpan(element.ToAvaloniaControl(), value);
    }
}

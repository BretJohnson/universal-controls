// This file is generated from IGrid.cs. Update the source file to change its contents.

using AnywhereUI.Controls;

namespace AnywhereUI.Blazor.Controls
{
    public class GridAttached : IGridAttached
    {
        public static GridAttached Instance = new GridAttached();
        
        public int GetRow(IUIElement element) => Grid.GetRow((Microsoft.AspNetCore.Components.ComponentBase) element);
        public void SetRow(IUIElement element, int value) => Grid.SetRow((Microsoft.AspNetCore.Components.ComponentBase) element, value);
        
        public int GetColumn(IUIElement element) => Grid.GetColumn((Microsoft.AspNetCore.Components.ComponentBase) element);
        public void SetColumn(IUIElement element, int value) => Grid.SetColumn((Microsoft.AspNetCore.Components.ComponentBase) element, value);
        
        public int GetRowSpan(IUIElement element) => Grid.GetRowSpan((Microsoft.AspNetCore.Components.ComponentBase) element);
        public void SetRowSpan(IUIElement element, int value) => Grid.SetRowSpan((Microsoft.AspNetCore.Components.ComponentBase) element, value);
        
        public int GetColumnSpan(IUIElement element) => Grid.GetColumnSpan((Microsoft.AspNetCore.Components.ComponentBase) element);
        public void SetColumnSpan(IUIElement element, int value) => Grid.SetColumnSpan((Microsoft.AspNetCore.Components.ComponentBase) element, value);
    }
}

// This file is generated from IGrid.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.WinForms.Controls
{
    public class GridAttached : IGridAttached
    {
        public static GridAttached Instance = new GridAttached();
        
        public int GetRow(IUIElement element) => Grid.GetRow((System.Windows.Forms.Control) element);
        public void SetRow(IUIElement element, int value) => Grid.SetRow((System.Windows.Forms.Control) element, value);
        
        public int GetColumn(IUIElement element) => Grid.GetColumn((System.Windows.Forms.Control) element);
        public void SetColumn(IUIElement element, int value) => Grid.SetColumn((System.Windows.Forms.Control) element, value);
        
        public int GetRowSpan(IUIElement element) => Grid.GetRowSpan((System.Windows.Forms.Control) element);
        public void SetRowSpan(IUIElement element, int value) => Grid.SetRowSpan((System.Windows.Forms.Control) element, value);
        
        public int GetColumnSpan(IUIElement element) => Grid.GetColumnSpan((System.Windows.Forms.Control) element);
        public void SetColumnSpan(IUIElement element, int value) => Grid.SetColumnSpan((System.Windows.Forms.Control) element, value);
    }
}

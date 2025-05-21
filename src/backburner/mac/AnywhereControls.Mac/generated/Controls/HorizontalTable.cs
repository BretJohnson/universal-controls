// This file is generated from IHorizontalTable.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using UniversalUI.Controls;

namespace AnywhereControls.Mac.Controls
{
    public class HorizontalTable : GridBase, IHorizontalTable
    {
        public static readonly UIProperty RowDefinitionsProperty = new UIProperty(nameof(RowDefinitions), null, readOnly:true);
        public static readonly UIProperty ColumnsProperty = new UIProperty(nameof(Columns), null, readOnly:true);
        
        private UICollection<IRowDefinition> _rowDefinitions;
        private UIElementCollection<Microsoft.StandardUI.Controls.IColumn> _columns;
        
        public HorizontalTable()
        {
            _rowDefinitions = new UICollection<IRowDefinition>(this);
            SetValue(RowDefinitionsProperty, _rowDefinitions);
            _columns = new UIElementCollection<Microsoft.StandardUI.Controls.IColumn>(this);
            SetValue(ColumnsProperty, _columns);
        }
        
        public UICollection<IRowDefinition> RowDefinitions => _rowDefinitions;
        IUICollection<IRowDefinition> IHorizontalTable.RowDefinitions => RowDefinitions;
        
        public UIElementCollection<Microsoft.StandardUI.Controls.IColumn> Columns => _columns;
        IUICollection<IColumn> IHorizontalTable.Columns => Columns.ToStandardUIElementCollection();
    }
}

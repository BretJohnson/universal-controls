// This file is generated from IGrid.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Controls;

namespace Microsoft.StandardUI.WinForms.Controls
{
    public class Grid : Panel, IGrid
    {
        public static readonly UIProperty ColumnDefinitionsProperty = new UIProperty(nameof(ColumnDefinitions), null, readOnly:true);
        public static readonly UIProperty RowDefinitionsProperty = new UIProperty(nameof(RowDefinitions), null, readOnly:true);
        public static readonly UIProperty ColumnSpacingProperty = new UIProperty(nameof(ColumnSpacing), 0.0);
        public static readonly UIProperty RowSpacingProperty = new UIProperty(nameof(RowSpacing), 0.0);
        public static readonly AttachedUIProperty RowProperty = new AttachedUIProperty("Row", 0);
        public static readonly AttachedUIProperty ColumnProperty = new AttachedUIProperty("Column", 0);
        public static readonly AttachedUIProperty RowSpanProperty = new AttachedUIProperty("RowSpan", 1);
        public static readonly AttachedUIProperty ColumnSpanProperty = new AttachedUIProperty("ColumnSpan", 1);
        
        public static int GetRow(System.Windows.Forms.Control element) => (int) AttachedPropertiesValues.GetValue(element, RowProperty);
        public static void SetRow(System.Windows.Forms.Control element, int value) => AttachedPropertiesValues.SetValue(element, RowProperty, value);
        
        public static int GetColumn(System.Windows.Forms.Control element) => (int) AttachedPropertiesValues.GetValue(element, ColumnProperty);
        public static void SetColumn(System.Windows.Forms.Control element, int value) => AttachedPropertiesValues.SetValue(element, ColumnProperty, value);
        
        public static int GetRowSpan(System.Windows.Forms.Control element) => (int) AttachedPropertiesValues.GetValue(element, RowSpanProperty);
        public static void SetRowSpan(System.Windows.Forms.Control element, int value) => AttachedPropertiesValues.SetValue(element, RowSpanProperty, value);
        
        public static int GetColumnSpan(System.Windows.Forms.Control element) => (int) AttachedPropertiesValues.GetValue(element, ColumnSpanProperty);
        public static void SetColumnSpan(System.Windows.Forms.Control element, int value) => AttachedPropertiesValues.SetValue(element, ColumnSpanProperty, value);
        
        private UICollection<IColumnDefinition> _columnDefinitions;
        private UICollection<IRowDefinition> _rowDefinitions;
        
        public Grid()
        {
            _columnDefinitions = new UICollection<IColumnDefinition>(this);
            SetValue(ColumnDefinitionsProperty, _columnDefinitions);
            _rowDefinitions = new UICollection<IRowDefinition>(this);
            SetValue(RowDefinitionsProperty, _rowDefinitions);
        }
        
        public IUICollection<IColumnDefinition> ColumnDefinitions => (UICollection<IColumnDefinition>) GetNonNullValue(ColumnDefinitionsProperty);
        
        public IUICollection<IRowDefinition> RowDefinitions => (UICollection<IRowDefinition>) GetNonNullValue(RowDefinitionsProperty);
        
        public double ColumnSpacing
        {
            get => (double) GetNonNullValue(ColumnSpacingProperty);
            set => SetValue(ColumnSpacingProperty, value);
        }
        
        public double RowSpacing
        {
            get => (double) GetNonNullValue(RowSpacingProperty);
            set => SetValue(RowSpacingProperty, value);
        }
        
        protected override Size MeasureOverride(double widthConstraint, double heightConstraint) =>
            GridLayoutManager.Instance.MeasureOverride(this, widthConstraint, heightConstraint);
        
        protected override Size ArrangeOverride(Rect bounds) =>
            GridLayoutManager.Instance.ArrangeOverride(this, bounds.Size);
    }
}

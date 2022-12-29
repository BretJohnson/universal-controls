// This file is generated from IGrid.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Controls;
using DependencyProperty = System.Windows.DependencyProperty;

namespace Microsoft.StandardUI.Wpf.Controls
{
    public class Grid : Panel, IGrid
    {
        public static readonly DependencyProperty ColumnDefinitionsProperty = PropertyUtils.Register(nameof(ColumnDefinitions), typeof(UICollection<IColumnDefinition>), typeof(Grid), null);
        public static readonly DependencyProperty RowDefinitionsProperty = PropertyUtils.Register(nameof(RowDefinitions), typeof(UICollection<IRowDefinition>), typeof(Grid), null);
        public static readonly DependencyProperty ColumnSpacingProperty = PropertyUtils.Register(nameof(ColumnSpacing), typeof(double), typeof(Grid), 0.0);
        public static readonly DependencyProperty RowSpacingProperty = PropertyUtils.Register(nameof(RowSpacing), typeof(double), typeof(Grid), 0.0);
        public static readonly DependencyProperty RowProperty = PropertyUtils.RegisterAttached("Row", typeof(int), typeof(System.Windows.UIElement), 0);
        public static readonly DependencyProperty ColumnProperty = PropertyUtils.RegisterAttached("Column", typeof(int), typeof(System.Windows.UIElement), 0);
        public static readonly DependencyProperty RowSpanProperty = PropertyUtils.RegisterAttached("RowSpan", typeof(int), typeof(System.Windows.UIElement), 1);
        public static readonly DependencyProperty ColumnSpanProperty = PropertyUtils.RegisterAttached("ColumnSpan", typeof(int), typeof(System.Windows.UIElement), 1);
        
        public static int GetRow(System.Windows.UIElement element) => (int) element.GetValue(RowProperty);
        public static void SetRow(System.Windows.UIElement element, int value) => element.SetValue(RowProperty, value);
        
        public static int GetColumn(System.Windows.UIElement element) => (int) element.GetValue(ColumnProperty);
        public static void SetColumn(System.Windows.UIElement element, int value) => element.SetValue(ColumnProperty, value);
        
        public static int GetRowSpan(System.Windows.UIElement element) => (int) element.GetValue(RowSpanProperty);
        public static void SetRowSpan(System.Windows.UIElement element, int value) => element.SetValue(RowSpanProperty, value);
        
        public static int GetColumnSpan(System.Windows.UIElement element) => (int) element.GetValue(ColumnSpanProperty);
        public static void SetColumnSpan(System.Windows.UIElement element, int value) => element.SetValue(ColumnSpanProperty, value);
        
        private UICollection<IColumnDefinition> _columnDefinitions;
        private UICollection<IRowDefinition> _rowDefinitions;
        
        public Grid()
        {
            _columnDefinitions = new UICollection<IColumnDefinition>(this);
            SetValue(ColumnDefinitionsProperty, _columnDefinitions);
            _rowDefinitions = new UICollection<IRowDefinition>(this);
            SetValue(RowDefinitionsProperty, _rowDefinitions);
        }
        
        public UICollection<IColumnDefinition> ColumnDefinitions => _columnDefinitions;
        IUICollection<IColumnDefinition> IGrid.ColumnDefinitions => ColumnDefinitions;
        
        public UICollection<IRowDefinition> RowDefinitions => _rowDefinitions;
        IUICollection<IRowDefinition> IGrid.RowDefinitions => RowDefinitions;
        
        public double ColumnSpacing
        {
            get => (double) GetValue(ColumnSpacingProperty);
            set => SetValue(ColumnSpacingProperty, value);
        }
        
        public double RowSpacing
        {
            get => (double) GetValue(RowSpacingProperty);
            set => SetValue(RowSpacingProperty, value);
        }
        
        protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint) =>
            GridLayoutManager.Instance.MeasureOverride(this, constraint.Width, constraint.Height).ToWpfSize();
        
        protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize) =>
            GridLayoutManager.Instance.ArrangeOverride(this, arrangeSize.ToStandardUISize()).ToWpfSize();
    }
}

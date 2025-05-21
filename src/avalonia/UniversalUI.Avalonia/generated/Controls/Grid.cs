// This file is generated from IGrid.cs. Update the source file to change its contents.

using UniversalUI;
using UniversalUI.Controls;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereControlsAvalonia.Controls
{
    public class Grid : Panel, IGrid
    {
        public static readonly Avalonia.StyledProperty<UICollection<IColumnDefinition>> ColumnDefinitionsProperty = AvaloniaProperty.Register<Grid, UICollection<IColumnDefinition>>(nameof(ColumnDefinitions), null);
        public static readonly Avalonia.StyledProperty<UICollection<IRowDefinition>> RowDefinitionsProperty = AvaloniaProperty.Register<Grid, UICollection<IRowDefinition>>(nameof(RowDefinitions), null);
        public static readonly Avalonia.StyledProperty<double> ColumnSpacingProperty = AvaloniaProperty.Register<Grid, double>(nameof(ColumnSpacing), 0.0);
        public static readonly Avalonia.StyledProperty<double> RowSpacingProperty = AvaloniaProperty.Register<Grid, double>(nameof(RowSpacing), 0.0);
        public static readonly Avalonia.AttachedProperty<int> RowProperty = AvaloniaProperty.RegisterAttached<Grid, Avalonia.Controls.Control, int>("Row", 0);
        public static readonly Avalonia.AttachedProperty<int> ColumnProperty = AvaloniaProperty.RegisterAttached<Grid, Avalonia.Controls.Control, int>("Column", 0);
        public static readonly Avalonia.AttachedProperty<int> RowSpanProperty = AvaloniaProperty.RegisterAttached<Grid, Avalonia.Controls.Control, int>("RowSpan", 1);
        public static readonly Avalonia.AttachedProperty<int> ColumnSpanProperty = AvaloniaProperty.RegisterAttached<Grid, Avalonia.Controls.Control, int>("ColumnSpan", 1);
        
        public static int GetRow(Avalonia.Controls.Control element) => (int) element.GetValue(RowProperty);
        public static void SetRow(Avalonia.Controls.Control element, int value) => element.SetValue(RowProperty, value);
        
        public static int GetColumn(Avalonia.Controls.Control element) => (int) element.GetValue(ColumnProperty);
        public static void SetColumn(Avalonia.Controls.Control element, int value) => element.SetValue(ColumnProperty, value);
        
        public static int GetRowSpan(Avalonia.Controls.Control element) => (int) element.GetValue(RowSpanProperty);
        public static void SetRowSpan(Avalonia.Controls.Control element, int value) => element.SetValue(RowSpanProperty, value);
        
        public static int GetColumnSpan(Avalonia.Controls.Control element) => (int) element.GetValue(ColumnSpanProperty);
        public static void SetColumnSpan(Avalonia.Controls.Control element, int value) => element.SetValue(ColumnSpanProperty, value);
        
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
        
        protected override Avalonia.Size MeasureOverride(Avalonia.Size availableSize) =>
            GridLayoutManager.Instance.MeasureOverride(this, availableSize.Width, availableSize.Height).ToAvaloniaSize();
        
        protected override Avalonia.Size ArrangeOverride(Avalonia.Size finalSize) =>
            GridLayoutManager.Instance.ArrangeOverride(this, finalSize.ToAnywhereControlsSize()).ToAvaloniaSize();
    }
}

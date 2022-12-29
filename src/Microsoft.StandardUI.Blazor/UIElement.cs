using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.StandardUI.DefaultImplementations;

namespace Microsoft.StandardUI.Blazor
{
    public abstract class UIElement : ComponentBase, IUIElement, IDisposable
    {
        private PropertyValues _properties = new(true);
        private Rect _frame = new Rect(0, 0, -1, -1);
        private bool _layoutInvalid = true;

        public Size DesiredSize { get; protected set; }

        public static readonly UIProperty WidthProperty = new(nameof(WidthProperty), double.NaN);
        public static readonly UIProperty MinWidthProperty = new(nameof(MinWidthProperty), 0.0);
        public static readonly UIProperty MaxWidthProperty = new(nameof(MaxWidthProperty), double.PositiveInfinity);

        public static readonly UIProperty HeightProperty = new(nameof(HeightProperty), double.NaN);
        public static readonly UIProperty MinHeightProperty = new(nameof(MinHeightProperty), 0.0);
        public static readonly UIProperty MaxHeightProperty = new(nameof(MaxHeightProperty), double.PositiveInfinity);

        public static readonly UIProperty MarginProperty = new(nameof(Margin), Thickness.Default);
        public static readonly UIProperty HorizontalAlignmentProperty = new(nameof(HorizontalAlignment), HorizontalAlignment.Stretch);
        public static readonly UIProperty VerticalAlignmentProperty = new(nameof(VerticalAlignment), VerticalAlignment.Stretch);

        public static readonly UIProperty FlowDirectionProperty = new(nameof(VerticalAlignment), FlowDirection.LeftToRight);
        public static readonly UIProperty VisibleProperty = new(nameof(Visible), true);

        public static readonly UIProperty ParentingInfoProperty = new(nameof(ParentingInfo), null);
        public static readonly UIProperty RenderLayerProperty = new(nameof(RenderLayer), null);

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            // Create layer for the root element
            if (ParentingInfo == null)
            {
                IVisualFramework visualFramework = HostEnvironment.VisualFramework;
                RenderLayer renderLayer = visualFramework.CreateRenderLayer(this, builder, 0);

                RenderLayer = renderLayer;
            }
        }

        [Parameter]
        public double Width
        {
            get => (double)GetNonNullValue(WidthProperty);
            set => SetValue(WidthProperty, value);
        }

        [Parameter]
        public double MinWidth
        {
            get => (double)GetNonNullValue(MinWidthProperty);
            set => SetValue(MinWidthProperty, value);
        }

        [Parameter]
        public double MaxWidth
        {
            get => (double)GetNonNullValue(MaxWidthProperty);
            set => SetValue(MaxWidthProperty, value);
        }

        [Parameter]
        public double Height
        {
            get => (double)GetNonNullValue(HeightProperty);
            set => SetValue(HeightProperty, value);
        }

        [Parameter]
        public double MinHeight
        {
            get => (double)GetNonNullValue(MinHeightProperty);
            set => SetValue(MinHeightProperty, value);
        }

        [Parameter]
        public double MaxHeight
        {
            get => (double)GetNonNullValue(MaxHeightProperty);
            set => SetValue(MaxHeightProperty, value);
        }

        [Parameter]
        public Thickness Margin
        {
            get => (Thickness)GetNonNullValue(MarginProperty);
            set => SetValue(MarginProperty, value);
        }

        [Parameter]
        public HorizontalAlignment HorizontalAlignment
        {
            get => (HorizontalAlignment)GetNonNullValue(HorizontalAlignmentProperty);
            set => SetValue(HorizontalAlignmentProperty, value);
        }

        [Parameter]
        public VerticalAlignment VerticalAlignment
        {
            get => (VerticalAlignment)GetNonNullValue(VerticalAlignmentProperty);
            set => SetValue(VerticalAlignmentProperty, value);
        }

        [Parameter]
        public FlowDirection FlowDirection
        {
            get => (FlowDirection)GetNonNullValue(FlowDirectionProperty);
            set => SetValue(FlowDirectionProperty, value);
        }

        [Parameter]
        public bool Visible
        {
            get => (bool)GetNonNullValue(VisibleProperty);
            set => SetValue(VisibleProperty, value);
        }

        [CascadingParameter(Name = "ParentingInfo")]
        private IList? ParentingInfo
        {
            get => (IList?)GetValue(ParentingInfoProperty);
            set
            {
                IList? oldValue = ParentingInfo;

                if (oldValue == value)
                    return;

                if (oldValue != null)
                    oldValue.Remove(this);

                if (value != null)
                    value.Add(this);

                SetValue(ParentingInfoProperty, value);
            }
        }

        public Rect Frame => _frame;

        protected RenderLayer? RenderLayer
        {
            get => (RenderLayer?) GetValue(RenderLayerProperty);
            set => SetValue(RenderLayerProperty, value);
        }

        protected virtual Size MeasureOverride(double widthConstraint, double heightConstraint)
        {
            return new Size(0.0, 0.0);
        }

        private SizeRequest GetSizeRequest(double widthConstraint, double heightConstraint)
        {
            var constraintSize = new Size(widthConstraint, heightConstraint);

            double widthRequest = Width;
            double heightRequest = Height;
            if (widthRequest >= 0)
                widthConstraint = Math.Min(widthConstraint, widthRequest);
            if (heightRequest >= 0)
                heightConstraint = Math.Min(heightConstraint, heightRequest);

            SizeRequest result = MeasureOverride(widthConstraint, heightConstraint);
            bool hasMinimum = result.Minimum != result.Request;
            Size request = result.Request;
            Size minimum = result.Minimum;

            if (heightRequest != -1 && !double.IsNaN(heightRequest))
            {
                request.Height = heightRequest;
                if (!hasMinimum)
                    minimum.Height = heightRequest;
            }

            if (widthRequest != -1 && !double.IsNaN(widthRequest))
            {
                request.Width = widthRequest;
                if (!hasMinimum)
                    minimum.Width = widthRequest;
            }

            double minimumHeightRequest = MinHeight;
            double minimumWidthRequest = MinWidth;

            if (minimumHeightRequest != -1)
                minimum.Height = minimumHeightRequest;
            if (minimumWidthRequest != -1)
                minimum.Width = minimumWidthRequest;

            minimum.Height = Math.Min(request.Height, minimum.Height);
            minimum.Width = Math.Min(request.Width, minimum.Width);

            var r = new SizeRequest(request, minimum);

            return r;
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (ParentingInfo == null)
            {
                // The components were just created or changed, so layout again
                Size availableSize = new Size(0, double.MaxValue);
                Layout(availableSize);
            }
        }

        internal void Layout(Size availableSize)
        {
            if (!_layoutInvalid)
                return;

            Measure(availableSize);

            Rect finalSize = new Rect(0, 0, DesiredSize.Width, DesiredSize.Height);
            Arrange(finalSize);

            _layoutInvalid = false;
        }

        public void Measure(Size availableSize)
        {
            Measure(availableSize.Width, availableSize.Height);
        }

        public void Measure(double widthConstraint, double heightConstraint)
        {
            Thickness margin = Margin;
            widthConstraint = Math.Max(0, widthConstraint - margin.HorizontalThickness);
            heightConstraint = Math.Max(0, heightConstraint - margin.VerticalThickness);

            SizeRequest result = GetSizeRequest(widthConstraint, heightConstraint);

            if (!margin.IsEmpty)
            {
                result.Minimum = new Size(result.Minimum.Width + margin.HorizontalThickness, result.Minimum.Height + margin.VerticalThickness);
                result.Request = new Size(result.Request.Width + margin.HorizontalThickness, result.Request.Height + margin.VerticalThickness);
            }

            DesiredSize = result.Request;
        }

        public void Arrange(Rect bounds)
        {
            Size size = ArrangeOverride(bounds);
            _frame = new Rect(bounds.X, bounds.Y, size.Width, size.Height);
        }

        protected virtual Size ArrangeOverride(Rect bounds)
        {
            return bounds.Size;
        }

        public double ActualX => throw new NotImplementedException();

        public double ActualY => throw new NotImplementedException();

        public double ActualWidth => throw new NotImplementedException();

        public double ActualHeight => throw new NotImplementedException();

        public object GetNonNullValue(UIProperty property) => _properties.GetNonNullValue(property);
        public object? GetValue(UIProperty property) => _properties.GetValue(property);
        object? IUIObject.GetValue(IUIProperty property) => _properties.GetValue((UIProperty)property);

        public object? ReadLocalValue(UIProperty property) => _properties.ReadLocalValue(property);
        object? IUIObject.ReadLocalValue(IUIProperty property) => _properties.ReadLocalValue((UIProperty)property);

        public void SetValue(UIProperty property, object? value) => _properties.SetValue(property, value);
        void IUIObject.SetValue(IUIProperty property, object? value) => _properties.SetValue((UIProperty)property, value);

        public void ClearValue(UIProperty property) => _properties.ClearValue(property);
        void IUIObject.ClearValue(IUIProperty property) => _properties.ClearValue((UIProperty)property);

        public virtual int VisualChildrenCount => 0;

        public virtual IUIElement GetVisualChild(int index) => throw new IndexOutOfRangeException("UIElement has no children");

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                IList? parentingInfo = ParentingInfo;
                if (parentingInfo != null)
                {
                    parentingInfo.Remove(this);
                    ParentingInfo = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

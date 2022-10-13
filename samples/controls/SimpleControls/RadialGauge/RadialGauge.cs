// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel;
using Microsoft.StandardUI;
using Microsoft.StandardUI.Controls;
using Microsoft.StandardUI.Controls.Primitives;
using Microsoft.StandardUI.Media;
using static Microsoft.StandardUI.StandardUIStatics;
using Microsoft.StandardUI.Shapes;
using Microsoft.StandardUI.Text;

namespace SimpleControls.RadialGauge
{
    /// <summary>
    /// A Modern UI Radial Gauge using XAML and Composition API.
    /// The scale of the gauge is a clockwise arc that sweeps from MinAngle (default lower left, at -150°) to MaxAngle (default lower right, at +150°).
    /// </summary>
    //// All calculations are for a 200x200 square. The viewbox will do the rest.
    //[TemplatePart(Name = ContainerPartName, Type = typeof(Grid))]
    //[TemplatePart(Name = ScalePartName, Type = typeof(Path))]
    //[TemplatePart(Name = TrailPartName, Type = typeof(Path))]
    //[TemplatePart(Name = ValueTextPartName, Type = typeof(TextBlock))]
    public interface IRadialGauge : IRangeBase
    {
        /// <summary>
        /// Identifies the optional StepSize property.
        /// </summary>
        [DefaultValue(0.0)]
        public double StepSize { get; set; }

        [DefaultValue(false)]
        public bool IsInteractive { get; set; }

        [DefaultValue(26.0)]
        public double ScaleWidth { get; set; }

        [DefaultValue(null)]
        public ISolidColorBrush? NeedleBrush { get; set; }

        [DefaultValue("")]
        public string Unit { get; set; }

        [DefaultValue(null)]
        public IBrush? TrailBrush { get; set; }

        [DefaultValue(null)]
        public IBrush? ScaleBrush { get; set; }

        [DefaultValue(null)]
        public IBrush? ScaleTickBrush { get; set; }

        [DefaultValue(null)]
        public ISolidColorBrush? TickBrush { get; set; }

        [DefaultValue("N0")]
        public string ValueStringFormat { get; set; }

        [DefaultValue(10)]
        public int TickSpacing { get; set; }

        [DefaultValue(100d)]
        public double NeedleLength { get; set; }

        [DefaultValue(5d)]
        public double NeedleWidth { get; set; }

        [DefaultValue(23d)]
        public double ScalePadding { get; set; }

        [DefaultValue(2.5)]
        public double ScaleTickWidth { get; set; }

        [DefaultValue(5d)]
        public double TickWidth { get; set; }

        [DefaultValue(18d)]
        public double TickLength { get; set; }

        [DefaultValue(-150)]
        public int MinAngle { get; set; }

        [DefaultValue(150)]
        public int MaxAngle { get; set; }

        [DefaultValue(double.NaN)]
        public double ValueAngle { get; set; }

        public class Metadata
        {
            public static IGrid DefaultTemplate(IRadialGauge control, out IPath? partScale, out IPath? partTrail, out ITextBlock? partValueText) =>
                Grid()
                    .Width(200)
                    .Height(200)._(

                    // Scale
                    Path()
                        .Assign<IPath>(out partScale)
                        .Stroke(control.ScaleBrush)
                        .StrokeThickness(control.ScaleWidth),

                    // Trail
                    Path()
                        .Assign<IPath>(out partTrail)
                        .Stroke(control.ScaleBrush)
                        .StrokeThickness(control.ScaleWidth),

                    // Value and unit
                    VerticalStack()
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Bottom).Children(

                        TextBlock()
                            .Assign<ITextBlock>(out partValueText)
                            .FontSize(control.ScaleWidth)
                            .Margin(new Thickness(0, 0, 0, 2))
                            .FontSize(20)
                            .FontWeight(FontWeights.SemiBold)
                            //.Foreground(Control.Foreground)
                            .TextAlignment(TextAlignment.Center),

                        TextBlock()
                            .Margin(new Thickness(0))
                            .FontSize(16)
                            //.Foreground(Control.Foreground)
                            .Text(control.Unit)
                            .TextAlignment(TextAlignment.Center)
                        )
                );
        }
    }

    public class RadialGauge : StandardControlImplementation<IRadialGauge>
    {
        // For convenience
        private const double Degrees2Radians = Math.PI / 180;

#if LATER
        // High-contrast accessibility
        private static readonly ThemeListener ThemeListener = new ThemeListener();
        private SolidColorBrush _needleBrush;
        private Brush _trailBrush;
        private Brush _scaleBrush;
        private SolidColorBrush _scaleTickBrush;
        private SolidColorBrush _tickBrush;
        private Brush _foreground;
#endif

        private double _normalizedMinAngle;
        private double _normalizedMaxAngle;

        /// <summary>
        /// Initializes a new instance of the <see cref="RadialGauge"/> class.
        /// Create a default radial gauge control.
        /// </summary>
        public RadialGauge(IRadialGauge control) : base(control)
        {
            //DefaultStyleKey = typeof(RadialGauge);

            control.SmallChange = 1;
            control.LargeChange = 10;
            //Unloaded += RadialGauge_Unloaded;
        }

#if LATER
        private void ThemeListener_ThemeChanged(ThemeListener sender)
        {
            OnColorsChanged();
        }

        private void RadialGauge_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            double step = SmallChange;
            var ctrl = Window.Current.CoreWindow.GetKeyState(VirtualKey.Control);
            if (ctrl.HasFlag(CoreVirtualKeyStates.Down))
            {
                step = LargeChange;
            }

            step = Math.Max(StepSize, step);
            if ((e.Key == VirtualKey.Left) || (e.Key == VirtualKey.Down))
            {
                Value = Math.Max(Minimum, Value - step);
                e.Handled = true;
                return;
            }

            if ((e.Key == VirtualKey.Right) || (e.Key == VirtualKey.Up))
            {
                Value = Math.Min(Maximum, Value + step);
                e.Handled = true;
            }
        }

        private void RadialGauge_Unloaded(object sender, RoutedEventArgs e)
        {
            // Unregister event handlers.
            KeyDown -= RadialGauge_KeyDown;
            ThemeListener.ThemeChanged -= ThemeListener_ThemeChanged;
            PointerReleased -= RadialGauge_PointerReleased;
            Unloaded -= RadialGauge_Unloaded;
        }
#endif

        /// <summary>
        /// Gets the normalized minimum angle.
        /// </summary>
        /// <value>The minimum angle in the range from -180 to 180.</value>
        protected double NormalizedMinAngle => _normalizedMinAngle;

        /// <summary>
        /// Gets the normalized maximum angle.
        /// </summary>
        /// <value>The maximum angle, in the range from -180 to 540.</value>
        protected double NormalizedMaxAngle => _normalizedMaxAngle;

#if LATER
        /// <inheritdoc/>
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new RadialGaugeAutomationPeer(this);
        }

        /// <summary>
        /// Update the visual state of the control when its template is changed.
        /// </summary>
        protected override void OnApplyTemplate()
        {
            // Remember local brushes.
            _needleBrush = ReadLocalValue(NeedleBrushProperty) as SolidColorBrush;
            _trailBrush = ReadLocalValue(TrailBrushProperty) as SolidColorBrush;
            _scaleBrush = ReadLocalValue(ScaleBrushProperty) as SolidColorBrush;
            _scaleTickBrush = ReadLocalValue(ScaleTickBrushProperty) as SolidColorBrush;
            _tickBrush = ReadLocalValue(TickBrushProperty) as SolidColorBrush;
            _foreground = ReadLocalValue(ForegroundProperty) as SolidColorBrush;

            // Register event handlers.
            PointerReleased += RadialGauge_PointerReleased;
            ThemeListener.ThemeChanged += ThemeListener_ThemeChanged;
            KeyDown += RadialGauge_KeyDown;

            // Apply color scheme.
            OnColorsChanged();

            base.OnApplyTemplate();
        }

        /// <inheritdoc/>
        protected override void OnMinimumChanged(double oldMinimum, double newMinimum)
        {
            base.OnMinimumChanged(oldMinimum, newMinimum);
            OnScaleChanged(this);
        }

        /// <inheritdoc/>
        protected override void OnMaximumChanged(double oldMaximum, double newMaximum)
        {
            base.OnMaximumChanged(oldMaximum, newMaximum);
            OnScaleChanged(this);
        }

        /// <inheritdoc/>
        protected override void OnValueChanged(double oldValue, double newValue)
        {
            OnValueChanged(this);
            base.OnValueChanged(oldValue, newValue);
            if (AutomationPeer.ListenerExists(AutomationEvents.LiveRegionChanged))
            {
                var peer = FrameworkElementAutomationPeer.FromElement(this) as RadialGaugeAutomationPeer;
                peer?.RaiseValueChangedEvent(oldValue, newValue);
            }
        }
#endif

        public override IUIElement Build()
        {
            IGrid grid = BuildTemplate(out IPath? partScale, out IPath? partTrail, out ITextBlock? partValueText);

            return null;
        }

        private IGrid BuildTemplate(out IPath? partScale, out IPath? partTrail, out ITextBlock? partValueText) =>
            IRadialGauge.Metadata.DefaultTemplate(Control, out partScale, out partTrail, out partValueText);

        private void DrawValue(IDrawingContext drawingContext, IPath? trailPart, ITextBlock? valuePart)
        {
            if (!double.IsNaN(Control.Value))
            {
                if (Control.StepSize != 0)
                {
                    Control.Value = RoundToMultiple(Control.Value, Control.StepSize);
                }

                var middleOfScale = 100 - Control.ScalePadding - (Control.ScaleWidth / 2);
                Control.ValueAngle = ValueToAngle(Control.Value);

                drawingContext.PushRotateTransform(
                    angle: Control.ValueAngle,
                    centerX: Control.NeedleWidth / 2,
                    centerY: Control.NeedleLength);
                drawingContext.DrawRectangle(
                    brush: Control.NeedleBrush,
                    pen: null,
                    rect: new Rect(
                        x: 100 - (Control.NeedleWidth / 2),
                        y: 100 - (float)Control.NeedleLength,
                        width: Control.NeedleWidth,
                        height: Control.NeedleLength));
                drawingContext.Pop();

                // Trail
                if (trailPart != null)
                {
                    if (Control.ValueAngle > _normalizedMinAngle)
                    {
                        trailPart.Visible = true;

                        if (Control.ValueAngle - _normalizedMinAngle == 360)
                        {
#if LATER
                            // Draw full circle
                            var eg = EllipseGeometry();
                            eg.Center = new Point(100, 100);
                            eg.RadiusX = 100 - Control.ScalePadding - (Control.ScaleWidth / 2);
                            eg.RadiusY = eg.RadiusX;
                            trail.Data = eg;
#endif
                        }
                        else
                        {
                            // Draw arc.
                            trailPart.Data =
                                PathGeometry()
                                    .Figures(
                                        PathFigure()
                                            .IsClosed(false)
                                            .StartPoint(ScalePoint(NormalizedMinAngle, middleOfScale))
                                            .Segments(
                                                ArcSegment()
                                                    .SweepDirection(SweepDirection.Clockwise)
                                                    .IsLargeArc(Control.ValueAngle > (180 + NormalizedMinAngle))
                                                    .Size(new Size(middleOfScale, middleOfScale))
                                                    .Point(ScalePoint(Math.Min(Control.ValueAngle, NormalizedMaxAngle), middleOfScale))
                                            )
                                        );
                        }
                    }
                    else
                    {
                        trailPart.Visible = false;
                    }
                }

                // Value Text
                if (valuePart != null)
                {
                    valuePart.Text = Control.Value.ToString(Control.ValueStringFormat);
                }
            }
        }

#if LATER
        private static void OnInteractivityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RadialGauge radialGauge = (RadialGauge)d;

            if (Control.IsInteractive)
            {
                Control.Tapped += Control.RadialGauge_Tapped;
                Control.ManipulationDelta += Control.RadialGauge_ManipulationDelta;
                Control.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
            }
            else
            {
                Control.Tapped -= Control.RadialGauge_Tapped;
                Control.ManipulationDelta -= Control.RadialGauge_ManipulationDelta;
                Control.ManipulationMode = ManipulationModes.None;
            }
        }
#endif

        private void DrawScale(IDrawingContext drawingContext, IPath? scalePart)
        {
            UpdateNormalizedAngles();

            if (scalePart != null)
            {
                if (_normalizedMaxAngle - _normalizedMinAngle == 360)
                {
#if LATER
                    // Draw full circle.
                    var eg = new EllipseGeometry();
                    eg.Center = new Point(100, 100);
                    eg.RadiusX = 100 - Control.ScalePadding - (Control.ScaleWidth / 2);
                    eg.RadiusY = eg.RadiusX;
                    scalePart.Data = eg;
#endif
                }
                else
                {
                    var middleOfScale = 100 - Control.ScalePadding - (Control.ScaleWidth / 2);

                    // Draw arc.
                    scalePart.Data =
                        PathGeometry()
                            .Figures(
                                PathFigure()
                                    .IsClosed(false)
                                    .StartPoint(ScalePoint(NormalizedMinAngle, middleOfScale))
                                    .Segments(
                                        ArcSegment()
                                            .SweepDirection(SweepDirection.Clockwise)
                                            .IsLargeArc(NormalizedMaxAngle > (NormalizedMinAngle + 180))
                                            .Size(new Size(middleOfScale, middleOfScale))
                                            .Point(ScalePoint(NormalizedMaxAngle, middleOfScale))
                                    )
                                );
                }

                if (!DesignTimeHelpers.IsRunningInLegacyDesignerMode)
                {
                    OnFaceChanged(radialGauge);
                }
            }
        }

        private static void OnFaceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!DesignTimeHelpers.IsRunningInLegacyDesignerMode)
            {
                OnFaceChanged(d);
            }
        }

        private void DrawTicks(IDrawingContext drawingContext)
        {
            if (Control.TickSpacing > 0)
            {
                // Ticks
                Rect tickRect = new Rect(100 - Control.TickWidth / 2, 0.0, Control.TickWidth, Control.TickLength);
                for (double i = Control.Minimum; i <= Control.Maximum; i += Control.TickSpacing)
                {
                    drawingContext.PushRotateTransform(
                        angle: ValueToAngle(i),
                        centerX: Control.TickWidth / 2,
                        centerY: 100.0);
                    drawingContext.DrawRectangle(
                        brush: Control.TickBrush,
                        pen: null,
                        rect: tickRect);
                    drawingContext.Pop();
                }

                // Scale Ticks
                Rect scaleTickRect = new Rect(100 - (Control.ScaleTickWidth / 2), Control.ScalePadding, Control.ScaleTickWidth, Control.ScaleTickWidth);
                for (double i = Control.Minimum; i <= Control.Maximum; i += Control.TickSpacing)
                {
                    drawingContext.PushRotateTransform(
                        angle: ValueToAngle(i),
                        centerX: Control.ScaleTickWidth / 2,
                        centerY: 100 - Control.ScalePadding);
                    drawingContext.DrawRectangle(
                        brush: Control.ScaleTickBrush,
                        pen: null,
                        rect: tickRect);
                    drawingContext.Pop();
                }
            }
        }

        private void RadialGauge_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            SetGaugeValueFromPoint(e.Position);
        }

        private void RadialGauge_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SetGaugeValueFromPoint(e.GetPosition(this));
        }

        private void RadialGauge_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (Control.IsInteractive)
            {
                e.Handled = true;
            }
        }

        private void UpdateNormalizedAngles()
        {
            var result = Mod(Control.MinAngle, 360);

            if (result >= 180)
            {
                result -= 360;
            }

            _normalizedMinAngle = result;

            result = Mod(Control.MaxAngle, 360);

            if (result < 180)
            {
                result += 360;
            }

            if (result > NormalizedMinAngle + 360)
            {
                result -= 360;
            }

            _normalizedMaxAngle = result;
        }

        private void SetGaugeValueFromPoint(Point p)
        {
            var pt = new Point(p.X - (Control.ActualWidth / 2), -p.Y + (Control.ActualHeight / 2));

            var angle = Math.Atan2(pt.X, pt.Y) / Degrees2Radians;
            var divider = Mod(NormalizedMaxAngle - NormalizedMinAngle, 360);
            if (divider == 0)
            {
                divider = 360;
            }

            var value = Control.Minimum + ((Control.Maximum - Control.Minimum) * Mod(angle - NormalizedMinAngle, 360) / divider);
            if (value < Control.Minimum || value > Control.Maximum)
            {
                // Ignore positions outside the scale angle.
                return;
            }

            Control.Value = RoundToMultiple(value, Control.StepSize);
        }

        private static Point ScalePoint(double angle, double middleOfScale) =>
            new Point(
                100 + (Math.Sin(Degrees2Radians * angle) * middleOfScale),
                100 - (Math.Cos(Degrees2Radians * angle) * middleOfScale));

        private double ValueToAngle(double value)
        {
            // Off-scale on the left.
            if (value < Control.Minimum)
            {
                return Control.MinAngle;
            }

            // Off-scale on the right.
            if (value > Control.Maximum)
            {
                return Control.MaxAngle;
            }

            return ((value - Control.Minimum) / (Control.Maximum - Control.Minimum) * (NormalizedMaxAngle - NormalizedMinAngle)) + NormalizedMinAngle;
        }

        private static double Mod(double number, double divider)
        {
            var result = number % divider;
            result = result < 0 ? result + divider : result;
            return result;
        }

        private static double RoundToMultiple(double number, double multiple)
        {
            double modulo = number % multiple;
            if (double.IsNaN(modulo))
            {
                return number;
            }

            if ((multiple - modulo) <= modulo)
            {
                modulo = multiple - modulo;
            }
            else
            {
                modulo *= -1;
            }

            return number + modulo;
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel;
using AnywhereControls;
using AnywhereControls.Controls;

namespace Microcharts
{
    [AnywhereControl]
    public interface IChart : IAnywhereControl
    {
        /// <summary>
        /// The type of chart (bar chart, pie chart, etc.)
        /// </summary>
        [DefaultValue(ChartType.BarChart)]
        ChartType ChartType { get; set; }

        /// <summary>
        /// Data for the chart
        /// </summary>
        IEnumerable<ChartEntry> Entries { get; set; }

        /// <summary>
        /// Color used for chart background
        /// </summary>
        [DefaultValue(DefaultColor.White)]
        Color BackgroundColor { get; set; }

        /// <summary>
        /// Color used for chart labels
        /// </summary>
        [DefaultValue(DefaultColor.Gray)]
        Color LabelColor { get; set; }
    }

    public abstract class Chart : AnywhereControl, IChart
    {
        private ChartBase _chart;

        public abstract ChartType ChartType { get; set; }
        public abstract IEnumerable<ChartEntry> Entries { get; set; }
        public abstract Color BackgroundColor { get; set; }
        public abstract Color LabelColor { get; set; }

        /// <summary>
        /// Build the UI element hierarchy for the chart control, for the current chart type.
        /// </summary>
        protected override IUIElement Build()
        {
            switch (ChartType)
            {
                case ChartType.BarChart:
                    _chart = new BarChart(this);
                    break;

                case ChartType.PointChart:
                    _chart = new PointChart(this);
                    break;

                case ChartType.RadarChart:
                    _chart = new RadarChart(this);
                    break;
            }

            return _chart.Build();
        }
    }
}

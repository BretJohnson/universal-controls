using System.Collections.Generic;
using System.ComponentModel;
using AnywhereUI;
using AnywhereUI.Controls;

namespace Microcharts
{
    [AnywhereControl]
    public abstract class Chart : AnywhereControl
    {
        private ChartBase _chart;

        [DefaultValue(ChartType.BarChart)]
        public abstract ChartType ChartType { get; set; }

        public abstract IEnumerable<ChartEntry> Entries { get; set; }

        [DefaultValue(DefaultColor.White)]
        public abstract Color BackgroundColor { get; set; }

        [DefaultValue(DefaultColor.Gray)]
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

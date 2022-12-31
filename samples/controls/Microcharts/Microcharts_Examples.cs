using Microsoft.ComponentModelEx;
using Microsoft.Maui.Graphics;
using Microsoft.StandardUI;
using Microsoft.StandardUI.Controls;
using static Microcharts.MicrochartsStatics;

namespace Microcharts
{
    public class Microcharts_Examples
    {
        [UIExample("Bar Chart")]
        public static IChart BarChart() =>
            Chart()
                .Width(300)
                .Height(300)
                .ChartType(ChartType.BarChart)
                .LabelColor(Colors.Blue)
                .Entries(CreateChartEntries());

        [UIExample("Point Chart")]
        public static IChart PointChart() =>
            Chart()
                .Width(300)
                .Height(300)
                .ChartType(ChartType.PointChart)
                .Entries(CreateChartEntries());

        private static ChartEntry[] CreateChartEntries()
        {
            return new[]
            {
                new ChartEntry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                    Color = Color.FromArgb("#266489")
                },
                new ChartEntry(400)
                {
                    Label = "February",
                    ValueLabel = "400",
                    Color = Color.FromArgb("#68B9C0"),
                },
                new ChartEntry(100)
                {
                    Label = "March",
                    ValueLabel = "100",
                    Color = Color.FromArgb("#90D585"),
                },
            };
        }
    }
}

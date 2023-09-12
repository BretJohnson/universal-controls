//using Blazor.Extensions.Canvas.Canvas2D;
//using Microcharts;

namespace AnywhereControls.Blazor.NativeVisualFramework
{
#if LATER
    public class BlazorDrawingContext : IDrawingContext
    {
        Canvas2DContext canvas2Dcontext;

        public BlazorDrawingContext(Canvas2DContext context)
        {
            this.canvas2Dcontext = context;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void DrawEllipse(IEllipse ellipse)
        {
            throw new NotImplementedException();
        }

        public void DrawLine(ILine line)
        {
            throw new NotImplementedException();
        }

        public void DrawPath(IPath path)
        {
            throw new NotImplementedException();
        }

        public void DrawPolygon(IPolygon polygon)
        {
            throw new NotImplementedException();
        }

        public void DrawPolyline(IPolyline polyline)
        {
            throw new NotImplementedException();
        }

        public void DrawBarChart(ChartEntry[] entries)
        {
            Task t = Task.Run(async () =>
            {
                int xPosition = 10;
                int widthcalculation = (500 - 100) / entries.Length;
                int chartHeight = 500 - 40;
                int maxVal = (int)entries.Max(row => row.Value);
                int barPadding = 15;

                await this.canvas2Dcontext.BeginPathAsync();
                await this.canvas2Dcontext.MoveToAsync(xPosition, xPosition);

                // Draw Y axis
                //await this.canvas2Dcontext.LineToAsync(xPosition, chartHeight);

                //// Draw X axis
                //await this.canvas2Dcontext.LineToAsync(490, chartHeight);
                //await this.canvas2Dcontext.StrokeAsync();

                // Draw Xasxi plot lines
                foreach (ChartEntry entry in entries)
                {
                    xPosition = xPosition + widthcalculation + barPadding;
                    await this.canvas2Dcontext.MoveToAsync(xPosition, chartHeight);
                    await this.canvas2Dcontext.StrokeAsync();
                    await this.canvas2Dcontext.SetFillStyleAsync("#90D585");
                    await this.canvas2Dcontext.SetFontAsync("16pt Calibri");
                    await this.canvas2Dcontext.StrokeTextAsync(entry.Label, xPosition - widthcalculation/2 - barPadding - 5, chartHeight + 24);

                    //  Draw Bar Graph
                    int maxRatio = (int)entries.Max(row => row.Value);
                    int maxFill = maxRatio * (chartHeight - xPosition);
                    maxFill = chartHeight - maxRatio;

                    int barRatio = (int)entries.Max(row => row.Value) - (int)entry.Value;
                    int fillheight = barRatio * (chartHeight - xPosition);
                    fillheight = chartHeight - barRatio;
                    string color = HexConverter(entry.Color);
                    string alphaColor = string.Format("{0}{1}", color, "42");

                    //For the BackColor Filing
                    await this.canvas2Dcontext.SetFillStyleAsync(alphaColor);
                    await this.canvas2Dcontext.FillRectAsync(xPosition - widthcalculation - 1, chartHeight - 1, widthcalculation + 4, -maxRatio);
                    //// *****

                    // for the ACTUAL bar Chart
                    await this.canvas2Dcontext.SetFillStyleAsync(color);
                    await this.canvas2Dcontext.FillRectAsync(xPosition - widthcalculation, chartHeight, widthcalculation + 2, -(fillheight - 60));

                    //Add the vaule to each bar

                    //await this.canvas2Dcontext.SetFillStyleAsync("#000000");
                    //await this.canvas2Dcontext.SetFontAsync("18pt Calibri");
                    //await this.canvas2Dcontext.FillTextAsync(entry.Value.ToString(), chartHeight - widthcalculation + 4, chartHeight / 2);
                    //await this.canvas2Dcontext.SetFillStyleAsync(entry.Color);

                    //colorIndex++;
                }
            });
        }
        private static String HexConverter(Color c)
        {
            return "#" +  c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static ChartEntry[] CreateChartEntries()
        {
            return new[]
            {
                new ChartEntry(200)
                {
                        Label = "January",
                        ValueLabel = "200",
                        Color = Color.FromHex("#31577c")
                },
                 new ChartEntry(400)
                {
                        Label = "February",
                        ValueLabel = "400",
                        Color = Color.FromHex("#68B9C0"),
                },
                new ChartEntry(100)
                {
                        Label = "March",
                        ValueLabel = "100",
                        Color = Color.FromHex("#90D585"),
                },
            };
        }

        public void DrawRectangle(IRectangle rectangle)
        {
            Task t = Task.Run(async () =>
            {
                this.DrawBarChart(CreateChartEntries());
            });
        }

        public void DrawTextBlock(ITextBlock textBlock)
        {
            throw new NotImplementedException();
        }

        public IVisual End()
        {
            throw new NotImplementedException();
        }
    }
#endif
}
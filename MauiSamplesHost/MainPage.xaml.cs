// Import our sample controls. This triggers source generation, turning them into WPF controls.
// To see the generated source, in Solution Explorer look under
// Dependencies / Analyzers / AnywhereControls.Analyzers / ImportControlLibraryGenerator
using AnywhereControls;
using Microcharts;
using SimpleControls;
using AnywhereControls.Maui;
using AnywhereControls.Maui.NativeVisualFramework;

[assembly: ImportControlLibrary(typeof(SimpleControlsControlLibrary))]
[assembly: ImportControlLibrary(typeof(MicrochartsControlLibrary))]

namespace MauiHost
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            // TODO: Initialize MauiHostFramework

            InitializeComponent();

            InitalizeExamples();
        }

        public static ChartEntry[] CreateChartEntries()
        {
            return new[]
            {
                new ChartEntry(200)
                {
                    Label = "January",
                    ValueLabel = "200",
                    Color = AnywhereControls.Color.FromHex("#266489")
                },
                new ChartEntry(400)
                {
                    Label = "February",
                    ValueLabel = "400",
                    Color = AnywhereControls.Color.FromHex("#68B9C0"),
                },
                new ChartEntry(100)
                {
                    Label = "March",
                    ValueLabel = "100",
                    Color = AnywhereControls.Color.FromHex("#90D585"),
                },
            };
        }

        void InitalizeExamples()
        {
            // TODO: Create samples UI
        }
    }
}
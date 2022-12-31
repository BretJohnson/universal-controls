using System.Windows;
using System.Windows.Controls;
using Microcharts;
using Microcharts.Wpf;
using Microsoft.ComponentModelEx.Tooling;
using Microsoft.Maui.Graphics;
using Microsoft.StandardUI;
using Microsoft.StandardUI.Wpf;
using Microsoft.StandardUI.Wpf.NativeVisualFramework;
using SimpleControls;
using SimpleControls.Wpf;

// Import our sample controls. This triggers source generation, turning them into WPF controls.
// To see the generated source, in Solution Explorer look under
// Dependencies / Analyzers / Microwsoft.StandardUI.Analyzers / ImportControlLibraryGenerator
[assembly: ImportControlLibrary(typeof(SimpleControlsControlLibrary))]
[assembly: ImportControlLibrary(typeof(MicrochartsControlLibrary))]

namespace WpfHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WpfHostFramework.Init(new WpfNativeVisualFramework());

            SimpleControlsLibrary.Initialize();
            MicrochartsLibrary.Initialize();

            InitializeComponent();

            InitalizeExamples();
        }

        private void InitalizeExamples()
        {
            UIExamples uiExamples = new UIExamples();

            uiExamples.LoadFromAssembly(typeof(SimpleControlsControlLibrary).Assembly);
            uiExamples.LoadFromAssembly(typeof(MicrochartsControlLibrary).Assembly);

            int rowIndex = 0;
            foreach (UIExample uiExample in uiExamples.Examples)
            {
                string? description = uiExample.Description;
                object control = uiExample.Create();

                if (control is not UIElement controlUIElement)
                    continue;

                var rowDefinition = new RowDefinition();
                Examples.RowDefinitions.Add(rowDefinition);

                var descriptionText = new TextBlock()
                {
                    Text = uiExample.Description,
                    Padding = new System.Windows.Thickness(10.0),
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                };
                Grid.SetRow(descriptionText, rowIndex);
                Grid.SetColumn(descriptionText, 0);
                Examples.Children.Add(descriptionText);

                Border controlBorder = new Border()
                {
                    Padding = new System.Windows.Thickness(10.0),
                    Child = controlUIElement,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                };
                Grid.SetRow(controlBorder, rowIndex);
                Grid.SetColumn(controlBorder, 1);
                Examples.Children.Add(controlBorder);

                ++rowIndex;
            }
        }

        public static ChartEntry[] CreateChartEntries()
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

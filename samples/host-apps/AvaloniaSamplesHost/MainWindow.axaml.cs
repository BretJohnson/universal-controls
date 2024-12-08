using AnywhereUI;
using AnywhereUIAvalonia;
using AnywhereUIAvalonia.NativeVisualFramework;
using Avalonia.Controls;
using Microcharts;
using Microsoft.ComponentModelEx.Tooling;
using SimpleControls;
using SimpleControls.Avalonia;
using Microcharts.Avalonia;

// Import our sample controls. This triggers source generation, turning them into Avalonia controls.
// To see the generated source, in Solution Explorer look under
// Dependencies / Analyzers / AnywhereControls.Analyzers / ImportControlLibraryGenerator
[assembly: ImportControlLibrary(typeof(SimpleControlsControlLibrary))]
[assembly: ImportControlLibrary(typeof(MicrochartsControlLibrary))]

namespace AvaloniaSamplesHost
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AvaloniaHostFramework.Init(new AvaloniaNativeVisualFramework());

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

                if (control is not Control controlUIElement)
                    continue;

                var rowDefinition = new RowDefinition();
                Examples.RowDefinitions.Add(rowDefinition);

                var descriptionText = new TextBlock()
                {
                    Text = uiExample.Description,
                    Padding = new Avalonia.Thickness(10.0),
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                };
                Grid.SetRow(descriptionText, rowIndex);
                Grid.SetColumn(descriptionText, 0);
                Examples.Children.Add(descriptionText);

                Border controlBorder = new Border()
                {
                    Padding = new Avalonia.Thickness(10.0),
                    Child = controlUIElement,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                };
                Grid.SetRow(controlBorder, rowIndex);
                Grid.SetColumn(controlBorder, 1);
                Examples.Children.Add(controlBorder);

                ++rowIndex;
            }
        }
    }
}
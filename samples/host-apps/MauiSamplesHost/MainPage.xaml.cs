// Import our sample controls. This triggers source generation, turning them into WPF controls.
// To see the generated source, in Solution Explorer look under
// Dependencies / Analyzers / AnywhereUI.Analyzers / ImportControlLibraryGenerator
using AnywhereUI;
using Microcharts;
using Microcharts.Maui;
using SimpleControls;
using SimpleControls.Maui;
using AnywhereUI.Maui;
using AnywhereUI.Maui.NativeVisualFramework;
using ExampleFramework.Tooling;

[assembly: ImportControlLibrary(typeof(SimpleControlsControlLibrary))]
[assembly: ImportControlLibrary(typeof(MicrochartsControlLibrary))]

namespace MauiHost
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            SimpleControlsLibrary.Initialize();
            MicrochartsLibrary.Initialize();

            InitializeComponent();

            InitalizeExamples();
        }

        void InitalizeExamples()
        {
            UIComponents uiComponents = new UIComponents();

            uiComponents.AddFromAssembly(typeof(SimpleControlsControlLibrary).Assembly);
            uiComponents.AddFromAssembly(typeof(MicrochartsControlLibrary).Assembly);

            int rowIndex = 0;
            foreach (UIComponent uiComponent in uiComponents.Components)
            {
                foreach (UIExample uiExample in uiComponent.Examples)
                {
                    string? description = uiExample.Title;
                    object control = uiExample.Create();

                    if (control is not View controlUIElement)
                        continue;

                    var rowDefinition = new RowDefinition();
                    Examples.RowDefinitions.Add(rowDefinition);

                    var descriptionText = new Label()
                    {
                        Text = uiExample.Title,
                        Padding = new Microsoft.Maui.Thickness(10.0),
                        VerticalOptions = LayoutOptions.Center
                    };
                    Grid.SetRow(descriptionText, rowIndex);
                    Grid.SetColumn(descriptionText, 0);
                    Examples.Children.Add(descriptionText);

                    Border controlBorder = new Border()
                    {
                        StrokeThickness = 0,
                        Padding = new Microsoft.Maui.Thickness(10.0),
                        Content = controlUIElement,
                        VerticalOptions = LayoutOptions.Center
                    };
                    Grid.SetRow(controlBorder, rowIndex);
                    Grid.SetColumn(controlBorder, 1);
                    Examples.Children.Add(controlBorder);

                    ++rowIndex;
                }
            }
        }
    }
}
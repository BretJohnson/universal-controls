// Import our sample controls. This triggers source generation, turning them into WPF controls.
// To see the generated source, in Solution Explorer look under
// Dependencies / Analyzers / AnywhereControls.Analyzers / ImportControlLibraryGenerator
using AnywhereControls;
using Microcharts;
using Microcharts.Maui;
using SimpleControls;
using SimpleControls.Maui;
using AnywhereControls.Maui;
using AnywhereControls.Maui.NativeVisualFramework;
using Microsoft.ComponentModelEx.Tooling;

[assembly: ImportControlLibrary(typeof(SimpleControlsControlLibrary))]
[assembly: ImportControlLibrary(typeof(MicrochartsControlLibrary))]

namespace MauiHost
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            MauiHostFramework.Init(new MauiNativeVisualFramework(null));

            SimpleControlsLibrary.Initialize();
            MicrochartsLibrary.Initialize();

            InitializeComponent();

            InitalizeExamples();
        }

        void InitalizeExamples()
        {
            UIExamples uiExamples = new UIExamples();

            uiExamples.LoadFromAssembly(typeof(SimpleControlsControlLibrary).Assembly);
            uiExamples.LoadFromAssembly(typeof(MicrochartsControlLibrary).Assembly);

            int rowIndex = 0;
            foreach (UIExample uiExample in uiExamples.Examples)
            {
                string description = uiExample.Description;
                object control = uiExample.Create();

                if (control is not View controlUIElement)
                    continue;

                var rowDefinition = new RowDefinition();
                Examples.RowDefinitions.Add(rowDefinition);

                var descriptionText = new Label()
                {
                    Text = uiExample.Description,
                    Padding = new Microsoft.Maui.Thickness(10.0),
                    VerticalOptions = LayoutOptions.Center
                };
                Grid.SetRow(descriptionText, rowIndex);
                Grid.SetColumn(descriptionText, 0);
                Examples.Children.Add(descriptionText);

                Border controlBorder = new Border()
                {
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
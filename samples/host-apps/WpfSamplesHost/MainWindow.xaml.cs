using System.Windows;
using System.Windows.Controls;
using ExampleFramework.App;
using Microcharts;
using Microcharts.Wpf;
using SimpleControls;
using SimpleControls.Wpf;
using UniversalUI;
using UniversalUI.Wpf;
using UniversalUI.Wpf.NativeVisualFramework;

// Import our sample controls. This triggers source generation, turning them into WPF controls.
// To see the generated source, in Solution Explorer look under
// Dependencies / Analyzers / AnywhereControls.Analyzers / ImportControlLibraryGenerator
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
            var uiComponentsManager = new UIComponentsManagerReflection(null, [], null);

            uiComponentsManager.AddUIComponentsFromAssembly(typeof(SimpleControlsControlLibrary).Assembly);
            uiComponentsManager.AddUIComponentsFromAssembly(typeof(MicrochartsControlLibrary).Assembly);

            int rowIndex = 0;
            foreach (UIComponentReflection uiComponent in uiComponentsManager.UIComponents)
            {
                foreach (ExampleReflection example in uiComponent.Examples)
                {
                    object control = example.Create();

                    if (control is not UIElement controlUIElement)
                        continue;

                    var rowDefinition = new RowDefinition();
                    Examples.RowDefinitions.Add(rowDefinition);

                    var descriptionText = new TextBlock()
                    {
                        Text = example.DisplayName,
                        Padding = new System.Windows.Thickness(10.0),
                        VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    };
                    Grid.SetRow(descriptionText, rowIndex);
                    Grid.SetColumn(descriptionText, 0);
                    Examples.Children.Add(descriptionText);

                    var controlBorder = new Border()
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
        }
    }
}

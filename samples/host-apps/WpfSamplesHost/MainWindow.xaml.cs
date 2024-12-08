using System.Windows;
using System.Windows.Controls;
using Microcharts;
using Microcharts.Wpf;
using AnywhereUI;
using AnywhereUI.Wpf;
using AnywhereUI.Wpf.NativeVisualFramework;
using SimpleControls;
using SimpleControls.Wpf;
using ExampleFramework;
using ExampleFramework.App;

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
            AppUIComponents uiComponents = new AppUIComponents();

            uiComponents.AddFromAssembly(typeof(SimpleControlsControlLibrary).Assembly);
            uiComponents.AddFromAssembly(typeof(MicrochartsControlLibrary).Assembly);

            int rowIndex = 0;
            foreach (AppUIComponent uiComponent in uiComponents.Components)
            {
                foreach (AppUIExample uiExample in uiComponent.Examples)
                {
                    object control = uiExample.Create();

                    if (control is not UIElement controlUIElement)
                        continue;

                    var rowDefinition = new RowDefinition();
                    Examples.RowDefinitions.Add(rowDefinition);

                    var descriptionText = new TextBlock()
                    {
                        Text = uiExample.DisplayName,
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
        }
    }
}

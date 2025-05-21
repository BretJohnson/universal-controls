using UniversalUI.SkiaVisualFramework;
using UniversalUI.WinForms;

[assembly: ImportStandardControl("SimpleControls.IRadialGauge")]
[assembly: ImportStandardControl("Microcharts.IChart")]

namespace WinFormsSamplesHost
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WinFormsHostFramework.Init(new SkiaVisualFramework());

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
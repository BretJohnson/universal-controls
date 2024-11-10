using AnywhereControls;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace AnywhereControlsAvalonia
{
    internal struct SizeInPixels
    {
        public static SizeInPixels Empty = new SizeInPixels(-1, -1);

        public int Width { get; }
        public int Height { get; }

        public SizeInPixels(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    /// <summary>
    /// This provides support for predefined StandardUI controls
    /// </summary>
    internal struct StandardUIFrameworkElementHelper
    {
        private WriteableBitmap? _bitmap;

        public void OnRender(IVisual visual, double width, double height, DrawingContext drawingContext)
        {
#if LATER
            if (visual.NativeVisual is DrawingGroup drawingGroup)
            {
                foreach (Drawing drawing in drawingGroup.Children)
                {
                    drawingContext.DrawD
                }


                drawingContext.DrawDrawing(drawingGroup);
            }
            else
            {
                if (!IsPositive(width) || !IsPositive(height))
                    return;

                double scaleX = 1.0;
                double scaleY = 1.0;

                // TODO: Put this back once fix NRE
#if false
                Matrix m = PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice;
                scaleX = m.M11;
                scaleY = m.M22;

                widthInPixels = width * m.M11;
                heightInPixels = height * m.M22;
#endif
                int widthInPixels = (int)(width * scaleX);
                int heightInPixels = (int)(height * scaleY);

                // reset the bitmap if the size has changed
                if (_bitmap == null || widthInPixels != _bitmap.PixelWidth || heightInPixels != _bitmap.PixelHeight)
                    _bitmap = new WriteableBitmap(widthInPixels, heightInPixels, 96 * scaleX, 96 * scaleY, PixelFormats.Pbgra32, null);

                // draw on the bitmap
                _bitmap.Lock();

                IVisualFramework visualFramework = HostEnvironment.VisualFramework;
                visualFramework.RenderToBuffer(visual, _bitmap.BackBuffer, widthInPixels, heightInPixels, _bitmap.BackBufferStride);

                _bitmap.AddDirtyRect(new Int32Rect(0, 0, widthInPixels, heightInPixels));
                _bitmap.Unlock();
                drawingContext.DrawImage(_bitmap, new Avalonia.Rect(0, 0, widthInPixels, heightInPixels));

                //var rect = new Avalonia.Rect(0, 0, 175, 50);
                //drawingContext.DrawRectangle(new SolidColorBrush(Avalonia.Media.Colors.Red), null, rect);
            }

            /*
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Colors.LimeGreen;
            Pen myPen = new Pen(Brushes.Blue, 10);
            Rect myRect = new Rect(0, 0, 500, 500);
            dc.DrawRectangle(mySolidColorBrush, myPen, myRect);
            */
#endif
        }

        private static bool IsPositive(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value) && value > 0;
        }
    }
}

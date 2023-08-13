// This file is generated from ITranslateTransform.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Mac.Media
{
    public class TranslateTransform : Transform, ITranslateTransform
    {
        public static readonly UIProperty XProperty = new UIProperty(nameof(X), 0.0);
        public static readonly UIProperty YProperty = new UIProperty(nameof(Y), 0.0);
        
        public double X
        {
            get => (double) GetNonNullValue(XProperty);
            set => SetValue(XProperty, value);
        }
        
        public double Y
        {
            get => (double) GetNonNullValue(YProperty);
            set => SetValue(YProperty, value);
        }
    }
}

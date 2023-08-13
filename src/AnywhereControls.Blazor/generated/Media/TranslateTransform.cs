// This file is generated from ITranslateTransform.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using AnywhereControls.Media;

namespace AnywhereControls.Blazor.Media
{
    public class TranslateTransform : Transform, ITranslateTransform
    {
        public static readonly UIProperty XProperty = new UIProperty(nameof(X), 0.0);
        public static readonly UIProperty YProperty = new UIProperty(nameof(Y), 0.0);
        
        [Parameter]
        public double X
        {
            get => (double) GetNonNullValue(XProperty);
            set => SetValue(XProperty, value);
        }
        
        [Parameter]
        public double Y
        {
            get => (double) GetNonNullValue(YProperty);
            set => SetValue(YProperty, value);
        }
    }
}

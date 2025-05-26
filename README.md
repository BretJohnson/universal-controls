# .NET Universal Controls

.NET Universal Controls is an experimental project that enables building controls, primarily with drawn UI,
that can be used "anywhere", on multiple .NET UI frameworks. Frameworks that can eventually be supported
include .NET MAUI, WPF, WinUI, WinForms, Avalonia, Uno, and Blazor. 

Today the .NET UI ecosystem is fragmented - lots of the frameworks above work similarly, but they
are all slightly different and incompatible. Control authors that want to support multiple frameworks
need to write their own abstraction layer. Many do that, but it's a pain and new frameworks aren't
automatically supported.  Rather than everyone writing their own abstraction layer, it would be better
if there's a standard set of APIs, where if you use those to author your control it'll
work anywhere. That's the intention of this project. Controls written using these standard APIs,
that can work anywhere, are called .NET Universal Controls.

Here's how it works:
1. You create a .NET Universal Control by defining an interface for the control's public API, including
properties exposed and events emitted.

2. You also provide a control implementation class, which provides the core functionality of the control.
There you can respond to input events, using standard event APIs (based on those in WPF/WinUI/MAUI today, but standardized).
In response to events, you can update the control state and regenerate the control visual output.

    Universal Control visuals follow the same model as WPF/WinUI/MAUI today - a control is basically a tree of UI objects,
shape UI objects used for retained mode drawn UI or other controls that are composed together. The control
defines what this tree is, and updates it, in order to define its visual look.

3. Now say a user wants to use an Universal Control in their .NET MAUI app. So, like any other control, they start by
adding the assembly to their client app, say via NuGet. At the point the magic of source generators comes into play,
generating the MAUI specific glue code, where the control properties turn into MAUI BindableProperties,
to be a proper native MAUI control. The Universal Control is just a .NET Standard assembly - it works
everywhere (normally, though it can use multitargetting and include framework specific code if needed). It's the source
generator that turns the Universal Control into a MAUI native control, functioning like any other MAUI native control.

    At that point, the user can use the control in their MAUI XAML, set control properties including thru bindings,
    define control styles, etc. It works like any other MAUI native control, because it is. But because it's an
Universal control, it can also be used in WPF, WinForms, and other frameworks, acting like native controls there too.

.NET Universal Controls aims to help solve these problems:

**Grow the .NET UI control ecosystem** - Writing a single control that can target several UI
frameworks means it's easier to write controls and they can target a bigger set of users. This
helps control vendors, community members that build controls, and Microsoft as it builds out first
party controls - cheaper + wider reach should mean more controls in the ecosystem. For Microsoft controls,
possibilities include cross platform Fluent UI or controls that interoperate with MS services,
like the MS Graph controls [here](https://docs.microsoft.com/en-us/windows/communitytoolkit/graph/controls/peoplepicker).

**Reduce .NET UI Fragementation** - Today there are several XAML UI frameworks (WPF, UWP, WinUI, Xamarin.Forms,
.NET MAUI, Uno, Avalonia, etc.). Even though they are very similar, they are incompatible - controls and other
code developed for one framework don't work on others.
This project is similar in some ways to [XAML Standard](https://github.com/microsoft/xaml-standard), but this is a binary
standard, not just aligned naming conventions. A binary standard is much more useful, at it allows writing shared code.
As the standard is based on WPF/UWP/WinUI, it means that it isn't a big leap to take an existing WPF/UWP/WinUI control
definition (something like [this](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/controls/button-styles-and-templates?view=netframeworkdesktop-4.8)
for instance, contructed out of shape primitives, visual states, and storyboards) and make it a cross platform control.

# Documentation

Doc is a work in progress. The latest doc is here (though currently only accessible by Microsoft internals, unfortunately):

[Reference (API) doc](https://review.docs.microsoft.com/en-us/dotnet/api/microsoft.standardui?view=dotnet-standard-ui&branch=pr-en-us-4)

[Conceptual doc](https://review.docs.microsoft.com/en-us/dotnet/standard-ui/?branch=main)

# FAQ

**How is this different than other embedding approaches, like XAML islands?**

Universal Controls interoperate much more seamlessly with the host platform - they act like native controls because they are. XAML based host platforms, like WPF and MAUI, can set Universal Control properties in XAML and use bindings and styles to set properties, just like normal controls. VS tools like the (design time) property editor and (runtime) live property explorer all work, same as native controls.

Importantly, Universal Controls embrace **composability** - native UI can contain (compose) Universal Controls and Standard Controls can
contain (compose) native UI - you can mix and match in the visual tree. For example, a button Universal Control can have a Content property
for the content of the button, drawn inside the button border. When the control is used in WPF XAML, the Content property XAML can
use native WPF controls, just like a normal WPF button.

**What about layout - controls that just position other controls?**

Another advantage of composability is that this tech enables standardized layout controls. The built in `StackPanel` and `Grid`
controls - and their more modern and concise `HorizontalStack`/`VerticalStack` and `HorizontalGrid`/`VerticalGrid` can be used in
any host framework. No more different StackLayout vs StackPanel differences between MAUI and WPF/WinUI - now you can use the same
layout controls everywhere, with the same modern conveniences making for more concise XAML.

# Architecture and APIs

The API is interface based. For instance, an ellipse is `Microsoft.AnywhereControls.Shapes.IEllipse`. Users of the API always use the interface.

In terms of implementation, UI platforms can implement the interface directly OR it can be implemented by a wrapper object (which typically lives in this repo). Having both options available provides maximum flexibility.

For new UI platforms, like WinUI3 and .NET MAUI, ideally they have their native
`Ellipse` object implement `IEllipse` directly. That helps enforce API naming consistency and is slightly more efficient.

Or the interface can be implemented via a wrapper, which requires no changes to the underlying UI platform at all. That's a good choice for platforms like WPF.

The API interfaces are all defined [here](src/AnywhereControls). Implementations for the different UI frameworks are created through a mix of [code generation](src/AnywhereControls.Analyzers) from those interfaces and hand coding.

### Control hierarchy

[IUIElement](src/AnywhereControls.CommonTypes/IUIElement.cs),
[IUIElementCollection](src/AnywhereControls/Controls/IUIElementCollection.cs),
[IControl](src/AnywhereControls/Controls/IControl.cs),
[IUserControl](src/AnywhereControls/Controls/IUserControl.cs)

### Shapes and Drawing

_Shapes:_
[IShape](src/AnywhereControls/Shapes/IShape.cs),
[IEllipse](src/AnywhereControls/Shapes/IEllipse.cs),
[ILine](src/AnywhereControls/Shapes/ILine.cs),
[IPath](src/AnywhereControls/Shapes/IPath.cs),
[IPolygon](src/AnywhereControls/Shapes/IPolygon.cs),
[IPolyline](src/AnywhereControls/Shapes/IPolyline.cs),
[IRectangle](src/AnywhereControls/Shapes/IRectangle.cs)

_Geometries:_
[IGeometry](src/AnywhereControls/Media/IGeometry.cs),
[IArcSegement](src/AnywhereControls/Media/IArcSegement.cs),
[IBezierSegment](src/AnywhereControls/Media/IBezierSegment.cs),
[ILineSegment](src/AnywhereControls/Media/ILineSegment.cs),
[IPathFigure](src/AnywhereControls/Media/IPathFigure.cs),
[IPathGeometry](src/AnywhereControls/Media/IPathGeometry.cs),
[IPathSegment](src/AnywhereControls/Media/IPathSegment.cs),
[IPolyBezierSegment](src/AnywhereControls/Media/IPolyBezierSegment.cs)
[IPolyQuadraticBezierSegment](src/AnywhereControls/Media/IPolyQuadraticBezierSegment.cs)
[IQuadraticBezierSegment](src/AnywhereControls/Media/IQuadraticBezierSegment.cs)

_Transforms:_
[ITransform](src/AnywhereControls/Media/ITransform.cs),
[IRotateTransform](src/AnywhereControls/Media/IRotateTransform.cs),
[IScaleTransform](src/AnywhereControls/Media/IScaleTransform.cs),
[ITransformGroup](src/AnywhereControls/Media/ITransformGroup.cs),
[ITranslateTransform](src/AnywhereControls/Media/ITranslateTransform.cs)

_Brushes and Strokes:_
[BrushMappingMode](src/AnywhereControls/Media/BrushMappingMode.cs),
[FillMode](src/AnywhereControls/Media/FillMode.cs),
[GradientStreamMethod](src/AnywhereControls/Media/GradientStreamMethod.cs),
[IGradientBrush](src/AnywhereControls/Media/IGradientBrush.cs),
[ILinearGradientBrush](src/AnywhereControls/Media/ILinearGradientBrush.cs),
[IRadialGradientBrush](src/AnywhereControls/Media/IRadialGradientBrush.cs),
[ISolidColorBrush](src/AnywhereControls/Media/ISolidColorBrush.cs),
[PenLineCap](src/AnywhereControls/Media/PenLineCap.cs),
[PenLineJoin](src/AnywhereControls/Media/PenLineJoin.cs),
[SweepDirection](src/AnywhereControls/Media/SweepDirection.cs)

All of these APIs are nearly identical to UWP, WPF, and Xamarin.Forms 4.8 (which added shape and brush support).

Shapes are [IUIElements](src/AnywhereControls/IUIElement.cs) that can be used as children to build the visual representation of a control, often as part of a control template. That's the same model used by UWP/WPF/Forms.

Geometries, transforms, and brushes all help support the drawing.

### Text

[ITextBlock](src/AnywhereControls/Controls/ITextBlock.cs),
[FontStyle](src/AnywhereControls/Text/FontStyle.cs),
[FontWeight](src/AnywhereControls/Text/FontWeight.cs),
[FontWeights](src/AnywhereControls/Text/FontWeights.cs)

### Other controls

[IBorder](src/AnywhereControls/Controls/IBorder.cs)

### Layout

[IPanel](src/AnywhereControls/Controls/IPanel.cs),
[IStackPanel](src/AnywhereControls/Controls/IStackPanel.cs),
[IGrid](src/AnywhereControls/Controls/IGrid.cs),
[ICanvas](src/AnywhereControls/Controls/ICanvas.cs)

namespace AnywhereUI.Controls;

public abstract class AnywhereControl : AnywhereUIElement, IAnywhereControl
{
    protected IUIElement? _buildContent;
    private bool _buildContentInvalid = true;

    protected override IUIElement? SingleChild => _buildContent;

    IUIElement? IAnywhereControl.Content => _buildContent;

    protected override Size MeasureOverride(Size availableSize)
    {
        if (_buildContentInvalid)
        {
            IUIElement? oldContent = _buildContent;
            _buildContent = Build();
            OnSingleChildChanged(oldContent, _buildContent);

            _buildContentInvalid = false;
        }

        // By default, return the size of the content
        if (_buildContent != null)
        {
            _buildContent.Measure(availableSize);
            return _buildContent.DesiredSize;
        }

        return base.MeasureOverride(availableSize);
    }

    protected override Size ArrangeOverride(Size finalSize)
    {
        // By default, give all the space to the content
        if (_buildContent != null)
        {
            var finalRect = new Rect(0, 0, finalSize.Width, finalSize.Height);
            _buildContent.Arrange(finalRect);
        }

        return base.ArrangeOverride(finalSize);
    }

    protected abstract IUIElement? Build();
}

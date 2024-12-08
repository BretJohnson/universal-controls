namespace AnywhereUI
{
    public enum TextWrapping
    {
        /// <summary>
        /// No line wrapping is performed.
        /// </summary>
        NoWrap = 1,

        /// <summary>
        /// 	
        /// Line breaking occurs if a line of text overflows beyond the available width of its container. Line breaking occurs
        /// even if the text logic can't determine any line break opportunity. For example, if a very long word is constrained
        /// in a fixed-width container that can't scroll, it will wrap at a point that might be in the middle of a word.
        /// </summary>
        Wrap = 2,

        /// <summary>
        /// Line-breaking occurs if the line overflows beyond the available block width. A line may overflow beyond the block
        /// width if the text logic can't determine a line break opportunity. For example, if a very long word is constrained
        /// in a fixed-width container that can't scroll, it will overflow the long word and continue the text after the long
        /// word on the next line. Not supported by all controls; see Remarks.
        /// </summary>
        WrapWholeWords = 0
    }
}

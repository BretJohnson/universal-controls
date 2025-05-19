using System.IO;

namespace AnywhereUI.SourceGenerator
{
    public class SourceLine
    {
        public int Indent { get; }
        public string Text { get; }

        public SourceLine(int indent, string text)
        {
            Indent = indent;
            Text = text;
        }

        public void Write(TextWriter textWriter)
        {
            for (int i = 0; i < Indent; ++i)
                textWriter.Write(' ');
            textWriter.WriteLine(Text);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace UniversalUI.SourceGenerator
{
    public class Source
    {
        public static string LineEnding = Environment.NewLine;

        private Usings? _usings;
        private List<SourceLine> _lines = new List<SourceLine>();
        private int _indent = 0;

        public Context Context { get; }

        public Usings Usings
        {
            get
            {
                if (_usings == null)
                    throw new UserViewableException("Source doesn't contain usings");
                return _usings;
            }
        }

        public Source(Context context, Usings usings)
        {
            Context = context;
            _usings = usings;
        }

        public Source(Context context)
        {
            Context = context;
            _usings = null;
        }

        public void AddBlankLine()
        {
            AddLine("");
        }

        public void AddBlankLineIfNonempty()
        {
            if (_lines.Count > 0)
                AddBlankLine();
        }

        public void Add(string text)
        {
            if (text.Contains("\n"))
            {
                text = text.Replace("\r", "");

                string[] textLines = text.Split('\n');
                AddLines(textLines);
            }
            else
            {
                AddLine(text);
            }
        }

        public void AddLine(string text)
        {
            var sourceLine = new SourceLine(_indent, text);
            _lines.Add(sourceLine);
        }

        public void AddLines(params string[] lines)
        {
            foreach (var line in lines)
                AddLine(line);
        }

        public void AddProperty(string propertyDeclaration, string getter, string setter)
        {
            AddLine(propertyDeclaration);
            AddLine("{");

            using (Indent())
            {
                AddLine($"get => {getter};");
                AddLine($"set => {setter};");
            }

            AddLine("}");
        }

        public bool IsEmpty => _lines.Count == 0;

        public IEnumerable<SourceLine> SourceLines => _lines;

        public IndentRestorer Indent()
        {
            IndentRestorer indentRestorer = new IndentRestorer(this, _indent);
            _indent += Context.IndentSize;
            return indentRestorer;
        }

        public void RestoreIndent(int previousIndent)
        {
            _indent = previousIndent;
        }

        public void AddSource(Source source)
        {
            foreach (SourceLine sourceLine in source._lines)
            {
                if (_indent == 0)
                    _lines.Add(sourceLine);
                else _lines.Add(new SourceLine(_indent + sourceLine.Indent, sourceLine.Text));
            }
        }

        public void WriteToFile(string directory, string fileName)
        {
            Directory.CreateDirectory(directory);

            string destinationFilePath = Path.Combine(directory, fileName);
            using (TextWriter textWriter = File.CreateText(destinationFilePath))
            {
                textWriter.NewLine = LineEnding;
                Write(textWriter);
            }
        }

        public void Write(TextWriter textWriter)
        {
            foreach (SourceLine line in _lines)
                line.Write(textWriter);
        }

        public class IndentRestorer : IDisposable
        {
            private Source _source;
            private int _previousIndent;

            public IndentRestorer(Source source, int previousIndent)
            {
                _source = source;
                _previousIndent = previousIndent;
            }

            public void Dispose()
            {
                _source.RestoreIndent(_previousIndent);
            }
        }
    }
}

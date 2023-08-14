using System;
using System.Collections.Generic;
using CommonUI;

namespace AnywhereControls
{
    public readonly struct Points
    {
        private readonly Point[] _points;

        public static readonly Points Default = new Points(Array.Empty<Point>());

        public Points(Point[] points)
        {
            _points = points;
        }

        public Points(List<Point> points)
        {
            _points = points.ToArray();
        }

        public readonly int Length => _points.Length;

        public readonly Point this[int index] => _points[index];
    }
}

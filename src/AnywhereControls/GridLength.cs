using System;

namespace Microsoft.StandardUI
{
    /// <summary>
    /// Represents a measurement for control logic that explicitly supports Star (*) sizing and Auto sizing.
    /// </summary>
    public struct GridLength
    {
        public static readonly GridLength Auto = new(1.0, GridUnitType.Auto);
        public static readonly GridLength Star = new(1.0, GridUnitType.Star);
        public static readonly GridLength Default = Star;

        private readonly double _unitValue;
        private readonly GridUnitType _unitType;

        public GridLength(double pixels) : this(pixels, GridUnitType.Pixel)
        {
        }

        public GridLength(double value, GridUnitType type)
        {
            if (!IsFinite(value) || value < 0.0)
            {
                throw new ArgumentException("value");
            }

            if (type != 0 && type != GridUnitType.Pixel && type != GridUnitType.Star)
            {
                throw new ArgumentException("value");
            }

            _unitValue = ((type == GridUnitType.Auto) ? 1.0 : value);
            _unitType = type;
        }

        public GridUnitType GridUnitType => _unitType;

        public bool IsAbsolute => _unitType == GridUnitType.Pixel;

        public bool IsAuto => _unitType == GridUnitType.Auto;

        public bool IsStar => _unitType == GridUnitType.Star;

        public double Value
        {
            get
            {
                if (_unitType != GridUnitType.Auto)
                {
                    return _unitValue;
                }

                return Auto._unitValue;
            }
        }

        public static implicit operator GridLength(double pixels) => new GridLength(pixels);

        internal static bool IsFinite(double value)
        {
            if (!double.IsNaN(value))
            {
                return !double.IsInfinity(value);
            }

            return false;
        }
    }
}

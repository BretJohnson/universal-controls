﻿// Copyright (c) Aloïs DENIEL. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UniversalUI;

namespace Microcharts
{
    /// <summary>
    /// A data entry for a chart.
    /// </summary>
    public class ChartEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microcharts.ChartEntry"/> class.
        /// </summary>
        /// <param name="value">The entry value.</param>
        public ChartEntry(float value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public double Value { get; }

        /// <summary>
        /// Gets or sets the caption label.
        /// </summary>
        /// <value>The label.</value>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the label associated to the value.
        /// </summary>
        /// <value>The value label.</value>
        public string ValueLabel { get; set; }

        /// <summary>
        /// Gets or sets the color of the fill.
        /// </summary>
        /// <value>The color of the fill.</value>
        public Color Color { get; set; } = Colors.Black;

        /// <summary>
        /// Gets or sets the color of the text (for the caption label).
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor { get; set; } = Colors.Gray;
    }
}

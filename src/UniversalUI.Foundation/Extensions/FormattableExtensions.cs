// This file is copied, with modifications, from the Uno project.

// ******************************************************************
// Copyright � 2015-2018 Uno Platform Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ******************************************************************
using System;
using System.Globalization;

namespace UniversalUI.Extensions
{
	internal static class FormattableExtensions
	{
		public static string ToStringInvariant<T>(this T number) where T : IFormattable
		{
			return number.ToString(null, CultureInfo.InvariantCulture);
		}
	}
}

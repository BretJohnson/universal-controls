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

namespace UniversalUI.Extensions
{
	/// <summary>
	/// Provides Extensions Methods for ICollection.
	/// </summary>
	internal static class CollectionExtensions
	{
		/// <summary>
		/// Projects the specified array to another array.
		/// </summary>
		public static TResult[] SelectToArray<TSource, TResult>(this TSource[] source, Func<TSource, TResult> selector)
		{
			var output = new TResult[source.Length];

			for (int i = 0; i < output.Length; i++)
			{
				output[i] = selector(source[i]);
			}

			return output;
		}
	}
}

using System.Collections.Generic;
using UnityEngine;

namespace P1.Core
{
	public static class ColorUtils
	{
		private const int Divider = 9;

		private static readonly Dictionary<int, string> RemainderToHexColor = new()
		{
			{ 1, "#2A3A9C" },
			{ 2, "#ADE4FF" },
			{ 3, "#FFA96E" },
			{ 4, "#7682CC" },
			{ 5, "#D49B87" },
			{ 6, "#53D492" },
			{ 7, "#9C6703" },
			{ 8, "#A83B7E" }
		};

		public static bool TryGetCircleColor(int number, out Color color)
		{
			color = default;
			var remainder = number % Divider;

			return RemainderToHexColor.TryGetValue(remainder, out var hexColor)
				&& ColorUtility.TryParseHtmlString(hexColor.ToLower(), out color) ;
		}
	}
}
using System.Collections.Generic;
using UnityEngine;

namespace P1.Core
{
	public static class ColorUtils
	{
		private const int Divider = 9;

		private static readonly Dictionary<int, Color> _remainderToColor = new ();

		static ColorUtils()
		{
			ParseColors((1, "2A3A9C"),
				(2, "ADE4FF"),
				(3, "FFA96E"),
				(4, "7682CC"),
				(5, "D49B87"),
				(6, "53D492"),
				(7, "9C6703"),
				(8, "A83B7E"));
		}

		private static void ParseColors(params (int, string)[] remainderToColors)
		{
			foreach (var remainderToColor in remainderToColors)
			{
				if (ColorUtility.TryParseHtmlString(remainderToColor.Item2, out var color))
				{
					_remainderToColor.Add(remainderToColor.Item1, color);
				}
			}
		}

		public static Color GetColorByNumber(int number)
		{
			var returnValue = Color.black;

			var remainder = number % Divider;

			if (_remainderToColor.TryGetValue(remainder, out var color))
			{
				returnValue = color;
			}

			return returnValue;
		}
	}
}
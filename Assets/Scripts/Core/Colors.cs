using UnityEngine;

namespace P1.Core
{
	public static class Colors
	{
		public static Color Two => _two;
		public static Color Three => _three;
		public static Color Four => _four;
		public static Color Five => _five;
		public static Color Six => _six;
		public static Color Seven => _seven;
		public static Color Eight => _eight;
		public static Color Nine => _nine;

		private static readonly Color _two;
		private static readonly Color _three;
		private static readonly Color _four;
		private static readonly Color _five;
		private static readonly Color _six;
		private static readonly Color _seven;
		private static readonly Color _eight;
		private static readonly Color _nine;

		static Colors()
		{
			TrySetColor("2A3A9C", out _two);
			TrySetColor("ADE4FF", out _three);
			TrySetColor("FFA96E", out _four);
			TrySetColor("7682CC", out _five);
			TrySetColor("D49B87", out _six);
			TrySetColor("53D492", out _seven);
			TrySetColor("9C6703", out _eight);
			TrySetColor("A83B7E", out _nine);
		}

		private static bool TrySetColor(string hexColor, out Color color)
		{
			return ColorUtility.TryParseHtmlString(hexColor, out color);
		}
	}
}
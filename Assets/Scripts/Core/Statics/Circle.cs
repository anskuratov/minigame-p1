using UnityEngine;

namespace P1.Core
{
	public readonly struct Circle
	{
		public readonly int Number;
		public readonly Vector2 Position;

		public Circle(int number, Vector2 position)
		{
			Number = number;
			Position = position;
		}
	}
}
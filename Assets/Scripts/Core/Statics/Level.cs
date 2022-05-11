using UnityEngine;

namespace P1.Core
{
	public readonly struct Level
	{
		public readonly int NextLevelId;
		public readonly Circle[] Circles;
		public readonly Vector2 GameFieldScale;

		public Level(int nextLevelId, Circle[] circles, Vector2 gameFieldScale)
		{
			NextLevelId = nextLevelId;
			Circles = circles;
			GameFieldScale = gameFieldScale;
		}
	}
}
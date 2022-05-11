using System;
using System.Collections.Generic;
using UnityEngine;

namespace P1.Core
{
	[Serializable]
	public struct Level
	{
		[SerializeField] private int _id;
		[SerializeField] private int _nextLevelId;
		[SerializeField] private Circle[] _circles;
		[SerializeField] private Vector2 _gameFieldScale;

		public int Id => _id;
		public int NextLevelId => _nextLevelId;
		public IReadOnlyCollection<Circle> Circles => _circles;
		public Vector2 GameFieldScale => _gameFieldScale;
	}
}
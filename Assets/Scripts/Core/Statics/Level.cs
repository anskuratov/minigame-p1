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
		[SerializeField] private float _timerValueInSeconds;

		public int Id => _id;
		public int NextLevelId => _nextLevelId;
		public IReadOnlyCollection<Circle> Circles => _circles;
		public Vector2 GameFieldScale => _gameFieldScale;
		public float TimerValueInSeconds => _timerValueInSeconds;

		public Level(int id, int nextLevelId, Circle[] circles, Vector2 gameFieldScale, float timerValueInSeconds)
		{
			_id = id;
			_nextLevelId = nextLevelId;
			_circles = circles;
			_gameFieldScale = gameFieldScale;
			_timerValueInSeconds = timerValueInSeconds;
		}
	}
}
using System;
using UnityEngine;

namespace P1.Core
{
	[Serializable]
	public struct Circle
	{
		[SerializeField] private int _number;
		[SerializeField] private Vector2 _position;

		public int Number => _number;
		public Vector2 Position => _position;

		public Circle(int number, Vector2 position)
		{
			_number = number;
			_position = position;
		}
	}
}
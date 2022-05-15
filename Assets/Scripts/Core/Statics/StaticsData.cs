using System.Collections.Generic;
using UnityEngine;

namespace P1.Core
{
	[CreateAssetMenu(menuName = "ScriptableObject/Statics")]
	public class StaticsData : ScriptableObject
	{
		[SerializeField] private Level[] _levels;

		public IReadOnlyCollection<Level> Levels => _levels;

		public void SetStaticsData(Level[] levels)
		{
			_levels = levels;
		}
	}
}
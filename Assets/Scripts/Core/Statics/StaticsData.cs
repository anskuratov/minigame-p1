using System.Collections.Generic;
using UnityEngine;

namespace P1.Core
{
	[CreateAssetMenu(menuName = "ScriptableObject/Statics")]
	public class StaticsData : ScriptableObject
	{
		[SerializeField] private Level[] _levels;
		[SerializeField] private Chapter[] _chapters;

		public IReadOnlyCollection<Level> Levels => _levels;
		public IReadOnlyCollection<Chapter> Chapters => _chapters;

		public void SetStaticsData(Level[] levels)
		{
			_levels = levels;
		}
	}
}
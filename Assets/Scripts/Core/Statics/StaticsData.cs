using System.Collections.Generic;

namespace P1.Core
{
	public readonly struct StaticsData
	{
		public IReadOnlyDictionary<int, Level> Levels => _levels;

		private readonly Dictionary<int, Level> _levels;

		public StaticsData(Dictionary<int, Level> levels)
		{
			_levels = levels;
		}
	}
}
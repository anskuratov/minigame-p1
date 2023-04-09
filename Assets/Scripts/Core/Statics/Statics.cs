using System.Collections.Generic;

namespace P1.Core
{
	public class Statics : IStatics
	{
		public IReadOnlyCollection<Chapter> Chapters => _staticsData.Chapters;

		private readonly StaticsData _staticsData;

		private readonly Dictionary<int, Level> _levels;

		public Statics(StaticsData staticsData)
		{
			_staticsData = staticsData;

			_levels = new Dictionary<int, Level>();

			ParseLevels();
		}

		public bool TryGetLevel(int levelId, out Level level)
		{
			return _levels.TryGetValue(levelId, out level);
		}

		private void ParseLevels()
		{
			foreach (var level in _staticsData.Levels)
			{
				_levels.Add(level.Id, level);
			}
		}
	}
}
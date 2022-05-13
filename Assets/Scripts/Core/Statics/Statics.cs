using System.Collections.Generic;

namespace P1.Core
{
	public class Statics : IStatics
	{
		private readonly Dictionary<int, Level> _levels;

		public Statics(StaticsData staticsData)
		{
			_levels = new Dictionary<int, Level>();

			ParseLevels(staticsData.Levels);
		}

		public bool TryGetLevel(int levelId, out Level level)
		{
			return _levels.TryGetValue(levelId, out level);
		}

		private void ParseLevels(IReadOnlyCollection<Level> levels)
		{
			foreach (var level in levels)
			{
				_levels.Add(level.Id, level);
			}
		}
	}
}
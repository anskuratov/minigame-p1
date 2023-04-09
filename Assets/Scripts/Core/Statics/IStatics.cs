using System.Collections.Generic;

namespace P1.Core
{
	public interface IStatics
	{
		IReadOnlyCollection<Chapter> Chapters { get; }

		bool TryGetLevel(int levelId, out Level level);
	}
}
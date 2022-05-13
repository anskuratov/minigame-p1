using System;

namespace P1.Core
{
	public class GameManager
	{
		public event Action<Level> OnLevelChanged;

		public Level Level { get; private set; }

		private readonly IStatics _statics;
		private readonly ProgressManager _progressManager;

		private int _circlesCount;

		public GameManager(IStatics statics, ProgressManager progressManager)
		{
			_statics = statics;
			_progressManager = progressManager;
		}

		public void Init()
		{
			SetLevel(_progressManager.CurrentLevelId);
		}

		public void ConnectCircle()
		{
			_circlesCount -= 1;
			CheckLevelComplete();
		}

		private void SetLevel(int levelId)
		{
			if (_statics.TryGetLevel(levelId, out var level))
			{
				_circlesCount = level.Circles.Count;
			}

			Level = level;

			OnLevelChanged?.Invoke(level);
		}

		private void CheckLevelComplete()
		{
			if (_circlesCount == 0)
			{
				_progressManager.CoinsCount += Level.Circles.Count;
				_progressManager.CurrentLevelId = Level.NextLevelId;

				SetLevel(_progressManager.CurrentLevelId);
			}
		}
	}
}
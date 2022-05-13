using System;

namespace P1.Core
{
	public class GameManager
	{
		public event Action OnLevelStarted;
		public event Action OnLevelFinished;
		public event Action OnCoinsChanged;
		public event Action<Circle> OnCircleConnected;

		public Level Level { get; private set; }
		public int CoinsCount { get; private set; }

		private readonly IStatics _statics;
		private readonly ProgressManager _progressManager;

		private int _circlesCount;

		public GameManager(IStatics statics)
		{
			_statics = statics;
			_progressManager = new ProgressManager();

			_progressManager.OnLevelChanged += SetLevel;
			_progressManager.OnCoinsChanged += SetCoins;
		}

		public void Init()
		{
			SetLevel(_progressManager.CurrentLevelId);
			SetCoins(_progressManager.CoinsCount);
		}

		public void StartLevel()
		{
			_circlesCount = Level.Circles.Count;
			OnLevelStarted?.Invoke();
		}

		public void ConnectCircle(Circle circle)
		{
			_circlesCount -= 1;
			CheckLevelComplete();

			OnCircleConnected?.Invoke(circle);
		}

		private void SetLevel(int levelId)
		{
			if (_statics.TryGetLevel(levelId, out var level))
			{
				Level = level;
			}
		}

		private void SetCoins(int coinsCount)
		{
			CoinsCount = coinsCount;
			OnCoinsChanged?.Invoke();
		}

		private void CheckLevelComplete()
		{
			if (_circlesCount == 0)
			{
				_progressManager.CoinsCount += Level.Circles.Count / 2;
				_progressManager.CurrentLevelId = Level.NextLevelId;

				OnLevelFinished?.Invoke();
			}
		}
	}
}
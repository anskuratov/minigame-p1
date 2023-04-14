using AS.Framework;
using TMPro;
using UnityEngine;

namespace P1.Core
{
	public class CountdownTimerUiView : View
	{
		[SerializeField] private TMP_Text _timerText;

		public TMP_Text TimerText => _timerText;
	}

	public class CountdownTimerUiViewController :
		ViewController<CountdownTimerUiView>,
		IUpdatable
	{
		private readonly GameManager _gameManager;
		private readonly IUpdater _updater;

		private float _currentTimerValue;

		public CountdownTimerUiViewController(GameManager gameManager, IUpdater updater)
		{
			_gameManager = gameManager;
			_updater = updater;
		}

		protected override void HandleInit()
		{
			_gameManager.OnLevelStarted += OnLevelStarted;
			_gameManager.OnLevelFinished += OnLevelFinished;

			_updater.Add(this);
		}

		public void Update(double deltaTime)
		{
			if (_currentTimerValue <= 0
				|| _gameManager.LevelResult != LevelResult.None
				|| _gameManager.IsPaused)
			{
				return;
			}

			var timerColor = View.TimerText.color = Color.white;
			if (_currentTimerValue <= 10)
			{
				timerColor = Color.red;
			}

			if (View.TimerText.color != timerColor)
			{
				View.TimerText.color = timerColor;
			}

			var minutes = Mathf.FloorToInt(_currentTimerValue / 60);
			var seconds = Mathf.FloorToInt(_currentTimerValue % 60);
			View.TimerText.text = $"{minutes.ToString("00")}:{seconds.ToString("00")}";

			_currentTimerValue -= (float) deltaTime;

			if (_currentTimerValue <= 0)
			{
				_gameManager.Defeat();
			}
		}

		private void OnLevelStarted()
		{
			var timerValueInSeconds = _gameManager.Level.TimerValueInSeconds;

			if (Mathf.Approximately(timerValueInSeconds, 0) == false)
			{
				_currentTimerValue = timerValueInSeconds;
				SetActive(true);
			}
			else
			{
				_currentTimerValue = 0;
				SetActive(false);
			}
		}

		private void OnLevelFinished()
		{
			View.TimerText.color = Color.white;
			SetActive(false);
		}
	}
}
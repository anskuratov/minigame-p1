using P1.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class ResultWindowView : View
	{
		[SerializeField] private Button _nextButton;
		[SerializeField] private Button _retryButton;
		[SerializeField] private Image _windowBackgroundImage;
		[SerializeField] private View _rewardContainer;
		[SerializeField] private TMP_Text _resultText;
		[SerializeField] private TMP_Text _coinsCountText;

		[Space]

		[Header("Settings")]
		[SerializeField] private Color _winColor;
		[SerializeField] private Color _defeatColor;

		public Button NextButton => _nextButton;
		public Button RetryButton => _retryButton;
		public View RewardContainer => _rewardContainer;
		public TMP_Text CoinsCountText => _coinsCountText;

		public void SetWin()
		{
			_resultText.text = "Well done!";
			_windowBackgroundImage.color = _winColor;
		}

		public void SetDefeat()
		{
			_resultText.text = "Try again!";
			_windowBackgroundImage.color = _defeatColor;
		}
	}

	public class ResultWindowViewController : ViewController<ResultWindowView>
	{
		private readonly GameManager _gameManager;

		public ResultWindowViewController(GameManager gameManager)
		{
			_gameManager = gameManager;
			_gameManager.OnLevelFinished += OnLevelFinished;
		}

		protected override void HandleInit()
		{
			View.NextButton.onClick.RemoveAllListeners();
			View.NextButton.onClick.AddListener(() =>
			{
				_gameManager.StartLevel();
				SetActive(false);
			});

			View.RetryButton.onClick.RemoveAllListeners();
			View.RetryButton.onClick.AddListener(() =>
			{
				_gameManager.StartLevel();
				SetActive(false);
			});

			Refresh();
		}

		protected override void HandleRefresh()
		{
			if (_gameManager.LevelResult == LevelResult.Win)
			{
				View.SetWin();
				View.CoinsCountText.text = _gameManager.CoinsReward.ToString();
			}
			else if (_gameManager.LevelResult == LevelResult.Defeat)
			{
				View.SetDefeat();
			}

			View.RewardContainer.SetActive(_gameManager.LevelResult == LevelResult.Win
				&& View.RewardContainer.isActiveAndEnabled);
			View.NextButton.gameObject.SetActive(_gameManager.LevelResult == LevelResult.Win);
			View.RetryButton.gameObject.SetActive(_gameManager.LevelResult == LevelResult.Defeat);
		}

		private void OnLevelFinished()
		{
			Refresh();
			SetActive(true);
		}
	}
}
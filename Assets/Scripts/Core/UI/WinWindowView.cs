using P1.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class WinWindowView : View
	{
		[SerializeField] private Button _continueButton;
		[SerializeField] private TMP_Text _coinsCountText;

		public Button ContinueButton => _continueButton;
		public TMP_Text CoinsCountText => _coinsCountText;
	}

	public class WinWindowViewController : ViewController<WinWindowView>
	{
		private readonly GameManager _gameManager;

		public WinWindowViewController(GameManager gameManager)
		{
			_gameManager = gameManager;

			_gameManager.OnLevelFinished += () =>
			{
				Refresh();
				SetActive(true);
			};
		}

		protected override void HandleInit()
		{
			View.ContinueButton.onClick.RemoveAllListeners();
			View.ContinueButton.onClick.AddListener(() =>
			{
				_gameManager.StartLevel();
				SetActive(false);
			});

			Refresh();
		}

		protected override void HandleRefresh()
		{
			View.CoinsCountText.text = (_gameManager.Level.Circles.Count / 2).ToString();
		}
	}
}
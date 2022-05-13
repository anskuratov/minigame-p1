using P1.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class WinWindowView : BaseView
	{
		[SerializeField] private Button _continueButton;
		[SerializeField] private TMP_Text _coinsCountText;

		public Button ContinueButton => _continueButton;
		public TMP_Text CoinsCountText => _coinsCountText;
	}

	public class WinWindowViewController : BaseViewController<WinWindowView, WinWindowViewController.InitData>
	{
		public readonly struct InitData
		{
		}

		private readonly GameManager _gameManager;

		public WinWindowViewController(GameManager gameManager)
		{
			_gameManager = gameManager;

			_gameManager.OnLevelChanged += () =>
			{
				Refresh();
				SetActive(true);
			};
		}

		protected override void HandleInit(InitData initData)
		{
			View.ContinueButton.onClick.RemoveAllListeners();
			View.ContinueButton.onClick.AddListener(() => SetActive(false));

			Refresh();
		}

		protected override void HandleRefresh()
		{
			View.CoinsCountText.text = _gameManager.Level.Circles.Count.ToString();
		}
	}
}
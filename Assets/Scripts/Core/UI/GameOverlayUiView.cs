using P1.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class GameOverlayUiView : View
	{
		[SerializeField] private Button _menuButton;
		[SerializeField] private TMP_Text _coinsCountText;

		public Button MenuButton => _menuButton;
		public TMP_Text CoinsCountText => _coinsCountText;
	}

	public class GameOverlayUiViewController :
		ViewController<GameOverlayUiView>
	{
		private readonly GameManager _gameManager;
		private readonly MenuWindowViewController _menuWindowViewController;

		public GameOverlayUiViewController(GameManager gameManager, MenuWindowViewController menuWindowViewController)
		{
			_gameManager = gameManager;
			_menuWindowViewController = menuWindowViewController;

			_gameManager.OnCoinsChanged += Refresh;
		}

		protected override void HandleInit()
		{
			View.MenuButton.onClick.AddListener(OnMenuButtonClick);
			Refresh();
		}

		protected override void HandleRefresh()
		{
			View.CoinsCountText.text = _gameManager.CoinsCount.ToString();
		}

		private void OnMenuButtonClick()
		{
			_menuWindowViewController.SetActive(true);
		}
	}
}
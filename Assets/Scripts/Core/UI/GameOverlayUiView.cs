using P1.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class GameOverlayUiView : BaseView
	{
		[SerializeField] private Button _menuButton;

		public Button MenuButton => _menuButton;
	}

	public class GameOverlayUiViewController :
		BaseViewController<GameOverlayUiView, GameOverlayUiViewController.InitData>
	{
		public readonly struct InitData
		{
		}

		private readonly MenuWindowViewController _menuWindowViewController;

		public GameOverlayUiViewController(MenuWindowViewController menuWindowViewController)
		{
			_menuWindowViewController = menuWindowViewController;
		}

		protected override void HandleInit(InitData initData)
		{
			View.MenuButton.onClick.AddListener(OnMenuButtonClick);
		}

		private void OnMenuButtonClick()
		{
			_menuWindowViewController.SetActive(true);
		}
	}
}
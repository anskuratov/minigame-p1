using AS.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class MenuWindowView : View
	{
		[SerializeField] private Button _continueButton;
		[SerializeField] private Button _retryButton;
		[SerializeField] private Button _shopButton;

		public Button ContinueButton => _continueButton;
		public Button RetryButton => _retryButton;
		public Button ShopButton => _shopButton;
	}

	public class MenuWindowViewController : ViewController<MenuWindowView>
	{
		private readonly GameManager _gameManager;

		public MenuWindowViewController(GameManager gameManager)
		{
			_gameManager = gameManager;
		}

		protected override void HandleInit()
		{
			View.ContinueButton.onClick.RemoveAllListeners();
			View.ContinueButton.onClick.AddListener(OnContinueButtonClick);
			
			View.RetryButton.onClick.RemoveAllListeners();
			View.RetryButton.onClick.AddListener(OnRetryButtonClick);

			View.ShopButton.onClick.RemoveAllListeners();
			View.ShopButton.onClick.AddListener(OnShopButtonClick);
		}

		private void OnContinueButtonClick()
		{
			_gameManager.Pause(false);
			SetActive(false);
		}

		private void OnRetryButtonClick()
		{
			_gameManager.Pause(false);

			_gameManager.StartLevel();
			SetActive(false);
		}

		private void OnShopButtonClick()
		{
		}
	}
}
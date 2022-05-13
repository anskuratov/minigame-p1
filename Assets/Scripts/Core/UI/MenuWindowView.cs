using P1.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class MenuWindowView : View
	{
		[SerializeField] private Button _continueButton;
		[SerializeField] private Button _shopButton;

		public Button ContinueButton => _continueButton;
		public Button ShopButton => _shopButton;
	}

	public class MenuWindowViewController : ViewController<MenuWindowView>
	{
		protected override void HandleInit()
		{
			View.ContinueButton.onClick.RemoveAllListeners();
			View.ContinueButton.onClick.AddListener(OnContinueButtonClick);

			View.ShopButton.onClick.RemoveAllListeners();
			View.ShopButton.onClick.AddListener(OnShopButtonClick);
		}

		private void OnContinueButtonClick()
		{
			SetActive(false);
		}

		private void OnShopButtonClick()
		{
		}
	}
}
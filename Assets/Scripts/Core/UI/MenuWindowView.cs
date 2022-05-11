using P1.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class MenuWindowView : BaseView
	{
		[SerializeField] private Button _continueButton;
		[SerializeField] private Button _shopButton;

		public Button ContinueButton => _continueButton;
		public Button ShopButton => _shopButton;
	}

	public class MenuWindowViewController : BaseViewController<MenuWindowView, MenuWindowViewController.InitData>
	{
		public struct InitData
		{
		}

		protected override void HandleInit(InitData initData)
		{
			View.ContinueButton.onClick.AddListener(OnContinueButtonClick);
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
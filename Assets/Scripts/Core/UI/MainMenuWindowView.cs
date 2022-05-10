using P1.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class MainMenuWindowView : BaseView
	{
		[SerializeField] private Button _startButton;

		public Button StartButton => _startButton;
	}

	public class MainMenuWindowViewController : BaseViewController<MainMenuWindowView, MainMenuWindowViewController.InitData>
	{
		public struct InitData
		{
		}

		protected override void HandleInit(InitData initData)
		{
		}
	}
}
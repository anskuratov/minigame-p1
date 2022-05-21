using P1.Framework;
using TMPro;
using UnityEngine;

namespace P1.Core
{
	public class MainOverlayUiView : View
	{
		[SerializeField] private TMP_Text _coinsCountText;

		public TMP_Text CoinsCountText => _coinsCountText;
	}

	public class MainOverlayUiViewController : ViewController<MainOverlayUiView>
	{
		private readonly GameManager _gameManager;

		public MainOverlayUiViewController(GameManager gameManager)
		{
			_gameManager = gameManager;
		}

		protected override void HandleInit()
		{
			_gameManager.OnCoinsChanged += Refresh;
			Refresh();
		}

		protected override void HandleRefresh()
		{
			View.CoinsCountText.text = _gameManager.CoinsCount.ToString();
		}
	}
}
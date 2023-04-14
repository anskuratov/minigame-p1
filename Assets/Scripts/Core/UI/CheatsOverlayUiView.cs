using AS.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class CheatsOverlayUiView : View
	{
		[SerializeField] private Button _devButton;
		[SerializeField] private GameObject _cheatsPanel;
		[SerializeField] private TMP_InputField _selectLevelInputField;
		[SerializeField] private Button _selectLevelButton;
		[SerializeField] private Button _resetProgressButton;

		public Button DevButton => _devButton;
		public GameObject CheatsPanel => _cheatsPanel;
		public TMP_InputField SelectLevelInputField => _selectLevelInputField;
		public Button SelectLevelButton => _selectLevelButton;
		public Button ResetProgressButton => _resetProgressButton;
	}

	public class CheatsOverlayUiViewController : ViewController<CheatsOverlayUiView>
	{
		private readonly GameManager _gameManager;
		private readonly ProgressManager _progressManager;

		public CheatsOverlayUiViewController(GameManager gameManager, ProgressManager progressManager)
		{
			_gameManager = gameManager;
			_progressManager = progressManager;
		}

		protected override void HandleInit()
		{
			View.DevButton.onClick.AddListener(OnDevButtonClicked);
			View.SelectLevelButton.onClick.AddListener(OnSelectLevelButtonClicked);
			View.ResetProgressButton.onClick.AddListener(OnResetProgressButtonClicked);

			View.CheatsPanel.SetActive(false);
		}

		private void OnDevButtonClicked()
		{
			View.CheatsPanel.SetActive(View.CheatsPanel.gameObject.activeSelf == false);
		}

		private void OnSelectLevelButtonClicked()
		{
			int.TryParse(View.SelectLevelInputField.text, out var levelToSelect);
			if (levelToSelect > 0)
			{
				_progressManager.CurrentLevelId = levelToSelect;
				_gameManager.StartLevel();
				View.CheatsPanel.SetActive(false);
			}
		}

		private void OnResetProgressButtonClicked()
		{
			_progressManager.CurrentLevelId = 1;
			_progressManager.CoinsCount = 0;
			_gameManager.StartLevel();
			View.CheatsPanel.SetActive(false);
		}
	}
}
using System.Text;
using P1.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class GameOverlayUiView : View
	{
		[SerializeField] private Button _menuButton;
		[SerializeField] private TMP_Text _levelText;
		[SerializeField] private CountdownTimerUiView _countdownTimerUiView;

		public Button MenuButton => _menuButton;
		public TMP_Text LevelText => _levelText;
		public CountdownTimerUiView CountdownTimerUiView => _countdownTimerUiView;
	}

	public class GameOverlayUiViewController :
		ViewController<GameOverlayUiView>
	{
		private readonly GameManager _gameManager;
		private readonly MenuWindowViewController _menuWindowViewController;
		private readonly IUpdater _frameUpdater;

		private readonly StringBuilder _levelStringBuilder;

		public GameOverlayUiViewController(GameManager gameManager, MenuWindowViewController menuWindowViewController,
			IUpdater frameUpdater)
		{
			_gameManager = gameManager;
			_menuWindowViewController = menuWindowViewController;
			_frameUpdater = frameUpdater;

			_levelStringBuilder = new StringBuilder();

			_gameManager.OnLevelStarted += Refresh;
		}

		protected override void HandleInit()
		{
			var countdownTimerController = new CountdownTimerUiViewController(_gameManager, _frameUpdater);
			countdownTimerController.SetView(View.CountdownTimerUiView);
			countdownTimerController.Init();

			View.MenuButton.onClick.AddListener(OnMenuButtonClick);

			Refresh();
		}

		protected override void HandleRefresh()
		{
			View.MenuButton.gameObject.SetActive(_gameManager.Level.Id > 3);

			_levelStringBuilder.Clear();
			_levelStringBuilder.Append("Level ");
			_levelStringBuilder.Append(_gameManager.Level.Id.ToString());
			View.LevelText.text = _levelStringBuilder.ToString();
		}

		private void OnMenuButtonClick()
		{
			_gameManager.Pause(true);
			_menuWindowViewController.SetActive(true);
		}
	}
}
using System.Text;
using AS.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace P1.Core
{
	public class GameOverlayUiView : View
	{
		[SerializeField] private Button _menuButton;
		[SerializeField] private TMP_Text _levelText;
		[SerializeField] private TMP_Text _fieldParametersText;
		[SerializeField] private CountdownTimerUiView _countdownTimerUiView;
		[SerializeField] private DifficultyProgressUiView _difficultyProgressUiView;

		public Button MenuButton => _menuButton;
		public TMP_Text LevelText => _levelText;
		public TMP_Text FieldParametersText => _fieldParametersText;
		public CountdownTimerUiView CountdownTimerUiView => _countdownTimerUiView;
		public DifficultyProgressUiView DifficultyProgressUiView => _difficultyProgressUiView;
	}

	public class GameOverlayUiViewController :
		ViewController<GameOverlayUiView>
	{
		private readonly IStatics _statics;
		private readonly GameManager _gameManager;
		private readonly MenuWindowViewController _menuWindowViewController;
		private readonly IUpdater _frameUpdater;

		private readonly StringBuilder _levelStringBuilder;
		private readonly StringBuilder _fieldParametersBuilder;

		public GameOverlayUiViewController(IStatics statics, GameManager gameManager, MenuWindowViewController menuWindowViewController,
			IUpdater frameUpdater)
		{
			_statics = statics;
			_gameManager = gameManager;
			_menuWindowViewController = menuWindowViewController;
			_frameUpdater = frameUpdater;

			_levelStringBuilder = new StringBuilder();
			_fieldParametersBuilder = new StringBuilder();

			_gameManager.OnLevelStarted += Refresh;
		}

		protected override void HandleInit()
		{
			var countdownTimerController = new CountdownTimerUiViewController(_gameManager, _frameUpdater);
			countdownTimerController.SetView(View.CountdownTimerUiView);
			countdownTimerController.Init();

			var difficultyProgressController = new DifficultyProgressUiViewController(_statics, _gameManager);
			difficultyProgressController.SetView(View.DifficultyProgressUiView);
			difficultyProgressController.Init();

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

			_fieldParametersBuilder.Clear();
			_fieldParametersBuilder.Append(_gameManager.Level.GameFieldScale.x);
			_fieldParametersBuilder.Append(":");
			_fieldParametersBuilder.Append(_gameManager.Level.GameFieldScale.y);
			View.FieldParametersText.text = _fieldParametersBuilder.ToString();
		}

		private void OnMenuButtonClick()
		{
			_gameManager.Pause(true);
			_menuWindowViewController.SetActive(true);
		}
	}
}
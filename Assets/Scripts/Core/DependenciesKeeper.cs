using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class DependenciesKeeper : MonoBehaviour
	{
		[Header("Configs")]
		[SerializeField] private StaticsData _staticsData;

		[Header("Dependencies")]
		[SerializeField] private FrameUpdater _frameUpdater;
		[SerializeField] private FixedUpdater _fixedUpdater;

		[SerializeField] private MenuWindowView _menuWindowView;
		[SerializeField] private WinWindowView _winWindowView;
		[SerializeField] private GameFieldSceneView _gameFieldSceneView;
		[SerializeField] private GameOverlayUiView _gameOverlayUiView;

		private void Awake()
		{
			var statics = new Statics(_staticsData);
			var gameManager = new GameManager(statics);
			gameManager.Init();

			var inputControllerFactory = new InputControllerFactory(_frameUpdater);
			inputControllerFactory.Create();

			var menuWindowController = new MenuWindowViewController();
			menuWindowController.SetView(_menuWindowView);
			menuWindowController.Init();
			menuWindowController.SetActive(false);

			var winWindowController = new WinWindowViewController(gameManager);
			winWindowController.SetView(_winWindowView);
			winWindowController.Init();
			winWindowController.SetActive(false);

			var gameFieldController = new GameFieldSceneViewController(gameManager);
			gameFieldController.SetView(_gameFieldSceneView);
			gameFieldController.Init();

			var gameOverlayController = new GameOverlayUiViewController(gameManager, menuWindowController);
			gameOverlayController.SetView(_gameOverlayUiView);
			gameOverlayController.Init();

			gameManager.StartLevel();
		}
	}
}
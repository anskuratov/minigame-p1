using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class DependenciesKeeper : MonoBehaviour
	{
		[Header("Configs")]
		[SerializeField] private StaticsData _staticsData;

		[Header("Dependencies")]
		[SerializeField] private MenuWindowView _menuWindowView;
		[SerializeField] private GameFieldSceneView _gameFieldSceneView;
		[SerializeField] private GameOverlayUiView _gameOverlayUiView;
		[SerializeField] private FrameUpdater _frameUpdater;
		[SerializeField] private FixedUpdater _fixedUpdater;
		[SerializeField] private Camera _camera;

		private void Awake()
		{
			var statics = new Statics(_staticsData);
			var progressManager = new ProgressManager();

			var inputControllerFactory = new InputControllerFactory(_fixedUpdater, _camera);
			var inputController = inputControllerFactory.Create();

			var menuController = new MenuWindowViewController();
			menuController.SetView(_menuWindowView);
			menuController.Init(new MenuWindowViewController.InitData());

			var gameFieldController = new GameFieldSceneViewController(statics, progressManager);
			gameFieldController.SetView(_gameFieldSceneView);
			gameFieldController.Init(new GameFieldSceneViewController.InitData());

			var gameOverlayController = new GameOverlayUiViewController(menuController);
			gameOverlayController.SetView(_gameOverlayUiView);
			gameOverlayController.Init(new GameOverlayUiViewController.InitData());
		}
	}
}
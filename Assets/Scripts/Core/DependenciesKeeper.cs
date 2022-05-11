using UnityEngine;

namespace P1.Core
{
	public class DependenciesKeeper : MonoBehaviour
	{
		[Header("Configs")]
		[SerializeField] private StaticsData _staticsData;

		[Header("Instances")]
		[SerializeField] private MainMenuWindowView _mainMenuWindowView;
		[SerializeField] private GameFieldSceneView _gameFieldSceneView;

		private void Awake()
		{
			var statics = new Statics(_staticsData);

			var progressManager = new ProgressManager();

			var mainMenuController = new MainMenuWindowViewController();
			mainMenuController.Init(new MainMenuWindowViewController.InitData());
			mainMenuController.SetView(_mainMenuWindowView);

			var gameFieldController = new GameFieldSceneViewController(statics, progressManager);
			gameFieldController.Init(new GameFieldSceneViewController.InitData());
			gameFieldController.SetView(_gameFieldSceneView);
		}
	}
}
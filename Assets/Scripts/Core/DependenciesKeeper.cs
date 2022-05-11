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
			mainMenuController.SetView(_mainMenuWindowView);
			mainMenuController.Init(new MainMenuWindowViewController.InitData());

			var gameFieldController = new GameFieldSceneViewController(statics, progressManager);
			gameFieldController.SetView(_gameFieldSceneView);
			gameFieldController.Init(new GameFieldSceneViewController.InitData());
		}
	}
}
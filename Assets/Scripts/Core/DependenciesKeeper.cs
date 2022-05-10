using UnityEngine;

namespace P1.Core
{
	public class DependenciesKeeper : MonoBehaviour
	{
		[SerializeField] private MainMenuWindowView mainMenuWindowView;
		[SerializeField] private GameFieldSceneView _gameFieldSceneView;

		private void Awake()
		{
			var mainMenuController = new MainMenuWindowViewController();
			mainMenuController.Init(new MainMenuWindowViewController.InitData());
			mainMenuController.SetView(mainMenuWindowView);

			var gameFieldController = new GameFieldSceneViewController();
			gameFieldController.Init(new GameFieldSceneViewController.InitData());
			gameFieldController.SetView(_gameFieldSceneView);
		}
	}
}
using AS.Framework;
using UnityEngine;

namespace P1.Core.Installer
{
	public readonly struct GameOverlaysInstallerInitData
	{
		public readonly IStatics Statics;
		public readonly GameManager GameManager;
		public readonly MenuWindowViewController MenuWindowViewController;
		public readonly IUpdater FrameUpdater;

		public GameOverlaysInstallerInitData(IStatics statics, GameManager gameManager, MenuWindowViewController menuWindowViewController, IUpdater frameUpdater)
		{
			Statics = statics;
			GameManager = gameManager;
			MenuWindowViewController = menuWindowViewController;
			FrameUpdater = frameUpdater;
		}
	}

	public class GameOverlaysInstaller : MonoBehaviour,
		IInitializable<GameOverlaysInstallerInitData>
	{
		[SerializeField] private GameOverlayUiView _gameOverlayPrefab;
		[SerializeField] private TutorialHandHintUiView _tutorialHandHintPrefab;

		public void Init(GameOverlaysInstallerInitData initData)
		{
			var gameOverlayUiView = Instantiate(_gameOverlayPrefab, transform);
			var gameOverlayUiViewController = new GameOverlayUiViewController(
				initData.Statics,
				initData.GameManager,
				initData.MenuWindowViewController,
				initData.FrameUpdater
			);
			gameOverlayUiViewController.SetView(gameOverlayUiView);
			gameOverlayUiViewController.Init();

			var tutorialHandHintUiView = Instantiate(_tutorialHandHintPrefab, transform);
			var tutorialHandHintUiViewController = new TutorialHandHintUiViewController(initData.GameManager);
			tutorialHandHintUiViewController.SetView(tutorialHandHintUiView);
			tutorialHandHintUiViewController.Init();
		}
	}
}
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

		[SerializeField] private CameraSceneView _cameraSceneView; 

		[SerializeField] private MenuWindowView _menuWindowView;
		[SerializeField] private ResultWindowView _resultWindowView;
		[SerializeField] private GameFieldSceneView _gameFieldSceneView;
		[SerializeField] private GameOverlayUiView _gameOverlayUiView;
		[SerializeField] private MainOverlayUiView _mainOverlayUiView;
		[SerializeField] private TutorialHandHintUiView _tutorialHandHint;

		private GameManager _gameManager;
		private GoogleMobileAds _googleMobileAds;

		private void Awake()
		{
			InitGame();
			InitAds();

			var inputControllerFactory = new InputControllerFactory(_frameUpdater);
			inputControllerFactory.Create();

			var cameraController = new CameraSceneViewController(_gameManager);
			cameraController.SetView(_cameraSceneView);
			cameraController.Init();

			var menuWindowController = new MenuWindowViewController(_gameManager);
			menuWindowController.SetView(_menuWindowView);
			menuWindowController.Init();
			menuWindowController.SetActive(false);

			var winWindowController = new ResultWindowViewController(_gameManager);
			winWindowController.SetView(_resultWindowView);
			winWindowController.Init();
			winWindowController.SetActive(false);

			var gameFieldController = new GameFieldSceneViewController(_gameManager);
			gameFieldController.SetView(_gameFieldSceneView);
			gameFieldController.Init();

			var gameOverlayController =
				new GameOverlayUiViewController(_gameManager, menuWindowController, _frameUpdater);
			gameOverlayController.SetView(_gameOverlayUiView);
			gameOverlayController.Init();

			var mainOverlayController = new MainOverlayUiViewController(_gameManager);
			mainOverlayController.SetView(_mainOverlayUiView);
			mainOverlayController.Init();

			var tutorialHandHintController = new TutorialHandHintUiViewController(_gameManager);
			tutorialHandHintController.SetView(_tutorialHandHint);
			tutorialHandHintController.Init();
		}

		private void Start()
		{
			_gameManager.StartLevel();
		}

		private void InitGame()
		{
			var statics = new Statics(_staticsData);
			_gameManager = new GameManager(statics);
			_gameManager.Init();
		}

		private void InitAds()
		{
			_googleMobileAds = new GoogleMobileAds();

			_ = new AdBannerController(_googleMobileAds);
			_ = new InterstitialAdController(_googleMobileAds, _gameManager);

			_googleMobileAds.Init();
		}
	}
}
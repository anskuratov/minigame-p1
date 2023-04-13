using P1.Core.Installer;
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

		[SerializeField] private GameFieldSceneView _gameFieldSceneView;

		[Header("Installers")]
		[SerializeField] private SystemOverlaysInstaller _systemOverlaysInstaller;
		[SerializeField] private MainOverlaysInstaller _mainOverlaysInstaller;
		[SerializeField] private WindowsInstaller _windowsInstaller;
		[SerializeField] private GameOverlaysInstaller _gameOverlaysInstaller;

		private IStatics _statics;
		private ProgressManager _progressManager;
		private GameManager _gameManager;
		private GoogleMobileAds _googleMobileAds;

		private void Awake()
		{
			InitGame();
			InitAds();

			var settingsController = new SettingsController();
			settingsController.Init();

			var inputControllerFactory = new InputControllerFactory(_frameUpdater);
			inputControllerFactory.Create();

			var cameraController = new CameraSceneViewController(_gameManager);
			cameraController.SetView(_cameraSceneView);
			cameraController.Init();

			var gameFieldController = new GameFieldSceneViewController(_gameManager);
			gameFieldController.SetView(_gameFieldSceneView);
			gameFieldController.Init();

			InitInstallers();
		}

		private void Start()
		{
			_gameManager.StartLevel();
		}

		private void InitGame()
		{
			_statics = new Statics(_staticsData);
			_progressManager = new ProgressManager();

			_gameManager = new GameManager(_statics, _progressManager);
			_gameManager.Init();
		}

		private void InitAds()
		{
			_googleMobileAds = new GoogleMobileAds();

			_ = new BannerAdController(_googleMobileAds);
			_ = new InterstitialAdController(_googleMobileAds, _gameManager);

			_googleMobileAds.Init();
		}

		private void InitInstallers()
		{
			_systemOverlaysInstaller.Init(new SystemOverlaysInstallerInitData(_gameManager, _progressManager));
			_mainOverlaysInstaller.Init(new MainOverlaysInstallerInitData(_gameManager));
			_windowsInstaller.Init(new WindowsInstallerInitData(_gameManager));
			_gameOverlaysInstaller.Init(new GameOverlaysInstallerInitData(
				_statics,
				_gameManager,
				_windowsInstaller.MenuWindowViewController,
				_frameUpdater
			));
		}
	}
}
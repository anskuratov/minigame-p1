using AS.Framework;
using UnityEngine;

namespace P1.Core.Installer
{
	public readonly struct MainOverlaysInstallerInitData
	{
		public readonly GameManager GameManager;

		public MainOverlaysInstallerInitData(GameManager gameManager)
		{
			GameManager = gameManager;
		}
	}

	public class MainOverlaysInstaller : MonoBehaviour,
		IInitializable<MainOverlaysInstallerInitData>
	{
		[SerializeField] private MainOverlayUiView _mainOverlayUiViewPrefab;

		public void Init(MainOverlaysInstallerInitData initData)
		{
			var mainOverlayUiView = Instantiate(_mainOverlayUiViewPrefab, transform);
			var mainOverlayUiViewController = new MainOverlayUiViewController(initData.GameManager);
			mainOverlayUiViewController.SetView(mainOverlayUiView);
			mainOverlayUiViewController.Init();
		}
	}
}
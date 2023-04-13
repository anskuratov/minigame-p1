using P1.Framework;
using UnityEngine;

namespace P1.Core.Installer
{
	public readonly struct WindowsInstallerInitData
	{
		public readonly GameManager GameManager;

		public WindowsInstallerInitData(GameManager gameManager)
		{
			GameManager = gameManager;
		}
	}

	public class WindowsInstaller : MonoBehaviour,
		IInitializable<WindowsInstallerInitData>
	{
		[SerializeField] private MenuWindowView _menuWindowViewPrefab;
		[SerializeField] private ResultWindowView _resultWindowViewPrefab;

		public MenuWindowViewController MenuWindowViewController { get; private set; }

		public void Init(WindowsInstallerInitData initData)
		{
			var menuWindowView = Instantiate(_menuWindowViewPrefab, transform);
			MenuWindowViewController = new MenuWindowViewController(initData.GameManager);
			MenuWindowViewController.SetView(menuWindowView);
			MenuWindowViewController.Init();
			MenuWindowViewController.SetActive(false);

			var resultWindowView = Instantiate(_resultWindowViewPrefab, transform);
			var resultWindowViewController = new ResultWindowViewController(initData.GameManager);
			resultWindowViewController.SetView(resultWindowView);
			resultWindowViewController.Init();
			resultWindowViewController.SetActive(false);
		}
	}
}
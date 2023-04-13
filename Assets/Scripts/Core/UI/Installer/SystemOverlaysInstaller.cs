using P1.Framework;
using UnityEngine;

namespace P1.Core.Installer
{
	public readonly struct SystemOverlaysInstallerInitData
	{
		public readonly GameManager GameManager;
		public readonly ProgressManager ProgressManager;

		public SystemOverlaysInstallerInitData(GameManager gameManager, ProgressManager progressManager)
		{
			GameManager = gameManager;
			ProgressManager = progressManager;
		}
	}

	public class SystemOverlaysInstaller : MonoBehaviour,
		IInitializable<SystemOverlaysInstallerInitData>
	{
		[SerializeField] private CheatsOverlayUiView _cheatsOverlayPrefab;

		public void Init(SystemOverlaysInstallerInitData initData)
		{
			var cheatsOverlayUiView = Instantiate(_cheatsOverlayPrefab, transform);
			var cheatsOverlayUiViewController = new CheatsOverlayUiViewController(initData.GameManager, initData.ProgressManager);
			cheatsOverlayUiViewController.SetView(cheatsOverlayUiView);
			cheatsOverlayUiViewController.Init();
		}
	}
}
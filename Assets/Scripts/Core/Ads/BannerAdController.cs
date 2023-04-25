using System.Collections;
using AS.Framework;
using GoogleMobileAds.Api;
using UnityEngine;

namespace P1.Core
{
	public class BannerAdController
	{
		private const string AdUnitId =
#if UNITY_ANDROID
			"ca-app-pub-5513167403112618/9015123859";
#elif UNITY_IPHONE
			"unknown";
#else
			"unused";
#endif

		private static readonly WaitForSeconds WaitForOneSecond = new (1);

		private bool IsLevelSuitableForAd => _gameManager.Level.Id >= 5;

		private readonly GameManager _gameManager;
		private readonly ICoroutines _coroutines;

		private bool _isEnabled;
		private BannerView _bannerView;

		private Coroutine _loadingBannerCoroutine;

		public BannerAdController(IGoogleMobileAds googleMobileAds, GameManager gameManager, ICoroutines coroutines)
		{
			googleMobileAds.OnInitialized += OnGoogleMobileAdsInitialized;
			_gameManager = gameManager;
			_coroutines = coroutines;

			_gameManager.OnLevelStarted += OnLevelStarted;
		}

		private void OnGoogleMobileAdsInitialized(InitializationStatus initializationStatus)
		{
			var allClassesInitializedSuccessfully = true;
			foreach (var adapterStatus in initializationStatus.getAdapterStatusMap())
			{
				allClassesInitializedSuccessfully &= adapterStatus.Value.InitializationState == AdapterState.Ready;
			}

			_isEnabled = allClassesInitializedSuccessfully;

			TryToLoadBanner();
		}

		private void OnLevelStarted()
		{
			TryToLoadBanner();
		}

		private void TryToLoadBanner()
		{
			if (_isEnabled && IsLevelSuitableForAd && _bannerView == null)
			{
				if (_loadingBannerCoroutine != null)
				{
					_coroutines.Stop(_loadingBannerCoroutine);
					_loadingBannerCoroutine = null;
				}

				_loadingBannerCoroutine = _coroutines.Run(DeferredLoadBannerAd());
			}
		}

		private IEnumerator DeferredLoadBannerAd()
		{
			yield return WaitForOneSecond;

			LoadBannerAd();
			_loadingBannerCoroutine = null;
		}

		private void DestroyBannerAd()
		{
			if (_bannerView != null)
			{
				_bannerView.Destroy();
				_bannerView = null;
			}
		}

		private void LoadBannerAd()
		{
			if (_bannerView == null)
			{
				CreateDefaultBanner();
			}

			var adRequest = new AdRequest.Builder()
				.AddKeyword("unity-admob-sample")
				.Build();

			_bannerView?.LoadAd(adRequest);
		}

		private void CreateDefaultBanner()
		{
			_bannerView = new BannerView(AdUnitId, AdSize.IABBanner, AdPosition.Bottom);
		}
	}
}
using GoogleMobileAds.Api;

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
		private bool IsLevelSuitableForAd => _gameManager.Level.Id >= 5;

		private readonly GameManager _gameManager;

		private bool _isEnabled;
		private BannerView _bannerView;

		public BannerAdController(IGoogleMobileAds googleMobileAds, GameManager gameManager)
		{
			googleMobileAds.OnInitialized += OnGoogleMobileAdsInitialized;
			_gameManager = gameManager;

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

			if (_isEnabled && IsLevelSuitableForAd && _bannerView == null)
			{
				LoadBannerAd();
			}
		}

		private void OnLevelStarted()
		{
			if (_isEnabled && IsLevelSuitableForAd && _bannerView == null)
			{
				LoadBannerAd();
			}
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
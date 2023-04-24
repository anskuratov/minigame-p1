using GoogleMobileAds.Api;

namespace P1.Core
{
	public class InterstitialAdController
	{
		private const string AdUnitId =
#if UNITY_ANDROID
			"ca-app-pub-5513167403112618/8178089873";
#elif UNITY_IPHONE
			"unknown";
#else
			"unused";
#endif

		private bool IsLevelSuitableForAd => _gameManager.Level.Id >= 9 && _gameManager.Level.Id % 3 == 0;

		private readonly GameManager _gameManager;

		private bool _isEnabled;
		private InterstitialAd _interstitialAd;

		public InterstitialAdController(IGoogleMobileAds googleMobileAds, GameManager gameManager)
		{
			googleMobileAds.OnInitialized += OnGoogleMobileAdsInitialized;
			_gameManager = gameManager;

			_gameManager.OnLevelStarted += OnLevelStarted;
			_gameManager.OnLevelFinished += OnLevelFinished;
		}

		private void OnGoogleMobileAdsInitialized(InitializationStatus initializationStatus)
		{
			var allClassesInitializedSuccessfully = true;
			foreach (var adapterStatus in initializationStatus.getAdapterStatusMap())
			{
				allClassesInitializedSuccessfully &= adapterStatus.Value.InitializationState == AdapterState.Ready;
			}

			_isEnabled = allClassesInitializedSuccessfully;
		}

		private void OnLevelStarted()
		{
			if (_isEnabled && IsLevelSuitableForAd)
			{
				DestroyInterstitialAd();
				LoadInterstitialAd();
			}
		}

		private void OnLevelFinished()
		{
			if (_isEnabled)
			{
				if (_interstitialAd != null
					&& _interstitialAd.CanShowAd()
					&& _gameManager.LevelResult == LevelResult.Win)
				{
					_interstitialAd.Show();
				}
			}
		}

		private void DestroyInterstitialAd()
		{
			if (_interstitialAd != null)
			{
				_interstitialAd.Destroy();
				_interstitialAd = null;
			}
		}

		private void LoadInterstitialAd()
		{
			var adRequest = new AdRequest.Builder()
				.AddKeyword("unity-admob-sample")
				.Build();

			InterstitialAd.Load(AdUnitId, adRequest, OnAdLoaded);
		}

		private void OnAdLoaded(InterstitialAd ad, LoadAdError error)
		{
			if (ad != null && error == null)
			{
				_interstitialAd = ad;
			}
		}
	}
}
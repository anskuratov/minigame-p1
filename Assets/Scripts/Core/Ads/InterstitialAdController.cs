using GoogleMobileAds.Api;

namespace P1.Core
{
	public class InterstitialAdController
	{
		private const string AdUnitId =
#if UNITY_ANDROID
			"ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
			"ca-app-pub-3940256099942544/4411468910";
#else
			"unused";
#endif

		private bool IsLevelSuitableForAd => _gameManager.Level.Id >= 9 && _gameManager.Level.Id % 3 == 0;

		private readonly GameManager _gameManager;

		private InterstitialAd _interstitialAd;

		private bool _isEnabled;

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
			if (_isEnabled)
			{
				if (_interstitialAd != null)
				{
					_interstitialAd.Destroy();
					_interstitialAd = null;
				}

				if (IsLevelSuitableForAd)
				{

					var adRequest = new AdRequest.Builder()
						.AddKeyword("unity-admob-sample")
						.Build();

					InterstitialAd.Load(AdUnitId, adRequest, OnAdLoaded);
				}
			}
		}

		private void OnAdLoaded(InterstitialAd ad, LoadAdError error)
		{
			if (ad != null && error == null)
			{
				_interstitialAd = ad;
			}
		}

		private void OnLevelFinished()
		{
			if (_isEnabled)
			{
				if (_interstitialAd != null && _interstitialAd.CanShowAd())
				{
					_interstitialAd.Show();
				}
			}
		}
	}
}
using GoogleMobileAds.Api;

namespace P1.Core
{
	public class AdBannerController
	{
		private const string AdUnitId =
#if UNITY_ANDROID
		"ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
		"ca-app-pub-3940256099942544/2934735716";
#else
		"unused";
#endif

		public AdBannerController(IGoogleMobileAds googleMobileAds)
		{
			googleMobileAds.OnInitialized += OnGoogleMobileAdsInitialized;
		}

		private void OnGoogleMobileAdsInitialized(InitializationStatus initializationStatus)
		{
			var allClassesInitializedSuccessfully = true;
			foreach (var adapterStatus in initializationStatus.getAdapterStatusMap())
			{
				allClassesInitializedSuccessfully &= adapterStatus.Value.InitializationState == AdapterState.Ready;
			}

			if (allClassesInitializedSuccessfully)
			{
				CreateDefaultBanner();
			}
		}

		private void CreateDefaultBanner()
		{
			_ = new BannerView(AdUnitId, AdSize.Banner, AdPosition.Bottom);
		}
	}
}
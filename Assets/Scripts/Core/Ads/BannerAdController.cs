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

		public BannerAdController(IGoogleMobileAds googleMobileAds)
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
			var bannerView = new BannerView(AdUnitId, AdSize.IABBanner, AdPosition.Bottom);
			bannerView.Show();
		}
	}
}
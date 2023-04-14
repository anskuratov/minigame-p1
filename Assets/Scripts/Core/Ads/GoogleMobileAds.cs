using System;
using AS.Framework;
using GoogleMobileAds.Api;

namespace P1.Core
{
	public class GoogleMobileAds : IInitializable,
		IGoogleMobileAds
	{
		public event Action<InitializationStatus> OnInitialized;

		public void Init()
		{
			MobileAds.Initialize(OnMobileAdsInitialized);
		}

		private void OnMobileAdsInitialized(InitializationStatus initializationStatus)
		{
			OnInitialized?.Invoke(initializationStatus);
		}
	}
}
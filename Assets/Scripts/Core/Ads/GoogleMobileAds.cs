using System;
using GoogleMobileAds.Api;
using P1.Framework;

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
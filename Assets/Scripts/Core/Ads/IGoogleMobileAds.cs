using System;
using GoogleMobileAds.Api;

namespace P1.Core
{
	public interface IGoogleMobileAds
	{
		event Action<InitializationStatus> OnInitialized;
	}
}
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceApp.ViewModels
{
   public class AppCenterHelper
    {

        public static async void TrackEvent(string eventName, Dictionary<string, string> properties)
        {
            if (await Analytics.IsEnabledAsync())
            {
                Analytics.TrackEvent(eventName, properties);

            }
        }

        public static async void TrackError(Exception ex, Dictionary<string, string> properties)
        {
            if (await Crashes.IsEnabledAsync())
            {
                Crashes.TrackError(ex, properties);

            }
        }
    }
}

﻿using Foundation;
using Octane.Xamarin.Forms.VideoPlayer.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ChillPlayer.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			#if ENABLE_TEST_CLOUD
			// requires Xamarin Test Cloud Agent
			Xamarin.Calabash.Start();
			#endif

            Forms.Init();

			// Test Cloud StyleId
			Forms.ViewInitialized += (sender, e) => {
				// http://developer.xamarin.com/recipes/testcloud/set-accessibilityidentifier-ios/
				if (null != e.View.StyleId) {
					e.NativeView.AccessibilityIdentifier = e.View.StyleId;
				}
			};

            FormsVideoPlayer.Init("C9107D52F8CDFAB6C552D5CA415D9A926BCEE319");
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}

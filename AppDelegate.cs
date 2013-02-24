using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace DrinkMeter
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		public LocalisationManager localisationManager;

		public UserDrinkRecordsController userDrinkRecordsController;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			//initialise localisation controller
			localisationManager = new LocalisationManager("./Assets/loc");
			localisationManager.initLocale("fr");

			//initialize user drink record controller
			userDrinkRecordsController = new UserDrinkRecordsController ();
			userDrinkRecordsController.loadUserDrinkModel ();


			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			//-> Instanciate the navigation controller
			var rootNavigationController = new UINavigationController();

			rootNavigationController.NavigationBar.TintColor = UIColor.Black;

			//-> Instanciate the Home window
			HomeScreen homeScreen = new HomeScreen();

			//-> add home view to controller
			rootNavigationController.PushViewController(homeScreen,false);

			//-> associate the rootNavigationControler to the window
			this.window.RootViewController = rootNavigationController;

			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}



using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace DrinkMeter
{
	public partial class HomeScreen : UIViewController
	{

		private AppDelegate appDelegate;

		CheckInScreen checkInScreen;
		ReportScreen reportScreen;
		SettingsScreen settingsScreen;


		public HomeScreen () : base ("HomeScreen", null)
		{
			appDelegate = (UIApplication.SharedApplication.Delegate as AppDelegate);
			this.Title = appDelegate.localisationManager.getText("screen_home_title");
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();


			//set buttons design :
			RectangleF rect;
			UIImage image;

			image = new UIImage ("./Assets/images/btn_checkin-"+appDelegate.localisationManager.locale+".png");
			rect = btnCheckIn.Frame;
			rect.Size = image.Size;
			btnCheckIn.Frame = rect;
			btnCheckIn.SetBackgroundImage (image,UIControlState.Normal);

			image = new UIImage ("./Assets/images/btn_reports-"+appDelegate.localisationManager.locale+".png");
			rect = btnReports.Frame;
			rect.Size = image.Size;
			btnReports.Frame = rect;
			btnReports.SetBackgroundImage (image,UIControlState.Normal);

			image = new UIImage ("./Assets/images/btn_params-"+appDelegate.localisationManager.locale+".png");
			rect = btnSettings.Frame;
			rect.Size = image.Size;
			btnSettings.Frame = rect;
			btnSettings.SetBackgroundImage (image,UIControlState.Normal);



			//-> add listener on btn checkin
			this.btnCheckIn.TouchUpInside += (sender, e) => 
			{
				//-> create checkin screen if not exists
				if (this.checkInScreen ==null)
					this.checkInScreen = new CheckInScreen();

				//-> change the view
				this.NavigationController.PushViewController(this.checkInScreen,true);
			};

			//-> addListener on btn Report
			this.btnReports.TouchUpInside += (sender, e) => 
			{
				//-> create checkin screen if not exists
				if (this.reportScreen ==null)
					this.reportScreen = new ReportScreen();
				
				//-> change the view
				this.NavigationController.PushViewController(this.reportScreen,true);
			};

			//-> addListener on btn Settings
			this.btnSettings.TouchUpInside += (sender, e) => 
			{
				if (this.settingsScreen==null)
					this.settingsScreen = new SettingsScreen();

				this.NavigationController.PushViewController(settingsScreen,true);
			};
		}

		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}


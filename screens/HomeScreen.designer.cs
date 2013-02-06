// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace DrinkMeter
{
	[Register ("HomeScreen")]
	partial class HomeScreen
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnCheckIn { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnReports { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSettings { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCheckIn != null) {
				btnCheckIn.Dispose ();
				btnCheckIn = null;
			}

			if (btnReports != null) {
				btnReports.Dispose ();
				btnReports = null;
			}

			if (btnSettings != null) {
				btnSettings.Dispose ();
				btnSettings = null;
			}
		}
	}
}

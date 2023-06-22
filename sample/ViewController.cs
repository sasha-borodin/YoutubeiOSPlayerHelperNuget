using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using YouTubeiOSPlayerHelper;

namespace sample
{
    public partial class ViewController : UIViewController
    {

        NSDictionary PlayerParams()
        {
            var _playerVars = new Dictionary<string, object>
            {
                {"controls" , 1 },
                {"playsinline" , 1},
                {"showinfo" , 0},
                {"modestbranding" , 1},
                {"rel", 0 },
                {"enablejsapi", 1 },
                {"start", 0}
            };
            return NSDictionary.FromObjectsAndKeys(_playerVars.Values.ToArray(), _playerVars.Keys.ToArray());
        }

        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            PlayerView.LoadWithVideoId("o-YBDTqX_ZU", PlayerParams());
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

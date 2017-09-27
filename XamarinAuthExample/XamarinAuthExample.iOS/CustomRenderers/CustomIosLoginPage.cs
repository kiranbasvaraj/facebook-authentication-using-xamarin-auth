using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using XamarinAuthExample.LoginPageForIosOnly;
using XamarinAuthExample.iOS.CustomRenderers;
using Xamarin.Auth;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(CustomIosLoginPage))]
[assembly: ExportRenderer(typeof(IosLoginPage), typeof(CustomIosLoginPage))]
namespace XamarinAuthExample.iOS.CustomRenderers
{
   public class CustomIosLoginPage:PageRenderer, ILogin
    {
        public event EventHandler LoginHandler;

        public async Task LoginToFb()
        {
            
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            
            // I've used the values from your original post
               var auth = new OAuth2Authenticator(
                clientId: "Your Facebook app id",
                scope: "basic",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));
             PresentViewController(auth.GetUI(), true, null);
            auth.Completed += (sender, eventArgs) => {
                // We presented the UI, so it's up to us to dismiss it on iOS.
                DismissViewController(true, null);
                // you may want to also do something to dismiss THIS viewcontroller, 
                // or else you'll keep seeing the login screen              
           
                if (eventArgs.IsAuthenticated)
                {
                    // Use eventArgs.Account to do wonderful things
                    // ...such as saving the token, and then getting some more detailed user info from the API
                    App.SaveToken(eventArgs);
                    AccountStore.Create().Save(eventArgs.Account, "Facebook");
                    LoginHandler?.Invoke(sender,eventArgs);
                }
                else
                {
                    // The user cancelled
                }
            };

           
        }

      
    }
}
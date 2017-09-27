using System;

using Android.App;
using Android.OS;
using Android.Widget;
using Xamarin.Auth;
using System.Threading.Tasks;
using Xamarin.Forms;
// this activity is not used in the implementation.
namespace XamarinAuthExample.Droid.Activities
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
       
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            await Task.Run(() =>
            {
                OAuth2Authenticator auth = new OAuth2Authenticator
            (
                clientId: "109487139734891",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")
                     );

                global::Android.Content.Intent ui_object = auth.GetUI(this);

                StartActivity(ui_object);
                auth.Completed += delegate (object s, AuthenticatorCompletedEventArgs e)
                {

                    if (e.IsAuthenticated)
                    {
                        //FbLoginStorage.IsSuccess = true;
                        Finish();
                    }
                    else
                    {
                       // FbLoginStorage.IsSuccess = false;
                        Toast.MakeText(this, "something went wrong", ToastLength.Short);
                    }
                    MessagingCenter.Send<LoginActivity>(this, "hi");
                };

            });


        }


    }
}
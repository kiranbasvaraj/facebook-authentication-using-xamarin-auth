using System;
using XamarinAuthExample.Droid.DependencyServices;
using System.Threading.Tasks;
using Xamarin.Auth;

[assembly: Xamarin.Forms.Dependency(typeof(FbLoginAndroid))]
namespace XamarinAuthExample.Droid.DependencyServices
{
    public class FbLoginAndroid : ILogin
    {

        public event EventHandler LoginHandler;
        public async Task LoginToFb()
        {
            await Task.Run(() =>
            {
                OAuth2Authenticator auth = new OAuth2Authenticator
                 (
                    clientId: "109487139734891",
                    scope: "",
                    authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                    redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")

                );
                var _contaxt = Xamarin.Forms.Forms.Context;
                global::Android.Content.Intent ui_object = auth.GetUI(_contaxt);

                _contaxt.StartActivity(ui_object);
                auth.Completed += delegate (object sender, AuthenticatorCompletedEventArgs e)
                {

                    LoginHandler?.Invoke(sender, e);
                    AccountStore.Create(_contaxt).Save(e.Account, "Facebook");

                };

            });

        }


    }


}
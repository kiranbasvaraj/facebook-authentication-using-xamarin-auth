using Xamarin.Auth;
using Xamarin.Forms;

namespace XamarinAuthExample
{
    public partial class App : Application
    {
       public  static AuthenticatorCompletedEventArgs LoginValues { get; set; }
        public static void  SaveToken(AuthenticatorCompletedEventArgs value)
        {
            LoginValues = value;
        }
        public App()
        {
            InitializeComponent();
            //OAuth2Authenticator auth = new OAuth2Authenticator
            //             (
            //                 clientId: "109487139734891",
            //                 scope: "",
            //                 authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
            //                 redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html")
            //                 // switch for new Native UI API
            //                 //      true = Android Custom Tabs and/or iOS Safari View Controller
            //                 //      false = Embedded Browsers used (Android WebView, iOS UIWebView)
            //                 //  default = false  (not using NEW native UI)
            //                // isUsingNativeUI: use_native_ui
            //             );
            //auth.Completed += Auth_Completed;
           MainPage = new XamarinAuthExample.MainPage();

           // MessagingCenter.Subscribe<MainACtivity, string>(this, "hi", (s, args) =>
           //{
           //    bool res = FbLoginStorage.IsSuccess;
           //    if (res)
           //    {
           //        Page page = new WelcomePage();
           //         //await Navigation.PushAsync(page);
           //     }
           //    else
           //    {
           //         // await DisplayAlert("alert", "login was not successfull", "ok");
           //     }
           //});
        }

        //private void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        //{
        //    if (e.IsAuthenticated)
        //    {
        //        MainPage = new XamarinAuthExample.MainPage();
        //    }
        //}

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

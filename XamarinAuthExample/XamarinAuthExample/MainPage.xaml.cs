using System;
using System.Collections.Generic;
using Xamarin.Auth;
using Xamarin.Forms;
using XamarinAuthExample.LoginPageForIosOnly;

namespace XamarinAuthExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var val =  DependencyService.Get<ILogin>();
            if (Device.OS==TargetPlatform.iOS)
            {
                await Navigation.PushAsync(new IosLoginPage());// only for ios
            }
          
            await val.LoginToFb();//android and ios
           
            val.LoginHandler += Val_LoginHanlder;



        }

        private void Val_LoginHanlder(object sender, EventArgs e)
        {
          var val=  e as AuthenticatorCompletedEventArgs;

            bool res = val.IsAuthenticated;
            if (res)
            {
                DisplayAlert("alert","login success","ok");
            }
            else
            {
                DisplayAlert("alert", "login not success", "ok");

            }
            //use this for retrieving account details.
            IEnumerable<Account> accounts = AccountStore.Create().FindAccountsForService("Facebook");
        }
    }
}

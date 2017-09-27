using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Auth;
using Xamarin.Forms;

namespace XamarinAuthExample.LoginPageForIosOnly
{
    public class IosLoginPage : ContentPage
    {
        public event EventHandler IosLoginHandler;
        public IosLoginPage()
        {
           // IEnumerable<Account> accounts  = AccountStore.Create().FindAccountsForService("Facebook");
        }
        
    }
}
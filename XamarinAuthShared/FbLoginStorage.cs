using System;
using Xamarin.Forms;

namespace XamarinAuthShared
{
    public static class FbLoginStorage
    {
        public static bool IsSuccess { get; set; }

         static FbLoginStorage()
        {
          //  MessagingCenter.Subscribe<FbLoginAndroid>
        }

    }
    public class CustomArgsShared : EventArgs
    {
        public bool IsSuccess;
        public CustomArgsShared(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}

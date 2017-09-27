using System;
using System.Threading.Tasks;

namespace XamarinAuthExample
{
    public interface ILogin
    {
        Task LoginToFb();
        event EventHandler LoginHandler;

    }
}

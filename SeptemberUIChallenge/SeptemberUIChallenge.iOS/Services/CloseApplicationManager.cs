using System.Threading;
using SeptemberUIChallenge.Services;

namespace SeptemberUIChallenge.iOS.Services
{
    public class CloseApplicationManager : ICloseApplicationManager
    {
        public void CloseApplication()
        {
            Thread.CurrentThread.Abort();
        }
    }
}
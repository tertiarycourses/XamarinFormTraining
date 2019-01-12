using System;
using Android.Content;
using Android.Net;

[assembly:Xamarin.Forms.Dependency(typeof(HPlusSports.Droid.NetworkManager))]
namespace HPlusSports.Droid
{
	public class NetworkManager : INetworkManager 
    {
        Context ctx = Android.App.Application.Context;

        public NetworkManager()
        {
        }

        public bool IsNetworkConnected()
        {
            var cSvc = (ConnectivityManager)ctx.GetSystemService(Context.ConnectivityService);
            return cSvc.ActiveNetworkInfo == null ? false : cSvc.ActiveNetworkInfo.IsConnected;
        }
    }
}

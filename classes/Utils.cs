using System;
using System.Net.NetworkInformation;

namespace securityalarm.classes
{
    public class Utils
    {
        public Utils (){}
       
        public bool isInternetConnected {
            get {return NetworkInterface.GetIsNetworkAvailable();}
        }
    }
}

    
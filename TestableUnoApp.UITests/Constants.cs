using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.UITest.Helpers.Queries;

namespace TestableUnoApp.UITests
{

    public class Constants
    {
        public readonly static string WebAssemblyDefaultUri = "https://localhost:44304/";
        public readonly static string iOSAppName = "com.companyname.TestableUnoApp";
        public readonly static string AndroidAppName = "com.companyname.TestableUnoApp";
        public readonly static string iOSDeviceNameOrId = "iPhone 13 iOS 15.0";

        public readonly static Platform CurrentPlatform = Platform.Android;
    }
}
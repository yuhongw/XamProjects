using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Really.Helpers
{
    class Helper
    {
        public static Stream GetResourceStream(string fn)
        {
            
#if __IOS__
            var resourcePrefix ="Really.IOS.";
#endif

#if __ANDROID__
            var resourcePrefix ="Really.Android.";
#endif

#if __WINDOWS_PHONE__
            var resourcePrefix ="Really.WinPhone.";
#endif

#if WINDOWS_UWP
            var resourcePrefix ="Really.UWP.";
#endif
            Debug.WriteLine("Using this resource prefix:" + resourcePrefix);
            var assembly = typeof(Really.MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{resourcePrefix}Resources.{fn}");
            

            return stream;
        }

        public static string GetResourceText(string fn)
        {
            Stream stream = GetResourceStream(fn);
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}

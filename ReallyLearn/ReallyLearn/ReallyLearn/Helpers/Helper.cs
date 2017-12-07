using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace ReallyLearn.Helpers
{
    class Helper
    {
        public static Stream GetResourceStream(string fn)
        {
            var assembly = typeof(ReallyLearn.MainPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"ReallyLearn.Resources.{fn}");
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

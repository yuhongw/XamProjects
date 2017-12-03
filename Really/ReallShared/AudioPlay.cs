using Plugin.SimpleAudioPlayer.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ReallShared
{
    public class AudioPlay
    {
        public static void Play(string fn)
        {
            ISimpleAudioPlayer player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(GetStreamFromFile(fn));
            player.Play();
        }

        private static Stream GetStreamFromFile(string fn)
        {
            var assembly = typeof(ReallShared.AudioPlay).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"ReallShared.Resources.{fn}");
            return stream;
        }
    }
}

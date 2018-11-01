using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Project_Memory_Card_Game
{
    public class SoundManager
    {
        private static MediaPlayer _mediaPlayer = new MediaPlayer();
        private static MediaPlayer _effectPlayer = new MediaPlayer();

        public static void PlayCorrect()
        {
            PlayEffect("project/correct.mp3");
        }

        private static void PlayEffect (string fileName)
        {
            _effectPlayer.Open(new Uri("project/correct.mp3", UriKind.Relative));
            _effectPlayer.Play();
        }
   
    }
}

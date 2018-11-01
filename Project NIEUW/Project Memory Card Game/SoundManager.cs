using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Project_Memory_Card_Game
{
    public class SoundManager
    {
        public static void PlayCorrect()
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.correct);
            audio.Play();
        }


   
    }
}

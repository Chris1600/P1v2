using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Project_Memory_Card_Game
{
    class CardFront
    {
        private ImageSource image;
        private int number;

        public CardFront(ImageSource image, int number)
        {
            this.image = image;
            this.number = number;
        }

        public int GetNumber()
        {
            return number;
        }

        public ImageSource GetImage()
        {
            return image;
        }

    }

    
}

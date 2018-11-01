using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Timers;
using System.Windows.Threading;

namespace Project_Memory_Card_Game
{
    class MemoryGrid
    {
        private int lastClicked = -1;
        private int lastClicked2 = -1;
        private Image lastClickedImage;
        private Grid grid;
        private int rows, cols;
        private bool match = false;
        private Image lastClickedImage2;
        private Image card2;
        private int Score1, Score2, streak, StreakScore = 0;
        private int beurt = 1;



        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello World!");
        }

        public MemoryGrid(Grid grid, int rows, int cols)
        {
            this.grid = grid;
            this.rows = rows;
            this.cols = cols;

            InitializeGrid();
            AddImage();
        }

        private void InitializeGrid()
        {
            for (int i = 0; i < rows; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            for (int i = 0; i < cols; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void AddImage()
        {
            List<CardFront> images = GetImagesList();

            Random random = new Random();

            int positie1 = 0;
            //int positie2 = 0;

            //int teller = 0;

            //bool buttonPressed2 = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Image ImageOnBacksideOfCard = new Image();
                    ImageOnBacksideOfCard.Source = new BitmapImage(new Uri("project/achterkant.png", UriKind.Relative));

                    //Ruimte tussen kaartjes
                    Thickness margin = ImageOnBacksideOfCard.Margin;
                    margin.Top = 10;
                    ImageOnBacksideOfCard.Margin = margin;

                    ImageOnBacksideOfCard.MouseDown += new MouseButtonEventHandler(CardClick);


                    //teller++;

                    //if (teller == 2 || teller == 4 || teller == 6 || teller == 8 || teller == 10 || teller == 12 || teller == 14 || teller == 16)
                    //{
                    //    positie2 = random.Next(images.Count);
                    //    ImageOnBacksideOfCard.Tag = images[positie2];
                    //    images.RemoveAt(positie2);
                    //}
                    //else
                    //{
                    //    positie1 = random.Next(images.Count);
                    //    ImageOnBacksideOfCard.Tag = images[positie1];
                    //    images.RemoveAt(positie1);

                    //    if (positie1 != positie2)
                    //    {
                    //        Reset();
                    //    }
                    //}

                    //Randomize

                    positie1 = random.Next(images.Count);


                    CardFront card = images[positie1];
                    ImageOnBacksideOfCard.Tag = card;
                    images.RemoveAt(positie1);

                    

                    Grid.SetColumn(ImageOnBacksideOfCard, col);
                    Grid.SetRow(ImageOnBacksideOfCard, row);
                    grid.Children.Add(ImageOnBacksideOfCard);
                }
            }
        }
        
        //Kaarten draaien om op klik
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            CardFront front = (CardFront)card.Tag;
            card.Source = front.GetImage();

            if (lastClicked == -1)
            {
                lastClicked = front.GetNumber();
                lastClickedImage = card;
                card.IsEnabled = false;
                card2 = card;
            }

            else
            {
                lastClickedImage2 = card;

                if (lastClicked == front.GetNumber())
                {
                    MessageBox.Show("Gefeliciteerd, je hebt een pair!" + Score1 + " " + Score2);
                    match = true;
                    Score();
                    card.Opacity = 0;
                    card2.Opacity = 0;
                    card.IsEnabled = false;
                    SoundManager.PlayCorrect();
                }
                
                if (match == false)
                {

                    MessageBox.Show("Helaas, je hebt geen pair!");
                    //lastClicked2 = front.GetNumber();
                    lastClickedImage.Source = new BitmapImage(new Uri("project/achterkant.png", UriKind.Relative));
                    lastClickedImage2.Source = new BitmapImage(new Uri("project/achterkant.png", UriKind.Relative));
                    //Task.Delay(2000).ContinueWith(t => Fout());
                    card.IsEnabled = true;
                    card2.IsEnabled = true;
                    streak = 0;
                    StreakScore = 0;

                    if (beurt == 1)
                    {
                        beurt = 2;
                    }

                    else
                    {
                        beurt = 1;
                    }
                }

                lastClicked = -1;
                match = false;
            }
        }

        //private void Fout()
        //{
        //    lastClickedImage.Source = new BitmapImage(new Uri("project/achterkant.png", UriKind.Relative));
        //    lastClickedImage2.Source = new BitmapImage(new Uri("project/achterkant.png", UriKind.Relative));
        //}

        //Score
        private int Score()
        {
            if (beurt == 1)
            {
                Score1 += 100;
                Streak();
                Score1 += StreakScore;
                streak++;
            }

            else
            {
                Score2 += 100;
                Streak();
                Score2 += StreakScore;
                streak++;
            }
            return Score1;
        }

        #region
        private int Streak()
        {
            switch (streak)
            {
                case 0:
                    StreakScore += 0;
                    break;
                case 1:
                    StreakScore += 20;
                    break;
                case 2:
                    StreakScore += 20;
                    break;
                case 3:
                    StreakScore += 20;
                    break;
                case 4:
                    StreakScore += 20;
                    break;
                case 5:
                    StreakScore += 20;
                    break;
                case 6:
                    StreakScore += 20;
                    break;
                case 7:
                    StreakScore += 20;
                    break;
                case 8:
                    StreakScore += 20;
                    break;
            }
            return StreakScore;
        }
        #endregion

        //Plaatjes inladen
        public List<CardFront> GetImagesList()
        {
            int imageNr = 0;
            List<CardFront> images = new List<CardFront>();

            for (int i = 0; i < 16; i++)
            {
                imageNr = i;
                ImageSource source = new BitmapImage(new Uri("project 2/" + imageNr + ".jpg", UriKind.Relative));
                CardFront card = new CardFront(source, imageNr % 8);
                images.Add(card);
            }
            return images;
        }

        //Reset
        public void Reset()
        {
            grid.Children.Clear();
            AddImage();
        }
    }
}



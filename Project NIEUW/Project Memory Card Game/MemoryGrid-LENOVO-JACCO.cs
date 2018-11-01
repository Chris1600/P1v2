using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Project_Memory_Card_Game
{
    class MemoryGrid
    {
        private Grid grid;
        private int rows, cols;

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
            List<ImageSource> images = GetImagesList();

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
                    ImageOnBacksideOfCard.Tag = images[positie1];
                    images.RemoveAt(positie1);

                    Grid.SetColumn(ImageOnBacksideOfCard, col);
                    Grid.SetRow(ImageOnBacksideOfCard, row);
                    grid.Children.Add(ImageOnBacksideOfCard);
                }
            }
        }


        ///// <param name="correct"></param>
        //public void keepscore(bool correct) //methode voor bij houden van score en het toepassen van de multiplier
        //{
        //    if (Variables.amountplayers == 1)
        //    {
        //        if (correct == true)
        //        {
        //            scores[0] += Convert.ToInt32(multiplier * 10);
        //            score1txt.Text = "Score: " + scores[0];

        //            if (multiplier % 1 == 0)
        //            {
        //                multiplier++;
        //            }
        //            else
        //            {
        //                multiplier = 1;
        //            }
        //        }
        //        else if (correct == false)
        //        {
        //            if (multiplier <= 1)
        //            {
        //                multiplier -= 0.1;
        //            }
        //            else
        //            {
        //                multiplier = 1;
        //            }
        //        }
        //    }
        //    else if (Variables.amountplayers >= 2)
        //    {
        //        stopwatch.Visible = true;
        //        {
        //            if (correct == true)
        //            {
        //                if (turn == 1)
        //                {
        //                    scores[0]++;
        //                    score1txt.Text = "Score: " + Convert.ToString(scores[0]);
        //                }
        //                else if (turn == 2)
        //                {
        //                    scores[1]++;
        //                    score2txt.Text = "Score: " + Convert.ToString(scores[1]);
        //                }
        //                else if (turn == 3 && Variables.amountplayers >= 3)
        //                {
        //                    scores[2]++;
        //                    score3txt.Text = "Score: " + Convert.ToString(scores[2]);
        //                }
        //                else if (turn == 4 && Variables.amountplayers == 4)
        //                {
        //                    scores[3]++;
        //                    score4txt.Text = "Score: " + Convert.ToString(scores[3]);
        //                }
        //            }
        //            else if (correct == false)
        //            {
        //                if (turn != Variables.amountplayers)
        //                {
        //                    turn += 1;
        //                }
        //                else
        //                {
        //                    turn = 1;
        //                    timercount++;
        //                }
        //            }
        //            timers();

        //            if (turn == 2) { arrow1.Visible = false; arrow2.Visible = true; }
        //            if (turn == 3) { arrow2.Visible = false; arrow3.Visible = true; }
        //            if (turn == 4) { arrow3.Visible = false; arrow4.Visible = true; }
        //            if (turn == 1) { arrow4.Visible = false; arrow3.Visible = false; arrow2.Visible = false; arrow1.Visible = true; }
        //        }
        //    }
        //}

        //Kaarten draaien om op klik
        private void CardClick(object sender, MouseButtonEventArgs e)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
        }
      
        //Plaatjes inladen
        public List<ImageSource> GetImagesList()
        {
            int imageNr = 0;
            List<ImageSource> images = new List<ImageSource>();

            for (int i = 0; i < 16; i++)
            {
                imageNr = i;
                ImageSource source = new BitmapImage(new Uri("project 2/" + imageNr + ".jpg", UriKind.Relative));
                images.Add(source);
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



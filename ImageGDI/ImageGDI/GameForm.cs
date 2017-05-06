using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageGDI
{
    public partial class GameForm : Form
    {
        private MainForm parent;
        private List<Bitmap> listBitmap;
        List<int> randowImage;
        List<int> winner;
        private int countImageRow;
        private Graphics gr1;
        private int limitX;
        private int limitY;
        private int positionBlack;      // position of Black Image
        private TimeSpan time;          // timer
        private int countSteps;
        private bool continueGame;

        public GameForm(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
            listBitmap = new List<Bitmap>();
            countImageRow = (int)Math.Sqrt(parent.CountItems);
            Bitmap bmp = new Bitmap(parent.PathImage);
            limitX = parent.WidthImage / countImageRow;
            limitY = parent.HeightImage / countImageRow;
            // Draw List of Images
            List<Bitmap> listBitmapClone = new List<Bitmap>();
            for (int i = 0; i < countImageRow; ++i)
            {
                for (int j = 0; j < countImageRow; ++j)
                {
                    listBitmapClone.Add(bmp.Clone(new Rectangle(limitX * j, limitY * i, limitX, limitY), new System.Drawing.Imaging.PixelFormat()));
                }
            }
            randowImage = new List<int>();
            winner = new List<int>();
            for (int i = 0; i < parent.CountItems; ++i)
            {
                winner.Add(i);
            }
            GeneratePuzzle(randowImage, parent.CountItems);
            // Generate Puzzle from randowImage
            for (int i = 0; i < parent.CountItems; ++i)
            {
                if (randowImage[i] > 0)
                {
                    listBitmap.Add(listBitmapClone[randowImage[i]]);
                }
                else
                {
                    positionBlack = i;
                    listBitmap.Add(GreateBlackImage(limitX, limitY));
                }
            }
            time = new TimeSpan(0, 5, 0);
            this.Text += " Time: " + time.ToString();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(StartTime);
            timer1.Start();
            continueGame = true;
            countSteps = 0;
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            gr1 = e.Graphics;
            for (int i = 0, k = 0; i < countImageRow; ++i)
            {
                for (int j = 0; j < countImageRow; ++j)
                {
                    gr1.DrawImage(listBitmap[k++], new Rectangle(limitX * j, limitY * i, limitX, limitY));
                }
            }
            // Draw Lines
            DrawLines(countImageRow - 1, limitX, limitY);
        }

        private Bitmap GreateBlackImage(int x, int y)
        {
            Bitmap image = new Bitmap(x, y);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    image.SetPixel(i, j, Color.Black);
                }
            }

            return image;
        }

        private void GeneratePuzzle(List<int> randowImage, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                randowImage.Add(i);
            }
            Random rnd = new Random();
            for (int i = 0; i < randowImage.Count; i++)
            {
                int tmp = randowImage[i];
                randowImage.RemoveAt(i);
                randowImage.Insert(rnd.Next(randowImage.Count), tmp);
            }
        }

        private void DrawLines(int countLines, int limitX, int limitY)
        {
            Pen pen = new Pen(Color.Red, 1);
            for (int i = 1; i <= countLines; ++i) // Draw lines on X
            {
                gr1.DrawLines(
                    pen,
                    new Point[]
                { 
                    new Point() {X = limitX * i, Y = 0},
                    new Point() {X = limitX * i, Y = parent.HeightImage},
                }
                );
            }
            for (int i = 1; i <= countLines; ++i) // Draw lines on Y
            {
                gr1.DrawLines(
                    pen,
                    new Point[]
                { 
                    new Point() {X = 0, Y = limitY * i },
                    new Point() {X = parent.WidthImage, Y = limitY * i},
                }
                );
            }
        }

        private void GameForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (continueGame && (e.X >= 0 && e.X <= parent.WidthImage) && (e.Y >= 0 && e.Y <= parent.HeightImage))
            {
                // define number of Image
                int positionImage = defineImage(e.X, e.Y);
                if (positionImage >= 0 && positionImage != positionBlack)
                {
                    if (CheckMove(positionImage))
                    {
                        // move
                        Bitmap tmp = listBitmap[positionImage];
                        listBitmap[positionImage] = listBitmap[positionBlack];
                        listBitmap[positionBlack] = tmp;
                        this.Refresh();
                        int tmpInt = randowImage[positionImage];
                        randowImage[positionImage] = randowImage[positionBlack];
                        randowImage[positionBlack] = tmpInt;
                        positionBlack = positionImage;
                        ++countSteps;
                        if (WinnerGame())
                        {
                            timer1.Stop();
                            continueGame = false;
                            MessageBox.Show("You win!!!");
                        }
                    }
                }
            }
        }

        private bool WinnerGame()
        {
            return winner.SequenceEqual(randowImage);
        }

        private void ShowArray(List<int> tmp)
        {
            string str = "";
            for (int i = 0; i < tmp.Count; ++i)
            {
                str += tmp[i] + " ";
            }
            MessageBox.Show(str);
        }

        private bool CheckMove(int positionImage) // Is  BlackImage near???
        {
            int[][] horizontal = new int[countImageRow][];
            int[][] vertical = new int[countImageRow][];
            for (int i = 0, k = 0; i < countImageRow; ++i)
            {
                horizontal[i] = new int[countImageRow];
                vertical[i] = new int[countImageRow];
                for (int j = 0; j < countImageRow; ++j, ++k)
                {
                    horizontal[i][j] = k;
                    vertical[i][j] = horizontal[0][j];
                }
            }
            if (Check(horizontal, positionImage))
            {
                return true;
            }
            else
            {
                int max = (countImageRow - 1) * countImageRow;
                for (int i = 0; i < countImageRow; ++i) // rotate array on 90 degrees
                {
                    for (int j = 0; j < countImageRow; ++j)
                    {
                        vertical[i][j] = (max - countImageRow * j) + i;
                    }
                }
                if (Check(vertical, positionImage))
                {
                    return true;
                }
            }

            return false;
        }

        private bool Check(int[][] temp, int positionImage)
        {
            for (int i = 0, k = 0; i < countImageRow; ++i)
            {
                for (int j = 0; j < countImageRow; ++j, ++k)
                {
                    if (temp[i][j] == positionBlack)
                    {
                        if (j > 0 && (temp[i][j - 1] == positionImage))
                        {
                            return true;
                        }
                        if ((j + 1) <= (countImageRow - 1) && (temp[i][j + 1] == positionImage))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private int defineImage(int x, int y)
        {
            int position = -1;
            for (int i = 0, k = 0; i < countImageRow; ++i)
            {
                for (int j = 0; j < countImageRow; ++j, ++k)
                {
                    if (((x > limitX * j) && (x < limitX * (j + 1))) &&
                        ((y > limitY * i) && (y < limitY * (i + 1))))
                    {
                        position = k;
                    }
                }
            }

            return position;
        }

        private void StartTime(object vObj, EventArgs e)
        {
            time -= new TimeSpan(0, 0, 1);
            string[] separators = { " Time: " };
            string[] words = this.Text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            this.Text = words[0] + " Time: " + time.ToString();
            if (time.Hours == 0 && time.Minutes == 0 && time.Seconds == 0)
            {
                timer1.Stop();
                continueGame = false;
                MessageBox.Show("The game is over. You lose");
            }
        }
    }
}

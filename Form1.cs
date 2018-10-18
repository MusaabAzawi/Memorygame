using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame1._0
{
    public partial class Form1 : Form
    {
        //List<Uri> memoryImages = new List<Uri> { new Uri("Resources/pic0.png"), new Uri("Resources/pic1.png"), new Uri("Resources/pic2.png")
        //, new Uri("Resources/pic3.png"), new Uri("Resources/pic4.png"), new Uri("Resources/pic5.png"), new Uri("Resources/pic6.png"), new Uri("Resources/pic7.png")
        //, new Uri("Resources/pic8.png"), new Uri("Resources/pic9.png"), new Uri("Resources/pic10.png"), new Uri("Resources/pic11.png"), new Uri("Resources/pic12.png"), new Uri("Resources/pic13.png")
        //, new Uri("Resources/pic14.png"), new Uri("Resources/pic15.png"), new Uri("Resources/pic16.png"), new Uri("Resources/pic17.png"), new Uri("Resources/pic18.png")};
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox prev;
        byte flag = 0;
        int remain = 8;
        byte hint = 3;
        byte timeLeft = 60;
        private void Form1_Load(object sender, EventArgs e)
        {
            newgame();
            
        }
        void restImages()
        {

            foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Image = Properties.Resources.pic0;
            
                    
            
        }

        void restTags()
        {
            foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Tag = "0";
        }

        void showImage(PictureBox box)
        {
            switch (Convert.ToInt32(box.Tag))
            {
                case 1:
                    box.Image = Properties.Resources.pic1;
                    break;
                case 2:
                    box.Image = Properties.Resources.pic2;
                    break;
                case 3:
                    box.Image = Properties.Resources.pic3;
                    break;
                case 4:
                    box.Image = Properties.Resources.pic4;
                    break;
                //case 5:
                //    box.Image = Properties.Resources.pic5;
                //    break;
                //case 6:
                //    box.Image = Properties.Resources.pic6;
                //    break;
                //case 7:
                //    box.Image = Properties.Resources.pic7;
                //    break;
                //case 8:
                //    box.Image = Properties.Resources.pic8;
                //    break;
                //case 9:
                //    box.Image = Properties.Resources.pic8;
                //    break;
                //case 10:
                //    box.Image = Properties.Resources.pic8;
                //    break;
                //case 11:
                //    box.Image = Properties.Resources.pic8;
                //    break;
                //case 12:
                //    box.Image = Properties.Resources.pic8;
                //    break;
                case 13:
                    box.Image = Properties.Resources.pic8;
                    break;
                case 14:
                    box.Image = Properties.Resources.pic8;
                    break;
                case 15:
                    box.Image = Properties.Resources.pic8;
                    break;
                case 16:
                    box.Image = Properties.Resources.pic8;
                    break;
                default:
                    box.Image = Properties.Resources.pic0;
                    break;
            }
        }


        void setTagRandom()
        {
            int[] arr = new int[16];
            int index = 0;
            Random rand = new Random();
            int r;
            while (index < 16)
            {
                r = rand.Next(1, 17);
                if (Array.IndexOf(arr, r) == -1)
                {
                    arr[index] = r;
                    index++;
                }
            }
            for(index =0; index <16; index++)
            {
                if (arr[index] > 8) arr[index] -=8;
            }
            index = 0;
            foreach(Control x in this.Controls)
            {
              if(x is PictureBox)
                {
                    (x as PictureBox).Tag = arr[index].ToString();
                }
            }
        }
        void compare(PictureBox previous, PictureBox current)
        {
            if(previous.Tag.ToString()== current.Tag.ToString())
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                previous.Visible = false;
                current.Visible = false;
                if (--remain == 0)
                {
                    timer.Enabled = false;
                    remaining.Text = "Congratualations.";
                    MessageBox.Show("Congratulations. You have fnished the game.", "End of the game");
                    Hint.Enabled = false;
                }
                else remaining.Text = "Remaining Items: " + remain;
            }
            else
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                previous.Image = Properties.Resources._0;
                current.Image = Properties.Resources._0;
            }
        }

        void allvisibleTrue()
        {
            foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Visible = true;
        }
        void activeAll()
        {
            foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Enabled = true;
        }
        void deActiveAll()
        {
            foreach (Control x in this.Controls) if (x is PictureBox) (x as PictureBox).Enabled = false;
        }
        void newgame()
        {
            remain = 8;
            hint = 3;
            setTagRandom();
            allvisibleTrue();
            resetImages();
            Hint.Enabled = true;
            remaining.Text = "Remaining Items: " + remain;
            Hint.Text = "Hint (" + hint + ")";
            flag = 0;
            timeLeft = 60;
            Time.Text = "Time Left: " + timeLeft;
            timer1.Enabled = true;
            activeAll();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox current = (sender as PictureBox);
            showImage((sender as PictureBox));
            if (flag == 0)
            {
                prev = current;
                flag = 1;
            }
            else if (prev != current)
            {
                compare(prev, current);
                flag = 0;
            }

        }

        private void Hint_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls) if (x is PictureBox) showImage((x as PictureBox));
            Application.DoEvents();
            System.Threading.Thread.Sleep(1500);
            resetImages();
            if (--hint == 0) Hint.Enabled = false;

            Hint.Text = "Hint (" + hint + ")";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (--timeLeft == 0)
            {
                timer1.Enabled = !timer1.Enabled;
                time.Text = "Time's out.";
                MessageBox.Show("TIME IS OVER", "End of the game");
                deActiveAll();
                Hint.Enabled = false;

            }
            else
                time.Text = "Time Left: " + timeLeft;

        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            newgame();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://" + (sender as LinkLabel).Text);
        }


    }
}

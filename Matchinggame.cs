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
    public partial class Matchinggame : Form
    {
        bool allowClick = false;
        PictureBox firstGuess; 
        Random rnd = new Random();
        Timer clickTimer = new Timer();
        int time = 60;
        Timer timer = new Timer { Interval = 1000 };

        public Matchinggame()
        {
            InitializeComponent();
        }

        private PictureBox[] pictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }
        private static IEnumerable<Image> images
        {
            get
            {
                return new Image[]
                {
                    Afbeelding.achterkant_kaartjes,
                    Afbeelding.pic1,
                    Afbeelding.pic10,
                    Afbeelding.pic11,
                    Afbeelding.pic12,
                    Afbeelding.pic13,
                    Afbeelding.pic14,
                    Afbeelding.pic15,
                    Afbeelding.pic16,
                    Afbeelding.pic2,
                    Afbeelding.pic3,
                    Afbeelding.pic4,
                    Afbeelding.pic5,
                    Afbeelding.pic6,
                    Afbeelding.pic8,
                    Afbeelding.pic7,
                    Afbeelding.pic9,
                   

                };
            }
        }

        private void startGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    MessageBox.Show("Tijd is afgelopen");
                    ResetImages();
                }

                var ssTime = TimeSpan.FromSeconds(time);
                label1.Text = "00:" + time.ToString();
            };
        }

        private void ResetImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }
        
        HideImages();
        setRandomImages();
        time = 60;
        timer.Start();
    }

    private void HideImages()
    {
        foreach(var pic in pictureBoxes)
            {
                pic.Image = Afbeelding.achterkant_kaartjes;
            }
    }

        private PictureBox getFreeSlot()
        {
            int num;

            do
            {
                num = rnd.Next(0, pictureBoxes.Count());
            }
            while (pictureBoxes[num].Tag != null);
            return pictureBoxes[num];
        }
    
        private void setRandomImages()
        {
            foreach(var image in images)
            {
                getFreeSlot().Tag = image;
                getFreeSlot().Tag = image;
            }
        }

        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {
            HideImages();
            allowClick = true;
            clickTimer.Stop();
        }

        private void clickImage(object sender, EventArgs e)
        {
            if (!allowClick) return;

            var pic = (PictureBox)sender;

            if (firstGuess == null)
            {
                firstGuess = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }
            pic.Image = (Image)pic.Tag;

            if (pic.Image == firstGuess.Image && pic != firstGuess)
            {
                pic.Visible = firstGuess.Visible = false;
                {
                    firstGuess = pic;
                }
                HideImages();
            }
            else
            {
                allowClick = false;
                clickTimer.Start();
            }

            firstGuess = null;
            if (pictureBoxes.Any(p => p.Visible)) return;
            MessageBox.Show("je bent gewonnen! probeer nog een keer");
            ResetImages();
        }
        private void startGame(object sender, EventArgs e)
        {
            allowClick = true;
            setRandomImages();
            HideImages();
            startGameTimer();
            clickTimer.Interval = 1000;
            clickTimer.Tick += CLICKTIMER_TICK;
            button1.Enabled = false;
        }
        }
    }

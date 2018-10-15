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
        public Form1()
        {
            InitializeComponent();
        }
        void fotoAchterkantkaartjes()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Image = Properties.Resources.pic0;

                }
            }
        }

        void tagAchterkantkaartjes()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Tag = "pic0";
                }
            }
        }
        private void Matchinggame_Load(object sender, EventArgs e)
        {
            fotoAchterkantkaartjes();
            tagAchterkantkaartjes();
        }

    }
}

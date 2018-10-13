using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using System.Resources;
using System.Globalization;


namespace MemoryGame1._0
{
    /// <summary>
    /// Interaction logic for SpeelScherm.xaml
    /// </summary>
    public partial class SpeelScherm : Window
    {
        private bool allowClick = false; // play again or not
        private Afbeelding _firstGuess;
        private readonly Random _random = new Random(); // selecet  arandom value from x and u list and assign a new location to each card
        private readonly Timer _clickTimer = new Timer();
        int tick = 60; // scores
        readonly Timer timer = new Timer { Interval = 1000 };
        //List<int> X = new List<int>(); //X Values of each picturebox
        //List<int> Y = new List<int>();// Y values of each picturebox
        // gebruik dit object om random icon te plaatsen in de grid
        public SpeelScherm()
        {
            InitializeComponent();
            SetRandomImages();
            HideImages();
            StartGameTimer();
            _clickTimer.Interval = 1000l;
            _clickTimer.Tick += _clickTimer_Tick;
        }

        private static Afbeelding[] afbeeldings
        {
            get { return Controls.typeof<Afbeelding>().ToArray(); }
        }
        //ResourceManager Afbeelding = new ResourceManager(typeof(Afbeelding));
        //ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
        private void SpeelScherm_Load(object sender, EventArgs e)
        {
            //foreach (Afbeelding afbeelding  in Resources)
            //{
            //   // (Bitmap)Properties.Resources.ResourceManager.GetObject(list[2])
            //  // Afbeelding.Image = ResourceManager;
            //}
        }
            
        
    }
        
}

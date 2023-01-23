using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TierGehege
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //UserControl1 userControl1 = new UserControl1();
        Tier bello = new Hund();
        Tier mellow = new Katze();
        Tier hellow = new Hamster();
       
        Random random= new Random();


        List<Tier> tierList = new List<Tier>();
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Animation;
            timer.Interval = TimeSpan.FromSeconds(1);
        }

        private void Animation(object sender, EventArgs e)
        {

            foreach (var tier in tierList)
            {
                tier.hunger -= tier.verbrauchHunger;
                tier.liebe -= tier.verbrauchLiebe;

                if (tier.hunger <= 0 || tier.liebe <= 0)
                    tier.leben -= 5;
            }

            tier1Hunger.Value = tierList[0].hunger;
            tier1Liebe.Value = tierList[0].liebe;
            tier1Leben.Value = tierList[0].leben;

            if (tierList.Count == 2)
            {
                tier2Hunger.Value = tierList[1].hunger; 
                tier2Liebe.Value = tierList[1].liebe; 
                tier2Leben.Value = tierList[1].leben;
            }

        }
        
        private void Füttern_Click(object sender, RoutedEventArgs e)
        {
          if (Tier1.IsChecked== true)
            {
                tierList[0].hunger += 5;
                tier1Hunger.Value= tierList[0].Essen(5,Convert.ToInt32(tier1Hunger.Value));
            }
          else if (Tier2.IsChecked == true)
            {
                try
                {
                    tierList[1].hunger += 5;
                    tier2Hunger.Value = tierList[1].Essen(5, Convert.ToInt32(tier2Hunger.Value));
                }
                catch
                { }
            }

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            visible();
            //UserControl1 userControl1 = new UserControl1();
            if (Hamster.IsChecked == true)
            {
                tierList.Add(hellow);
                tier1Img.Source = new BitmapImage(new Uri(hellow.pfad, UriKind.Relative));
            }
            else if(Katze.IsChecked == true)
            {
                tierList.Add(mellow);
                tier1Img.Source = new BitmapImage(new Uri(mellow.pfad, UriKind.Relative));
            }
            else if(Hund.IsChecked== true)
            {
                tierList.Add(bello);
                tier1Img.Source = new BitmapImage(new Uri(bello.pfad, UriKind.Relative));
            }
            else
            {
                tierList.Add(bello);
                tier1Img.Source = new BitmapImage(new Uri(bello.pfad, UriKind.Relative));

            }
            tier1Hunger.Value = 100;
            tier1Leben.Value = 100;
            tier1Liebe.Value = 100;
            Start.Visibility = Visibility.Hidden;
            timer.Start();
            


        }
        private void TierHinzufügen_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void visible()
        {
            tier1Hunger.Visibility = Visibility.Visible;
            tier1Hungerlabel.Visibility = Visibility.Visible;
            tier1Img.Visibility = Visibility.Visible;
            tier1Leben.Visibility = Visibility.Visible;
            tier1Lebenlabel.Visibility = Visibility.Visible;
            tier1Liebe.Visibility = Visibility.Visible;
            tier1Liebelabel.Visibility = Visibility.Visible;
            Tier1.Visibility = Visibility.Visible;
        }
    }

}
    

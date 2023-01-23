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
using System.Windows.Shell;
using System.Windows.Threading;

namespace TierGehege
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //UserControl1 userControl1 = new UserControl1();
        
       

        List<Tier> tierList = new List<Tier>();
        DispatcherTimer timer = new DispatcherTimer();
        List<RadioButton> TierAuswahl= new List<RadioButton>();
        List<Tier> Arten = new List<Tier>();

        double zeit;
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Animation;
            timer.Interval = TimeSpan.FromSeconds(5);

            TierAuswahl.Add(Hamster);
            TierAuswahl.Add(Katze);
            TierAuswahl.Add(Hund);

        }

        private void Animation(object sender, EventArgs e)
        {
            zeit +=0.05;
            string zeitanzeige = Convert.ToString(zeit).Replace(",",":");
            Zeit.Content=zeitanzeige;

            if (tierList.Count==0)
            {
                Ende();   
            }
            if(tierList.Count!=0)
            {
                foreach (Tier tier in tierList)
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

        }
        

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Arten.Clear();
            Arten.Add(new Hamster());
            Arten.Add(new Katze());
            Arten.Add(new Hund());

            if (Hamster.IsChecked == true)
            {
                tierList.Add(new Hamster());
                tier1Img.Source = new BitmapImage(new Uri(tierList[0].pfad, UriKind.Relative));
            }
            else if(Katze.IsChecked == true)
            {
                tierList.Add(new Katze());
                tier1Img.Source = new BitmapImage(new Uri(tierList[0].pfad, UriKind.Relative));
            }
            else if(Hund.IsChecked== true)
            {
                tierList.Add(new Hund());
                tier1Img.Source = new BitmapImage(new Uri(tierList[0].pfad, UriKind.Relative));
            }

            if (tierList.Count() == 0)
            {
                tierList.Add(new Hund());
                tier1Img.Source = new BitmapImage(new Uri(tierList[0].pfad, UriKind.Relative));

            }
            visibleOptions();
            visibleTier1();
            tier1Hunger.Value = 100;
            tier1Leben.Value = 100;
            tier1Liebe.Value = 100;
            Start.Visibility = Visibility.Hidden;
            timer.Start();




        }
        private void TierHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            Arten.Clear();
            Arten.Add(new Hamster());
            Arten.Add(new Katze());
            Arten.Add(new Hund());
            

            if (Hamster.IsChecked == true)
            {
                tierList.Add(new Hamster());
                tier2Img.Source = new BitmapImage(new Uri(tierList[1].pfad, UriKind.Relative));
                visibleTier2();
            }
            else if (Katze.IsChecked == true)
            {
                tierList.Add(new Katze());
                tier2Img.Source = new BitmapImage(new Uri(tierList[1].pfad, UriKind.Relative));
                visibleTier2();
            }
            else if (Hund.IsChecked == true)
            {
                tierList.Add(new Hund());
                tier2Img.Source = new BitmapImage(new Uri(tierList[1].pfad, UriKind.Relative));
                visibleTier2();
            }
            tier2Hunger.Value = 100;
            tier2Leben.Value = 100;
            tier2Liebe.Value = 100;


        }
        private void TierEntfernen_Click(object sender, RoutedEventArgs e)
        {
            if(tierList.Count == 0)
            {
                TierWeg.Visibility = Visibility.Hidden;
            }
            else if (Tier1.IsChecked==true)
            {
                tierList[0].Sterben(tierList, 0);

            }
            else if(Tier2.IsChecked==true)
            {
                tierList[1].Sterben(tierList, 1);
            }
            try
            {
                tier1Img.Source = new BitmapImage(new Uri(tierList[0].pfad, UriKind.Relative));
                InvisibleTier();
            }
            catch { }
            

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


        private void Kuscheln_Click(object sender, RoutedEventArgs e)
        {
            if (Tier1.IsChecked == true)
            {
                tierList[0].liebe += 5;
                tier1Liebe.Value = tierList[0].Kuscheln(5, Convert.ToInt32(tier1Liebe.Value));
            }
            else if (Tier2.IsChecked == true)
            {
                try
                {
                    tierList[1].liebe += 5;
                    tier2Liebe.Value = tierList[1].Kuscheln(5, Convert.ToInt32(tier2Liebe.Value));
                }
                catch
                { }
            }

        }

        private void visibleOptions()
        {
            Fuettern.Visibility= Visibility.Visible;
            Putzen.Visibility= Visibility.Visible;
            Kuscheln.Visibility= Visibility.Visible;
            TierHinzu.Visibility= Visibility.Visible;
            TierWeg.Visibility= Visibility.Visible;

        }
        private void visibleTier1()
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
        private void visibleTier2()
        {
            tier2Hunger.Visibility = Visibility.Visible;
            tier2Hungerlabel.Visibility = Visibility.Visible;
            tier2Img.Visibility = Visibility.Visible;
            tier2Leben.Visibility = Visibility.Visible;
            tier2Lebenlabel.Visibility = Visibility.Visible;
            tier2Liebe.Visibility = Visibility.Visible;
            tier2Liebelabel.Visibility = Visibility.Visible;
            Tier2.Visibility = Visibility.Visible;
        }
        protected void InvisibleTier()
        {
            tier2Hunger.Visibility = Visibility.Hidden;
            tier2Hungerlabel.Visibility = Visibility.Hidden;
            tier2Img.Visibility = Visibility.Hidden;
            tier2Leben.Visibility = Visibility.Hidden;
            tier2Lebenlabel.Visibility = Visibility.Hidden;
            tier2Liebe.Visibility = Visibility.Hidden;
            tier2Liebelabel.Visibility = Visibility.Hidden;
            Tier2.Visibility = Visibility.Hidden;
        }

        private void Ende()
        {
            MessageBox.Show("Alle Tot :(");
            Thread.Sleep(50);
            timer.Stop();
            zeit = 0;
            string zeitanzeige = Convert.ToString(zeit).Replace(",", ":");
            Zeit.Content = zeitanzeige;


            tierList.Clear();
            Start.Visibility = Visibility.Visible;
            tier1Hunger.Visibility = Visibility.Hidden;
            tier1Hungerlabel.Visibility = Visibility.Hidden;
            tier1Img.Visibility = Visibility.Hidden;
            tier1Leben.Visibility = Visibility.Hidden;
            tier1Lebenlabel.Visibility = Visibility.Hidden;
            tier1Liebe.Visibility = Visibility.Hidden;
            tier1Liebelabel.Visibility = Visibility.Hidden;
            Tier1.Visibility = Visibility.Hidden;

            InvisibleTier();
            Fuettern.Visibility = Visibility.Hidden;
            Putzen.Visibility = Visibility.Hidden;
            Kuscheln.Visibility = Visibility.Hidden;
            TierHinzu.Visibility = Visibility.Hidden;
            TierWeg.Visibility = Visibility.Hidden;

        }

    }

}
    

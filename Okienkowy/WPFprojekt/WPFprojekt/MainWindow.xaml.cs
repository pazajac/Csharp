using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using wzorce;

namespace wzorce
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string stype;
        Magazyn m;
        Klient k;
        Historia h;

        public MainWindow()
        {

            InitializeComponent();
            m = new Magazyn();
            k = new Klient("Klient 1", m);
            h = new Historia();
            stype = "Meble";
            mDgr.ItemsSource = m.getLista;
            kDgr.ItemsSource = k.getLista;
        }

        private void treeViewMebleClick(object sender, MouseButtonEventArgs e)
        {
            stype = "Meble";
            mDgr.ItemsSource = m.getCat<Meble>();
            kDgr.ItemsSource = k.getCat<Meble>();
        }

        private void treeViewPokojoweClick(object sender, MouseButtonEventArgs e)
        {
            stype = "Pokojowe";
            mDgr.ItemsSource = m.getCat<MeblePokojowe>();
            kDgr.ItemsSource = k.getCat<MeblePokojowe>();
        }

        private void treeViewBiuroweClick(object sender, MouseButtonEventArgs e)
        {
            stype = "Biurowe";
            mDgr.ItemsSource = m.getCat<MebleBiurowe>();
            kDgr.ItemsSource = k.getCat<MebleBiurowe>();
        }

        private void ZmienCeneClick(object sender, RoutedEventArgs e)
        {
            float zm = float.Parse(NowaCena.Text);
            if ( zm > 0.0)
            {
                switch (stype)
                {
                    case "Meble":
                        m.ZmianaCeny<Meble>(zm);
                        mDgr.ItemsSource = m.getLista;
                        break;
                    case "Pokojowe":
                        m.ZmianaCeny<MeblePokojowe>(zm);
                        mDgr.ItemsSource = m.getLista;
                        break;
                    case "Biurowe":
                        m.ZmianaCeny<MebleBiurowe>(zm);
                        mDgr.ItemsSource = m.getLista;
                        break;  
                }
            }
        }

        private void Kupuj_Click(object sender, RoutedEventArgs e)
        {
            Meble wybrany = (Meble)mDgr.SelectedItem;

            if (!k.Zakupy(m, m.getLista.IndexOf(wybrany), Convert.ToInt32(iloscTow.Text)))
            {
               
                MessageBox.Show("Zakup nieudany");
            }    
      
            kDgr.ItemsSource = k.getLista;

            Koszty.Text = k.Koszty();

            

        }

        private void ZakonczZakup_Click(object sender, RoutedEventArgs e)
        {
                MessageBox.Show("Dziekujemy za zakupy \n");
                k.ZapiszZakup(h);
                k.lista_prod.Clear();
                Koszty.Text = "";
                kDgr.ItemsSource = k.getLista;
            
        }

        private void hist_Click(object sender, RoutedEventArgs e)
        {
            HistoriaWindow p = new HistoriaWindow(h);
            p.Show();
        }
    }
}

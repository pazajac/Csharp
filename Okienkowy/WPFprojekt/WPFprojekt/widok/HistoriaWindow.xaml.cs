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
using System.Windows.Shapes;

namespace wzorce
{
    /// <summary>
    /// Interaction logic for HistoriaWindow.xaml
    /// </summary>
    public partial class HistoriaWindow : Window
    {
        public HistoriaWindow(Historia h)
        {
            InitializeComponent();
            wpisy.ItemsSource = h.Archiwum;
        }

        private void WyswietlWpisClick(object sender, RoutedEventArgs e)
        {
            zakupione.ItemsSource = ((Wpis)wpisy.SelectedItem).Zakupione;
        }
    }
}

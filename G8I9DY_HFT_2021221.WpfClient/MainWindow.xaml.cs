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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace G8I9DY_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ArtistWindow aw = new ArtistWindow();
            aw.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AlbumWindow aw = new AlbumWindow();
            aw.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            TrackWindow tw = new TrackWindow();
            tw.ShowDialog();
        }
    }
}

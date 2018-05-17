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

namespace HCI2018PZ4._3EURA78_2015
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

        private void Vrsta_Click(object sender, RoutedEventArgs e)
        {
            Dijalozi.VrstaDialog vrstaDialog = new Dijalozi.VrstaDialog();
            vrstaDialog.Show();
        }

        private void Tip_Click(object sender, RoutedEventArgs e)
        {
            Dijalozi.TipDialog tipDialog = new Dijalozi.TipDialog();
            tipDialog.Show();
        }

        private void Etiketa_Click(object sender, RoutedEventArgs e)
        {
            Dijalozi.EtiketaDialog etiketaDialog = new Dijalozi.EtiketaDialog();
            etiketaDialog.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Model.Kolekcije.Sacuvaj();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Model.Kolekcije.Ucitaj();
        }

        private void VrstaLisa_Click(object sender, RoutedEventArgs e)
        {
            Tabele.ListaVrste listaVrste = new Tabele.ListaVrste();
            listaVrste.Show();
        }

        private void TipLista_Click(object sender, RoutedEventArgs e)
        {
            Tabele.ListaTipovi listaTipovi = new Tabele.ListaTipovi();
            listaTipovi.Show();
        }

        private void EtiketaLista_Click(object sender, RoutedEventArgs e)
        {
            Tabele.ListaEtikete listaEtikete= new Tabele.ListaEtikete();
            listaEtikete.Show();

        }
    }
}

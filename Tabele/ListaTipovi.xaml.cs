using HCI2018PZ4._3EURA78_2015.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HCI2018PZ4._3EURA78_2015.Tabele
{
    /// <summary>
    /// Interaction logic for ListaTipovi.xaml
    /// </summary>
    public partial class ListaTipovi : Window
    {
        public ListaTipovi()
        {
            InitializeComponent();
            this.DataContext = this;
            TipoviLista = Kolekcije.InstancaKolekcije.Tipovi;
        }

        public ObservableCollection<Tip> TipoviLista
        {
            get;
            set;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Tip t = (Tip)tabela.SelectedItem;
            Dijalozi.TipDialog tipDialog = new Dijalozi.TipDialog(t);
            tipDialog.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Tip t = (Tip)tabela.SelectedItem;
            Kolekcije.InstancaKolekcije.Tipovi.Remove(t);
        }
    }
}

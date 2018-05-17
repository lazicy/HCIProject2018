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
    /// Interaction logic for ListaVrste.xaml
    /// </summary>
    public partial class ListaVrste : Window
    {
        public ListaVrste()
        {
            InitializeComponent();
            this.DataContext = this;
            VrsteLista = Kolekcije.InstancaKolekcije.Vrste;
        }

        public ObservableCollection<Vrsta> VrsteLista
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
            Vrsta v = (Vrsta)tabela.SelectedItem;
            Dijalozi.VrstaDialog vrstaDialog = new Dijalozi.VrstaDialog(v);
            vrstaDialog.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Vrsta v = (Vrsta)tabela.SelectedItem;
            Kolekcije.InstancaKolekcije.Vrste.Remove(v);
        }
    }
}

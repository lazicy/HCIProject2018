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
            VrsteLista = MainWindow.InstancaKolekcije.Vrste;
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
            MainWindow.InstancaKolekcije.Vrste.Remove(v);
            // MainWindow.InstancaKolekcije.ListaVrste.Remove(v);

            for (int i = 0; i < MainWindow.InstancaKolekcije.ListaVrste.Count; i++)
            {
                if (MainWindow.InstancaKolekcije.ListaVrste[i].Id.Equals(v.Id))
                {
                    MainWindow.InstancaKolekcije.ListaVrste.RemoveAt(i);
                }
            }
          //  MainWindow.InstanceMW.RefreshView();



            // TODO brisanje iz MapaVrste



            for (int i = 0; i < MainWindow.InstancaKolekcije.MapaVrste.Count; i++)
            {
                if (MainWindow.InstancaKolekcije.MapaVrste[i].V.Id.Equals(v.Id))
                {
                    Ikonica tempV = MainWindow.InstancaKolekcije.MapaVrste[i];
                    MainWindow.InstanceMW.canvasMapa.Children.RemoveAt(i);
                    MainWindow.InstancaKolekcije.MapaVrste.RemoveAt(i);
                    break;
                }
            }
            
        }
    }
}

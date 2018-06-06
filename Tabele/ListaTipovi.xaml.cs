using HCI2018PZ4._3EURA78_2015.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            TipoviLista = MainWindow.InstancaKolekcije.Tipovi;
            MainWindow.InstanceMW.Hide();
        }

        public ObservableCollection<Tip> TipoviLista
        {
            get;
            set;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Dijalozi.TipDialog tipDialog = new Dijalozi.TipDialog();
            tipDialog.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.InstanceMW.Show();
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
            MainWindow.InstancaKolekcije.Tipovi.Remove(t);
        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {

            MainWindow.InstanceMW.Show();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = HelpProvider.GetHelpKey(this);
            HelpProvider.ShowHelp(str, this);
        }

    }
}


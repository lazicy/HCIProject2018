﻿using HCI2018PZ4._3EURA78_2015.Model;
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
    /// Interaction logic for ListaEtikete.xaml
    /// </summary>
    public partial class ListaEtikete : Window
    {
        public ListaEtikete()
        {
            InitializeComponent();
            this.DataContext = this;
            EtiketeLista = MainWindow.InstancaKolekcije.Etikete;
            MainWindow.InstanceMW.Hide();
        }

        public ObservableCollection<Etiketa> EtiketeLista
        {
            get;
            set;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Dijalozi.EtiketaDialog etiketaDialog= new Dijalozi.EtiketaDialog();
            etiketaDialog.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.InstanceMW.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Etiketa et = (Etiketa)tabela.SelectedItem;
            Dijalozi.EtiketaDialog etiketaDialog = new Dijalozi.EtiketaDialog(et);
            etiketaDialog.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Etiketa et = (Etiketa)tabela.SelectedItem;
            MainWindow.InstancaKolekcije.Etikete.Remove(et);
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


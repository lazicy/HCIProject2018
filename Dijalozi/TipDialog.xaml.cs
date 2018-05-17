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
using System.ComponentModel;
using Microsoft.Win32;
using HCI2018PZ4._3EURA78_2015.Model;

namespace HCI2018PZ4._3EURA78_2015.Dijalozi
{
    /// <summary>
    /// Interaction logic for TipDialog.xaml
    /// </summary>
    public partial class TipDialog : Window, INotifyPropertyChanged
    {
        private Tip t = null;
        private Tip editTip = null;
        public TipDialog()
        {
            InitializeComponent();
            t = new Tip();
            this.DataContext = t;
            btnAdd.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Hidden;

        }

        public TipDialog(Tip editT)
        {
            InitializeComponent();
            t = new Tip();
            editTip = editT;
            this.DataContext = t;

            btnAdd.Visibility = Visibility.Hidden;
            btnEdit.Visibility = Visibility.Visible;
            
            t.Id = editTip.Id;
            t.Ikonica = editTip.Ikonica;
            t.Naziv = editTip.Naziv;
            t.Opis = editTip.Opis;
        }


        #region propertyChanged 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(name));
            }
        }

        #endregion


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("[TipV]: Id: {0} || Naziv: {1} || Opis: {2} || Ikonica: {3}", t.Id, t.Naziv, t.Opis, t.Ikonica);
           
            // dodavanjeu glavnu kolekciju tipova
            Kolekcije.InstancaKolekcije.Tipovi.Add(t);
            Kolekcije.InstancaKolekcije.PrintTipova();
            this.Close();



        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIzaberi_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                //Console.WriteLine("URI: " + openFileDialog.FileName);
                t.Ikonica = openFileDialog.FileName;
                

            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

            editTip.Id = t.Id;
            editTip.Naziv = t.Naziv;
            editTip.Opis = t.Opis;
            editTip.Ikonica = t.Ikonica;
            this.Close();


        }
    }
}

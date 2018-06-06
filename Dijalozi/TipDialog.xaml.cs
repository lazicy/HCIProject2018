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
            id.IsEnabled = false;
            btnAdd.Visibility = Visibility.Hidden;
            btnEdit.Visibility = Visibility.Visible;
            
            t.Id = editTip.Id;
            t.Ikonica = editTip.Ikonica;
            t.Naziv = editTip.Naziv;
            t.Opis = editTip.Opis;

            id.IsEnabled = false;
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
          
            if (validate())
            {
            // dodavanjeu glavnu kolekciju tipova
            MainWindow.InstancaKolekcije.Tipovi.Add(t);
            MainWindow.InstancaKolekcije.PrintTipova();
            this.Close();

            }


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
            if (validate())
            {


                editTip.Id = t.Id;
                editTip.Naziv = t.Naziv;
                editTip.Opis = t.Opis;
                editTip.Ikonica = t.Ikonica;

                for (int i = 0; i < MainWindow.InstancaKolekcije.Vrste.Count; i++)
                {
                    if (MainWindow.InstancaKolekcije.Vrste[i].Tip.Id.Equals(editTip.Id))
                    {
                        MainWindow.InstancaKolekcije.Vrste[i].Ikonica = editTip.Ikonica;
                    }
                }

                for (int i = 0; i < MainWindow.InstancaKolekcije.ListaVrste.Count; i++)
                {
                    if (MainWindow.InstancaKolekcije.ListaVrste[i].Tip.Id.Equals(editTip.Id))
                    {
                        MainWindow.InstancaKolekcije.ListaVrste[i].Ikonica = editTip.Ikonica;
                    }
                }

                for (int i = 0; i < MainWindow.InstancaKolekcije.MapaVrste.Count; i++)
                {

                    if (MainWindow.InstancaKolekcije.MapaVrste[i].V.Tip.Id.Equals(editTip.Id))
                    {
                        MainWindow.InstancaKolekcije.MapaVrste[i].V.Ikonica = editTip.Ikonica;
                    }
                }

                MainWindow.InstanceMW.canvasMapa_RemoveIkonice();
                MainWindow.InstanceMW.canvasMapa_AddIkonice();


                this.Close();
            }

        }

        private bool validate()
        {
            bool retVal = true;
            if (id.Text.Trim().Equals(""))
            {
                id_LostFocus(null, null);
                retVal = false;
            }

            if (naziv.Text.Trim().Equals(""))
            {
                naziv_LostFocus(null, null);
                retVal = false;
            }
            return retVal;
        }

        private void id_LostFocus(object sender, RoutedEventArgs e)
        {
            if (id.Text.Trim().Equals(""))
            {
                id.BorderBrush = System.Windows.Media.Brushes.Red;
                idLabel.Foreground = System.Windows.Media.Brushes.OrangeRed;
                btnAdd.IsEnabled = false;
                return;
            }

            idLabel.Text = "Oznaka tipa: ";
            idLabel.ClearValue(TextBox.ForegroundProperty);
            id.ClearValue(TextBox.BorderBrushProperty);
            btnAdd.IsEnabled = true;

        }

        private void id_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Tip t in MainWindow.InstancaKolekcije.Tipovi)
            {
                if (t.Id.Trim().Equals(id.Text.Trim()))
                {
                    id.BorderBrush = System.Windows.Media.Brushes.OrangeRed;
                    idLabel.Text = "Uneta oznaka je zauzeta. Unesite novu oznaku: ";
                    idLabel.Foreground = System.Windows.Media.Brushes.OrangeRed;
                    btnAdd.IsEnabled = false;
                    return;
                }
            }
            btnAdd.IsEnabled = true;
            idLabel.Text = "Oznaka tipa: ";
            idLabel.ClearValue(TextBox.ForegroundProperty);
        }


        private void naziv_LostFocus(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = true;
            nazivLabel.ClearValue(TextBox.ForegroundProperty);
            naziv.ClearValue(TextBox.BorderBrushProperty);
            if (naziv.Text.Trim().Equals(""))
            {
                naziv.BorderBrush = System.Windows.Media.Brushes.Red;
                nazivLabel.Foreground = System.Windows.Media.Brushes.OrangeRed;
                btnAdd.IsEnabled = false;
                return;
            }

        }

        private void naziv_GotFocus(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = true;
            nazivLabel.ClearValue(TextBox.ForegroundProperty);
            naziv.ClearValue(TextBox.BorderBrushProperty);
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = HelpProvider.GetHelpKey(this);
            HelpProvider.ShowHelp(str, this);
        }

    }
}

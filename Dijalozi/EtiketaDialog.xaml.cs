using HCI2018PZ4._3EURA78_2015.Model;
using System;
using System.Collections.Generic;
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

namespace HCI2018PZ4._3EURA78_2015.Dijalozi
{
    /// <summary>
    /// Interaction logic for EtiketaDialog.xaml
    /// </summary>
    public partial class EtiketaDialog : Window, INotifyPropertyChanged
    {
        private Etiketa et = null;
        private Etiketa editEt = null;

        public EtiketaDialog()
        {
            InitializeComponent();
            et = new Etiketa();
            this.DataContext = et;

            btnAdd.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Hidden;
           
        }

        public EtiketaDialog(Etiketa editEtiketa)
        {
            InitializeComponent();
            this.et = new Etiketa();
            this.editEt = editEtiketa;
            this.DataContext = et;

            btnAdd.Visibility = Visibility.Hidden;
            btnEdit.Visibility = Visibility.Visible;

            et.Id = editEt.Id;
            et.Boja = editEt.Boja;
            et.Opis = editEt.Opis;
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


        private string _id;
        private string _opis;
        
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }

            }
        }

        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }

            }
        }

        public string Boja;



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                Console.WriteLine("[EtiketaV]: Id: {0} || Boja: {1} || Opis: {2}", et.Id, et.Boja, et.Opis);
                MainWindow.InstancaKolekcije.Etikete.Add(et);
                MainWindow.InstancaKolekcije.PrintEtiketa();
                this.Close();
                }


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
            {
                editEt.Id = et.Id;
                editEt.Boja = et.Boja;
                editEt.Opis = et.Opis;
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
            if (colorPicker.SelectedColor == null)
            {
                colorPicker_LostFocus(null, null);
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

            idLabel.Text = "Oznaka etikete: ";
            idLabel.ClearValue(TextBox.ForegroundProperty);
            id.ClearValue(TextBox.BorderBrushProperty);
            btnAdd.IsEnabled = true;

        }

        private void id_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Etiketa etiketa in MainWindow.InstancaKolekcije.Etikete)
            {
                if (etiketa.Id.Trim().Equals(id.Text.Trim()))
                {
                    id.BorderBrush = System.Windows.Media.Brushes.OrangeRed;
                    idLabel.Text = "Uneta oznaka je zauzeta. Unesite novu oznaku: ";
                    idLabel.Foreground = System.Windows.Media.Brushes.OrangeRed;
                    btnAdd.IsEnabled = false;
                    return;
                }
            }
            btnAdd.IsEnabled = true;
            idLabel.Text = "Oznaka etikete: ";
            idLabel.ClearValue(TextBox.ForegroundProperty);
        }

        private void colorPicker_LostFocus(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = true;
            bojaLabel.ClearValue(TextBox.ForegroundProperty);
            if (colorPicker.SelectedColor == null)
            {
                bojaLabel.Foreground = System.Windows.Media.Brushes.OrangeRed;
                btnAdd.IsEnabled = false;
                return;
            }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = HelpProvider.GetHelpKey(this);
            HelpProvider.ShowHelp(str, this);
        }

    }
}

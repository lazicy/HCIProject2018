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
using System.Collections.ObjectModel;

namespace HCI2018PZ4._3EURA78_2015.Dijalozi
{
    /// <summary>
    /// Interaction logic for VrstaDialog.xaml
    /// </summary>
    public partial class VrstaDialog : Window, INotifyPropertyChanged
    {

        private Vrsta v = null;
        private Vrsta editV = null;
        public VrstaDialog()
        {
            InitializeComponent();
            this.v = new Vrsta();
            v.Tipovi = MainWindow.InstancaKolekcije.Tipovi;
            v.Etikete = MainWindow.InstancaKolekcije.Etikete;
            this.DataContext = v;
            closeBtnImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/close.png"));
            btnAdd.Visibility = Visibility.Visible;
            btnEdit.Visibility = Visibility.Hidden;
            closeBtn.Visibility = Visibility.Hidden;


        }

        public VrstaDialog(Vrsta editVrsta)
        {
            InitializeComponent();
            this.v = new Vrsta();
           
            this.editV = editVrsta;
            id.IsEnabled = false;
            v.Id = editV.Id;
            v.Naziv = editV.Naziv;
            v.Opis = editV.Opis;
            v.StatusUgrozenosti = editV.StatusUgrozenosti;
            v.Tip = editV.Tip;
            v.OpasnaPoLjude = editV.OpasnaPoLjude;
            v.ListaIUCN = editV.ListaIUCN;
            v.NaseljeniRegion = editV.NaseljeniRegion;
            v.TuristickiStatus = editV.TuristickiStatus;
            v.Ikonica = editV.Ikonica;
            v.Prihod = editV.Prihod;
            v.DatumOtkrivanja = editV.DatumOtkrivanja;
            v.DodeljeneEtikete = editV.DodeljeneEtikete;
            v.CustomIcon = editV.CustomIcon;
            v.Tipovi = MainWindow.InstancaKolekcije.Tipovi;
            v.Etikete = MainWindow.InstancaKolekcije.Etikete;

            // jako brljavo, ovo moras ispraviti
            foreach (Etiketa et in v.DodeljeneEtikete)
            {
                foreach (Etiketa etik in v.Etikete)
                {
                    if (etik.Boja.Equals(et.Boja))
                    {
                        etik.Otkaceno = true;
                    }
                }
            }
            

            this.DataContext = v;
            closeBtnImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/close.png"));



            if (v.CustomIcon)
            {
                Binding binding = new Binding();
                binding.Source = v.Ikonica;
                BindingOperations.SetBinding(ikonicaShow, Image.SourceProperty, binding);

                closeBtn.Visibility = Visibility.Visible;
            }
            else
            {
                closeBtn.Visibility = Visibility.Hidden;
            }

            btnEdit.Visibility = Visibility.Visible;
            btnAdd.Visibility = Visibility.Hidden;



        }


        #region Properties Declarations



        public event PropertyChangedEventHandler PropertyChanged;
        #region propertyChanged 

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

       
        #endregion






        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (validate())
            {
                if (!v.CustomIcon)
                {
                    v.Ikonica = v.Tip.Ikonica;
                }

                v.ProveriChekiraneEtikete();

                //dodavanje u glavnu listu
                MainWindow.InstancaKolekcije.Vrste.Add(v);
                MainWindow.InstancaKolekcije.ListaVrste.Add(v);
                //MainWindow.RefreshView();

                MainWindow.InstancaKolekcije.PrintVrstaListe();
                MainWindow.InstancaKolekcije.PrintVrsta();
                this.Close();
            }


        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (validate())
                {

                v.ProveriChekiraneEtikete();
                foreach (Etiketa etik in MainWindow.InstancaKolekcije.Etikete)
                {
                    etik.Otkaceno = false;
                }


                if (!v.CustomIcon)
                {
                    v.Ikonica = v.Tip.Ikonica;
                }

                editV.Id = v.Id;
                editV.Naziv = v.Naziv;
                editV.Opis = v.Opis;
                editV.StatusUgrozenosti = v.StatusUgrozenosti;
                editV.StatusUgrozenostiStr = v.StatusUgrozenostiStr;
                editV.Tip = v.Tip;
                editV.OpasnaPoLjude = v.OpasnaPoLjude;
                editV.ListaIUCN = v.ListaIUCN;
                editV.NaseljeniRegion = v.NaseljeniRegion;
                editV.TuristickiStatus = v.TuristickiStatus;
                editV.TuristickiStatusStr = v.TuristickiStatusStr;
                editV.Ikonica = v.Ikonica;
                editV.Prihod = v.Prihod;
                editV.DatumOtkrivanja = v.DatumOtkrivanja;
                editV.CustomIcon = v.CustomIcon;
                editV.DodeljeneEtikete = v.DodeljeneEtikete;



                // izmena za ListaVrste
                for (int i = 0; i < MainWindow.InstancaKolekcije.ListaVrste.Count; i++)
                {
                    if (MainWindow.InstancaKolekcije.ListaVrste[i].Id.Equals(editV.Id))
                    {
                        MainWindow.InstancaKolekcije.ListaVrste[i] = editV;
                        Console.WriteLine("[LOG:VrstaDialogIzmena] Novi naziv[Lista] " + editV.Naziv);
                    }
                }

                for (int i = 0; i < MainWindow.InstancaKolekcije.MapaVrste.Count; i++)
                {
                    if (MainWindow.InstancaKolekcije.MapaVrste[i].V.Id.Equals(editV.Id))
                    {
                        MainWindow.InstancaKolekcije.MapaVrste[i].V = editV;
                        Console.WriteLine("[LOG:VrstaDialogIzmena] Novi naziv[Mapa] " + editV.Naziv);
                    }
                }

                MainWindow.InstanceMW.canvasMapa_RemoveIkonice();
                MainWindow.InstanceMW.canvasMapa_AddIkonice();



                this.Close();

            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            //defanziva 
            foreach (Etiketa etik in MainWindow.InstancaKolekcije.Etikete)
            {
                etik.Otkaceno = false;
            }

            this.Close();

        }

        private void btnIzaberi_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {

                v.Ikonica = openFileDialog.FileName;
                Binding binding = new Binding();
                binding.Source = v.Ikonica;
                BindingOperations.SetBinding(ikonicaShow, Image.SourceProperty, binding);
                v.CustomIcon = true;
                closeBtn.Visibility = Visibility.Visible;


            }

        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {

            Binding binding = new Binding();
            binding.Path = new PropertyPath("Ikonica");
            binding.Source = v.Tip;
            binding.Mode = BindingMode.TwoWay;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            binding.IsAsync = true;
            BindingOperations.SetBinding(ikonicaShow, Image.SourceProperty, binding);
            v.Ikonica = null;
            v.CustomIcon = false;


            closeBtn.Visibility = Visibility.Hidden;
        }

        // provera obaveznih polja (id, naziv, tip, turisticki status, status ugrozenosti, prih
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

            if (v.Tip == null)
            {
                tip_LostFocus(null, null);
                retVal = false;
            }

            if(statusUgr.SelectedIndex == 0)
            {
                statusUgr_LostFocus(null, null);
                retVal = false;
            }

            if (turistickiStatus.SelectedIndex == 0)
            {
                turistickiStatus_LostFocus(null, null);
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

            idLabel.Text = "Oznaka vrste: ";
            idLabel.ClearValue(TextBox.ForegroundProperty);
            id.ClearValue(TextBox.BorderBrushProperty);
            btnAdd.IsEnabled = true;

        }

        private void id_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Vrsta v in MainWindow.InstancaKolekcije.Vrste)
            {
                if (v.Id.Trim().Equals(id.Text.Trim()))
                {
                    id.BorderBrush = System.Windows.Media.Brushes.OrangeRed;
                    idLabel.Text = "Uneta oznaka je zauzeta. Unesite novu oznaku: ";
                    idLabel.Foreground = System.Windows.Media.Brushes.OrangeRed;
                    btnAdd.IsEnabled = false;
                    return;
                }
            }
            btnAdd.IsEnabled = true;
            idLabel.Text = "Oznaka vrste: ";
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


        private void tip_LostFocus(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = true;
            tipLabel.ClearValue(TextBox.ForegroundProperty);
            if (tip.SelectedItem == null)
            {
                tipLabel.Foreground = System.Windows.Media.Brushes.OrangeRed;
                btnAdd.IsEnabled = false;
                return;
            }

        }

        private void turistickiStatus_LostFocus(object sender, RoutedEventArgs e)
        {
            btnAdd.IsEnabled = true;
            turistickiStatusLabel.ClearValue(TextBox.ForegroundProperty);
            if (turistickiStatus.SelectedIndex == 0)
            {
                turistickiStatusLabel.Foreground = System.Windows.Media.Brushes.OrangeRed;
                btnAdd.IsEnabled = false;
                return;
            }
        }

        private void statusUgr_LostFocus(object sender, RoutedEventArgs e)
        {

            btnAdd.IsEnabled = true;
            statusUgrLabel.ClearValue(TextBox.ForegroundProperty);
            if (statusUgr.SelectedIndex == 0)
            {
                statusUgrLabel.Foreground = System.Windows.Media.Brushes.OrangeRed;
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

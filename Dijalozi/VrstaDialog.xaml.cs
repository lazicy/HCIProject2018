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
            } else
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

        /*      
        private ObservableCollection<Tip> _tipovi;
        private ObservableCollection<Etiketa> _etikete;
        public ObservableCollection<Tip> Tipovi
        {
            get
            {
                return _tipovi;
            }
            set
            {
                if (value != _tipovi)
                {
                    _tipovi = value;
                    OnPropertyChanged("Tipovi");
                }
            }

        }

        public ObservableCollection<Etiketa> Etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                if (value != _etikete)
                {
                    _etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }

        }
         private string _id;
         private string _naziv;
         private string _opis;
         private double _prihod = 0;
         private BitmapImage _ikonicaView;
        


        public ObservableCollection<Tip> Tipovi
        {
            get
            {
                return _tipovi;
            }
            set
            {
                if (value != _tipovi)
                {
                    _tipovi = value;
                    OnPropertyChanged("Tipovi");
                }
            }

        }

        public ObservableCollection<Etiketa> Etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                if (value != _etikete)
                {
                    _etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }

        }




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


        public string Naziv
        {
            get
            {
                return _naziv;
            }
            set
            {
                if (value != _naziv)
                {
                    _naziv = value;
                    OnPropertyChanged("Naziv");
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



        public double Prihod
        {
            get
            {
                return _prihod;
            }
            set
            {
                if (value != _prihod)
                {
                    _prihod= value;
                    OnPropertyChanged("Prihod");
                }
            }
        }
        *
        public BitmapImage IkonicaView
        {
            get
            {
                return _ikonicaView;
            }
            set
            {
                if (value != _ikonicaView)
                {
                    _ikonicaView = value;
                    OnPropertyChanged("IkonicaView");
                }
            }
        }

        //public var Tip;
        public Uri Ikonica;
        public string StatusUgrozenosti;
        public bool OpasnaPoLjude;
        public bool ListaIUCN;
        public bool NaseljenaRegija;
        public string TuristickiStatus;
        public DateTime Datum;
        public ObservableCollection<Etiketa> DodeljeneEtikete;



    */
        #endregion

        




        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            /*Tip Tip = (Tip)tip.SelectedItem;
            StatusUgrozenosti = statusUgr.Text;
            OpasnaPoLjude = (bool)opasnaPoLjude.IsChecked;
            ListaIUCN = (bool)listaIUCN.IsChecked;
            NaseljenaRegija = (bool)naseljenaRegija.IsChecked;
            TuristickiStatus = turStatus.Text;
            Datum = datum.SelectedDate.Value;
            DodeljeneEtikete = new ObservableCollection<Etiketa>();
            
            foreach(Etiketa etiketa in listaEtiketa.Items)
            {
                if(etiketa.Otkaceno)
                {
                    DodeljeneEtikete.Add(etiketa);
                    etiketa.Otkaceno = false;
                }
            }


            Console.WriteLine("[V] ID: {0} || Naziv: {1} || Opis: {2} || Ugrozen: {3} || Opasna: {4} || IUCN: {5} || Regija: {6} || Datum: {7} || Prihod: {8} || Ikonica: {9} || Tip {10}"
                , Id, Naziv, Opis, StatusUgrozenosti, OpasnaPoLjude, ListaIUCN, NaseljenaRegija, Datum, Prihod, Ikonica, Tip.Naziv);
            Model.Vrsta v = new Model.Vrsta(Id, Naziv, Opis, Tip, StatusUgrozenosti, Ikonica, OpasnaPoLjude, ListaIUCN, NaseljenaRegija, TuristickiStatus, Prihod, Datum, DodeljeneEtikete);
            MainWindow.InstancaKolekcije.Vrste.Add(v);
            this.Close();
            MainWindow.InstancaKolekcije.PrintVrsta();
            */
            Console.WriteLine("[V] ID: {0} || Naziv: {1} || Opis: {2} || Ugrozen: {3} || Opasna: {4} || IUCN: {5} || Regija: {6} || Datum: {7} || Prihod: {8} || Ikonica: {9} || TurStatus: {10} || Tip: {11} "
               ,v.Id, 
                v.Naziv, 
                v.Opis, 
                v.StatusUgrozenosti, 
                v.OpasnaPoLjude, 
                v.ListaIUCN, 
                v.NaseljeniRegion, 
                v.DatumOtkrivanja, 
                v.Prihod,
                v.Ikonica,
                v.TuristickiStatus,
                v.Tip.Naziv
               );

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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
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
            editV.Tip = v.Tip;
            editV.OpasnaPoLjude = v.OpasnaPoLjude;
            editV.ListaIUCN = v.ListaIUCN;
            editV.NaseljeniRegion = v.NaseljeniRegion;
            editV.TuristickiStatus = v.TuristickiStatus;
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
       

        
    }
}

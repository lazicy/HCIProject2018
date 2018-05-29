using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HCI2018PZ4._3EURA78_2015.Model
{
    public class Kolekcije : INotifyPropertyChanged
    {
        private ObservableCollection<Vrsta> _vrste;
        private ObservableCollection<Tip> _tipovi;
        private ObservableCollection<Etiketa> _etikete;
        private ObservableCollection<Vrsta> _listaVrste;
        private ObservableCollection<Ikonica> _mapaVrste;


        public Kolekcije()
        {
            this._vrste = new ObservableCollection<Vrsta>();
            this._tipovi = new ObservableCollection<Tip>();
            this._etikete = new ObservableCollection<Etiketa>();
            this._listaVrste= new ObservableCollection<Vrsta>();
            this._mapaVrste = new ObservableCollection<Ikonica>();

        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private static Kolekcije instancaKolekcije = null;
        public static Kolekcije InstancaKolekcije
        {
            get
            {
                if (instancaKolekcije == null)
                {
                    instancaKolekcije = new Kolekcije();
                }
                return instancaKolekcije;
                    
            }
            set
            {
                instancaKolekcije = value;
             }
        }



        public ObservableCollection<Vrsta> Vrste
        {
            get { return _vrste; }
            set
            {
                if (this._vrste != value)
                {
                    this._vrste = value;
                    OnPropertyChanged("Vrste");
                }
            }
        }

        public ObservableCollection<Tip> Tipovi
        {
            get { return _tipovi; }
            set
            {
                if (this._tipovi != value)
                {
                    this._tipovi = value;
                    OnPropertyChanged("Tipovi");
                }
            }
        }

        public ObservableCollection<Etiketa> Etikete
        {
            get { return _etikete; }
            set
            {
                if (this._etikete != value)
                {
                    this._etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

        public ObservableCollection<Vrsta> ListaVrste
        {
            get { return _listaVrste; }
            set
            {
                if (this._listaVrste != value)
                {
                    this._listaVrste= value;
                    OnPropertyChanged("ListaVrste");
                }
            }
        }

        public ObservableCollection<Ikonica> MapaVrste
        {
            get { return _mapaVrste; }
            set
            {
                if (this._mapaVrste != value)
                {
                    this._mapaVrste = value;
                    OnPropertyChanged("MapaVrste");
                }
            }
        }



        public static void Sacuvaj()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "XML Files |*.xml";
            if (saveDialog.ShowDialog() == true)
            {
                using (var stream = new FileStream(saveDialog.FileName, FileMode.Create))
                {
                    var Xml = new XmlSerializer(typeof(Kolekcije));
                    Xml.Serialize(stream, Kolekcije.InstancaKolekcije);
                }
            }
        }
        
        public static void Ucitaj()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "XML Files |*.xml";
            if (openDialog.ShowDialog() == true)
            {

                using (var stream = new FileStream(openDialog.FileName, FileMode.Open))
                {
                    var Xml = new XmlSerializer(typeof(Kolekcije));
                    InstancaKolekcije =(Kolekcije) Xml.Deserialize(stream);
                    MainWindow.InstanceMW.RefreshView();
               }
            }
        }

        public void PrintVrsta()
        {
            foreach (Vrsta v in Vrste)
            {
                Console.WriteLine("IDvrste: {0} | Naziv vrste: {1}", v.Id, v.Naziv);
            }
        }

        public void PrintTipova()
        {
            foreach (Tip t in Tipovi)
            {
                Console.WriteLine("IDtipa: {0} | Naziv tipa: {1}", t.Id, t.Naziv);
            }
        }

        public void PrintEtiketa()
        {
            foreach (Etiketa e in Etikete)
            {
                Console.WriteLine("IDetikete: {0} | Boja etikete: {1}", e.Id, e.Boja);
            }
        }



    }
}

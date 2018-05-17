using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace HCI2018PZ4._3EURA78_2015.Model
{
    [Serializable]
    public class Vrsta : INotifyPropertyChanged
    {
        /*  public string Id {  get;  set; }
          public string Naziv { get; set; }
          public string Opis { get; set; }
          public Tip Tip { get; set; }
          public string StatusUgrozenosti { get; set; }
          public Uri Ikonica { get; set; }
          public bool OpasnaPoLjude { get; set; }
          public bool ListaIUCN { get; set; }
          public bool NaseljeniRegion { get; set; }
          public string TuristickiStatus { get; set; }
          public double Prihod { get; set; }
          public DateTime DatumOtkrivanja { get; set; }
          public ObservableCollection<Etiketa> Etikete { get; set; }
          
             public Vrsta(string id, string naziv, string opis, Tip tip, string statusUgrozenosti, Uri ikonica, bool opasna, bool IUCN, bool naseljeni, string turistickiStatus,
            double prihod, DateTime datumOtkrivanja, ObservableCollection<Etiketa> dodeljeneEtikete)
        {
            this.Id = id;
            this.Naziv = naziv;
            this.Opis = opis;
            this.Tip = tip;
            this.StatusUgrozenosti = statusUgrozenosti;
            this.Ikonica = ikonica;
            this.OpasnaPoLjude = opasna;
            this.ListaIUCN = IUCN;
            this.NaseljeniRegion = naseljeni;
            this.TuristickiStatus = turistickiStatus;
            this.Prihod = prihod;
            this.DatumOtkrivanja = datumOtkrivanja;
            this.Etikete = dodeljeneEtikete;
           // Console.WriteLine("ID: {0} || Naziv: {1} || Opis: {2} || Ikonica: {3} || Prihod {4}" , Id, Naziv, Opis, Ikonica, Prihod);

        }   
             
             */

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

        private string _id;
        private string _naziv;
        private string _opis;
        private Tip _tip;
        private int _statusUgrozenosti;
        private string _ikonica;
       // private BitmapImage _ikonicaView;
        private bool _opasnaPoLjude;
        private bool _listaIUCN;
        private bool _naseljeniRegion;
        private int _turistickiStatus;
        private double _prihod;
        private DateTime _datumOtkrivanja = System.DateTime.Today;
        private ObservableCollection<Etiketa> _dodeljeneEtikete = new ObservableCollection<Etiketa>();

        public Vrsta()
        {
            
        }

        public void ProveriChekiraneEtikete()
        {
            DodeljeneEtikete.Clear();
            foreach (Etiketa e in Etikete)
            {
                if (e.Otkaceno)
                {
                    Console.WriteLine("Otkacena etiketa: " + e.Id);
                    e.Otkaceno = false;
                    if (!DodeljeneEtikete.Contains(e))
                        DodeljeneEtikete.Add(e);
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
                    _prihod = value;
                    OnPropertyChanged("Prihod");
                }
            }
        }


        public Tip Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        public int StatusUgrozenosti
        {
            get
            {
                return _statusUgrozenosti;
            }
            set
            {
                if (value != _statusUgrozenosti)
                {
                    _statusUgrozenosti = value;
                    OnPropertyChanged("StatusUgrozenosti");
                }
            }
        }

        public string Ikonica
        {
            get
            {
                return _ikonica;
            }
            set
            {
                if (value != _ikonica)
                {
                    _ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        public bool OpasnaPoLjude
        {
            get
            {
                return _opasnaPoLjude;
            }
            set
            {
                if (value != _opasnaPoLjude)
                {
                    _opasnaPoLjude = value;
                    OnPropertyChanged("OpasnaPoLjude");
                }
            }
        }

        public bool ListaIUCN
        {
            get
            {
                return _listaIUCN;
            }
            set
            {
                if (value != _listaIUCN)
                {
                    _listaIUCN = value;
                    OnPropertyChanged("ListaIUCN");
                }
            }
        }


        public bool NaseljeniRegion
        {
            get
            {
                return _naseljeniRegion;
            }
            set
            {
                if (value != _naseljeniRegion)
                {
                    _naseljeniRegion = value;
                    OnPropertyChanged("NaseljeniRegion");
                }
            }
        }

        public int TuristickiStatus
        {
            get
            {
                return _turistickiStatus;
            }
            set
            {
                if (value != _turistickiStatus)
                {
                    _turistickiStatus = value;
                    OnPropertyChanged("TuristickiStatus");
                }
            }
        }

        public DateTime DatumOtkrivanja
        {
            get
            {
                return _datumOtkrivanja;
            }
            set
            {
                if (value != _datumOtkrivanja)
                {
                    _datumOtkrivanja = value;
                    OnPropertyChanged("DatumOtkrivanja");
                }
            }
        }

        public ObservableCollection<Etiketa> DodeljeneEtikete
        {
            get
            {
                return _dodeljeneEtikete;
            }
            set
            {
                if (value != _dodeljeneEtikete)
                {
                    _dodeljeneEtikete = value;
                    OnPropertyChanged("DodeljeneEtikete");
                }
            }
        }

        /*  
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
          }*/

        #region zaBinding dijaloga
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
        #endregion

    }
}



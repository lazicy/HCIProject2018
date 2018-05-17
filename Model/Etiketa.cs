using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HCI2018PZ4._3EURA78_2015.Model
{
    [Serializable]
    public class Etiketa : INotifyPropertyChanged
    {
        private string _id;
        private string _boja;
        private string _opis;
        private bool _otkaceno;

        public Etiketa()
        {
          
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


        public string Boja
        {
            get
            {
                return _boja;
            }
            set
            {
                if (value != _boja)
                {
                    _boja = value;
                    OnPropertyChanged("Boja");
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

        public bool Otkaceno
        {
            get
            {
                return _otkaceno;
            }
            set
            {
                if (value != _otkaceno)
                {
                    _otkaceno = value;
                    OnPropertyChanged("Otkaceno");
                }

            }
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

    }
}

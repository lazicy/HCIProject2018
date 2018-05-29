using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI2018PZ4._3EURA78_2015.Model
{
    public class Ikonica : INotifyPropertyChanged
    {

        private double x;
        private double y;
        private Vrsta v;

        public event PropertyChangedEventHandler PropertyChanged;

        public Ikonica() { }

        public Ikonica(double x, double y, Vrsta v)
        {
            this.x = x;
            this.y = y;
            this.v = v;
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (value != y)
                {
                    y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        public Vrsta V
        {
            get { return this.v; }
            set
            {
                if (this.v != value)
                {
                    v = value;
                    OnPropertyChanged("V");
                }
            }
        }
    }
}

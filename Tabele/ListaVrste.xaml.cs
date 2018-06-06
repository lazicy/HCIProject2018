using HCI2018PZ4._3EURA78_2015.Model;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCI2018PZ4._3EURA78_2015.Tabele
{
    /// <summary>
    /// Interaction logic for ListaVrste.xaml
    /// </summary>
   [ContentPropertyAttribute("Items")]
    public partial class ListaVrste : Window, INotifyPropertyChanged
    {
        public ListaVrste()
        {
            InitializeComponent();
            this.DataContext = this;
            VrsteLista = MainWindow.InstancaKolekcije.Vrste;
            Tipovi = MainWindow.InstancaKolekcije.Tipovi;
            MainWindow.InstanceMW.Hide();
            
        }
       



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

        

        private int _opcijaPretrage;
        public int OpcijaPretrage
        {
            get
            {
                return _opcijaPretrage;
            }
            set
            {
                if (value != _opcijaPretrage)
                {
                    _opcijaPretrage = value;
                    //OnPropertyChanged("OpcijaPretrage");
                    //Console.WriteLine("Opcija pretrage: " + OpcijaPretrage);
                }
            }
        }

        private ObservableCollection<Vrsta> _vrsteLista;
        public ObservableCollection<Vrsta> VrsteLista
        {
            get
            {
                return _vrsteLista;
            }
            set
            {
                if (value != _vrsteLista)
                {
                    _vrsteLista = value;
                    OnPropertyChanged("VrsteLista");
                }
            }
        }

        //public ObservableCollection<Vrsta> VrsteLista
        //{
        //    get;
        //    set;
        //}

        public ObservableCollection<Tip> Tipovi
        {
            get;
            set;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Dijalozi.VrstaDialog vrstaDialog = new Dijalozi.VrstaDialog();
            vrstaDialog.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow.InstanceMW.Show();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Vrsta v = (Vrsta)tabela.SelectedItem;
            Dijalozi.VrstaDialog vrstaDialog = new Dijalozi.VrstaDialog(v);
            vrstaDialog.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Vrsta v = (Vrsta)tabela.SelectedItem;
            MainWindow.InstancaKolekcije.Vrste.Remove(v);
            // MainWindow.InstancaKolekcije.ListaVrste.Remove(v);

            for (int i = 0; i < MainWindow.InstancaKolekcije.ListaVrste.Count; i++)
            {
                if (MainWindow.InstancaKolekcije.ListaVrste[i].Id.Equals(v.Id))
                {
                    MainWindow.InstancaKolekcije.ListaVrste.RemoveAt(i);
                }
            }
          //  MainWindow.InstanceMW.RefreshView();



            // TODO brisanje iz MapaVrste



            for (int i = 0; i < MainWindow.InstancaKolekcije.MapaVrste.Count; i++)
            {
                if (MainWindow.InstancaKolekcije.MapaVrste[i].V.Id.Equals(v.Id))
                {
                    Ikonica tempV = MainWindow.InstancaKolekcije.MapaVrste[i];
                    MainWindow.InstanceMW.canvasMapa.Children.RemoveAt(i);
                    MainWindow.InstancaKolekcije.MapaVrste.RemoveAt(i);
                    break;
                }
            }

            for (int i = 0; i < VrsteLista.Count; i++)
            {
                if (VrsteLista[i].Id.Equals(v.Id))
                {
                    VrsteLista.RemoveAt(i);
                }
            }

        }

        private void WindowClosing(object sender, CancelEventArgs e)
        {
            
            MainWindow.InstanceMW.Show();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ObservableCollection<Vrsta> filter = new ObservableCollection<Vrsta>();
            if (poljePretrage.Text.Equals(""))
            {
                VrsteLista = MainWindow.InstancaKolekcije.Vrste;
                return;
            }
           
            foreach(Vrsta v in MainWindow.InstancaKolekcije.Vrste)
            {
                //Console.WriteLine("Vrsta: " + v.Naziv);
                //Console.WriteLine("Opcija pretrage: " + OpcijaPretrage);
                //Console.WriteLine("Polje pretrage: " + poljePretrage.Text.ToLower());

                if ( OpcijaPretrage == 0)
                {
                    String all = v.Id.ToLower() + v.Naziv.ToLower() +  v.Tip.Naziv.ToLower() + v.Opis.ToLower() + v.Prihod.ToString() + v.TuristickiStatusStr.ToLower() + v.StatusUgrozenostiStr.ToLower();
                    if ( all.Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(v);
                        continue;
                    }
                }

                if ( OpcijaPretrage == 1)
                {
                    if (v.Id.ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(v);
                        continue;
                    }
                    
                }

                if (OpcijaPretrage == 2)
                {
                    if (v.Naziv.ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(v);
                        continue;
                    }

                }


                if (OpcijaPretrage == 3)
                {
                    if (v.Opis.ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(v);
                        continue;
                    }

                }


                if (OpcijaPretrage == 4)
                {
                    if (v.Tip.Naziv.ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(v);
                        continue;
                    }

                }

                if (OpcijaPretrage == 5)
                {
                    if (v.Prihod.ToString().ToLower().Contains(poljePretrage.Text.ToLower()))
                    {
                        filter.Add(v);
                        continue;
                    }

                }

            }

            VrsteLista = filter;
        }

        private void clearFilter_Click(object sender, RoutedEventArgs e)
        {
            poljePretrage.Text = "";
            TextBox_KeyUp(null, null);
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string str = HelpProvider.GetHelpKey(this);
            HelpProvider.ShowHelp(str, this);
        }

    }
}


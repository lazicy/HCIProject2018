using HCI2018PZ4._3EURA78_2015.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HCI2018PZ4._3EURA78_2015
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public static MainWindow InstanceMW { get; private set; }
        public Point startPoint;
        private bool promena = false;

        public MainWindow()
        {
            InitializeComponent();
            vrsteLista.ItemsSource = Kolekcije.InstancaKolekcije.ListaVrste;
            this.DataContext = this;
            InstanceMW = this;


            //btnAdd.Source = new BitmapImage(new Uri("pack://application:,,,/Images/addbtn.png"));
            
            mapaImg.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/map.jpg"));
            startPoint = new Point();
                
        }

        public static MainWindow MainWindowInstance
        {
            get;
            set;
        }

        public void RefreshView()
        {
            vrsteLista.ItemsSource = Kolekcije.InstancaKolekcije.ListaVrste;
        }
        


        private void Vrsta_Click(object sender, RoutedEventArgs e)
        {
            Dijalozi.VrstaDialog vrstaDialog = new Dijalozi.VrstaDialog();
            vrstaDialog.Show();
        }

        private void Tip_Click(object sender, RoutedEventArgs e)
        {
            Dijalozi.TipDialog tipDialog = new Dijalozi.TipDialog();
            tipDialog.Show();
        }

        private void Etiketa_Click(object sender, RoutedEventArgs e)
        {
            Dijalozi.EtiketaDialog etiketaDialog = new Dijalozi.EtiketaDialog();
            etiketaDialog.Show();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Model.Kolekcije.Sacuvaj();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Model.Kolekcije.Ucitaj();
        }

        private void VrstaLisa_Click(object sender, RoutedEventArgs e)
        {
            Tabele.ListaVrste listaVrste = new Tabele.ListaVrste();
            listaVrste.Show();
        }

        private void TipLista_Click(object sender, RoutedEventArgs e)
        {
            Tabele.ListaTipovi listaTipovi = new Tabele.ListaTipovi();
            listaTipovi.Show();
        }

        private void EtiketaLista_Click(object sender, RoutedEventArgs e)
        {
            Tabele.ListaEtikete listaEtikete= new Tabele.ListaEtikete();
            listaEtikete.Show();

        }

        // drag n drop 
        private void vrsteLista_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
            promena = false;
        }

        private void vrsteLista_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                Vrsta v = (Vrsta)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", v);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

       
        private void canvasMapa_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void canvasMapa_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Vrsta v= e.Data.GetData("myFormat") as Vrsta;

                Kolekcije.InstancaKolekcije.ListaVrste.Remove(v);
                Image ikonica = new Image();
                ikonica.Height = 30;
                ikonica.Width = 30;
                BitmapImage ikonicaSource = new BitmapImage(new Uri(v.Ikonica));
                ikonica.Name = v.Id;
                ikonica.Source = ikonicaSource;

                if (!promena)
                {
                    this.canvasMapa.Children.Add(ikonica);

                    Point p = e.GetPosition(this.canvasMapa);

                    Canvas.SetLeft(ikonica, p.X);
                    Canvas.SetTop(ikonica, p.Y);

                    Ikonica icon = new Ikonica(p.X, p.Y, v);
                    Kolekcije.InstancaKolekcije.MapaVrste.Add(icon);
                }
                else
                {
                    Point p = e.GetPosition(this.canvasMapa);
                    for (int i = 0; i < Kolekcije.InstancaKolekcije.MapaVrste.Count; i++)
                    {
                        if (Kolekcije.InstancaKolekcije.MapaVrste[i].V.Id.Equals(v.Id))
                        {

                            Ikonica saCanvasa = Kolekcije.InstancaKolekcije.MapaVrste[i];
                            canvasMapa.Children.RemoveAt(i);
                            canvasMapa.Children.Insert(i, ikonica);

                            Vrsta pomV = razdaljina(p);
                            if (pomV != null)
                            {
                                p.X = saCanvasa.X;
                                p.Y = saCanvasa.Y;
                            }

                            Canvas.SetLeft(ikonica, p.X);
                            Canvas.SetTop(ikonica, p.Y);

                            Kolekcije.InstancaKolekcije.MapaVrste[i].X = p.X;
                            Kolekcije.InstancaKolekcije.MapaVrste[i].Y = p.Y;
                            break;
                        }
                    }
                }
            }

        }

        private void canvasMapa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(this.canvasMapa);
            promena = true;

            int i = 0;

            Vrsta pomV = razdaljina(startPoint);

            if (pomV != null)
            {
                for (i = 0; i < Kolekcije.InstancaKolekcije.MapaVrste.Count; i++)
                {
                    Image img = (Image)canvasMapa.Children[i];
                    //img.Opacity = 0.7;
                    canvasMapa.Children.RemoveAt(i);
                    canvasMapa.Children.Insert(i, img);
                    if (pomV.Id.Equals(Kolekcije.InstancaKolekcije.MapaVrste[i].V))
                    {
                        //img.Opacity = 1;
                        //img.Focus();
                        canvasMapa.Children.RemoveAt(i);
                        canvasMapa.Children.Insert(i, img);
                        break;
                    }
                }
            }
        }

        private void canvasMapa_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(canvasMapa);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Vrsta v = razdaljina(startPoint);

                if (v != null)
                {
                    DataObject dragData = new DataObject("myFormat", v);
                    DragDrop.DoDragDrop((DependencyObject)e.OriginalSource, dragData, DragDropEffects.Move);
                }
            }

        }


        public Vrsta razdaljina(Point p)
        {
            foreach (Ikonica icon in Kolekcije.InstancaKolekcije.MapaVrste)
            {
                if ((p.X > icon.X - 1 && p.X < icon.X + 40) && (p.Y > icon.Y - 1 && p.Y < icon.Y + 40))
                {
                    return icon.V;
                }
            }

            return null;
        }


        internal void doThings(string param)
        {
            throw new NotImplementedException();
        }

       

        private void canvasMapa_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(this.canvasMapa);
            Vrsta v = razdaljina(startPoint);

            if (v != null)
            {
                for (int i = 0; i < Kolekcije.InstancaKolekcije.MapaVrste.Count; i++)
                {
                    if (Kolekcije.InstancaKolekcije.MapaVrste[i].V.Id.Equals(v.Id))
                    {
                        Ikonica tempV = Kolekcije.InstancaKolekcije.MapaVrste[i];
                        canvasMapa.Children.RemoveAt(i);
                        Kolekcije.InstancaKolekcije.ListaVrste.Add(tempV.V);
                        Kolekcije.InstancaKolekcije.MapaVrste.RemoveAt(i);
                        break;
                    }
                }
            }

        }

        private void canvasMapa_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int i = 0;

            Vrsta pomV= razdaljina(startPoint);

            if (pomV != null)
            {
                for (i = 0; i < Kolekcije.InstancaKolekcije.MapaVrste.Count; i++)
                {
                    Image img = (Image)canvasMapa.Children[i];
                    canvasMapa.Children.RemoveAt(i);
                    canvasMapa.Children.Insert(i, img);
                    if (pomV.Id.Equals(Kolekcije.InstancaKolekcije.MapaVrste[i].V))
                    {
                        canvasMapa.Children.RemoveAt(i);
                        canvasMapa.Children.Insert(i, img);
                        break;
                    }
                }
            }
        }







    }
}

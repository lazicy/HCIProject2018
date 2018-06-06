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

namespace HCI2018PZ4._3EURA78_2015.Dijalozi
{
    /// <summary>
    /// Interaction logic for Tutorial.xaml
    /// </summary>
    public partial class Tutorial : Window
    {
        public Tutorial()
        {
            InitializeComponent();
            state();

        }
        public int gridIndex = 0;
        private void btnTutorialStart_Click(object sender, RoutedEventArgs e)
        {
            tabs.SelectedIndex += 1;
        }

        private void btnDalje_Click(object sender, RoutedEventArgs e)
        {
            if (gridIndex < 3)
            {
                gridIndex++;
                state();
            }
        }

        private void btnNazad_Click(object sender, RoutedEventArgs e)
        {
            if (gridIndex > 0)
            {
                gridIndex--;
                state();
            }
        }

        private void state()
        {
            switch (gridIndex)
            {
                case 0:
                    if (id.Text.Trim().Equals(""))
                    {
                        btnDalje.IsEnabled = false;
                    } else
                    {
                        btnDalje.IsEnabled = true;
                    }

                    btnDalje.Visibility = Visibility.Visible;
                    btnAdd.Visibility = Visibility.Hidden;
                    btnNazad.Visibility = Visibility.Hidden;

                    kec.Visibility = Visibility.Visible;
                    dvojka.Visibility = Visibility.Hidden;
                    trojka.Visibility = Visibility.Hidden;
                    cetvorka.Visibility = Visibility.Hidden;

                    id.IsEnabled = true;
                    id.BorderThickness = new Thickness(2, 2, 2, 2);
                    id.BorderBrush = System.Windows.Media.Brushes.Navy;
                    id.Focusable = true;
                    id.Focus();

                    colorPicker.IsEnabled = false;
                    colorPicker.ClearValue(TextBox.BorderBrushProperty);
                    colorPicker.ClearValue(TextBox.BorderThicknessProperty);

                    opis.IsEnabled = false;

                    break;

                case 1:
                    if (colorPicker.SelectedColor == null)
                    {
                        btnDalje.IsEnabled = false;
                    } else
                    {
                        btnDalje.IsEnabled = true;
                    }

                    id.IsEnabled = false;
                    id.ClearValue(TextBox.BorderBrushProperty);
                    id.ClearValue(TextBox.BorderThicknessProperty);

                    colorPicker.IsEnabled = true;
                    colorPicker.BorderThickness = new Thickness(2, 2, 2, 2);
                    colorPicker.BorderBrush = System.Windows.Media.Brushes.Navy;

                    opis.IsEnabled = false;
                    opis.ClearValue(TextBox.BorderBrushProperty);
                    opis.ClearValue(TextBox.BorderThicknessProperty);

                    btnDalje.Visibility = Visibility.Visible;
                    btnAdd.Visibility = Visibility.Hidden;
                    btnNazad.Visibility = Visibility.Visible;

                    kec.Visibility = Visibility.Hidden;
                    dvojka.Visibility = Visibility.Visible;
                    trojka.Visibility = Visibility.Hidden;
                    cetvorka.Visibility = Visibility.Hidden;
                    break;
                case 2:

                    id.IsEnabled = false;
                    id.ClearValue(TextBox.BorderBrushProperty);
                    id.ClearValue(TextBox.BorderThicknessProperty);

                    colorPicker.IsEnabled = false;
                    colorPicker.ClearValue(TextBox.BorderBrushProperty);
                    colorPicker.ClearValue(TextBox.BorderThicknessProperty);

                    opis.IsEnabled = true;
                    opis.BorderThickness = new Thickness(2, 2, 2, 2);
                    opis.BorderBrush = System.Windows.Media.Brushes.Navy;


                    btnDalje.Visibility = Visibility.Visible;
                    btnAdd.Visibility = Visibility.Hidden;
                    btnNazad.Visibility = Visibility.Visible;

                    kec.Visibility = Visibility.Hidden;
                    dvojka.Visibility = Visibility.Hidden;
                    trojka.Visibility = Visibility.Visible;
                    cetvorka.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    opis.IsEnabled = false;
                    opis.ClearValue(TextBox.BorderBrushProperty);
                    opis.ClearValue(TextBox.BorderThicknessProperty);

                    btnDalje.Visibility = Visibility.Hidden;
                    btnAdd.Visibility = Visibility.Visible;
                    btnNazad.Visibility = Visibility.Visible;

                    kec.Visibility = Visibility.Hidden;
                    dvojka.Visibility = Visibility.Hidden;
                    trojka.Visibility = Visibility.Hidden;
                    cetvorka.Visibility = Visibility.Visible;
                    
                    break;

            }
        }

        private void id_KeyUp(object sender, KeyEventArgs e)
        {
            if (id.Text.Trim().Equals(""))
            {
                btnDalje.IsEnabled = false;
                return;
            }

            btnDalje.IsEnabled = true;
        }

        private void colorPicker_GotFocus(object sender, RoutedEventArgs e)
        {
            if (colorPicker.SelectedColor == null)
            {
                btnDalje.IsEnabled = false;
                return;
            }
            btnDalje.IsEnabled = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

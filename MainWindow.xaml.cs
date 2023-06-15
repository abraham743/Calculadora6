
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace calculadora6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }
        public void ButtonClick(object sender, RoutedEventArgs e)
        {

            try
            {
                Button button = (Button)sender;
                string value = (string)button.Content;
                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }

            }
            catch (Exception ex)
            {

                throw new Exception("ha ocurrido un error" + ex.Message);
            }
        }
        //Metodo axuliares
        private bool IsNumber(string num)
        {
            // forma directa para validar si es numero
            return double.TryParse(num, out _);

            //if (double.TryParse(num, out _))
            //{
            //    return true;
            //}
            //return false;
        }
        // encabezado de numeros
        private void HandleNumbers(string value)
        {
            if (String.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text = value;
            }

            else
            {
                Screen.Text += value;
            }
        }










    }
    
}

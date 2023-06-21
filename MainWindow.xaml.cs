
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
                else if (IsOperator(value)) { HandleOperator(value); }
                else if (value=="CE") { Screen.Clear(); }
                else if (value =="=") { HandleEquals(Screen.Text); }

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

        private bool IsOperator(string possibleOperator)
        {
            //if(possibleOperator =="+" || possibleOperator =="-" || possibleOperator=="*" ||
               // possibleOperator=="/") 
            //{
                return possibleOperator == "+" || possibleOperator == "-" || possibleOperator == "*" ||
                possibleOperator=="/";
            //}
        }

        private void HandleOperator(string value) 
        { 
            if(!String.IsNullOrEmpty(Screen.Text)&& !ContainsOtherOperator(Screen.Text))
            {
                Screen.Text += value;
            }
        }
        
        //validacion
        
        private bool ContainsOtherOperator(string screenContent)
        {
            return screenContent.Contains("+") || screenContent.Contains("-") 
                || screenContent.Contains("*") || screenContent.Contains("/");
        }
        
        private void HandleEquals(string ScreenContenet)
        {
            string op=FindOperator(ScreenContenet);
            if(!string.IsNullOrEmpty(op))
            {
                switch (op)
                {
                    case "+":
                        Screen.Text = Sum();
                        break;

                        case "-":
                        Screen.Text = Res();
                       break;

                    case "*":
                        Screen.Text = Mult();
                        break;

                        case "/":
                        Screen.Text = Div();
                        break;
                    default:
                        break;

                }
            }
        }

        private string FindOperator(string screenContenet)
        {
            foreach (var c in screenContenet)
            {
                if (IsOperator(c.ToString()))
                { return c.ToString(); }
                
            }
            return "";
        }
         
        private string Sum()
        {
            string[] number = Screen.Text.Split('+');
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);

            return Math.Round(n1 + n2,12).ToString();
        }
        private string Res()
        {
            string[]number = Screen.Text.Split("-");
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1],out double n2);

            return Math.Round(n1 - n2,12).ToString();

        }

        private string Mult()
        {
            string[]number=Screen.Text.Split("*");
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);

            return Math.Round(n1 * n2,12).ToString();
        }

        private string Div()
        {
            string[] number = Screen.Text.Split("/");
            double.TryParse(number[0], out double n1);
            double.TryParse(number[1], out double n2);

            return Math.Round(n1 / n2,12).ToString();
        }
    }
    
}

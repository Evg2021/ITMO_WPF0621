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


namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Calcul : Window
    {

		/// Required designer variable.

		//private System.ComponentModel.Container components = null;
		private bool AdvCalcVisibility = false;
		public WPFCalculator.Funkt NewWindow { get; set; }

		public Calcul()
        {
            InitializeComponent();
            AdvCalc.Visibility = Visibility.Collapsed;
			foreach (UIElement c in NumPad.Children)
            {
				((Button)c).Click += Button_Click;
            }
			foreach (UIElement c in AdvCalc.Children)
			{
				((Button)c).Click += Button_Click;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
        {
			string ButtonName = (string)((Button)e.OriginalSource).Content;
			
			switch (ButtonName)
            {
				case "AХ²+BX+C":
					if (NewWindow == null)
					{
						NewWindow = new WPFCalculator.Funkt();
						NewWindow.Owner = this;
						NewWindow.Show();
					}
					break;
				case "3√":
					OutputDisplay.Text = CalcEngine.CalcCubic();
					break;
				case "n!":
                    OutputDisplay.Text = CalcEngine.CalcFactorial();
					break;
				case "x^2":
					OutputDisplay.Text = CalcEngine.CalcSquare();
					break;
				case "1/x":
					OutputDisplay.Text = CalcEngine.CalcReverseValue();
					break;
				case "√":
					OutputDisplay.Text = CalcEngine.CalcSqrt();
					break;
				case "x^n":
					CalcEngine.CalcOperation(CalcEngine.Operator.ePow);
					break;
				case "-/+":
					OutputDisplay.Text = CalcEngine.CalcSign();
					break;
				case ".":
					OutputDisplay.Text = CalcEngine.CalcDecimal();
					break;
				case "+":
					CalcEngine.CalcOperation(CalcEngine.Operator.eAdd);
					break;
				case "-":
					CalcEngine.CalcOperation(CalcEngine.Operator.eSubtract);
					break;
				case "×":
					CalcEngine.CalcOperation(CalcEngine.Operator.eMultiply);
					break;
				case "/":
					CalcEngine.CalcOperation(CalcEngine.Operator.eDivide);
					break;
				case "Date":
					OutputDisplay.Text = CalcEngine.GetDate();
					CalcEngine.CalcReset();
					break;
				case "C":
					CalcEngine.CalcReset();
					OutputDisplay.Text = "0";
					break;
				case "=":
					OutputDisplay.Text = CalcEngine.CalcEqual();
					CalcEngine.CalcReset();
					break;
				case "Exit":
					this.Close();
					break;
				default:
					OutputDisplay.Text = CalcEngine.CalcNumber(ButtonName);
					break;
			}
			

		}

        private void About_Click(object sender, RoutedEventArgs e)
        {
			MessageBox.Show(CalcEngine.GetVersion());
        }

        private void AdvancedCalc_Click(object sender, RoutedEventArgs e)
        {
			if (!AdvCalcVisibility)
            {
				MainWindow.Height = 590;
				AdvCalc.Height = 80;
				AdvCalc.Visibility = Visibility.Visible;
				AdvCalcVisibility = true;
			}
			else
            {
				MainWindow.Height = 510;
				AdvCalc.Height = 0;
				AdvCalc.Visibility = Visibility.Collapsed;
				AdvCalcVisibility = false;
			}
		}
    }
}

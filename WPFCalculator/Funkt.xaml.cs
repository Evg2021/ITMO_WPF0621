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

namespace WPFCalculator
{
    /// <summary>
    /// Логика взаимодействия для QuadEquation.xaml
    /// </summary>
   
    public partial class Funkt : Window
    {
        public Funkt()
        {
            InitializeComponent();
        }       
        private void ResButton_Click(object sender, RoutedEventArgs e)
        {
            string Result = WPFCalculator.CalcEngine.CalcQuad(Convert.ToDouble(NumA.Text), Convert.ToDouble(NumB.Text), Convert.ToDouble(NumC.Text));
            string[] Res = Result.Split(';');
            if (Res.Count() == 2)
            {
                NumX1.Text = Res[0];
                NumX2.Text = Res[1];
            }
            else
            {
                NumX1.Text = Res[0];
                NumX2.Text = "н/д";
            }
        }

    }

}

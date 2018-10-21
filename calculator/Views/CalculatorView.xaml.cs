using Calculator.ViewModels;
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

namespace Calculator.Views
{
    /// <summary>
    /// Interaction logic for CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : Window
    {
        public CalculatorView()
        {
            InitializeComponent();
            DataContext = new CalculatorViewModel();
            //tb1.Text = DataContext.CalculatorVar.FirstOperand;
            //tb1.Text = "hello";
        }

        private void TextBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
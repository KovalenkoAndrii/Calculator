using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class CalculatorModel : INotifyPropertyChanged
    {
        private string firstOperand;
        private string secondOperand;
        private string operation;
        private string result;

        public string FirstOperand
        {
            get { return firstOperand; }
            set
            {
                firstOperand = value;
                OnPropertyChanged("FirstOperand");
            }
        }
        public string SecondOperand
        {
            get { return secondOperand; }
            set
            {
                secondOperand = value;
                OnPropertyChanged("SecondOperand");
            }
        }
        public string Operation
        {
            get { return operation; }
            set
            {
                operation = value;
                OnPropertyChanged("Operation");
            }
        }
        public string Result
        {
            get { return result; }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

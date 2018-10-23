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
         
        public CalculatorModel()
        {
            firstOperand = string.Empty;
            secondOperand = string.Empty;
            operation = string.Empty;
            result = string.Empty;
        }
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
        public void Calculation(string FirstOperand,string Operation, string SecondOperand)
        {
            double res = 0.0;
            switch (Operation)
            {
                case "+":
                    res = double.Parse(FirstOperand) + double.Parse(SecondOperand);
                    Result = res.ToString();
                    break;
                case "-":
                    res = double.Parse(FirstOperand) - double.Parse(SecondOperand);
                    Result = res.ToString();
                    break;
                case "*":
                    res = double.Parse(FirstOperand) * double.Parse(SecondOperand);
                    Result = res.ToString();
                    break;
                case "/":
                    if (SecondOperand != "0")
                    {
                        res = double.Parse(FirstOperand) / double.Parse(SecondOperand);
                        Result = res.ToString();
                    }
                    else
                    {
                        Result = "Деление на ноль";
                    }
                    break;
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

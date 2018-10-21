using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using calculator.Command;
using Calculator.Models;

namespace Calculator.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
        public CalculatorModel CalculatorVar;
        public string TextBox1;

        public ObservableCollection<CalculatorModel> Phones { get; set; }

        private CalculatorCommand plusCommand;

        public CalculatorCommand PlusCommand
        {
            get
            {
                return plusCommand ??
                  (plusCommand = new CalculatorCommand(obj =>
                  { 
                      CalculatorModel objCalculator = new CalculatorModel();
                      objCalculator.Result = objCalculator.FirstOperand + objCalculator.Operation + objCalculator.SecondOperand;
                      Phones[0].Result = "x2lel";
                  }));
            }
        }
        //command for write value button in operand
        private CalculatorCommand digitBtnPressCommand;

        public CalculatorCommand DigitBtnPressCommand
        {
            get
            {
                return digitBtnPressCommand ??
                    (digitBtnPressCommand = new CalculatorCommand(obj =>
                    {
                        string number = obj as string;
                        Phones[0].Result = number;
                    }));
            }
        }

        public CalculatorViewModel()
        {
            CalculatorVar = new CalculatorModel();
            CalculatorVar.FirstOperand = "Hello";

            Phones = new ObservableCollection<CalculatorModel>
            {
                new CalculatorModel { FirstOperand="2",SecondOperand="+",Operation="1",Result="lel" }
            };
        }

    }
}

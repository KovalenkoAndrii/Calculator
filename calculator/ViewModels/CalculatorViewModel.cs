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
        private string display;

        public ObservableCollection<CalculatorModel> Calculation { get; set; }

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
                      Calculation[0].Result = "x2lel";
                  }));
            }
        }
        //command to track button presses and call method for write operand
        private CalculatorCommand digitBtnPressCommand;

        public CalculatorCommand DigitBtnPressCommand
        {
            get
            {
                return digitBtnPressCommand ??
                    (digitBtnPressCommand = new CalculatorCommand(obj =>
                    {
                        
                        string valueButton = obj as string;
                        DigitButtonPress(valueButton);
                        
                    }));
            }
        }
        //
        public void DigitButtonPress(string valueButton)
        {
            if (Display != null) { Display += valueButton; }
            else { Display = valueButton; }
            
           // Calculation[0].Result = valueButton;
        }

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged("Display");
            }
        }
        public CalculatorViewModel()
        {
            CalculatorVar = new CalculatorModel();
            CalculatorVar.FirstOperand = "Hello";

            Calculation = new ObservableCollection<CalculatorModel>
            {
                new CalculatorModel { FirstOperand="2",SecondOperand="+",Operation="1",Result="lel" }
            };
        }

    }
}

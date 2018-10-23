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
        public CalculatorModel vmCalculation;
        private string display="0";
        private bool newDisplayRequired = false;
        private string lastOperation;
        private string vmFirstOperand;
        private string vmSecondOperand;
        private string fullExpression;

        public ObservableCollection<CalculatorModel> Calculation { get; set; }

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
        public void DigitButtonPress(string valueButton)//work display
        {
            switch (valueButton)
            {
                default:
                    if (display == "0" || newDisplayRequired)
                        Display = valueButton;
                    else
                        Display = display + valueButton ;
                    break;

            }
            newDisplayRequired = false;
        }
        private CalculatorCommand operationBtnPressCommand;
        public CalculatorCommand OperationBtnPressCommand
        {
            get
            {
                return operationBtnPressCommand ??
                    (operationBtnPressCommand = new CalculatorCommand(obj =>
                    {

                        string valueButton = obj as string;
                        OperationButtonPress(valueButton);

                    }));
            }
        }
        public void OperationButtonPress(string valueBtnOperation)
        {

            if (vmCalculation.FirstOperand == string.Empty || LastOperation == "=")
            {
                vmCalculation.FirstOperand = display;
                LastOperation = valueBtnOperation;
            }
            else
            { 
                vmCalculation.SecondOperand = display;
                vmCalculation.Operation = lastOperation;
                vmCalculation.Calculation(vmCalculation.FirstOperand, vmCalculation.Operation, vmCalculation.SecondOperand);
                if (vmCalculation.SecondOperand != "0" && vmCalculation.Operation != "/")
                {
                    FullExpression = vmCalculation.FirstOperand + " " + vmCalculation.Operation + " " + vmCalculation.SecondOperand + " " + "=" + vmCalculation.Result;
                }
                else
                {
                    FullExpression = "Ділення на нуль";
                }
                LastOperation = valueBtnOperation;
                Display = vmCalculation.Result;
                vmCalculation.FirstOperand   = display;
            }
            newDisplayRequired = true;
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
        public string LastOperation
        {
            get { return lastOperation; }
            set
            {
                lastOperation = value;
                OnPropertyChanged("LastOperation");
            }
        }
        public string VmFirstOperand
        {
            get { return vmFirstOperand; }
            set
            {
                
                   vmFirstOperand = value;
                OnPropertyChanged("VmFirstOperand");
            }
        }
        public string VmSecondOperand
        {
            get { return vmSecondOperand; }
            set
            {
                vmSecondOperand = value;
                OnPropertyChanged("VmSecondOperand");
            }
        }
        public string FullExpression
        {
            get { return fullExpression; }
            set
            {
                fullExpression = value;
                OnPropertyChanged("FullExpression");
            }
        }
        
        public CalculatorViewModel()
        {
            vmCalculation = new CalculatorModel();

            Calculation = new ObservableCollection<CalculatorModel>
            {
                new CalculatorModel { FirstOperand="",SecondOperand="",Operation="",Result="" }
            };
        }

    }
}

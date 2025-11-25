using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CalculatorGUI.ViewModels
{
    public partial class CalculatorViewModel : ViewModelBase
    {
        private readonly LinuxCalculator.Calculator _calculator;
        
        [ObservableProperty]
        private string _display = "0";
        
        [ObservableProperty]
        private string _memory = "";

        private string _operation = "";
        private double _firstOperand = 0;
        private bool _isNewEntry = true;

        public ObservableCollection<string> History { get; }

        public CalculatorViewModel()
        {
            _calculator = new LinuxCalculator.Calculator();
            History = new ObservableCollection<string>();
        }

        [RelayCommand]
        public void NumberPressed(string number)
        {
            if (_isNewEntry)
            {
                Display = number;
                _isNewEntry = false;
            }
            else
            {
                Display = Display == "0" ? number : Display + number;
            }
        }

        [RelayCommand]
        public void DecimalPressed()
        {
            if (_isNewEntry)
            {
                Display = "0.";
                _isNewEntry = false;
            }
            else if (!Display.Contains("."))
            {
                Display += ".";
            }
        }

        [RelayCommand]
        public void OperationPressed(string op)
        {
            if (!_isNewEntry && _operation != "")
            {
                EqualsPressed();
            }

            _operation = op;
            if (double.TryParse(Display, out double value))
            {
                _firstOperand = value;
            }
            _isNewEntry = true;
        }

        [RelayCommand]
        public void EqualsPressed()
        {
            if (_operation == "" || _isNewEntry) return;

            if (!double.TryParse(Display, out double secondOperand)) return;

            try
            {
                double result = _operation switch
                {
                    "+" => _calculator.Add(_firstOperand, secondOperand),
                    "-" => _calculator.Subtract(_firstOperand, secondOperand),
                    "*" => _calculator.Multiply(_firstOperand, secondOperand),
                    "/" => _calculator.Divide(_firstOperand, secondOperand),
                    "^" => _calculator.Power(_firstOperand, secondOperand),
                    _ => secondOperand
                };

                string calculation = $"{_firstOperand} {_operation} {secondOperand} = {result}";
                History.Insert(0, calculation);
                _calculator.SaveToHistory(result);

                Display = result.ToString();
                _operation = "";
                _isNewEntry = true;
            }
            catch (Exception ex)
            {
                Display = "Error: " + ex.Message;
                _isNewEntry = true;
            }
        }

        [RelayCommand]
        public void Clear()
        {
            Display = "0";
            _operation = "";
            _firstOperand = 0;
            _isNewEntry = true;
        }

        [RelayCommand]
        public void ClearEntry()
        {
            Display = "0";
            _isNewEntry = true;
        }

        [RelayCommand]
        public void Backspace()
        {
            if (Display.Length > 1 && !_isNewEntry)
            {
                Display = Display[..^1];
            }
            else
            {
                Display = "0";
                _isNewEntry = true;
            }
        }

        [RelayCommand]
        public void Negate()
        {
            if (double.TryParse(Display, out double value))
            {
                Display = (-value).ToString();
            }
        }

        [RelayCommand]
        public void SquareRoot()
        {
            if (double.TryParse(Display, out double value))
            {
                try
                {
                    double result = _calculator.SquareRoot(value);
                    History.Insert(0, $"√{value} = {result}");
                    Display = result.ToString();
                    _isNewEntry = true;
                }
                catch (Exception ex)
                {
                    Display = "Error: " + ex.Message;
                    _isNewEntry = true;
                }
            }
        }

        [RelayCommand]
        public void Square()
        {
            if (double.TryParse(Display, out double value))
            {
                double result = _calculator.Power(value, 2);
                History.Insert(0, $"{value}² = {result}");
                Display = result.ToString();
                _isNewEntry = true;
            }
        }

        [RelayCommand]
        public void Reciprocal()
        {
            if (double.TryParse(Display, out double value))
            {
                try
                {
                    double result = _calculator.Divide(1, value);
                    History.Insert(0, $"1/{value} = {result}");
                    Display = result.ToString();
                    _isNewEntry = true;
                }
                catch (Exception ex)
                {
                    Display = "Error: " + ex.Message;
                    _isNewEntry = true;
                }
            }
        }

        [RelayCommand]
        public void Percentage()
        {
            if (double.TryParse(Display, out double value))
            {
                double result = value / 100;
                Display = result.ToString();
            }
        }

        [RelayCommand]
        public void MemoryStore()
        {
            if (double.TryParse(Display, out double value))
            {
                _calculator.MemoryStore(value);
                Memory = "M";
            }
        }

        [RelayCommand]
        public void MemoryRecall()
        {
            double value = _calculator.MemoryRecall();
            Display = value.ToString();
            _isNewEntry = true;
        }

        [RelayCommand]
        public void MemoryClear()
        {
            _calculator.MemoryClear();
            Memory = "";
        }

        [RelayCommand]
        public void MemoryAdd()
        {
            if (double.TryParse(Display, out double value))
            {
                _calculator.MemoryAdd(value);
                Memory = "M";
            }
        }

        [RelayCommand]
        public void MemorySubtract()
        {
            if (double.TryParse(Display, out double value))
            {
                _calculator.MemorySubtract(value);
                Memory = "M";
            }
        }

        [RelayCommand]
        public void ClearHistory()
        {
            History.Clear();
            _calculator.ClearHistory();
        }

        [RelayCommand]
        public void Sin()
        {
            if (double.TryParse(Display, out double value))
            {
                double result = _calculator.Sine(value);
                History.Insert(0, $"sin({value}°) = {result}");
                Display = result.ToString();
                _isNewEntry = true;
            }
        }

        [RelayCommand]
        public void Cos()
        {
            if (double.TryParse(Display, out double value))
            {
                double result = _calculator.Cosine(value);
                History.Insert(0, $"cos({value}°) = {result}");
                Display = result.ToString();
                _isNewEntry = true;
            }
        }

        [RelayCommand]
        public void Tan()
        {
            if (double.TryParse(Display, out double value))
            {
                double result = _calculator.Tangent(value);
                History.Insert(0, $"tan({value}°) = {result}");
                Display = result.ToString();
                _isNewEntry = true;
            }
        }

        [RelayCommand]
        public void Log()
        {
            if (double.TryParse(Display, out double value))
            {
                try
                {
                    double result = _calculator.Logarithm(value);
                    History.Insert(0, $"log({value}) = {result}");
                    Display = result.ToString();
                    _isNewEntry = true;
                }
                catch (Exception ex)
                {
                    Display = "Error: " + ex.Message;
                    _isNewEntry = true;
                }
            }
        }

        [RelayCommand]
        public void Ln()
        {
            if (double.TryParse(Display, out double value))
            {
                try
                {
                    double result = _calculator.NaturalLog(value);
                    History.Insert(0, $"ln({value}) = {result}");
                    Display = result.ToString();
                    _isNewEntry = true;
                }
                catch (Exception ex)
                {
                    Display = "Error: " + ex.Message;
                    _isNewEntry = true;
                }
            }
        }
    }
}

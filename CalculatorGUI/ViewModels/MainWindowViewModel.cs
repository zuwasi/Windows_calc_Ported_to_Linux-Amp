namespace CalculatorGUI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public CalculatorViewModel Calculator { get; }

    public MainWindowViewModel()
    {
        Calculator = new CalculatorViewModel();
    }
}

namespace Calculations.Services.Calculators
{
    public class AddCalculator : ICalculator
    {
        public CalculationOperation Operation => CalculationOperation.Add;
        public string Name => "Add";

        public object Calculate(string a, string b)
        {
            return double.Parse(a) + double.Parse(b);
        }
    }
}

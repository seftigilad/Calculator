namespace Calculations.Services.Calculators
{
    public class CompareCalculator : ICalculator
    {
        public CalculationOperation Operation => CalculationOperation.Compare;
        public string Name => "Compare";

        public object Calculate(string a, string b)
        {
            return string.Compare(a, b, StringComparison.OrdinalIgnoreCase);
        }
    }
}

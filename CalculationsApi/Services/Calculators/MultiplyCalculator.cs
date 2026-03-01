namespace Calculations.Services.Calculators
{
    public class MultiplyCalculator : ICalculator
    {
        public CalculationOperation Operation => CalculationOperation.Multiply;
        public string Name => "Multiply";

        public object Calculate(string a, string b)
        {
            return double.Parse(a) * double.Parse(b);
        }
    }
}

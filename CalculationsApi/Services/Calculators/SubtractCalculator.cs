namespace Calculations.Services.Calculators
{
    public class SubtractCalculator : ICalculator
    {
        public CalculationOperation Operation => CalculationOperation.Subtract;
        public string Name => "Subtract";

        public object Calculate(string a, string b)
        {
            return double.Parse(a) - double.Parse(b);
        }
    }
}

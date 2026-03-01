namespace Calculations.Services.Calculators
{
    public class ConcatenateCalculator : ICalculator
    {
        public CalculationOperation Operation => CalculationOperation.Concatenate;
        public string Name => "Concatenate";

        public object Calculate(string a, string b)
        {
            return a + b;
        }
    }
}

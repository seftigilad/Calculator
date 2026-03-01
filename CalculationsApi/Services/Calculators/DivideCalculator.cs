namespace Calculations.Services.Calculators
{
    public class DivideCalculator : ICalculator
    {
        public CalculationOperation Operation => CalculationOperation.Divide;
        public string Name => "Divide";

        public object Calculate(string a, string b)
        {
            var divisor = double.Parse(b);
            if (divisor == 0)
                throw new DivideByZeroException("Cannot divide by zero.");

            return double.Parse(a) / divisor;
        }
    }
}

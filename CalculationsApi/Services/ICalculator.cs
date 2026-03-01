namespace Calculations.Services
{
    public interface ICalculator
    {
        CalculationOperation Operation { get; }
        string Name { get; }
        object Calculate(string a, string b);
    }
}

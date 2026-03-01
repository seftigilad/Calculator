namespace Calculations.Services
{
    public class CalculationRequest
    {
        public string A { get; set; }
        public string B { get; set; }
        public CalculationOperation Operation { get; set; }
    }
}

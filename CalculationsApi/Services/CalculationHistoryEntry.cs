namespace Calculations.Services
{
    public class CalculationHistoryEntry
    {
        public string A { get; set; }
        public string B { get; set; }
        public object Result { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}

namespace Calculations.Services
{
    public class CalculationResult
    {
        public object Result { get; set; }
        public IEnumerable<CalculationHistoryEntry> LastThreeSameTypeOperations { get; set; }
        public int SameTypeOperationsThisMonth { get; set; }
    }
}

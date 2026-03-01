namespace Calculations.Services
{
    public interface ICalculationService
    {
        IEnumerable<OperationInfo> GetOperations();
        object Calculate(string a, string b, CalculationOperation operation);
        Task<CalculationResult> CalculateWithHistoryAsync(string a, string b, CalculationOperation operation);
    }
}

using Calculations.Services;

namespace Calculations.Repositories
{
    public interface ICalculationHistoryRepository
    {
        Task AddAsync(CalculationOperation operation, string a, string b, object result);
        Task<IEnumerable<CalculationHistoryEntry>> GetLastThreeByOperationAsync(CalculationOperation operation);
        Task<int> GetCountThisMonthByOperationAsync(CalculationOperation operation);
    }
}

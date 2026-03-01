using Calculations.Repositories;
using Calculations.Services.Calculators;

namespace Calculations.Services
{
    public class CalculationService(ICalculationHistoryRepository historyRepository) : ICalculationService
    {
        private static readonly IEnumerable<ICalculator> _calculators =
        [
            new AddCalculator(),
            new SubtractCalculator(),
            new MultiplyCalculator(),
            new DivideCalculator(),
            new ConcatenateCalculator(),
            new CompareCalculator()
        ];

        public IEnumerable<OperationInfo> GetOperations() =>
            _calculators.Select(c => new OperationInfo { Operation = c.Operation, Name = c.Name });

        public object Calculate(string a, string b, CalculationOperation operation)
        {
            var calculator = _calculators.FirstOrDefault(c => c.Operation == operation)
                ?? throw new NotImplementedException($"Operation '{operation}' is not supported.");

            return calculator.Calculate(a, b);
        }

        public async Task<CalculationResult> CalculateWithHistoryAsync(string a, string b, CalculationOperation operation)
        {
            var result = Calculate(a, b, operation);

            await historyRepository.AddAsync(operation, a, b, result);

            var lastThree = await historyRepository.GetLastThreeByOperationAsync(operation);
            var countThisMonth = await historyRepository.GetCountThisMonthByOperationAsync(operation);

            return new CalculationResult
            {
                Result = result,
                LastThreeSameTypeOperations = lastThree,
                SameTypeOperationsThisMonth = countThisMonth
            };
        }
    }
}

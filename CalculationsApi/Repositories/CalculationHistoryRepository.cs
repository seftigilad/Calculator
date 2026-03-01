using Calculations.Services;
using Dapper;
using System.Data;

namespace Calculations.Repositories
{
    public class CalculationHistoryRepository(IDbConnection db) : ICalculationHistoryRepository
    {
        public async Task AddAsync(CalculationOperation operation, string a, string b, object result)
        {
            const string sql = """
                INSERT INTO CalculationHistory (Operation, A, B, Result, PerformedAt)
                VALUES (@Operation, @A, @B, @Result, GETUTCDATE())
                """;

            await db.ExecuteAsync(sql, new
            {
                Operation = operation.ToString(),
                A = a,
                B = b,
                Result = result.ToString()
            });
        }

        public async Task<IEnumerable<CalculationHistoryEntry>> GetLastThreeByOperationAsync(CalculationOperation operation)
        {
            const string sql = """
                SELECT TOP 3 A, B, Result, PerformedAt
                FROM CalculationHistory
                WHERE Operation = @Operation
                ORDER BY PerformedAt DESC
                """;

            return await db.QueryAsync<CalculationHistoryEntry>(sql, new { Operation = operation.ToString() });
        }

        public async Task<int> GetCountThisMonthByOperationAsync(CalculationOperation operation)
        {
            const string sql = """
                SELECT COUNT(*)
                FROM CalculationHistory
                WHERE Operation = @Operation
                  AND MONTH(PerformedAt) = MONTH(GETUTCDATE())
                  AND YEAR(PerformedAt)  = YEAR(GETUTCDATE())
                """;

            return await db.ExecuteScalarAsync<int>(sql, new { Operation = operation.ToString() });
        }
    }
}

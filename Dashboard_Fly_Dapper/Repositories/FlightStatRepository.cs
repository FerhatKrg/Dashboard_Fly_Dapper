using Dapper;
using Dashboard_Fly_Dapper.Dtos;
using Dashboard_Fly_Dapper.Models.DapperContext;

namespace Dashboard_Fly_Dapper.Repositories
{
    public class FlightStatRepository : IFlightStatRepository
    {
        private readonly Context _context;

        public FlightStatRepository(Context context)
        {
            _context = context;
        }

        public async Task<FlightStatusSummary> GetFlightStatusSummaryAsync()
        {
            string query = @"
        SELECT
            SUM(CASE WHEN cancelled = 1 THEN 1 ELSE 0 END) AS TotalCancelled,
            SUM(CASE WHEN dep_delay > 0 AND cancelled = 0 THEN 1 ELSE 0 END) AS TotalDelayed,
            CAST(SUM(CASE WHEN cancelled = 1 THEN 1 ELSE 0 END) AS FLOAT) 
                / COUNT(*) * 100 AS CancellationRate,
            CAST(SUM(CASE WHEN dep_delay > 0 AND cancelled = 0 THEN 1 ELSE 0 END) AS FLOAT) 
                / COUNT(*) * 100 AS DelayRate
        FROM Flights";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<FlightStatusSummary>(query);
        }
        public async Task<List<CancellationByReason>> GetCancellationByReasonAsync()
        {
            string query = @"
        SELECT
            CASE cancellation_code
                WHEN 'A' THEN 'Hava Koşulları'
                WHEN 'B' THEN 'Havayolu'
                WHEN 'C' THEN 'NAS'
                WHEN 'D' THEN 'Güvenlik'
                ELSE 'Bilinmiyor'
            END AS Reason,
            COUNT(*) AS TotalCancelled
        FROM Flights
        WHERE cancelled = 1
        GROUP BY cancellation_code
        ORDER BY TotalCancelled DESC";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<CancellationByReason>(query)).ToList();
        }

        public async Task<List<CancellationByMonth>> GetCancellationByMonthAsync()
        {
            string query = @"
        SELECT
            MONTH(fl_date) AS Month,
            COUNT(*)       AS TotalCancelled
        FROM Flights
        WHERE cancelled = 1
        GROUP BY MONTH(fl_date)
        ORDER BY Month ASC";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<CancellationByMonth>(query)).ToList();
        }

        public async Task<List<TopCancelledRoute>> GetTop10CancelledRoutesAsync()
        {
            string query = @"
        SELECT TOP 10
            origin           AS Origin,
            dest             AS Dest,
            origin_city_name AS OriginCity,
            dest_city_name   AS DestCity,
            COUNT(*)         AS TotalCancelled
        FROM Flights
        WHERE cancelled = 1
        GROUP BY origin, dest, origin_city_name, dest_city_name
        ORDER BY TotalCancelled DESC";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<TopCancelledRoute>(query)).ToList();
        }

        public async Task<List<TopDelayedAirline>> GetTop10DelayedAirlinesAsync()
        {
            string query = @"
        SELECT TOP 10
            op_unique_carrier    AS Carrier,
            AVG(CAST(dep_delay AS FLOAT)) AS AvgDelay
        FROM Flights
        WHERE dep_delay > 0 AND cancelled = 0
        GROUP BY op_unique_carrier
        ORDER BY AvgDelay DESC";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<TopDelayedAirline>(query)).ToList();
        }
    }
}

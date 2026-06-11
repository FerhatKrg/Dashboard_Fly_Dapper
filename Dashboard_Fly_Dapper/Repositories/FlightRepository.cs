using Dapper;
using Dashboard_Fly_Dapper.Dtos;
using Dashboard_Fly_Dapper.Models.DapperContext;

namespace Dashboard_Fly_Dapper.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly Context _context;

        public FlightRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<FlightByDayOfWeek>> GetFlightsByDayOfWeekAsync()
        {
            string query = @"
        SELECT 
            DATEPART(WEEKDAY, fl_date) AS DayOfWeek,
            COUNT(*)                   AS TotalFlights
        FROM Flights
        GROUP BY DATEPART(WEEKDAY, fl_date)
        ORDER BY DayOfWeek ASC";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<FlightByDayOfWeek>(query)).ToList();
        }

        public async Task<List<FlightByHour>> GetFlightsByHourAsync()
        {
            string query = @"
        SELECT 
            (crs_dep_time / 100) AS Hour,
            COUNT(*)             AS TotalFlights
        FROM Flights
        WHERE crs_dep_time IS NOT NULL
        GROUP BY (crs_dep_time / 100)
        ORDER BY Hour ASC";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<FlightByHour>(query)).ToList();
        }

        public async Task<List<FlightByMonth>> GetFlightsByMonthAsync()
        {
            string query = @"
        SELECT 
            MONTH(fl_date) AS Month,
            COUNT(*)       AS TotalFlights
        FROM Flights
        GROUP BY MONTH(fl_date)
        ORDER BY Month ASC";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<FlightByMonth>(query)).ToList();
        }

        public async Task<List<FlightByYear>> GetFlightsByYearAsync()
        {
            string query = @"
        SELECT 
            YEAR(fl_date) AS Year,
            COUNT(*)      AS TotalFlights
        FROM Flights
        GROUP BY YEAR(fl_date)
        ORDER BY Year ASC";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<FlightByYear>(query)).ToList();
        }

        public async Task<FlightSummary> GetFlightSummaryAsync()
        {
            string query = @"
        SELECT 
            COUNT(*) AS TotalFlights,
            CAST(COUNT(*) AS FLOAT) / COUNT(DISTINCT fl_date) AS DailyAverageFlights
        FROM Flights";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<FlightSummary>(query);
        }

        public async Task<AirportStat> GetLowestTrafficAirportAsync()
        {
            string query = @"
            SELECT TOP 1
                origin           AS AirportCode,
                origin_city_name AS CityName,
                COUNT(*)         AS TotalFlights
            FROM Flights
            GROUP BY origin, origin_city_name
            ORDER BY TotalFlights ASC";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<AirportStat>(query);
        }

        public async Task<AirportStat> GetMostDepartureAirportAsync()
        {
            string query = @"
            SELECT TOP 1
                origin           AS AirportCode,
                origin_city_name AS CityName,
                COUNT(*)         AS TotalFlights
            FROM Flights
            GROUP BY origin, origin_city_name
            ORDER BY TotalFlights DESC";

            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<AirportStat>(query);
        }

        public async Task<List<Top10Route>> GetTop10RoutesAsync()
        {
            string query = @"
        SELECT TOP 10
            origin           AS Origin,
            dest             AS Dest,
            origin_city_name AS OriginCity,
            dest_city_name   AS DestCity,
            COUNT(*)         AS TotalFlights
        FROM Flights
        GROUP BY origin, dest, origin_city_name, dest_city_name
        ORDER BY TotalFlights DESC";

            using var connection = _context.CreateConnection();
            return (await connection.QueryAsync<Top10Route>(query)).ToList();
        }
    }
}

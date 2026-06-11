using Dashboard_Fly_Dapper.Dtos;

namespace Dashboard_Fly_Dapper.Repositories
{
    public interface IFlightRepository
    {
        Task<AirportStat> GetMostDepartureAirportAsync();
        Task<FlightSummary> GetFlightSummaryAsync();
        Task<AirportStat> GetLowestTrafficAirportAsync();
        Task<List<FlightByYear>> GetFlightsByYearAsync();
        Task<List<FlightByDayOfWeek>> GetFlightsByDayOfWeekAsync();
        Task<List<FlightByMonth>> GetFlightsByMonthAsync();
        Task<List<Top10Route>> GetTop10RoutesAsync();
        Task<List<FlightByHour>> GetFlightsByHourAsync();
    }
}

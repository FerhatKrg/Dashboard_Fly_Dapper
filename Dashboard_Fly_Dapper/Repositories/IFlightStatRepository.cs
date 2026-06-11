using Dashboard_Fly_Dapper.Dtos;

namespace Dashboard_Fly_Dapper.Repositories
{
    public interface IFlightStatRepository
    {
        Task<FlightStatusSummary> GetFlightStatusSummaryAsync();
        Task<List<CancellationByReason>> GetCancellationByReasonAsync();
        Task<List<CancellationByMonth>> GetCancellationByMonthAsync();
        Task<List<TopCancelledRoute>> GetTop10CancelledRoutesAsync();
        Task<List<TopDelayedAirline>> GetTop10DelayedAirlinesAsync();
    }
}

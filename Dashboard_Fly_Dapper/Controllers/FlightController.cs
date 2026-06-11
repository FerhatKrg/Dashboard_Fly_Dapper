using Dashboard_Fly_Dapper.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dashboard_Fly_Dapper.Controllers
{
    [Authorize]
    public class FlightController : Controller
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IFlightStatRepository _flightStatRepository;
        public FlightController(IFlightRepository flightRepository, IFlightStatRepository flightStatRepository)
        {
            _flightRepository = flightRepository;
            _flightStatRepository = flightStatRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.LowestTrafficAirport = await _flightRepository.GetLowestTrafficAirportAsync();
            ViewBag.mostDepartureAirport = await _flightRepository.GetMostDepartureAirportAsync();

            ViewBag.FlightSummary = await _flightRepository.GetFlightSummaryAsync();


            ViewBag.flightsByMonth = await _flightRepository.GetFlightsByMonthAsync();
            ViewBag.flightsByDayOfWeek = await _flightRepository.GetFlightsByDayOfWeekAsync();
            ViewBag.top10Routes = await _flightRepository.GetTop10RoutesAsync();
            ViewBag.flightsByHour = await _flightRepository.GetFlightsByHourAsync();
            return View();
        }

        public async Task<IActionResult> FlightCancellationDelaySummary()
        {
            ViewBag.flightStatusSummary = await _flightStatRepository.GetFlightStatusSummaryAsync();
            ViewBag.cancellationByReason = await _flightStatRepository.GetCancellationByReasonAsync();
            ViewBag.cancellationByMonth = await _flightStatRepository.GetCancellationByMonthAsync();
            ViewBag.top10CancelledRoutes = await _flightStatRepository.GetTop10CancelledRoutesAsync();
            ViewBag.top10DelayedAirlines = await _flightStatRepository.GetTop10DelayedAirlinesAsync();
            return View();
        }
    }
}

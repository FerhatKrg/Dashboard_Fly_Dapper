namespace Dashboard_Fly_Dapper.Dtos
{
    public class FlightStatusSummary
    {
        public int TotalCancelled { get; set; }
        public int TotalDelayed { get; set; }
        public double CancellationRate { get; set; }
        public double DelayRate { get; set; }
    }
}

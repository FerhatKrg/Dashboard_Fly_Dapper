namespace Dashboard_Fly_Dapper.Dtos
{
    public class Top10Route
    {
        public string Origin { get; set; }
        public string Dest { get; set; }
        public string OriginCity { get; set; }
        public string DestCity { get; set; }
        public int TotalFlights { get; set; }
    }
}

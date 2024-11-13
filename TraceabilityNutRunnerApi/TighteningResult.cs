namespace TraceabilityNutRunnerApi
{
    public class TighteningResult
    {
        public Guid Id { get; set; }
        public string EngineNumber { get; set; }
        public string ResultTighteningStatus { get; set; }
        public string TimeStamp { get; set; }
        public List<TighteningDetail> TighteningDetails { get; set; } = new List<TighteningDetail>();
    }

    public class TighteningDetail
    {
        public int Id { get; set; }
        public int SpindleNumber { get; set; }
        public string TorqueResult { get; set; }
        public string AngleResult { get; set; }
        public Guid TighteningResultId { get; set; }
        public TighteningResult TighteningResult { get; set; }
    }
}

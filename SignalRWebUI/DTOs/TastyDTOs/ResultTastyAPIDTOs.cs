namespace SignalRWebUI.DTOs.TastyDTOs
{
    public class RootTastyApi
    {
        public List<ResultTastyAPIDTOs> Results { get; set; }
    }
    public class ResultTastyAPIDTOs
    {
        public string name { get; set; }
        public string original_video_url { get; set; }
        public int total_time_minutes { get; set; }
        public string thumbnail_url { get; set; }
    }
}

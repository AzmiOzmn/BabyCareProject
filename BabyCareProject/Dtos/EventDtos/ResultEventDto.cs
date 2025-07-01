namespace BabyCareProject.Dtos.EventDtos
{
    public class ResultEventDto
    {
        public string EventId { get; set; }
        public string Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}

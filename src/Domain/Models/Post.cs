namespace Domain.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }

        public bool IsSurvey { get; set; }
        public DateTime? SurveyClosureDateTime { get; set; }
        public List<Option>? Options { get; set; }
    }
}
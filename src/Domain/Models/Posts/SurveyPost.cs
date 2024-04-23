namespace Domain.Models.Posts
{
    public class SurveyPost: Post
    {
        public DateTime SurveyClosureDateTime { get; set; }
        public List<SurveyOption> Options { get; set; }
        public List<Vote> Votes { get; set; }
    }
}
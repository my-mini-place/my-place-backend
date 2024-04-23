namespace Domain.Models.Posts
{
    public class SurveyOption
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int NumVotes { get; set; }
    }
}
namespace Api.DTO.Posts
{
    public class PostDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public bool IsSurvey { get; set; }

        public DateTime? SurveyClosureDateTime { get; set; }
        public bool SurveyClosed { get; set; }
        public List<OptionDTO>? OptionsWithNumVotes { get; set; }
    }
}
using System.Data;

namespace Api.DTO.Posts
{
    public class PostCreateDTO
    {
       
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsSurvey { get; set; }

        public DateTime? SurveyClosureDateTime { get; set; }
        //public bool SurveyClosed { get; set; }
        public List<OptionDTO>? OptionsWithNumVotes { get; set; }
    }



    public class PostUpdateDTO
    {

        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    //    public bool IsSurvey { get; set; }

       // public DateTime? SurveyClosureDateTime { get; set; }
        //public bool SurveyClosed { get; set; }
       // public List<OptionDTO>? OptionsWithNumVotes { get; set; }
    }




    public class PostDTO
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsSurvey { get; set; }

        public DateTime? SurveyClosureDateTime { get; set; }
        public DateTime CreationDateTime { get; set; }
        public bool SurveyClosed { get; set; }
        public List<OptionDTO>? OptionsWithNumVotes { get; set; }

        public string UserVote { get; set; }
    }
}



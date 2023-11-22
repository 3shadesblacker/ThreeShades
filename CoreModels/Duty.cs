namespace WebAPI.Models
{
    public class Duty
    {
        public Duty()
        {
        }

        public Duty(int id, DutyState state, string? title, string? description, IEnumerable<Comment?>? comments)
        {
            Key = id;
            State = state;
            Title = title;
            Description = description;
            Comments = comments;
        }

        public Duty(DutyState state, string? title, string? description, IEnumerable<Comment?>? comments, DateTime? deadline, DateTime? completion)
        {
            State = state;
            Title = title;
            Description = description;
            Comments = comments;
            Deadline = deadline;
            CompletionDate = completion;
        }

        public int? Key { get; set; }

        public DutyState State { get; set; }

        public string? Title { get; set; }
        
        public string? Description { get; set; }

        public IEnumerable<Comment?>? Comments { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime? CompletionDate { get; set; }
    }
}

namespace WebAPI.Models
{
    public class Comment
    {
        public Comment() { }

        public Comment(int key, Duty duty, string text = "") 
        { 
            Key = key;
            DutyKey = duty.Key;
            Duty = duty;
            Text = text;
            Time = DateTime.Now;
        }

        public int? Key { get; set; }

        public int? DutyKey { get; set; }

        public Duty? Duty { get; set; } = new Duty();

        public string? Text { get; set; }

        public DateTime? Time { get; set; }
    }
}

using WebAPI.Models;

namespace MVC.Models
{
    public class CommentViewModel
    {
        public int? Key { get; set; }

        public int? DutyKey { get; set; }

        public DutyViewModel? Duty { get; set; } = new DutyViewModel();

        public string? Text { get; set; }

        public DateTime? Time { get; set; }
    }
}

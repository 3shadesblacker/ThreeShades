using System.ComponentModel;

namespace MVC.Models
{
    public class DutyViewModel
    {
        public int Key { get; set; }

        [DisplayName("Titre")]
        public string? Title { get; set; }

        [DisplayName("Description")]
        public string? Description { get; set; }

        [DisplayName("Commentaires")]
        public IEnumerable<CommentViewModel?>? Comments { get; set; }

        [DisplayName("Deadline")]
        public DateTime? Deadline { get; set; }

        public DateTime? CompletionDate { get; set; }

        public bool Done { get; set; }

        public int State { get; set; }

        public override string ToString()
        {
            return $"{Key} {Title} {Description} {Deadline} {CompletionDate}";
        }
    }
}

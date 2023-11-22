using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThreeShades.MVC.ViewModels
{
    public class DutyView
    {
        public DutyView(int id, bool done, bool canceled, string title, string description, DateTime deadline, string comments)
        {
            Id = id;
            Done = done;
            Canceled = canceled;
            Title = title;
            Description = description;
            Created = DateTime.Now;
            Deadline = deadline;
            Comments = comments;
        }

        public DutyView()
        {
            Id = -1;
            Done = false;
            Canceled = false;
            Title = string.Empty;
            Description = string.Empty;
            Created = DateTime.Now;
            Deadline = DateTime.MaxValue;
            Comments = string.Empty;
        }

        public int Id { get; set; }

        [DisplayName("Validée")]
        public bool Done { get; set; }

        [DisplayName("Titre")]
        [Required]
        public string Title { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Créée le")]
        public DateTime Created { get; }

        [DisplayName("Date limite: ")]
        [Required]
        public DateTime Deadline { get; set; }

        [DisplayName("Commentaires")]
        public string Comments { get; set; }

        public bool Canceled { get; set; }
    }
}
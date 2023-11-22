using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels
{
    public class DutyModel
    {
        public DutyModel() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Key { get; set; }

        [ForeignKey(nameof(State))]
        public int StateKey { get; set; }

        public DutyStateModel State { get; set; } = new DutyStateModel { Id = 0 };

        [StringLength(64)]
        [DefaultValue("")]
        public string? Title { get; set; }

        [StringLength(128)]
        [DefaultValue("")]
        public string? Description { get; set; }

        public DateTime? Deadline { get; set; }

        public DateTime? CompletionDate { get; set; }
    }
}
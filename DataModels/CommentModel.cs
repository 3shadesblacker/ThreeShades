using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels
{
    public class CommentModel
    {
        public CommentModel() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Key { get; set; }

        [ForeignKey(nameof(Duty))]
        public int DutyKey { get; set; }

        public DutyModel Duty { get; set; } = new DutyModel();

        [StringLength(128)]
        [DefaultValue("")]
        public string? Text { get; set; }

        public DateTime? Time { get; set; }
    }
}

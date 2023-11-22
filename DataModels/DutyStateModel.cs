using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModels
{
    public class DutyStateModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Key { get; set; }

        public byte Id { get; set; }

        [StringLength(16)]
        public string? Name { get; set; }
    }
}

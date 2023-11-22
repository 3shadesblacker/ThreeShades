using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThreeShades.MVC.Models
{
    public class Duty
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool Done { get; set; }

        [DefaultValue(false)]
        public bool Canceled { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Deadline { get; set; }

        public string? Comments { get; set; }
    }
}
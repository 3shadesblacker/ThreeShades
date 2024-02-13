using System.ComponentModel;
using WebAPI.Models;

namespace MVC.Models
{
    public class ListDutyViewModel
    {
        public ListDutyViewModel(int active, int done, int canceled)
        { 
            NActive = active;
            NDone = done;
            NCanceled = canceled;
        }

        public ListDutyViewModel(IEnumerable<DutyViewModel> list, DutyState state)
        { 
            switch (state)
            {
                case DutyState.Done:
                    Active = list;
                    break;
                case DutyState.Canceled:
                    Canceled = list;
                    break;
                default:
                    Done = list;
                    break;
            }
        }

        [DisplayName("Actives")]
        public IEnumerable<DutyViewModel> Active { get; set; } = new List<DutyViewModel>();

        [DisplayName("Complétées")]
        public IEnumerable<DutyViewModel> Done { get; set; } = new List<DutyViewModel>();

        [DisplayName("Annulées")]
        public IEnumerable<DutyViewModel> Canceled { get; set; } = new List<DutyViewModel>();

        [DisplayName("Tâches actives")]
        public int? NActive { get; set; }

        [DisplayName("Tâches complétées")]
        public int? NDone { get; set; }

        [DisplayName("Tâches annulées")]
        public int? NCanceled { get; set; }
    }
}

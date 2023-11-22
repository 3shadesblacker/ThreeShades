namespace ThreeShades.MVC.ViewModels
{
    public class DutyList
    {
        public DutyList(List<DutyView> active, List<DutyView> done, List<DutyView> canceled)
        {
            Active = active;
            Done = done;
            Canceled = canceled;
        }

        public List<DutyView> Active { get; set; }

        public List<DutyView> Done { get; set; }

        public List<DutyView> Canceled { get; set; }
    }
}
using I_did_those.Models;
using I_did_those.ViewModels;

namespace I_did_those.Interfaces
{
    public interface IDutyService
    {
        public DutyList GetDutyList(string tab, int page, int size);

        public DutyView GetDuty(int id);

        public bool DeleteDuty(int id);

        public bool CancelDuty(int id);

        public bool SaveDuty(int id);
    }
}

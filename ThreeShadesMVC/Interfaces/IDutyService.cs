using ThreeShades.MVC.ViewModels;

namespace ThreeShades.MVC.Interfaces
{
    public interface IDutyService
    {
        DutyList GetDutyList(string tab = "", int page = 1, int size = 10);

        DutyView GetDuty(int id);

        bool FinishDuty(int id);

        bool DeleteDuty(int id);

        bool CancelDuty(int id);

        bool SaveDuty(DutyView view);
    }
}

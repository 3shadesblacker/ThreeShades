using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IDutyService
    {
        Duty Get(int id);

        List<Duty> List(int page = 1, int size = 10, DutyState state = DutyState.None);

        IEnumerable<int> Stats();
    }
}

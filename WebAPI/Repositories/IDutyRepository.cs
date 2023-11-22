using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IDutyRepository
    {
        int Create(Duty duty);

        bool Update(Duty duty);

        bool Delete(int id);

        bool Cancel(int id);

        IEnumerable<Comment> GetComments(int? id);
    }
}

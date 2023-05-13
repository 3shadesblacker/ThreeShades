using I_did_those.Data;
using I_did_those.Interfaces;
using I_did_those.ViewModels;
using I_did_those.Mappers;
using System.Linq;

namespace I_did_those.Services
{
    public class DutyService : IDutyService
    {
        public DutyList dutyList;
        DutyService()
        {
            var active = new List<DutyView>();
            var done = new List<DutyView>();
            var canceled = new List<DutyView>();
            dutyList = new DutyList(active, done, canceled);
        }

        public DutyList GetDutyList(string tab, int page = 1, int size = 10)
        {
            switch (tab)
            {
                case "active":
                    GetActiveDuties(page, size);
                    break;

                case "done":
                    GetDoneDuties(page, size);
                    break;

                case "canceled":
                    GetCanceledDuties(page, size);
                    break;

                default:
                    GetActiveDuties(page, size);
                    GetDoneDuties(page, size);
                    GetCanceledDuties(page, size);
                    break;
            }
            return dutyList;
        }
        
        public DutyList GetActiveDuties(int page, int size)
        {
            using (var context = new IDidThoseDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<IDidThoseDbContext>()))
            {
                var active = context.Duties.Where(d => !d.Done)
                                           .OrderBy(d => d.Done)
                                           .Skip((page - 1) * size)
                                           .Take(size)
                                           .Select(d => DutyMapper.ToView(d))
                                           .ToList();
                dutyList.Active = dutyList.Active.Concat(active).ToList();
            }
            return dutyList;
        }
        
        public DutyList GetDoneDuties(int page, int size)
        {
            using (var context = new IDidThoseDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<IDidThoseDbContext>()))
            {
                var active = context.Duties.Where(d => d.Done)
                                           .OrderBy(d => d.Done)
                                           .Skip((page - 1) * size)
                                           .Take(size)
                                           .Select(d => DutyMapper.ToView(d))
                                           .ToList();
                dutyList.Active = dutyList.Done.Concat(active).ToList();
            }
            return dutyList;
        }
        
        public DutyList GetCanceledDuties(int page, int size)
        {
            using (var context = new IDidThoseDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<IDidThoseDbContext>()))
            {
                var active = context.Duties.Where(d => d.Canceled)
                                           .OrderBy(d => d.Done)
                                           .Skip((page - 1) * size)
                                           .Take(size)
                                           .Select(d => DutyMapper.ToView(d))
                                           .ToList();
                dutyList.Active = dutyList.Canceled.Concat(active).ToList();
            }
            return dutyList;
        }

        public bool CancelDuty(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDuty(int id)
        {
            throw new NotImplementedException();
        }

        public DutyView GetDuty(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveDuty(int id)
        {
            throw new NotImplementedException();
        }
    }
}

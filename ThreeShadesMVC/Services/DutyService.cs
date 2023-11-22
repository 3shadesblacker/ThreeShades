using ThreeShades.MVC.Interfaces;
using ThreeShades.MVC.Mappers;
using ThreeShades.MVC.Models;
using ThreeShades.MVC.ViewModels;

namespace ThreeShades.MVC.Services
{
    public class DutyService : IDutyService
    {
        private readonly ThreeShadesDataContext _context;
        public DutyList dutyList;

        public DutyService(ThreeShadesDataContext context)
        {
            _context = context;
            List<DutyView> active = new();
            List<DutyView> done = new();
            List<DutyView> canceled = new();
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
            using (_context)
            {
                List<DutyView> active = _context.Duties.Where(d => !d.Done)
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
            using (_context)
            {
                List<DutyView> active = _context.Duties.Where(d => d.Done)
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
            using (_context)
            {
                List<DutyView> active = _context.Duties.Where(d => d.Canceled)
                                           .OrderBy(d => d.Done)
                                           .Skip((page - 1) * size)
                                           .Take(size)
                                           .Select(d => DutyMapper.ToView(d))
                                           .ToList();
                dutyList.Active = dutyList.Canceled.Concat(active).ToList();
            }
            return dutyList;
        }

        public DutyView GetDuty(int id)
        {
            using (_context)
            {
                DutyView duty = DutyMapper.ToView(_context.Duties.FirstOrDefault(d => d.Id == id) ?? throw new NullReferenceException());
                return duty;
            }
        }

        public bool SaveDuty(DutyView duty)
        {
            try
            {
                using (_context)
                {
                    var model = _context.Duties.FirstOrDefault(m => m.Id == duty.Id);
                    if (model != null)
                    {
                        model.Title = duty.Title;
                        model.Description = duty.Description;
                        model.Deadline = duty.Deadline;
                        model.Comments = duty.Comments;
                        _context.Duties.Update(model);
                    }
                    else
                    {
                        model = new Duty
                        {
                            Title = duty.Title,
                            Description = duty.Description,
                            Created = duty.Created,
                            Deadline = duty.Deadline,
                            Comments = duty.Comments
                        };
                        _context.Duties.Add(model);
                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool FinishDuty(int id)
        {
            try
            {
                using (_context)
                {
                    var model = _context.Duties.FirstOrDefault(m => m.Id == id);
                    if (model != null)
                    {
                        model.Done = true;
                        _context.Duties.Update(model);
                        _context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool CancelDuty(int id)
        {
            try
            {
                using (_context)
                {
                    var model = _context.Duties.FirstOrDefault(m => m.Id == id);
                    if (model != null)
                    {
                        model.Canceled = true;
                        _context.Duties.Update(model);
                        _context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool DeleteDuty(int id)
        {
            try
            {
                using (_context)
                {
                    var model = _context.Duties.FirstOrDefault(m => m.Id == id);
                    if (model != null)
                    {
                        _context.Duties.Remove(model);
                        _context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}

using AutoMapper;
using DataModels;
using DBContext;
using WebAPI.Models;
using WebAPI.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Adapters.Repositories
{
    public class DutyRepository : IDutyRepository
    {
        #region Constructor
        private readonly ThreeShadesDBContext _context;
        private readonly IMapper _mapper;

        public DutyRepository(ThreeShadesDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        public bool Cancel(int id)
        {
            var model = _context.Duties.AsQueryable().FirstOrDefault(d => d.Key == id)
                      ?? throw new NullReferenceException("Duty couldn't be found");

            model.State = _context.DutyStates.AsQueryable().FirstOrDefault(d => d.Id == (int)DutyState.Canceled)
                        ?? throw new NullReferenceException("State 'Canceled' wasn't found");
            _context.Duties.ReplaceOne(d => d.Key == model.Key, model);
            return true;
        }

        public int Create(Duty duty)
        {
            var model = _mapper.Map<DutyModel>(duty);
            _context.Duties.InsertOne(model);
            return model.Key;
        }

        public bool Delete(int id)
        {
            try
            {
                var result = _context.Duties.DeleteOne(d => d.Key == id);
                return result.DeletedCount > 0;
            }
            catch { return false; }
        }

        public bool Update(Duty duty)
        {
            try
            {
                var model = _mapper.Map<DutyModel>(duty);
                model.State = _context.DutyStates.AsQueryable().FirstOrDefault(d => d.Id == (int)duty.State)
                            ?? throw new NullReferenceException("Duty State couldn't be found");
                _context.Duties.ReplaceOne(d => d.Key == model.Key, model);
                return true;
            }
            catch { return false; }
        }

        public IEnumerable<Comment> GetComments(int? id)
        {
            return _mapper.Map<IEnumerable<Comment>>(_context.Comments.AsQueryable()
                                                             .Where(c => c.DutyKey == id)
                                                             .AsEnumerable());
        }
    }
}

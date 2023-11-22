using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVC.Models;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Services;

namespace MVC.Controllers
{
    [Route("Duty")]
    public class DutyController : Controller
    {
        #region Constructors
        private readonly WebAPI.Controllers.DutyApiController _controller;
        private readonly IMapper _mapper;

        public DutyController(IDutyRepository repository, IDutyService service, IMapper mapper)
        {
            _controller = new WebAPI.Controllers.DutyApiController(repository, service);
            _mapper = mapper;
        }
        #endregion

        [Route("List")]
        public IActionResult List()
        {
            var stats = _controller.Stats();
            var viewModel = new ListDutyViewModel(stats.ElementAtOrDefault(0), stats.ElementAtOrDefault(1), stats.ElementAtOrDefault(2));
            return View("List", viewModel);
        }

        [HttpPost("PartialList")]
        public ActionResult PartialList()
        {
            try
            {
                var table = new DutyDatatable(Request.Form, 
                                              _mapper.Map<IEnumerable<DutyViewModel>>(_controller.List()));
                var data = table.Duties;
                var jsonData = new
                {
                    table.Draw,
                    table.RecordsFiltered,
                    table.RecordsTotal,
                    data
                };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Route("Details")]
        public IActionResult Details(int id)
        {
            return PartialView("_Details", _controller.Get(id));
        }

        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            if (id == -1)
                return PartialView("_Edit", new DutyViewModel());
            return PartialView("_Edit", _controller.Get(id));
        }

        [Route("Create")]
        public JsonResult Create(DutyViewModel viewModel)
        {
            var duty = _mapper.Map<Duty>(viewModel);
            return _controller.Create(duty);
        }

        [Route("Save")]
        public JsonResult Save(DutyViewModel viewModel)
        {
            var duty = _mapper.Map<Duty>(viewModel);
            return _controller.Update(duty);
        }

        [Route("Delete")]
        public JsonResult Delete(DutyViewModel viewModel)
        {
            var duty = _mapper.Map<Duty>(viewModel);
            return _controller.Delete(viewModel.Key);
        }

        [Route("Cancel")]
        public JsonResult Cancel(DutyViewModel viewModel)
        {
            var duty = _mapper.Map<Duty>(viewModel);
            return _controller.Cancel(viewModel.Key);
        }
    }

    public class DutyDatatable
    {
        public DutyDatatable(IFormCollection form, IEnumerable<DutyViewModel> duties)
        {
            Draw                = form["draw"].FirstOrDefault();
            Start               = form["start"].FirstOrDefault();
            Length              = form["length"].FirstOrDefault();
            SortColumn          = form["columns[" + form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            SortColumnDirection = form["order[0][dir]"].FirstOrDefault();
            SearchValue         = form["search[value]"].FirstOrDefault();
            PageSize            = Length != null ? Convert.ToInt32(Length) : 0;
            Skip                = Start != null ? Convert.ToInt32(Start) : 0;
            Duties              = duties;
            RecordsTotal        = 0;
            RecordsFiltered     = 0;
            Filter();
        }

        public string? Draw                      { get; set; }
        public string? Start                     { get; set; }
        public string? Length                    { get; set; }
        public string? SortColumn                { get; set; }
        public string? SortColumnDirection       { get; set; }
        public string? SearchValue               { get; set; }
        public int PageSize                      { get; set; }
        public int Skip                          { get; set; }
        public int RecordsTotal                  { get; set; }
        public int RecordsFiltered               { get; set; }
        public IEnumerable<DutyViewModel> Duties { get; set; }

        public void Filter()
        {
            if (!(string.IsNullOrEmpty(SortColumn) && string.IsNullOrEmpty(SortColumnDirection)))
                Duties = Duties.OrderBy(d => SortColumn + " " + SortColumnDirection);

            RecordsTotal = Duties.Count();

            if (!string.IsNullOrEmpty(SearchValue))
                Duties = Duties.Where(m => m.ToString().Contains(SearchValue));

            RecordsFiltered = Duties.Count();

            Duties = Duties.Skip(Skip)
                           .Take(PageSize);
        }
    }
}

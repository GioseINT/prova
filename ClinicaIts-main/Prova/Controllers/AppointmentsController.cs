using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prova.BLL.Interfaces;
using Prova.BLL.Models;
using Prova.Models;

namespace Prova.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentService _service;
        private readonly IPetService _petService;
        private readonly IVeterinaryService _veterinaryService;
        private readonly IMapper _mapper;

        public AppointmentsController(
            IAppointmentService service,
            IPetService petService,
            IVeterinaryService veterinaryService,
            IMapper mapper)
        {
            _service = service;
            _petService = petService;
            _veterinaryService = veterinaryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var items = _service.GetAll();
            var models = _mapper.Map<List<AppointmentViewModel>>(items);
            return View(models);
        }

        public IActionResult Details(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            var model = _mapper.Map<AppointmentViewModel>(item);
            return View(model);
        }

        public IActionResult Create()
        {
            PopulateDropdowns();
            return View(new AppointmentViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Date,Reason,Fee,PetId,VeterinayId")] AppointmentViewModel model)
        {
            if (model == null) return BadRequest();
            if (!ModelState.IsValid)
            {
                PopulateDropdowns();
                return View(model);
            }
            var item = _mapper.Map<AppointmentModel>(model);
            _service.Add(item);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            var model = _mapper.Map<AppointmentViewModel>(item);
            PopulateDropdowns();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Date,Reason,Fee,PetId,VeterinayId")] AppointmentViewModel model)
        {
            if (model == null) return BadRequest();
            if (id <= 0 || id != model.Id) return BadRequest();
            if (!ModelState.IsValid)
            {
                PopulateDropdowns();
                return View(model);
            }
            var item = _mapper.Map<AppointmentModel>(model);
            _service.Update(item);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            var model = _mapper.Map<AppointmentViewModel>(item);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private void PopulateDropdowns()
        {
            var pets = _petService.GetAll().ToList();
            var vets = _veterinaryService.GetAll().ToList();
            ViewBag.PetId = new SelectList(pets, "Id", "Name");
            ViewBag.VeterinayId = new SelectList(vets, "Id", "Name");
        }
    }
}




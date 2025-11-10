using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prova.BLL.Interfaces;
using Prova.BLL.Models;
using Prova.Models;

namespace Prova.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService _service;
        private readonly IMapper _mapper;

        public PetsController(IPetService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var items = _service.GetAll();
            var models = _mapper.Map<List<PetViewModel>>(items);
            return View(models);
        }

        public IActionResult Details(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            var model = _mapper.Map<PetViewModel>(item);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new PetViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Species,Breed,DateOfBirth")] PetViewModel model)
        {
            if (model == null) return BadRequest();
            if (!ModelState.IsValid) return View(model);
            var entity = _mapper.Map<PetModel>(model);
            _service.Add(entity);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            var model = _mapper.Map<PetViewModel>(item);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Species,Breed,DateOfBirth")] PetViewModel model)
        {
            if (model == null) return BadRequest();
            if (id <= 0 || id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);
            var entity = _mapper.Map<PetModel>(model);
            _service.Update(entity);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            var model = _mapper.Map<PetViewModel>(item);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}





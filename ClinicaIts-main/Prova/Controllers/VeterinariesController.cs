using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prova.BLL.Interfaces;
using Prova.BLL.Models;
using Prova.Models;

namespace Prova.Controllers
{
    public class VeterinariesController : Controller
    {
        private readonly IVeterinaryService _service;
        private readonly IMapper _mapper;

        public VeterinariesController(IVeterinaryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var items = _service.GetAll();
            var models = _mapper.Map<List<VeterinaryViewModel>>(items);
            return View(models);
        }

        public IActionResult Details(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            var model = _mapper.Map<VeterinaryViewModel>(item);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(new VeterinaryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Qualification,Phone")] VeterinaryViewModel model)
        {
            if (model == null) return BadRequest();
            if (!ModelState.IsValid) return View(model);
            var entity = _mapper.Map<VeterinaryModel>(model);
            _service.Add(entity);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            var model = _mapper.Map<VeterinaryViewModel>(item);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Qualification,Phone")] VeterinaryViewModel model)
        {
            if (model == null) return BadRequest();
            if (id <= 0 || id != model.Id) return BadRequest();
            if (!ModelState.IsValid) return View(model);
            var entity = _mapper.Map<VeterinaryModel>(model);
            _service.Update(entity);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            var model = _mapper.Map<VeterinaryViewModel>(item);
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



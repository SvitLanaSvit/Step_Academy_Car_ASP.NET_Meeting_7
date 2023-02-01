using ASP_Meeting_7.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Meeting_7.Controllers
{
    public class CarController : Controller
    {
        private readonly IRepository<Car> repository;

        public CarController(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            IEnumerable<Car> cars = repository.GetAll();
            return View(cars);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car) {
            if (!ModelState.IsValid)
            {
                return Content("Передані дані не вірні!");
            }
            int id = repository.GetAll().Max(t => t.Id);
            car.Id = ++id;
            repository.Add(car);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id==null)
                return NotFound(new { error = $"You must provide id of car!" });
            Car? car = repository.Get(id.Value);
            return View(car);
        }

        //car/delete/2
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (repository.Delete(id!.Value))
                return RedirectToAction("Index");
            else
                return NotFound(new { error = $"Car with Id: {id} not found!" });
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound(new { error = $"You must provide id of car!" });
            Car? car = repository.Get(id.Value);
            return View(car);
        }
        [HttpPost]
        public IActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                repository.Edit(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }

        public IActionResult Details(int? id)
        {
            if(id==null)
                return NotFound(new { error = $"You must provide id of car!" });
            Car? car = repository.Get(id.Value);
            if(car ==null)
                return NotFound(new { error = $"Car with Id: {id} not found!" });
            return View(car);
        }
    }
}

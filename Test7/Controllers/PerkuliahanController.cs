using Microsoft.AspNetCore.Mvc;
using Test7.Models;
using Test7.Repositories;

namespace Test7.Controllers
{
    public class PerkuliahanController : Controller
    {
        private readonly IPerkuliahanRepository _perkuliahanRepository;

        public PerkuliahanController(IPerkuliahanRepository perkuliahanRepository)
        {
            _perkuliahanRepository = perkuliahanRepository;
        }

        [HttpGet]
        public IActionResult DashboardPerkuliahan()
        {
            return View("DashboardPerkuliahan");
        }

        [HttpGet]
        public IActionResult CreatePerkuliahanForm()
        {
            return View("CreatePerkuliahan");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePerkuliahan([FromBody] Perkuliahan perkuliahan)
        {
            if (ModelState.IsValid)
            {
                _perkuliahanRepository.CreatePerkuliahan(perkuliahan);

                // Mengembalikan respons dalam format JSON
                return Json(new { success = true });
            }

            // Mengembalikan respons dalam format JSON dengan pesan kesalahan
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpGet]
        public IActionResult GetAllPerkuliahanByNimForm()
        {
            return View("GetAllPerkuliahanByNim");
        }

        [HttpGet]
        public IActionResult GetAllPerkuliahanByNim([FromQuery(Name = "nim")] string nim, int page, int pageSize)
        {
            IQueryable<Perkuliahan> perkuliahanList = _perkuliahanRepository.GetAllPerkuliahanByNim(nim);

            var paginatedList = PaginatedList<Perkuliahan>.Create(perkuliahanList, page, pageSize);

            // Mengembalikan objek JSON sebagai respons
            return Json(paginatedList);
        }



        [HttpDelete]
        public IActionResult DeletePerkuliahan([FromQuery(Name = "perkuliahanId")] int perkuliahanId)
        {
            _perkuliahanRepository.DeletePerkuliahanById(perkuliahanId);

            // Mengembalikan respons dalam format JSON
            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult UpdatePerkuliahanForm()
        {
            return View("UpdatePerkuliahan");
        }

        [HttpPut]
        public IActionResult UpdatePerkuliahan([FromBody] Perkuliahan perkuliahan)
        {
            if (ModelState.IsValid)
            {
                _perkuliahanRepository.UpdatePerkuliahan(perkuliahan);
                return Json(new { success = true });
            }

            // Mengembalikan respons dalam format JSON dengan pesan kesalahan
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }
}

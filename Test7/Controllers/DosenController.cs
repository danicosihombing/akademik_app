using Microsoft.AspNetCore.Mvc;
using Test7.Models;
using Test7.Repositories;

namespace Test7.Controllers
{
    public class DosenController : Controller
    {
        private readonly IDosenRepository _dosenRepository;

        public DosenController(IDosenRepository dosenRepository)
        {
            _dosenRepository = dosenRepository;
        }

        [HttpGet]
        public IActionResult DashboardDosen()
        {
            return View("DashboardDosen");
        }

        [HttpGet]
        public IActionResult CreateDosenForm()
        {
            return View("CreateDosen");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDosen([FromBody] Dosen dosen)
        {
            if (ModelState.IsValid)
            {
                _dosenRepository.CreateDosen(dosen);

                // Mengembalikan respons dalam format JSON
                return Json(new { success = true });
            }

            // Mengembalikan respons dalam format JSON dengan pesan kesalahan
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpGet]
        public IActionResult GetByNipForm()
        {
            return View("GetByNip");
        }

        [HttpGet]
        public IActionResult GetByNip([FromQuery(Name = "nip")] string nip)
        {
            var dosen = _dosenRepository.GetDosenByNip(nip);

            // Mengembalikan objek JSON sebagai respons
            return Json(dosen);
        }

        [HttpDelete]
        public IActionResult DeleteDosen([FromQuery(Name = "nip")] string nip)
        {
            _dosenRepository.DeleteDosenByNip(nip);

            // Mengembalikan respons dalam format JSON
            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult UpdateDosenForm()
        {
            return View("UpdateDosen");
        }

        [HttpPut]
        public IActionResult UpdateDosen([FromBody] Dosen dosen)
        {
            if (ModelState.IsValid)
            {
                _dosenRepository.UpdateDosen(dosen);
                return Json(new { success = true });
            }

            // Mengembalikan respons dalam format JSON dengan pesan kesalahan
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }
}

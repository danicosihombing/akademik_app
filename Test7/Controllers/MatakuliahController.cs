using Microsoft.AspNetCore.Mvc;
using Test7.Models;
using Test7.Repositories;

namespace Test7.Controllers
{
    public class MatakuliahController : Controller
    {
        private readonly IMatakuliahRepository _matakuliahRepository;

        public MatakuliahController(IMatakuliahRepository matakuliahRepository)
        {
            _matakuliahRepository = matakuliahRepository;
        }

        [HttpGet]
        public IActionResult DashboardMatakuliah()
        {
            return View("DashboardMatakuliah");
        }

        [HttpGet]
        public IActionResult CreateForm()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] Matakuliah matakuliah)
        {
            if (ModelState.IsValid)
            {
                _matakuliahRepository.AddMatakuliah(matakuliah);

                // Mengembalikan respons dalam format JSON
                return Json(new { success = true });
            }

            // Mengembalikan respons dalam format JSON dengan pesan kesalahan
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpGet]
        public IActionResult GetByKodeForm()
        {
            return View("GetByKode");
        }

        [HttpGet]
        public IActionResult GetByKode([FromQuery(Name = "kode")] string kode)
        {
            var matakuliah = _matakuliahRepository.GetMatakuliahByKode(kode);

            // Mengembalikan objek JSON sebagai respons
            return Json(matakuliah);
        }

        [HttpDelete]
        public IActionResult DeleteMatakuliah([FromQuery(Name = "kode")] string kode)
        {
             _matakuliahRepository.DeleteMatakuliahByKode(kode);

                // Mengembalikan respons dalam format JSON
                return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult UpdateMatakuliahForm()
        {
            return View("UpdateMatakuliah");
        }

        [HttpPut]
        public IActionResult UpdateMatakuliah([FromBody] Matakuliah matakuliah)
        {
            if (ModelState.IsValid)
            {
                _matakuliahRepository.UpdateMatakuliah(matakuliah);
                return Json(new { success = true });
            }

            // Mengembalikan respons dalam format JSON dengan pesan kesalahan
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Test7.Models;
using Test7.Repositories;

namespace Test7.Controllers
{
    public class MahasiswaController : Controller
    {
        private readonly IMahasiswaRepository _mahasiswaRepository;

        public MahasiswaController(IMahasiswaRepository mahasiswaRepository)
        {
            _mahasiswaRepository = mahasiswaRepository;
        }

        [HttpGet]
        public IActionResult DashboardMahasiswa()
        {
            return View("DashboardMahasiswa");
        }

        [HttpGet]
        public IActionResult CreateMahasiswaForm()
        {
            return View("CreateMahasiswa");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateMahasiswa([FromBody] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                _mahasiswaRepository.CreateMahasiswa(mahasiswa);
                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpGet]
        public IActionResult GetByNimForm()
        {
            return View("GetByNim");
        }

        [HttpGet]
        public IActionResult GetByNim([FromQuery(Name = "nim")] string nim)
        {
            var mahasiswa = _mahasiswaRepository.GetMahasiswaByNim(nim);
            return Json(mahasiswa);
        }

        [HttpDelete]
        public IActionResult DeleteMahasiswa([FromQuery(Name = "nim")] string nim)
        {
            _mahasiswaRepository.DeleteMahasiswa(nim);
            return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult UpdateMahasiswaForm()
        {
            return View("UpdateMahasiswa");
        }

        [HttpPut]
        public IActionResult UpdateMahasiswa([FromBody] Mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                _mahasiswaRepository.UpdateMahasiswa(mahasiswa);
                return Json(new { success = true });
            }

            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }
}

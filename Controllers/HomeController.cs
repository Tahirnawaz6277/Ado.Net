using CRUDInADO.NET.Models;
using CRUDInADO.NET.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDInADO.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPromotionRepository _repository;

        public HomeController(IPromotionRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            try
            {
                var records = _repository.GetRecordsAsync();
                return View(records);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Records records)
        {
            try
            {
                _repository.AddRecords(records);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Details(int Id)
        {
            try
            {
                Records data = _repository.GetRecordById(Id);
                return View(data);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                Records data = _repository.GetRecordById(id);
                return View(data);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Records records)
        {
            try
            {
                _repository.DeleteRecordsAsync(records.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int tahir)
        {
            try
            {
                Records data = _repository.GetRecordById(tahir);
                return View(data);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Records records)
        {
            try
            {
                _repository.UpdateRecords(records);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
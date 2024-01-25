using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesttAplictionn.Interface;
using TesttAplictionn.Models;

namespace TesttAplictionn.Controllers
{
    public class GenderController : Controller
    {
        // GET: GenderController

        private readonly IGenderRepository _genderRepository;



        public GenderController(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;

        }

        public ActionResult Index()
        {
            return View(_genderRepository.GetAllGender().ToList());
        }

        // GET: GenderController/Details/5
        public ActionResult Details(int id)
        {
            return View(_genderRepository.GetGenderById(id));
        }

        // GET: GenderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Gender gender)
        {
            try
            {
                _genderRepository.InsertGender(gender);
                _genderRepository.SaveGender();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_genderRepository.GetGenderById(id));
        }

        // POST: GenderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Gender gender)
        {
            try
            {
                _genderRepository.UpdateGender(gender);
                _genderRepository.SaveGender();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GenderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_genderRepository.GetGenderById(id));
        }

        // POST: GenderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Gender gender)
        {
            try
            {
                _genderRepository.DeleteGender(gender.GenderId);
                _genderRepository.SaveGender();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

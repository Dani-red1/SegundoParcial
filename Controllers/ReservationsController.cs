using CampusTech.Data;
using CampusTech.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CampusTech.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ReservationRepository _repo = new ReservationRepository();

        public IActionResult Index()
        {
            var data = _repo.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            ViewBag.Labs = new List<string>()
            {
                "Lab-01", "Lab-02", "Lab-03", "Lab-Redes", "Lab-IA"
            };
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reservation model)
        {
            ViewBag.Labs = new List<string>()
            {
                "Lab-01", "Lab-02", "Lab-03", "Lab-Redes", "Lab-IA"
            };

            if (model.ReservationDate < DateTime.Today)
                ModelState.AddModelError("ReservationDate",
                    "La fecha no puede estar en el pasado.");

            if (!ModelState.IsValid)
                return View(model);

            var result = _repo.Add(model);

            if (result != "OK")
            {
                ModelState.AddModelError("", result);
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}

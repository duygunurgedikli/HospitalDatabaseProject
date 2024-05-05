using BuisnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using BuisnessLayer.ValidationRules;
using System.ComponentModel.DataAnnotations;
using HospitalProje.Models;
using Microsoft.EntityFrameworkCore;



namespace HospitalProje.Controllers
{
    public class DoctorController : Controller
    {
        DoctorManager doctorManager = new DoctorManager(new EfDoctorDal(new Context()));
  
        public IActionResult Index()
        {
            var values = doctorManager.TGetList();
            return View(values);
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor newDoctor)
        {

            doctorManager.TAdd(newDoctor);
            doctorManager.RunTrigger();
            TempData["SuccessMessage"] = "Doktor başarıyla eklendi.";
            TempData["DoctorName"] = $"{newDoctor.Name} {newDoctor.Surname}";
           
             return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult AddDoctor()
        {
            return View();



        }
        public IActionResult DeleteDoctor(int id)
        {
            var values = doctorManager.TGetByID(id);
            doctorManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetDoctorsByBranch(string branch)
        {
            var doctors = doctorManager.TGetDoctorsByBranch(branch);
            return View(doctors); 
        }

        [HttpGet]
        public IActionResult GetAppointmentCount(bool status)
        {
            var values = doctorManager.TGetActiveDoctorCount(status);
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDoctorDetails()
        { 
            var values = doctorManager.TGetDoctorDetails();
            return View(values);
        }


    }
}

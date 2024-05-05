using BuisnessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace HospitalProje.Controllers
{
    public class PatientController : Controller
    {
        PatientManager patientManager = new PatientManager(new EfPatientDal(new Context()));
        public IActionResult Index()
        {
            var values= patientManager.TGetList();
            return View(values);
        }
        [HttpPost]
        public IActionResult AddPatient(Patient newPatient)
        {

            patientManager.TAdd(newPatient);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult AddPatient()
        {
            return View();
        }

        public IActionResult DeletePatient(int id)
        {
            var values =patientManager.TGetByID(id);
            patientManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdatePatient(int id)
        {
            var values = patientManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdatePatient(Patient patient)
        {
            patientManager.TUpdate(patient);
            return RedirectToAction("Index");
        }
    }
}

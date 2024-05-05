using BuisnessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProje.Controllers
{
    public class AppointmentController : Controller
    {
        AppointmentManager appointmentManager = new AppointmentManager(new EfAppointmentDal(new Context()));
        public IActionResult Index()
        {
            var values = appointmentManager.TGetList();
            return View(values);
        }
        [HttpPost]
        public IActionResult AddAppointment(Appointment newAppointment)
        {

            appointmentManager.TAdd(newAppointment);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }

        public IActionResult DeleteAppointment(int id)
        {
            var values = appointmentManager.TGetByID(id);
            appointmentManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAppointment(int id)
        {
            var values = appointmentManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAppointment(Appointment appointment)
        {
            appointmentManager.TUpdate(appointment);
            return RedirectToAction("Index");
        }
    }
}


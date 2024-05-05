using BuisnessLayer.Abstract;
using BuisnessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using HospitalProje.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalProje.Controllers
{
    public class ExcelController : Controller
    {
        ExcelManager _excelManager = new ExcelManager();
        public IActionResult Index()
        {
            return View();
        }
        public List<DoctorViewModel> DoctorList()
        {
            List<DoctorViewModel> doctorViewModels = new List<DoctorViewModel>();
            using (var c = new Context())
            {
                doctorViewModels = c.Doctors.Select(x => new DoctorViewModel
                {
                    DoctorID = x.DoctorID,
                    DoctorName = x.Name,
                    DoctorSurname = x.Surname,
                    DoctorContact = x.Concact,
                    DoctorStatus = x.Status,
                    DoctorBranch = x.Branch,

                }).ToList();
            }
            return doctorViewModels;
        }
        public IActionResult StaticExcelReport()
        {
            return File(_excelManager.ExcelList(DoctorList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
            //application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
        }
    }
}

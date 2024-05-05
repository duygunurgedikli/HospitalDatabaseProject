using BuisnessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BuisnessLayer.Concrete
{
    public class DoctorManager : IDoctorService
    {

        private readonly EfDoctorDal _efDoctorDal;

        public DoctorManager(EfDoctorDal efDoctorDal)
        {
            _efDoctorDal = efDoctorDal;

        }

        public DoctorManager(IDoctorDal doctordal)
        {
            throw new NotImplementedException();
        }
        public void RunTrigger()
        {
            _efDoctorDal.RunTrigger();
        }
        public void TAdd(Doctor t)
        {
           _efDoctorDal.SQLAddDoctor(t);
        }

        public void TDelete(Doctor t)
        {
            _efDoctorDal.SQLDeleteDoctor(t);
        }

        public Doctor TGetByID(int id)
        {
          return _efDoctorDal.GetDoctorById(id);
        }

        public List<Doctor> TGetList()
        {
            return _efDoctorDal.SQLGetList();
        }

        public void TUpdate(Doctor t)
        {
            throw new NotImplementedException();
        }
        public List<Doctor> TGetDoctorsByBranch(string branch)
        {
            return _efDoctorDal.GetDoctorsByBranch(branch);
        }
        public List<Doctor> TGetActiveDoctorCount(bool status)
        {
            return _efDoctorDal.GetActiveDoctorCount(status);
        }

        public List<Doctor> TGetDoctorsWithAppointments()
        {
            return _efDoctorDal.GetDoctorsWithAppointments();
        }
        public List<DoctorView> TGetDoctorDetails()
        {
            return _efDoctorDal.GetDoctorDetails();
        }

    }
}

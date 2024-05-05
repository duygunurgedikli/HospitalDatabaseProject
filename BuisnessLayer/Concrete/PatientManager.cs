using BuisnessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Concrete
{
    public class PatientManager : IPatientService
    {

        private readonly EfPatientDal _efPatientDal;

        public PatientManager(EfPatientDal efPatientDal)
        {
            _efPatientDal = efPatientDal;

        }
        public void TAdd(Patient t)
        {
            _efPatientDal.SQLAddPatient(t);
        }

        public void TDelete(Patient t)
        {
            _efPatientDal.SQLDeletePatient(t);
        }

        public Patient TGetByID(int id)
        {
           return _efPatientDal.GetPatientByID(id);
        }

        public List<Patient> TGetList()
        {
            return _efPatientDal.SQLGetList();
        }

        public void TUpdate(Patient t)
        {
            _efPatientDal.SQLUpdatePatient(t);
        }

        Patient IGenericService<Patient>.TGetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}

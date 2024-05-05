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
    public class AppointmentManager : IAppointmentService 
    {
        private readonly EfAppointmentDal _efAppointmentDal;

        public AppointmentManager(EfAppointmentDal efAppointmentDal)
        {
            _efAppointmentDal = efAppointmentDal;
            
        }
        public void TAdd(Appointment t)
        {
           _efAppointmentDal.SQLAddAppointment(t);
        }

        public void TDelete(Appointment t)
        {
            _efAppointmentDal.SQLDeleteAppointment(t);
        }

        public Appointment TGetByID(int id)
        {
           return _efAppointmentDal.GetAppointmentByID(id);
        }

        public List<Appointment> TGetList()
        {
      
             return _efAppointmentDal.SQLGetListAppointments();
        }

        public void TUpdate(Appointment t)
        {
            _efAppointmentDal.SQLUpdateAppointment(t);
        }
    }
}

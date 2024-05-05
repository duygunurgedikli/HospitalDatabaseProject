using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAppointmentDal : GenericRepository<Appointment>, IAppointmentDal
    {
        private readonly Context _context;

        public EfAppointmentDal(Context context)
        {
            _context = context;
        } 
    public List<Appointment> SQLGetListAppointments()
    {
        List<Appointment> appointments = new List<Appointment>();

        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SELECT * FROM APPOİNTMENTS";

            _context.Database.OpenConnection();

            using (var result = command.ExecuteReader())
            {
                while (result.Read())
                {
                    Appointment appointment = new Appointment
                    {
                        AppointmentID = Convert.ToInt32(result["AppointmentID"]),
                        Date = Convert.ToDateTime(result["Date"]),
                        PatientId = Convert.ToInt32(result["PatientId"]),
                        DoctorId = Convert.ToInt32(result["DoctorId"])
                    };

                    appointments.Add(appointment);
                }
            }
        }

        return appointments;
    }

    public void SQLAddAppointment(Appointment newAppointment)
    {
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "INSERT INTO APPOİNTMENTS (Date, PatientId, DoctorId) " +
                                  "VALUES (@Date, @PatientId, @DoctorId)";

            command.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime) { Value = newAppointment.Date });
            command.Parameters.Add(new SqlParameter("@PatientId", SqlDbType.Int) { Value = newAppointment.PatientId });
            command.Parameters.Add(new SqlParameter("@DoctorId", SqlDbType.Int) { Value = newAppointment.DoctorId });

            _context.Database.OpenConnection();
            command.ExecuteNonQuery();
        }
    }
        public void SQLDeleteAppointment(Appointment appointment)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "DELETE FROM APPOİNTMENTS WHERE AppointmentID = @AppointmentID";
                command.Parameters.Add(new SqlParameter("@AppointmentID", SqlDbType.Int) { Value = appointment.AppointmentID });

                _context.Database.OpenConnection();
                command.ExecuteNonQuery();
            }
        }

        public void SQLUpdateAppointment(Appointment updatedAppointment)
    {
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "UPDATE APPOİNTMENTS SET Date = @Date, PatientId = @PatientId, DoctorId = @DoctorId " +
                                  "WHERE AppointmentID = @AppointmentID";

            command.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime) { Value = updatedAppointment.Date });
            command.Parameters.Add(new SqlParameter("@PatientId", SqlDbType.Int) { Value = updatedAppointment.PatientId });
            command.Parameters.Add(new SqlParameter("@DoctorId", SqlDbType.Int) { Value = updatedAppointment.DoctorId });
            command.Parameters.Add(new SqlParameter("@AppointmentID", SqlDbType.Int) { Value = updatedAppointment.AppointmentID });

            _context.Database.OpenConnection();
            command.ExecuteNonQuery();
        }
    }
    public Appointment GetAppointmentByID(int appointmentID)
    {
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SELECT * FROM APPOİNTMENTS WHERE AppointmentID = @AppointmentID";
            command.Parameters.Add(new SqlParameter("@AppointmentID", SqlDbType.Int) { Value = appointmentID });

            _context.Database.OpenConnection();

            using (var result = command.ExecuteReader())
            {
                if (result.Read())
                {
                    Appointment appointment = new Appointment
                    {
                        AppointmentID = Convert.ToInt32(result["AppointmentID"]),
                        Date = Convert.ToDateTime(result["Date"]),
                        PatientId = Convert.ToInt32(result["PatientId"]),
                        DoctorId = Convert.ToInt32(result["DoctorId"])
                    };

                    return appointment;
                }
            }

            return null; 
        }
    }

}
    }
   

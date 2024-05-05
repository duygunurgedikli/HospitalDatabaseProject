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
    public class EfDoctorDal : GenericRepository<Doctor>, IDoctorDal
    {
      
            private readonly Context _context;

        public EfDoctorDal(Context context)
            {
                _context = context;
            }

            public List<Doctor> SQLGetList()
            {
                List<Doctor> doctors = new List<Doctor>();

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT * FROM DOCTORS";

                    _context.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            Doctor doctor = new Doctor
                            {
                                DoctorID = Convert.ToInt32(result["DoctorID"]),
                                Name = result["Name"].ToString(),
                                Surname = result["Surname"].ToString(),
                                Image = result["Image"] != DBNull.Value ? result["Image"].ToString() : null,
                                Concact = result["Concact"] != DBNull.Value ? result["Concact"].ToString() : null,
                                Status = Convert.ToBoolean(result["Status"]),
                                Branch = result["Branch"] != DBNull.Value ? result["Branch"].ToString() : null,
                            };

                            doctors.Add(doctor);
                        }
                    }
                }

                return doctors;
            }
        public void SQLAddDoctor(Doctor newDoctor)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "INSERT INTO DOCTORS (Name, Surname, Image, Concact, Status, Branch) " +
                                      "VALUES (@Name, @Surname, @Image, @Concact, @Status, @Branch)";

                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = newDoctor.Name });
                command.Parameters.Add(new SqlParameter("@Surname", SqlDbType.NVarChar) { Value = newDoctor.Surname });
                command.Parameters.Add(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = newDoctor.Image ?? (object)DBNull.Value });
                command.Parameters.Add(new SqlParameter("@Concact", SqlDbType.NVarChar) { Value = newDoctor.Concact ?? (object)DBNull.Value });
                command.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit) { Value = newDoctor.Status });
                command.Parameters.Add(new SqlParameter("@Branch", SqlDbType.NVarChar) { Value = newDoctor.Branch ?? (object)DBNull.Value });

                _context.Database.OpenConnection();
                command.ExecuteNonQuery();
            }
        }

        public void RunTrigger()
        {
            string triggerScript = "EXEC sp_settriggerorder @triggername = 'trgDoctorAdded', @order = 'First', @stmttype = 'INSERT';";

            using (SqlConnection connection = new SqlConnection("server=DESKTOP-7GDTQVL\\SQLEXPRESS01;database=HospitalNewDB;integrated security=true;"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(triggerScript, connection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Tetikleyici başarıyla yürütüldü.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Tetikleyici yürütülürken bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }

        public void SQLDeleteDoctor(Doctor doctorToDelete)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "DELETE FROM DOCTORS WHERE DoctorID = @DoctorID";
                command.Parameters.Add(new SqlParameter("@DoctorID", SqlDbType.Int) { Value = doctorToDelete.DoctorID });

                _context.Database.OpenConnection();
                command.ExecuteNonQuery();
            }
        }

        public Doctor GetDoctorById(int doctorId)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT * FROM DOCTORS WHERE DoctorID = @DoctorID";
                command.Parameters.Add(new SqlParameter("@DoctorID", SqlDbType.Int) { Value = doctorId });

                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    if (result.Read())
                    {
                        Doctor doctor = new Doctor
                        {
                            DoctorID = Convert.ToInt32(result["DoctorID"]),
                            Name = result["Name"].ToString(),
                            Surname = result["Surname"].ToString(),
                            Image = result["Image"] != DBNull.Value ? result["Image"].ToString() : null,
                            Concact = result["Concact"] != DBNull.Value ? result["Concact"].ToString() : null,
                            Status = Convert.ToBoolean(result["Status"]),
                            Branch = result["Branch"] != DBNull.Value ? result["Branch"].ToString() : null
                        };

                        return doctor;
                    }
                }

                // Doktor bulunamazsa null döner
                return null;
            }

        }

        public List<Doctor> GetDoctorsByBranch(string branch)
        {
            // Bu metodun geriye bir liste döndürmesi gerekir
            var result = _context.Doctors.FromSqlRaw("EXEC NewGetDoctorsByBranch @p0", branch).ToList();
            return result;
        }

        public int GetAppointmentCountForDoctor(int doctorId)
        {
            int appointmentCount = 0;

            string query = "SELECT COUNT(*) AS RandevuSayisi\r\nFROM Appointments\r\nWHERE DoctorId = @DoctorId;\r\n";

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@DoktorID", SqlDbType.Int) { Value = doctorId });

                _context.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        appointmentCount = Convert.ToInt32(reader["RandevuSayisi"]);
                    }
                }
            }

            return appointmentCount;
        }
        public List<Doctor> GetActiveDoctorCount(bool status)
        {
            var result = _context.Doctors.FromSqlRaw("EXEC GetActiveDoctorCount @p0", status).ToList();
            return result;
        }




        public List<Doctor> GetDoctorsWithAppointments()
        {
            string query = @"
        SELECT D.DoctorID, D.Name, D.Surname, A.AppointmentID, A.Date
        FROM Doctors D
        LEFT JOIN Appointments A ON D.DoctorID = A.DoctorID
    ";

            var doctorsWithAppointments = _context.Doctors
                .FromSqlRaw(query)
                .Include(d => d.Appointments)
                .ToList();

            return doctorsWithAppointments;
        }

      

        public List<DoctorView> GetDoctorDetails()
        {
            // vw_DoctorDetails view'ından veri çekme
            string query = "SELECT * FROM vw_DoctorDetails"; // Sütunları doğru bir şekilde listelemelisiniz.
            List<DoctorView> doctorDetailsList = _context.Set<DoctorView>().FromSqlRaw(query).ToList();

            return doctorDetailsList;
        }
    }

}


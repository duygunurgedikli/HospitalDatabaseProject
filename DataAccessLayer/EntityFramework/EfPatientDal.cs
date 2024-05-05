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
    public class EfPatientDal : GenericRepository<Patient>, IPatientDal
    {
        private readonly Context _context;

        public EfPatientDal(Context context)
        {
            _context = context;
        }

        public List<Patient> SQLGetList()
        {
            List<Patient> patients = new List<Patient>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT * FROM PATİENTS";

                _context.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        Patient patient = new Patient
                        {
                            PatientID = Convert.ToInt32(result["PatientID"]),
                            Name = result["Name"].ToString(),
                            Surname = result["Surname"].ToString(),
                            Gender = result["Gender"] != DBNull.Value ? result["Gender"].ToString() : null,
                            Image = result["Image"] != DBNull.Value ? result["Image"].ToString() : null,
                            DateOfBirth = Convert.ToDateTime(result["DateOfBirth"]),
                            Years = Convert.ToInt32(result["Years"]),
                            City = result["City"] != DBNull.Value ? result["City"].ToString() : null,
                            Town = result["Town"] != DBNull.Value ? result["Town"].ToString() : null,
                            Quarter = result["Quarter"] != DBNull.Value ? result["Quarter"].ToString() : null
                        };

                        patients.Add(patient);
                    }
                }
            }

            return patients;
        }
        public void SQLAddPatient(Patient newPatient)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "INSERT INTO PATİENTS (Name, Surname, Gender, Image, DateOfBirth, Years, City, Town, Quarter) " +
                                      "VALUES (@Name, @Surname, @Gender, @Image, @DateOfBirth, @Years, @City, @Town, @Quarter)";

                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = newPatient.Name });
                command.Parameters.Add(new SqlParameter("@Surname", SqlDbType.NVarChar) { Value = newPatient.Surname });
                command.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar) { Value = newPatient.Gender ?? (object)DBNull.Value });
                command.Parameters.Add(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = newPatient.Image ?? (object)DBNull.Value });
                command.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime) { Value = newPatient.DateOfBirth });
                command.Parameters.Add(new SqlParameter("@Years", SqlDbType.Int) { Value = newPatient.Years });
                command.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar) { Value = newPatient.City ?? (object)DBNull.Value });
                command.Parameters.Add(new SqlParameter("@Town", SqlDbType.NVarChar) { Value = newPatient.Town ?? (object)DBNull.Value });
                command.Parameters.Add(new SqlParameter("@Quarter", SqlDbType.NVarChar) { Value = newPatient.Quarter ?? (object)DBNull.Value });

                _context.Database.OpenConnection();
                command.ExecuteNonQuery();
            }
        }
        public void SQLDeletePatient(Patient patientToDelete)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "DELETE FROM PATİENTS WHERE PatientID = @PatientID";
                command.Parameters.Add(new SqlParameter("@PatientID", SqlDbType.Int) { Value = patientToDelete.PatientID });

                _context.Database.OpenConnection();
                command.ExecuteNonQuery();
            }
        }

        public void SQLUpdatePatient(Patient updatedPatient)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "UPDATE PATİENTS SET Name = @Name, Surname = @Surname, Gender = @Gender, " +
                                      "Image = @Image, DateOfBirth = @DateOfBirth, Years = @Years, City = @City, " +
                                      "Town = @Town, Quarter = @Quarter WHERE PatientID = @PatientID";

                command.Parameters.Add(new SqlParameter("@PatientID", SqlDbType.Int) { Value = updatedPatient.PatientID });
                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = updatedPatient.Name });
                command.Parameters.Add(new SqlParameter("@Surname", SqlDbType.NVarChar) { Value = updatedPatient.Surname });
                command.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar) { Value = updatedPatient.Gender ?? (object)DBNull.Value });
                command.Parameters.Add(new SqlParameter("@Image", SqlDbType.NVarChar) { Value = updatedPatient.Image ?? (object)DBNull.Value });
                command.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.DateTime) { Value = updatedPatient.DateOfBirth });
                command.Parameters.Add(new SqlParameter("@Years", SqlDbType.Int) { Value = updatedPatient.Years });
                command.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar) { Value = updatedPatient.City ?? (object)DBNull.Value });
                command.Parameters.Add(new SqlParameter("@Town", SqlDbType.NVarChar) { Value = updatedPatient.Town ?? (object)DBNull.Value });
                command.Parameters.Add(new SqlParameter("@Quarter", SqlDbType.NVarChar) { Value = updatedPatient.Quarter ?? (object)DBNull.Value });

                _context.Database.OpenConnection();
                command.ExecuteNonQuery();
            }
        }
        public Patient GetPatientByID(int patientID)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT * FROM PATİENTS WHERE PatientID = @PatientID";
                command.Parameters.Add(new SqlParameter("@PatientID", SqlDbType.Int) { Value = patientID });

                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    if (result.Read())
                    {
                        Patient patient = new Patient
                        {
                            PatientID = Convert.ToInt32(result["PatientID"]),
                            Name = result["Name"].ToString(),
                            Surname = result["Surname"].ToString(),
                            Gender = result["Gender"] != DBNull.Value ? result["Gender"].ToString() : null,
                            Image = result["Image"] != DBNull.Value ? result["Image"].ToString() : null,
                            DateOfBirth = Convert.ToDateTime(result["DateOfBirth"]),
                            Years = Convert.ToInt32(result["Years"]),
                            City = result["City"] != DBNull.Value ? result["City"].ToString() : null,
                            Town = result["Town"] != DBNull.Value ? result["Town"].ToString() : null,
                            Quarter = result["Quarter"] != DBNull.Value ? result["Quarter"].ToString() : null
                        };

                        return patient;
                    }
                }

                return null; // Eğer hastayı bulamazsa null dönebiliriz.
            }
        }

    }
}

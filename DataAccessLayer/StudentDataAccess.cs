using CrudUsingADO.NET.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CrudUsingADO.NET.DataAccessLayer
{
    public class StudentDataAccess
    {
        private readonly string _ConnectionStrings;

        public StudentDataAccess(string ConnectionStrings)
        {
            _ConnectionStrings = ConnectionStrings;
        }


     
        //List 
         public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (SqlConnection conn = new SqlConnection(_ConnectionStrings))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM studentTbl", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = reader.GetGuid(reader.GetOrdinal("Id")),
                        RefNo = reader.IsDBNull(reader.GetOrdinal("RefNo")) ? null : reader.GetString(reader.GetOrdinal("RefNo")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Address = reader.GetString(reader.GetOrdinal("Address")),
                        Gender = reader.GetString(reader.GetOrdinal("Gender"))
                    });
                }
            }

            return students;
        }




        //By Id
        public Student GetStudentById(Guid id)
        {
            Student student = null;

            using (SqlConnection conn = new SqlConnection(_ConnectionStrings))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM studentTbl WHERE Id = @Id", conn);
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id });

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        student = new Student
                        {
                            Id = reader.GetGuid(reader.GetOrdinal("Id")),
                            RefNo = reader.IsDBNull(reader.GetOrdinal("RefNo")) ? null : reader.GetString(reader.GetOrdinal("RefNo")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Address = reader.GetString(reader.GetOrdinal("Address")),
                            Gender = reader.GetString(reader.GetOrdinal("Gender"))
                        };
                    }
                }
            }

            return student;
        }



        //Add
        public void CreateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionStrings))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO studentTbl (Id, RefNo, Name, Address, Gender) VALUES (@Id, @RefNo, @Name, @Address, @Gender)", conn);
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = student.Id });
                cmd.Parameters.Add(new SqlParameter("@RefNo", SqlDbType.NVarChar) { Value = (object)student.RefNo ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = student.Name });
                cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar) { Value = student.Address });
                cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar) { Value = student.Gender });

                cmd.ExecuteNonQuery();
            }
        }




        //Edit
        public void UpdateStudent(Student student)
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionStrings))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE studentTbl SET RefNo = @RefNo, Name = @Name, Address = @Address, Gender = @Gender WHERE Id = @Id", conn);
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = student.Id });
                cmd.Parameters.Add(new SqlParameter("@RefNo", SqlDbType.NVarChar) { Value = (object)student.RefNo ?? DBNull.Value });
                cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = student.Name });
                cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar) { Value = student.Address });
                cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar) { Value = student.Gender });

                cmd.ExecuteNonQuery();
            }
        }




        //Delete
        public void DeleteStudent(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionStrings))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM studentTbl WHERE Id = @Id", conn);
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id });

                cmd.ExecuteNonQuery();
            }
        }

    }
}


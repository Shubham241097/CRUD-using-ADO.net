using FutureFacePractice.Models;
using System.Data.SqlClient;

namespace FutureFacePractice.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        readonly IConfiguration _configuration;
        private string connectionString;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Con");            
        }

        public async Task<List<Student>> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("GetAllStudentsSP", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (reader.Read())
                    {
                        students.Add(new Student
                        {

                            ID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Gender = reader.GetString(4),
                            Age = reader.GetInt32(5),
                            Address = reader.GetString(6),
                            PinCode = reader.GetInt32(7),
                            Center = reader.GetString(8),
                            Course = reader.GetString(9)

                        }) ;                        
                    }
                }
                return students;
            }                
        }

        public async Task<Student> GetStudentById(int id)
        { 
            Student student = new Student();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetStudentByStudentId", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", id));
                    SqlDataReader reader = await command.ExecuteReaderAsync();                    

                    while (reader.Read())
                    {
                        student.ID = reader.GetInt32(0);
                        student.FirstName = reader.GetString(1);
                        student.LastName = reader.GetString(2);
                        student.Email = reader.GetString(3);
                        student.Gender = reader.GetString(4);
                        student.Age = reader.GetInt32(5);
                        student.Address = reader.GetString(6);
                        student.PinCode = reader.GetInt32(7);
                        student.Center = reader.GetString(8);
                        student.Course = reader.GetString(9);
                    }                    
                }
                return student;
            }
        }

        public async Task<bool> AddStudent(Student student)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("AddStudentSP", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@FirstName", student.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                    command.Parameters.Add(new SqlParameter("@Email", student.Email));
                    command.Parameters.Add(new SqlParameter("@Gender", student.Gender));
                    command.Parameters.Add(new SqlParameter("@Age", student.Age));
                    command.Parameters.Add(new SqlParameter("@Address", student.Address));
                    command.Parameters.Add(new SqlParameter("@PinCode", student.PinCode));
                    command.Parameters.Add(new SqlParameter("@Course", student.Course));
                    command.Parameters.Add(new SqlParameter("@Center", student.Center));

                    int rows = await command.ExecuteNonQueryAsync();
                    if (rows > 0)
                    {
                        return true;
                    }
                        return false;
                }
            }
        }

        public async Task<bool> EditStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("EditStudentSP", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", student.ID));
                    command.Parameters.Add(new SqlParameter("@Firstname", student.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", student.LastName));
                    command.Parameters.Add(new SqlParameter("@Email", student.Email));
                    command.Parameters.Add(new SqlParameter("@Age", student.Age));
                    command.Parameters.Add(new SqlParameter("@Gender", student.Gender));
                    command.Parameters.Add(new SqlParameter("@Address", student.Address));
                    command.Parameters.Add(new SqlParameter("@PinCode", student.PinCode));
                    command.Parameters.Add(new SqlParameter("@Center", student.Center));
                    command.Parameters.Add(new SqlParameter("@Course", student.Course));

                    int rows = await command.ExecuteNonQueryAsync();
                    if (rows > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public async Task<bool> DeleteStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            { 
                connection.Open();
                using (SqlCommand command = new SqlCommand("DeleteStudentSP", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID", student.ID));

                    int rows = await command.ExecuteNonQueryAsync();
                    if (rows > 0) { return true; }
                    return false;
                }
            }
        }
        
    }
}

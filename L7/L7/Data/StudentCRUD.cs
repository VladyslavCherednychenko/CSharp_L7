using System.Data.SqlClient;
using L7.Models;

namespace L7.Data
{
    internal class StudentCRUD
    {
        string connectionString = "Server=localhost,1433;Database=laba;User ID=sa;Password=123Password!;TrustServerCertificate=True;";

        public StudentCRUD()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO Students(StudentId, StudentName, StudentGroup) " +
                    "SELECT 1, 'Cherednychenko Vladyslav', 'KIYKIy-21-2'" +
                    "WHERE NOT EXISTS(SELECT 1 FROM Students WHERE StudentId = 1)";
                command.Connection = connection;
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Students(StudentId, StudentName, StudentGroup) " +
                    "SELECT 2, 'Student A', 'KIYKIy-21-2'" +
                    "WHERE NOT EXISTS(SELECT 1 FROM Students WHERE StudentId = 2)";
                command.Connection = connection;
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Students(StudentId, StudentName, StudentGroup) " +
                    "SELECT 3, 'Student B', 'KIYKIy-21-2'" +
                    "WHERE NOT EXISTS(SELECT 1 FROM Students WHERE StudentId = 3)";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public List<Student> GetStudentsFromGroup(string groupName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT * FROM Students WHERE StudentGroup = '{groupName}'";
                command.Connection = connection;
                var result = command.ExecuteReader();
                List<Student> students = new List<Student>();
                while (result.Read())
                {
                    int id = (int)result["StudentId"];
                    string name = (string)result["StudentName"];
                    string group = (string)result["StudentGroup"];
                    students.Add(new Student { StudentId = id, StudentName = name, StudentGroup = group });
                }
                return students;
            }
        }

        public void CreateStudent(StudentDTO student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT COUNT(StudentId) FROM Students WHERE StudentGroup = '{student.StudentGroup}'";
                command.Connection = connection;
                int count = (int)command.ExecuteScalar();
                if (count >= 30)
                {
                    return;
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT TOP 1 StudentId FROM Students ORDER BY StudentId DESC";
                command.Connection = connection;
                int count = (int)command.ExecuteScalar();

                command.CommandText = $"INSERT INTO Students (StudentId, StudentName, StudentGroup) " +
                                      $"VALUES ({count + 1}, '{student.StudentName}', '{student.StudentGroup}')";
                command.Connection = connection;
                var result = command.ExecuteReader();
            }
        }

        public void EditStudent(int id, StudentDTO student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT COUNT(StudentId) FROM Students WHERE StudentGroup = '{student.StudentGroup}'";
                command.Connection = connection;
                int count = (int)command.ExecuteScalar();
                if (count >= 30)
                {
                    return;
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"UPDATE Students SET StudentName='{student.StudentName}', StudentGroup='{student.StudentGroup}' " +
                                      $"WHERE StudentId = {id}";
                command.Connection = connection;
                var result = command.ExecuteReader();
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"DELETE FROM Students WHERE StudentId = {id}";
                command.Connection = connection;
                var result = command.ExecuteReader();
            }
        }
    }
}

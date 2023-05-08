using L7.Models;
using System.Data.SqlClient;

namespace L7.Data
{
    internal class GroupCRUD
    {
        string connectionString = "Server=localhost,1433;Database=laba;User ID=sa;Password=123Password!;TrustServerCertificate=True;";

        public GroupCRUD()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "INSERT INTO Groups (GroupId, GroupName) " +
                    "SELECT 1, 'KIYKIy-21-2'" +
                    "WHERE NOT EXISTS(SELECT 1 FROM Groups WHERE GroupId = 1)";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }

        public List<Group> GetGroups()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT * FROM Groups";
                command.Connection = connection;
                var result = command.ExecuteReader();
                List<Group> groups = new List<Group>();
                while (result.Read())
                {
                    int id = (int)result["GroupId"];
                    string name = (string)result["GroupName"];
                    groups.Add(new Group { GroupId = id, GroupName = name });
                }
                return groups;
            }
        }

        public void CreateGroup(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT TOP 1 GroupId FROM Groups ORDER BY GroupId DESC";
                command.Connection = connection;
                int count = (int)command.ExecuteScalar();

                command.CommandText = $"INSERT INTO Groups (GroupId, GroupName) " +
                                      $"VALUES ({count + 1}, '{name}')";
                command.Connection = connection;
                var result = command.ExecuteReader();
            }
        }

        public void EditGroup(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"UPDATE Groups SET GroupName='{name}' WHERE GroupId = {id}";
                command.Connection = connection;
                var result = command.ExecuteReader();
            }
        }

        public void DeleteGroup(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"DELETE FROM Students WHERE StudentGroup = '{name}'";
                command.Connection = connection;
                command.ExecuteNonQuery();

                command.CommandText = $"DELETE FROM Groups WHERE GroupName = '{name}'";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
    }
}

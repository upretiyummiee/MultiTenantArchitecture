using Microsoft.Data.SqlClient;
using MultiTenantArchitecture.Data.Repositories.Interface;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantArchitecture.Data.Databases
{


    /// <summary>
    /// Order for it to properly work
    /// Call 
    /// 1) CreateDatabase 
    /// 2) CreateLogin
    /// 3) CreateUser
    /// 4) AssignDbOwnerRole
    /// </summary>

    public class MsSqlDatabase : IDatabase
    {

        public int AssignDbOwnerRole(string source, string catalog, string user, string password, string role = "db_owner")
        {
            using (SqlConnection myConnection = new SqlConnection())
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = source;
                builder.InitialCatalog = catalog;
                builder.UserID = user;
                builder.Password = password;
                builder.IntegratedSecurity = true;
                builder.ConnectTimeout = 30;

                myConnection.ConnectionString = builder.ConnectionString;

                SqlCommand command = new SqlCommand();
                myConnection.OpenAsync();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@rolename", SqlDbType.VarChar).Value = role;
                command.Parameters.Add("@membername", SqlDbType.VarChar).Value = user;
                var result = command.ExecuteNonQuery();
                myConnection.CloseAsync();
                return result;
            }
        }

        public string CreateDatabase(string Name)
        {
            using (SqlConnection myConnection = new SqlConnection())
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = "Wizard\\Rio";
                builder.InitialCatalog = "master";
                builder.UserID = "Wizard";
                builder.Password = "Wizard9116";
                builder.IntegratedSecurity = true;
                builder.ConnectTimeout = 30;

                myConnection.ConnectionString = builder.ConnectionString;

                var dbName = Name + Guid.NewGuid().ToString();

                SqlCommand command = new SqlCommand();
                myConnection.OpenAsync();
                command.CommandText = "CREATE DATABASE @dbname";
                command.Parameters.AddWithValue("@dbname", dbName);
                var result = command.ExecuteNonQuery();
                myConnection.CloseAsync();
                return dbName;
            }

        }

        public int CreateLogin(string username, string password)
        {
            using (SqlConnection myConnection = new SqlConnection())
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = "Wizard\\Rio";
                builder.InitialCatalog = "master";
                builder.UserID = "Wizard";
                builder.Password = "Wizard9116";
                builder.IntegratedSecurity = true;
                builder.ConnectTimeout = 30;

                myConnection.ConnectionString = builder.ConnectionString;

                SqlCommand command = new SqlCommand();
                myConnection.OpenAsync();
                command.CommandText = "CREATE LOGIN @login WITH PASSWORD = @password";
                command.Parameters.AddWithValue("@login", username);
                command.Parameters.AddWithValue("@password", password);
                var result = command.ExecuteNonQuery();
                myConnection.CloseAsync();
                return result;
            }
        }

        public int CreateUser(string source, string catalog, string username, string password)
        {
            using (SqlConnection myConnection = new SqlConnection())
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = source;
                builder.InitialCatalog = catalog;
                builder.UserID = username;
                builder.Password = password;
                builder.IntegratedSecurity = true;
                builder.ConnectTimeout = 30;

                myConnection.ConnectionString = builder.ConnectionString;

                SqlCommand command = new SqlCommand();
                myConnection.OpenAsync();
                command.CommandText = "CREATE USER @username FOR LOGIN @loginname";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@loginname", username);
                var result = command.ExecuteNonQuery();
                myConnection.CloseAsync();
                return result;
            }
        }

        public int MigrateModel() 
        {
            return 0;
        }
    }
}

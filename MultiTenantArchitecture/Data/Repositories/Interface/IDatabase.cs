using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantArchitecture.Data.Repositories.Interface
{
    public interface IDatabase
    {
        /// <summary>
        /// Creates a new databases
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        string CreateDatabase(string Name);
        int CreateLogin(string username, string password);

        /// <summary>
        /// Create a new login. Select The database first.
        /// </summary>
        /// <returns>Returns success result.</returns>
        int CreateUser(string Source, string catalog, string username, string password);

        /// <summary>
        /// Creates New role for the user
        /// </summary>
        /// <param name="role"></param>
        /// <param name="user"></param>
        int AssignDbOwnerRole(string source, string catalog, string user, string password, string role = "db_owner");

        int MigrateModel();

    }
}

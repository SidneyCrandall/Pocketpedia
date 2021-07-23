using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Pocketpedia.Repositories
{
    /* The use of the keyword abstract in the class definition is something we haven't used before in class.
     It indicates that our BaseRepository class cannot be directly instantiated, but can ONLY be used by inheritance.*/
    public abstract class BaseRepository
    {
        private readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // We mark the Connection property as protected to make it available to child classes, but inaccessible to any other code.
        protected SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }
    }
}
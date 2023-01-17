using EnsureThat;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Common
{
    public class DataContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DataContext(IConfiguration configuration)
        {
            Ensure.That(configuration, nameof(configuration)).IsNotNull();
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DbConnection");
        }
        public IDbConnection CreateConnection()
            => new System.Data.SqlClient.SqlConnection(_connectionString);
    }
}

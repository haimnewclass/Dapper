using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using YamlDotNet.Serialization;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Contrib;
using System.Transactions;

namespace WinFormsApp3
{
    internal class DbCon
    {
        protected IDbConnection db;

        public DbCon()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();  

            string connectionString = config.GetConnectionString("DefaultConnection");


            db = new SqlConnection(connectionString);
        }
    }
}

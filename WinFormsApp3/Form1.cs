using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using YamlDotNet.Serialization;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using Dapper.Contrib;
using System.Transactions;
namespace WinFormsApp3
{
    public static class Extention
    { 
        public static void Output(this object item)
        {
            var serialzer = new SerializerBuilder().Build();
            var yaml = serialzer.Serialize(item);
            string s = yaml.ToString();
        }
    
    }

    interface ITbl {
        tbl1 Fint(int id);
        List<tbl1> GetAll();
        tbl1 Add(tbl1 a);
        tbl1 Update(tbl1 a);
        void Remove(int id);


    }

    class ItblImp : ITbl
    {
        private IDbConnection db;

        public ItblImp(string connString)
        {
            this.db = new SqlConnection(connString);
        }

        //  SET IDENTITY_INSERT [Shippers] ON
        public tbl1 Add(tbl1 a)
        {
            int id;
            //string sql = "insert into [Shippers] (CompanyName,Phone) values(@CompanyName,@Phone); select @@identity";
            string sql = "insert into [Shippers] (CompanyName,Phone) values(@CompanyName,@Phone); select @@identity";
            a.ShipperID = this.db.Query<int>(sql, a).Single();
            a.ShipperID = null;
            //long id1 = this.db.Insert(a);



            return a;
        }

        public tbl1 Fint(int id)
        {
            string sql = "select * from Shippers where ShipperID=@id";
            this.db.Query<tbl1>(sql, new { id }).SingleOrDefault(new tbl1());
            
            throw new NotImplementedException();
        }

        public List<tbl1> GetAll()
        {
            var a = this.db.GetAll<Shippers>().ToList();
            return this.db.Query<tbl1>("select *,'aaa' as a from [Shippers] ").ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public tbl1 Update(tbl1 a)
        {
            throw new NotImplementedException();
        }
    }
    [Table("Shippers")]
    class tbl1
    {
        public int? ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        //public string a { get; set; }
    }

    class Customers
    {   
        public int CustomerID { get; set; }

        CompanyName

    }




    [Table("Shippers")]
    class Shippers
    {

        [ExplicitKey]
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        
    }

    public partial class Form1 : Form
    {
        IConfigurationRoot config;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            config = builder.Build();

            ItblImp itblImp = new ItblImp(config.GetConnectionString("DefaultConnection"));
            var lst = itblImp.GetAll();
            tbl1 tbl1 = new tbl1() { CompanyName = "ccccc", Phone = "2345345345" };
            itblImp.Add(tbl1);

        }
    }
}
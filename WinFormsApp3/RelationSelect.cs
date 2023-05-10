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
    internal class RelationSelect:DbCon
    {
       public void InsertData()
        {
            Student1 student1 = new Student1() { Id = 3,Name="Ben Tov",Address="Kochav" };

            string sql = "insert into [Student1] (Id,Name,Address) values(@Id,@Name,@Address)";
            db.Query(sql, student1);
            student1 = new Student1() { Id = 4, Name = "Levi", Address = "Kochav" };
            db.Query(sql, student1);

            db.Query("delete from Work ");

            sql = "insert into Work(StudentId,WorkName) values(@StudentId,@WorkName)";
            Work work = new Work() { StudentId = 3, WorkName = "Electronic" };
            db.Query(sql, work); ;

            work = new Work() { StudentId = 4, WorkName = "Liturture" };
            db.Query(sql, work); ;

        }

        public void Join()
        { 
            string sql = "select * from Student1 inner join Work on Work.StudentId = Student1.Id";
           
            var lst = db.Query<WorkJoined>(sql).ToList() ;

        }

        public void InsertIdentity(Student2 student)
        {
            string sql = "insert into [Student2] (Name,Address) values(@Name,@Address); select @@Identity";
            int newId = db.Query<int>(sql, student).Single();
            student.Id = newId;
        }


        public Student1 Select(int id)
        {
            Student1 student;
            string sql = "select * from Student1 where Id = @Id";
            student = db.Query<Student1>(sql,new { id }).First();

            return student;

        }
        public void Update(Student1 student)
        {
            string sql = "update [Student1] set Name=@Name where Id = @Id";
            db.Query(sql, student);

        }

        public void Delete(Student1 student)
        {
            string sql = "delete from [Student1] where Id = @Id";
            db.Query(sql, student);

        }
    }
}

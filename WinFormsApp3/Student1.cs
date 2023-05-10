using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    //create table Student2 (Id int identity  ,[Name] nvarchar(100),[Address] nvarchar(100))
    internal class Student1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  string Address { get; set; }
    }

    internal class Student2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    //create table Work (StudentId int    ,[WorkName] nvarchar(100))
    internal class Work 
    {
        public int StudentId { get; set; }
        public string WorkName { get; set; }
    }

    internal class WorkJoined :Work
    {
       
         
    }

    internal class WorkJoined2 : WorkJoined
    {


    }


}

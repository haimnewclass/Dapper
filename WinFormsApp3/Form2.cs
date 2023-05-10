using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SampleCRUD sampleCRUD = new SampleCRUD();
            sampleCRUD.Insert(new Student1() { Address = "aaa", Id = 1, Name = "Moris" });
            sampleCRUD.Insert(new Student1() { Address = "bbb", Id = 2, Name = "Avishalom" });
            sampleCRUD.InsertIdentity(new Student2() { Address = "aaa", Name = "Moris" });

            Student1 student1 = sampleCRUD.Select(1);
            student1.Name = "Avri";
            sampleCRUD.Update(student1);

            sampleCRUD.SelectAll();

            sampleCRUD.Delete(student1);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RelationSelect relationSelect = new RelationSelect();
            relationSelect.InsertData();
            relationSelect.Join();
        }
    }
}

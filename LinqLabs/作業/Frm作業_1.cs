using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHomeWork
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();

            students_scores = new List<Student>()
                                         {
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

                                          };
        }

        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }

        int 點擊次數 = 0;
        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            var q = from A in nwDataSet1.Products
                    select A;

            int page=int.Parse(textBox1.Text);
            
            //    return;
            //else
            點擊次數++;
            this.dataGridView2.DataSource = q.Skip(page* (點擊次數-1)).Take(page).ToList();

            //this.nwDataSet1.Product.Take(10);//Top 10 Skip(10)

            //Distinct()
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files =  dir.GetFiles();

            var r = from n in files
                    where n.Extension.ToLower().Contains(".log")
                    select n;

            this.dataGridView1.DataSource = r.ToList();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            #region 搜尋 班級學生成績

            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	

        		
            // 數學不及格 ... 是誰 
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var r = from x in files
                    where x.CreationTime.Year == 2019
                    select x;

            this.dataGridView1.DataSource = r.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            this.dataGridView1.DataSource = files;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();

            var r = from x in files
                    where x.Length>100000
                    select x;

            this.dataGridView1.DataSource = r.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
            var q = from x in nwDataSet1.Orders
                    select x;
            this.order_DetailsTableAdapter1.Fill(this.nwDataSet1.Order_Details);
            var qq = from x in nwDataSet1.Orders
                    select x;

            this.dataGridView1.DataSource = q.ToList();
            this.dataGridView2.DataSource = qq.ToList();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();

            this.ordersTableAdapter1.Fill(this.nwDataSet1.Orders);
            this.order_DetailsTableAdapter1.Fill(this.nwDataSet1.Order_Details);
            var q = from x in nwDataSet1.Orders
                    where x.OrderDate.Year == int.Parse(comboBox1.Text)
                    select x;
            this.dataGridView1.DataSource = q.ToList();
            
            this.order_DetailsTableAdapter1.Fill(this.nwDataSet1.Order_Details);
            var qq = from x in nwDataSet1.Order_Details
                     join o in q
                    on x.OrderID equals o.OrderID
                     select x;
            this.dataGridView2.DataSource = qq.ToList();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            this.productsTableAdapter1.Fill(this.nwDataSet1.Products);
            var q = from A in nwDataSet1.Products
                    select A;

            int page = int.Parse(textBox1.Text);
            if (點擊次數 <= 0)
                return;
            else
            點擊次數--;
            this.dataGridView2.DataSource = q.Skip(page * (點擊次數 - 1)).Take(page).ToList();
        }


    }
}

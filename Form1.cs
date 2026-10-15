using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SQLConnectionEx
{
    public partial class Form1 : Form
    {
        String ConStr;
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Read_Click(object sender, EventArgs e)
        {
            ConStr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\SQLConnectionEx\\SQLConnectionEx\\Employees.mdf;Integrated Security=True;User Instance=True";
            con = new SqlConnection(ConStr);
            SqlCommand cmd = new SqlCommand("Select * from Employee", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            adapter.Dispose();
            con.Close();
        }

        private void create_Click(object sender, EventArgs e)
        {
            ConStr = @"Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\SQLConnectionEx\\
                    SQLConnectionEx\\Employees.mdf;Integrated Security=True;User Instance=True";
             using (SqlConnection con = new SqlConnection(ConStr))
            {
                // Use parameterized queries to prevent SQL Injection and handle data types safely
                string query = "INSERT INTO Employee (EmpID, Name, Salary) VALUES (@EmpID, @Name, @Salary)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with their respective values
                    cmd.Parameters.AddWithValue("@EmpID", EmpID.Text);
                    cmd.Parameters.AddWithValue("@Name", EmpName.Text);
                    cmd.Parameters.AddWithValue("@Salary", Convert.ToInt32(Salary.Text));
                    // 1. Open the connection
                    con.Open();
                    // 2. Execute the query
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("One Record Added");
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            ConStr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\SQLConnectionEx\\SQLConnectionEx\\Employees.mdf;Integrated Security=True;User Instance=True";
             using (SqlConnection con = new SqlConnection(ConStr))
            {
                // Use parameterized queries to prevent SQL Injection and handle data types safely
                string query = "UPDATE Employee set Name=@Name,Salary=@Salary where EmpID=@EmpID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with their respective values
                    cmd.Parameters.AddWithValue("@EmpID", EmpID.Text);
                    cmd.Parameters.AddWithValue("@Name", EmpName.Text);
                    cmd.Parameters.AddWithValue("@Salary", Convert.ToInt32(Salary.Text));
                    // 1. Open the connection
                    con.Open();
                    // 2. Execute the query
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("One Record Updated");
                }
            }
        }

      
 

       

        private void delete_Click(object sender, EventArgs e)
        {
            ConStr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\SQLConnectionEx\\SQLConnectionEx\\Employees.mdf;Integrated Security=True;User Instance=True";
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                // Use parameterized queries to prevent SQL Injection and handle data types safely
                string query = "Delete from Employee where EmpID=@EmpID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmpID", EmpID.Text);
                    // 1. Open the connection
                    con.Open();
                    // 2. Execute the query
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("One Record Deleted");
                }
            }
        }
    }
}

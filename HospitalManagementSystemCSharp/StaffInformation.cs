using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagementSystemCSharp
{
    public partial class StaffInformation : Form
    {
        public StaffInformation()
        {
            InitializeComponent();
        }

        private void StaffInformation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet.staff' table. You can move, or remove it, as needed.
            this.staffTableAdapter.Fill(this.hospitalDataSet.staff);
            using (var con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True"))
            {

                const string str2 = "SELECT * FROM staff";
                var cmd2 = new SqlCommand(str2, con1);
                var da = new SqlDataAdapter(cmd2);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = new BindingSource(dt, null);
            }
            var con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True");
            con.Open();
            const string str1 = "select max(id) from staff;";

            var cmd1 = new SqlCommand(str1, con);
            var dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                var val = dr[0].ToString();
                if (val == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    var a = Convert.ToInt32(dr[0].ToString());
                    a += 1;
                    textBox1.Text = a.ToString();
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True");
            con.Open();
            var gen = string.Empty;
            gen = radioButton1.Checked ? "Male" : "Female";
            try
            {
                var str = "INSERT INTO staff(name,gender,position,salary,contact,address) VALUES('" + textBox2.Text + "','" + gen + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'); ";

                var cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                const string str1 = "select max(Id) from staff;";

                var cmd1 = new SqlCommand(str1, con);
                var dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Staff Information Saved Successfully..");
                    textBox2.Text = "";                  
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    using (var con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True"))
                    {

                        const string str2 = "SELECT * FROM staff";
                        var cmd2 = new SqlCommand(str2, con1);
                        var da = new SqlDataAdapter(cmd2);
                        var dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True");

            con.Open();
            if (textBox1.Text == "") return;
            try
            {
                var getCust = "select name,gender,position,salary,contact,address from staff where id=" + Convert.ToInt32(textBox1.Text) + " ;";

                var cmd = new SqlCommand(getCust, con);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    if (dr[1].ToString() == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                       
                    textBox4.Text = dr.GetValue(2).ToString();
                    textBox5.Text = dr.GetValue(3).ToString();
                    textBox6.Text = dr.GetValue(4).ToString();
                    textBox7.Text = dr.GetValue(5).ToString();
                       
                }
                else
                {
                    MessageBox.Show(" Sorry, This Staff, " + textBox1.Text + " ID is not Available.   ");
                    textBox1.Text = "";
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True");
            con.Open();
            var gen = string.Empty;
            if (radioButton1.Checked)
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";
            }
            try
            {
                string str = " Update staff set name='" + textBox2.Text + "',gender='" + gen + "',position='" + textBox4.Text + "',salary='" + textBox5.Text + "',contact='" + textBox6.Text + "',address='" + textBox7.Text + "' where id='" + textBox1.Text + "'";

                var cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                var str1 = "select max(id) from staff;";

                var cmd1 = new SqlCommand(str1, con);
                var dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("" + textBox2.Text + "'Details Updated Successfully.. ", "Important Message");
                    textBox2.Text = "";                    
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";                 
                    using (var con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True"))
                    {

                        const string str2 = "SELECT * FROM staff";
                        var cmd2 = new SqlCommand(str2, con1);
                        var da = new SqlDataAdapter(cmd2);
                        var dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
        }
    }
}

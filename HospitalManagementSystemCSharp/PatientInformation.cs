﻿using System;
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
    public partial class PatientInformation : Form
    {
        public PatientInformation()
        {
            InitializeComponent();
        }

        private void PatientInformation_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet1.patient' table. You can move, or remove it, as needed.
            this.patientTableAdapter.Fill(this.hospitalDataSet1.patient);
            using (var con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True"))
            {

                var str2 = "SELECT * FROM patient";
                var cmd2 = new SqlCommand(str2, con1);
                var da = new SqlDataAdapter(cmd2);
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True");

            con.Open();
            if (textBox1.Text == "") return;
            try
            {
                var getCust = "select name,gen,age,date,cont,addr,disease,status,r_type,building,r_no,price from patient where id=" + Convert.ToInt32(textBox1.Text) + " ;";

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
                    textBox3.Text = dr.GetValue(2).ToString();
                    textBox4.Text = dr.GetValue(3).ToString();
                    textBox5.Text = dr.GetValue(4).ToString();
                    textBox6.Text = dr.GetValue(5).ToString();
                    textBox7.Text = dr.GetValue(6).ToString();
                    textBox8.Text = dr.GetValue(7).ToString();
                    textBox10.Text = dr.GetValue(8).ToString();
                    textBox9.Text = dr.GetValue(9).ToString();
                    textBox11.Text = dr.GetValue(10).ToString();
                    textBox12.Text = dr.GetValue(11).ToString();
                        
                }
                else
                {
                    MessageBox.Show(" Sorry, This ID, " + textBox1.Text + " Staff is not Available.   ");
                    textBox1.Text = "";
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
            var gen = string.Empty;
            gen = radioButton1.Checked ? "Male" : "Female";
            try
            {
                var str = " Update patient set name='" + textBox2.Text + "',gen='" + gen + "',age='" + textBox3.Text + "',date='" + textBox4.Text + "',cont='" + textBox5.Text + "',addr='" + textBox6.Text + "',disease='" + textBox7.Text + "',status='" + textBox8.Text  + "',r_type='" + textBox10.Text + "',building='" + textBox9.Text + "',r_no='" + textBox11.Text + "',price='" + textBox12.Text + "' where id='" + textBox1.Text + "'";

                var cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                const string str1 = "select max(id) from patient;";

                var cmd1 = new SqlCommand(str1, con);
                var dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("" + textBox2.Text + "'s Details is Updated Successfully.. ", "Important Message");
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    using (var con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True"))
                    {

                        const string str2 = "SELECT * FROM patient";
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
            var con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True");
            con.Open();
            try
            {

                var str = "DELETE FROM patient WHERE id = '" + textBox1.Text + "'";

                var cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show(" Patient Record Delete Successfully");
                using (con)
                {

                    const string str2 = "SELECT * FROM patient";
                    var cmd2 = new SqlCommand(str2, con);
                    var da = new SqlDataAdapter(cmd2);
                    var dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Please Enter Patient Id..");
            }
        }
    }
    
}

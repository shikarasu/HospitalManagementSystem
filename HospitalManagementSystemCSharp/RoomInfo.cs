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
    public partial class RoomInfo : Form
    {
        public RoomInfo()
        {
            InitializeComponent();
        }

        private void RoomInfo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet2.room' table. You can move, or remove it, as needed.
            this.roomTableAdapter.Fill(this.hospitalDataSet2.room);
            using (var con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True"))
            {

                var str2 = "SELECT * FROM room";
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
           
            try
            {
                var str = "INSERT INTO room(building,r_type,r_no,no_bed,price,r_status) VALUES('" + textBox1.Text + "','" + textBox2.Text  + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "'); ";

                var cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                const string str1 = "select max(Id) from room;";

                var cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("room Information Saved Successfully..");
                    textBox2.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True"))
                    {

                        const string str2 = "SELECT * FROM room";
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
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}

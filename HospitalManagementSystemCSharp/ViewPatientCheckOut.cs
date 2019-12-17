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
    public partial class ViewPatientCheckOut : Form
    {
        public ViewPatientCheckOut()
        {
            InitializeComponent();
        }

        private void ViewPatientCheckOut_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hospitalDataSet3.checkout' table. You can move, or remove it, as needed.
            this.checkoutTableAdapter.Fill(this.hospitalDataSet3.checkout);
            var dt = new DataTable();
            using (var con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True"))
            {

                const string str2 = "SELECT * FROM checkout";
                var cmd2 = new SqlCommand(str2, con1);
                var da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            using (var con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\C# Projects\HOSPITAL_MANAGEMENT_SYSTEM_IN_C_WITH_SOURCE_CODE\HospitalManagementSystem_C#\HospitalManagementSystemCSharp\HospitalManagementSystemCSharp\hospital.mdf;Integrated Security=True"))
            {

                var str2 = "SELECT * FROM checkout where id='"+textBox1.Text +"'";
                var cmd2 = new SqlCommand(str2, con1);
                var da = new SqlDataAdapter(cmd2);
                da.Fill(dt);
                dataGridView1.DataSource = new BindingSource(dt, null);
            }
        }
    }
}

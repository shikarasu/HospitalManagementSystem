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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
                if (textBox1.Text == "admin" || textBox2.Text == "password")
                {
                    MessageBox.Show("Welcome. You are now logged in successfully.");
                    this.Visible = false;
                    var obj1 = new Home();
                    obj1.ShowDialog();
                    textBox1.Text = "";
                    textBox2.Text = "";                 
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password.");
                }
         }
    }
}

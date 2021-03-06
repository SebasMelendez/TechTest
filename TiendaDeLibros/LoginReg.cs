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

namespace TiendaDeLibros
{
    public partial class LoginReg : Form
    {
        string ConnectionString = @"Data Source=PROJECT-ALPHA\MELPOINT;Initial Catalog=UserReg;Integrated Security=True";
        public LoginReg()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

      

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonSubmit_Click_1(object sender, EventArgs e)
        {
            if (FirstNameText.Text == "" || LastNameText.Text == "" || EmailText.Text == "" || PhoneText.Text == "" || UserNameText.Text == "" || PasswordText.Text == "" || PasswordConfirmText.Text == "")
                MessageBox.Show("Es necesario llenar todos los campos");
            else if (PasswordText.Text != PasswordConfirmText.Text)
                MessageBox.Show("Las Contraseñas no coinciden");
            else
            {

                using (SqlConnection SqlCon = new SqlConnection(ConnectionString))
                {

                    string query = "Select * from UserTable Where UserName = '" + UserNameText.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, SqlCon);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                    if (dtbl.Rows.Count == 1)
                    {
                        MessageBox.Show("El Usuario Ya existe");
                    }
                    else if (dtbl.Rows.Count == 0)
                    {

                        SqlCon.Open();
                        SqlCommand SqlCmd = new SqlCommand("UserAdd", SqlCon);
                        SqlCmd.CommandType = CommandType.StoredProcedure;
                        SqlCmd.Parameters.AddWithValue("@FirstName", FirstNameText.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@LastName", LastNameText.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@Email", EmailText.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@Telephone", PhoneText.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@UserName", UserNameText.Text.Trim());
                        SqlCmd.Parameters.AddWithValue("@Password", PasswordText.Text.Trim());
                        SqlCmd.ExecuteNonQuery();
                        ClearForm();
                        MessageBox.Show("Usuario Regsitrado Con exito!");
                    }
                }
            }
        }

        void ClearForm()
        {
            FirstNameText.Text = LastNameText.Text = EmailText.Text = PhoneText.Text = UserNameText.Text = PasswordText.Text = PasswordConfirmText.Text = "";
        }
      
        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PasswordText_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void LoginUserName_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection SqlCon = new SqlConnection(ConnectionString))
            {
                string query = "Select * from UserTable Where UserName = '" + LoginUserNameText.Text.Trim() + "' and password = '" + LoginPasswordText.Text.Trim() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, SqlCon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if(dtbl.Rows.Count ==1)
                {
                    MainForm1 objMainForm = new MainForm1();
                    this.Hide();
                    objMainForm.Show();
                }
                else
                {
                    MessageBox.Show("Informacon de ingreso erronea.");
                }
                
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sklep_Terrarystyczny_Forms
{
    public partial class RegisterLogin : Form
    {
        public static string sql_conn_str = Form1.sql_conn_str;
        public bool IsLogin { get; set; }
        public RegisterLogin()
        {
            InitializeComponent();
        }

        private void regLogButton_Click(object sender, EventArgs e)
        {
            if (IsLogin)
            {

                SqlConnection conn = new SqlConnection(sql_conn_str);
                conn.Open();

                string str_cmd = $"SELECT \"id\" FROM \"Klient\" WHERE \"imie\" = '{nameText.Text}' AND \"nazwisko\" = '{lastNameText.Text}' AND \"email\".Filter('email', '{emailText.Text}') = 1";
                SqlCommand cmd = new SqlCommand(str_cmd, conn);
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    Form1.ClientID = (int)reader[0];

                    SuccessError success = new SuccessError();
                    success.Success = true;
                    success.Message = "Logged in!\nPlease press Load \\ Refresh to reload data.";
                    success.Show();
                }
                else
                {
                    Form1.ClientID = 0;

                    SuccessError error = new SuccessError();
                    error.Success = false;
                    error.Message = "Failed to log in.";
                    error.Show();
                }
                reader.Close();
                conn.Close();
            }
            else
            {

                SqlConnection conn = new SqlConnection(sql_conn_str);
                conn.Open();

                string adres_str = adres1Text.Text + "," + adres2Text.Text + "," + codeText.Text + "," + cityText.Text;

                try
                {
                    string str_cmd = $"INSERT INTO \"Klient\"(\"imie\", \"nazwisko\", \"email\", \"adres\") VALUES ('{nameText.Text}', '{lastNameText.Text}', '{emailText.Text}', '{adres_str}')";
                    SqlCommand cmd = new SqlCommand(str_cmd, conn);
                    cmd.ExecuteNonQuery();

                    str_cmd = "SELECT MAX(\"id\") FROM \"Klient\"";
                    cmd = new SqlCommand(str_cmd, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Form1.ClientID = (int)reader[0];
                        SuccessError success = new SuccessError();
                        success.Success = true;
                        success.Message = "Registered!\nPlease press Load \\ Refresh to reload data.";
                        success.Show();
                    }
                    else
                    {
                        Form1.ClientID = 0;
                        SuccessError error = new SuccessError();
                        error.Success = false;
                        error.Message = "Failed to register.";
                        error.Show();
                    }
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex) 
                {
                    SuccessError error = new SuccessError();
                    error.Success = false;
                    error.Message = (ex.Message.Contains("EmailAddress")) ? "ERROR: Invalid email" : ((ex.Message.Contains("Address") ? "ERROR: Invalid address" : ex.Message));
                    error.Show();
                }
                finally 
                { 
                    conn.Close(); 
                }
            }

            Close();
        }

        private void RegisterLogin_Load(object sender, EventArgs e)
        {
            adres1Text.Visible = !IsLogin;
            adres2Text.Visible = !IsLogin;
            cityText.Visible = !IsLogin;
            codeText.Visible = !IsLogin;
            adres1Label.Visible = !IsLogin;
            adres2Label.Visible = !IsLogin;
            codeLabel.Visible = !IsLogin;
            cityLabel.Visible = !IsLogin;

            regLogButton.Text = (IsLogin) ? "Zaloguj" : "Zarejestruj";
        }
    }
}

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
    public partial class ViewClientsForm : Form
    {
        public string sql_conn_str = Form1.sql_conn_str;
        private BindingList<Basic> _clientList = new BindingList<Basic>();
        private BindingList<Basic> _orderList = new BindingList<Basic>();
        private string? Filter { get; set; }
        public ViewClientsForm()
        {
            InitializeComponent();
        }

        private void ViewClientsForm_Load(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(sql_conn_str);
            conn.Open();

            string cmd_str = "SELECT \"id\", \"imie\", \"nazwisko\", \"email\".ToString() FROM \"Klient\"";
            SqlCommand cmd = new SqlCommand(cmd_str, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string string_data = (string)reader[1] + " " + (string)reader[2] + " " + (string)reader[3];
                _clientList.Add(new Basic() { Info = string_data, Id = (int)reader[0] });
            }
            reader.Close();

            clientDisplay.DataSource = _clientList;
            clientDisplay.DisplayMember = "Info";
            clientDisplay.ValueMember = "Id";

            conn.Close();
        }

        public class Basic
        {
            public int Id { get; set; }
            public string? Info { get; set; }

            public override string ToString()
            {
                return (Info != null) ? Info : "NULL";
            }
        }

        private void clientDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(sql_conn_str);
            conn.Open();

            if ((Basic)clientDisplay.SelectedItem != null)
            {
                int id = ((Basic)clientDisplay.SelectedItem).Id;

                string cmd_str = $"SELECT p.\"id\", z.\"data_wysyłki\", z.\"data_otrzymania\", p.\"zwierze_id\", p.\"pojemnik_id\", p.\"narzedzie_id\" " +
                                 $"FROM \"Zamówienie\" z, \"Przedmioty\" p WHERE p.\"zamówienie_id\" = z.\"id\" AND z.\"klient_id\" = {id}";

                SqlCommand cmd = new SqlCommand(cmd_str, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                _orderList.Clear();


                while (reader.Read())
                {
                    string string_data = (string)reader[1] + ((!reader.IsDBNull(2)) ? ", " + (string)reader[2] : "") + ((!reader.IsDBNull(3)) ? ", Animal" : "") + ((!reader.IsDBNull(4)) ? ", Enclosure" : "") + ((!reader.IsDBNull(5)) ? ", Tool" : "");
                    _orderList.Add(new Basic() { Info = string_data, Id = (int)reader[0] });
                }
                reader.Close();


                orderDisplay.DataSource = _orderList;
                orderDisplay.DisplayMember = "Info";
                orderDisplay.ValueMember = "Id";

                conn.Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void detailsClient_Click(object sender, EventArgs e)
        {
            Details details = new Details();
            details.toDisplay = "Klient";
            details.id = (int)clientDisplay.SelectedValue;
            details.Show();
        }

        private void detailsOrder_Click(object sender, EventArgs e)
        {
            Details details = new Details();
            details.toDisplay = "Zamówienie";
            details.id = (int)orderDisplay.SelectedValue;
            details.Show();
        }

        private void filterAddress_Click(object sender, EventArgs e)
        {
            if (filterAddress.Text.Equals("Filter by Address"))
            {
                FilterData filterData = new FilterData();
                filterData.toFilter = "Adres";
                filterData.Show();

                filterAddress.Text = "Clear filter";
            }
            else 
            {
                Filter = null;
                Form1.FilterString = null;
                filterAddress.Text = "Filter by Address";
            }
        }

        private void filterEmails_Click(object sender, EventArgs e)
        {
            if (filterEmails.Text.Equals("Filter by Email"))
            {
                FilterData filterData = new FilterData();
                filterData.toFilter = "Email";
                filterData.Show();

                filterEmails.Text = "Clear filter";
            }
            else 
            {
                Filter = null;
                Form1.FilterString = null;
                filterEmails.Text = "Filter by Email";
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (Form1.FilterString != null)
            {
                Filter = Form1.FilterString;

                if (Filter.Contains("Adres"))
                {
                    string[] data = Filter.Split(';');

                    SqlConnection conn = new SqlConnection(sql_conn_str);
                    conn.Open();

                    string cmd_str = $"SELECT \"id\", \"imie\", \"nazwisko\", \"email\".ToString() FROM \"Klient\" WHERE \"adres\".Filter('{data[1]}','{data[2]}') = 1";
                    SqlCommand cmd = new SqlCommand(cmd_str, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    _clientList.Clear();

                    while (reader.Read())
                    {
                        string string_data = (string)reader[1] + " " + (string)reader[2] + " " + (string)reader[3];
                        _clientList.Add(new Basic() { Info = string_data, Id = (int)reader[0] });
                    }

                    clientDisplay.DataSource = _clientList;
                    clientDisplay.DisplayMember = "Info";
                    clientDisplay.ValueMember = "Id";

                    conn.Close();
                }
                if (Filter.Contains("Email"))
                {
                    string[] data = Filter.Split(';');

                    SqlConnection conn = new SqlConnection(sql_conn_str);
                    conn.Open();

                    string cmd_str = $"SELECT \"id\", \"imie\", \"nazwisko\", \"email\".ToString() FROM \"Klient\" WHERE \"email\".Filter('{data[1]}','{data[2]}') = 1";
                    SqlCommand cmd = new SqlCommand(cmd_str, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    _clientList.Clear();

                    while (reader.Read())
                    {
                        string string_data = (string)reader[1] + " " + (string)reader[2] + " " + (string)reader[3];
                        _clientList.Add(new Basic() { Info = string_data, Id = (int)reader[0] });
                    }
                    reader.Close();

                    clientDisplay.DataSource = _clientList;
                    clientDisplay.DisplayMember = "Info";
                    clientDisplay.ValueMember = "Id";

                    conn.Close();
                }
            }
            else 
            {
                SqlConnection conn = new SqlConnection(sql_conn_str);
                conn.Open();

                string cmd_str = "SELECT \"id\", \"imie\", \"nazwisko\", \"email\".ToString() FROM \"Klient\"";
                SqlCommand cmd = new SqlCommand(cmd_str, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                _clientList.Clear();

                while (reader.Read())
                {
                    string string_data = (string)reader[1] + " " + (string)reader[2] + " " + (string)reader[3];
                    _clientList.Add(new Basic() { Info = string_data, Id = (int)reader[0] });
                }
                reader.Close();

                clientDisplay.DataSource = _clientList;
                clientDisplay.DisplayMember = "Info";
                clientDisplay.ValueMember = "Id";

                conn.Close();
            }
        }
    }
}

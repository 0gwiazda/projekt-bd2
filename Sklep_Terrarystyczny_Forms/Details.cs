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
using System.Windows.Forms.VisualStyles;

namespace Sklep_Terrarystyczny_Forms
{
    public partial class Details : Form
    {
        public string sql_conn_str = Form1.sql_conn_str;
        public int id { get; set; }
        public string? toDisplay { get; set; }

        public Details()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Details_animals_Load_1(object sender, EventArgs e)
        {
            if (id != 0 && toDisplay != null)
            {
                if (toDisplay.Equals("Zwierzę"))
                {

                    SqlConnection conn = new SqlConnection(sql_conn_str);
                    conn.Open();

                    string cmd_str = $"SELECT \"zwierzak\".ToString(), \"zwierzak\".Danger, \"cena\", \"ilosc\" FROM \"Zwierzę\" WHERE \"id\" = {id}";
                    SqlCommand cmd = new SqlCommand(cmd_str, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string[] data = ((string)reader[0]).Split(',');
                        int danger_lvl = (int)reader[1];
                        int cena = (int)reader[2];
                        int ilosc = (int)reader[3];

                        if (data.Length != 7) numOfChild.Visible = false;

                        name.Text += " " + data[0];
                        type.Text += " " + data[1];
                        gender.Text += " " + data[2];
                        maturity.Text += " " + data[3];
                        numOfChild.Text += " " + ((data.Length == 7) ? data[4].Split(':')[1].Trim() : "0");
                        danger.Text += " " + ((data.Length == 7) ? data[5].Split(':')[1].Trim() + " (" + danger_lvl + ")" : data[4].Split(':')[1].Trim() + " (" + danger_lvl + ")");
                        endangered.Text += " " + data.Last();

                        price.Text += " " + cena + " zł";
                        amount.Text += " " + ilosc;
                    }
                    reader.Close();
                    conn.Close();
                }
                if (toDisplay.Equals("Pojemnik"))
                {

                    SqlConnection conn = new SqlConnection(sql_conn_str);
                    conn.Open();

                    string cmd_str = $"SELECT \"pojemnik\".ToString(), \"ilosc\", \"cena\" FROM \"Pojemnik\" WHERE \"id\" = {id}";
                    SqlCommand cmd = new SqlCommand(cmd_str, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string[] data = ((string)reader[0]).Split(" ");
                        int ilosc = (int)reader[1];
                        int cena = (int)reader[2];

                        data = data.Where(element => !element.Equals("x")).ToArray();

                        name.Visible = false;
                        type.Visible = false;
                        gender.Visible = false;
                        numOfChild.Visible = false;
                        endangered.Visible = data.Length == 5 && data[4] != "";

                        maturity.Text = "Type of enclosure: " + data[0];
                        danger.Text = "Size: " + data[1] + " x " + data[2] + " x " + data[3];
                        endangered.Text = (endangered.Visible) ? "Decoration: " + data[4] : "";

                        price.Text += " " + cena + " zł";
                        amount.Text += " " + ilosc;
                    }
                    reader.Close();
                    conn.Close();
                }
                if (toDisplay.Equals("Narzędzie"))
                {

                    SqlConnection conn = new SqlConnection(sql_conn_str);
                    conn.Open();

                    string cmd_str = $"SELECT \"nazwa\", \"szczegóły\", \"ilosc\", \"price\" FROM \"Narzędzie\" WHERE \"id\" = {id}";
                    SqlCommand cmd = new SqlCommand(cmd_str, conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string[] data = ((string)reader[1]).Split(",");



                        string tool = (string)reader[0] + " " + data[0];
                        string details = "";


                        for (int i = 0; i < data.Length; i++)
                        {
                            if (i != 0)
                            {
                                details = (i == data.Length - 1) ? data[i] : data[i] + ", ";
                            }
                        }

                        int ilosc = (int)reader[2];
                        int cena = (int)reader[3];

                        name.Visible = false;
                        type.Visible = false;
                        gender.Visible = false;
                        numOfChild.Visible = false;
                        maturity.Visible = false;

                        danger.Text = "Name: " + tool;
                        endangered.Text = "Details: " + details;

                        price.Text += " " + cena + " zł";
                        amount.Text += " " + ilosc;
                    }
                }
                if (toDisplay.Equals("Hodowla"))
                {

                    SqlConnection conn = new SqlConnection(sql_conn_str);
                    conn.Open();

                    string cmd_str = $"SELECT \"zwierzak\".ToString(), \"zwierzak\".Danger, \"CITES\".ToString(), \"DangerDocument\".ToString() FROM \"Hodowla\" WHERE \"id\" = {id}";
                    SqlCommand cmd = new SqlCommand(cmd_str, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string[] data = ((string)reader[0]).Split(',');
                        int danger_lvl = (int)reader[1];
                        string cites = (!reader.IsDBNull(2)) ? (string)reader[2] : "NULL";
                        string danger_doc = (!reader.IsDBNull(3)) ? (string)reader[3] : "NULL";

                        if (data.Length != 7) numOfChild.Visible = false;

                        name.Text += " " + data[0];
                        type.Text += " " + data[1];
                        gender.Text += " " + data[2];
                        maturity.Text += " " + data[3];
                        numOfChild.Text += " " + ((data.Length == 7) ? data[4].Split(':')[1].Trim() : "0");
                        danger.Text += " " + ((data.Length == 7) ? data[5].Split(':')[1].Trim() + " (" + danger_lvl + ")" : data[4].Split(':')[1].Trim() + " (" + danger_lvl + ")");
                        endangered.Text += " " + data.Last();

                        price.Text = "CITES: " + cites;
                        amount.Text = "DangerDoc: " + danger_doc;
                    }
                    reader.Close();
                    conn.Close();
                }
                if(toDisplay.Equals("Klient"))
                {
                    numOfChild.Visible = false;
                    amount.Visible = false;
                    price.Visible = false;


                    SqlConnection conn = new SqlConnection(sql_conn_str);
                    conn.Open();

                    string cmd_str = $"SELECT \"imie\", \"nazwisko\", \"email\".ToString(), \"adres\".ToString() FROM \"Klient\" WHERE \"id\"={id}";
                    SqlCommand cmd = new SqlCommand(cmd_str, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(reader.Read()) 
                    {
                        string[] adres_data = ((string)reader[3]).Split(",");

                        name.Text = "First name: " + (string)reader[0];
                        type.Text = "Last name: " + (string)reader[1];
                        gender.Text = "Email: " + (string)reader[2];
                        maturity.Text = "Adres 1: " + adres_data[0];
                        danger.Text = "Adres 2: " + adres_data[1];
                        endangered.Text = "Code and City: " + adres_data[2];
                    }

                    reader.Close();
                    conn.Close();
                }
                if(toDisplay.Equals("Zamówienie"))
                {
                    numOfChild.Visible = false;
                    amount.Visible = false;
                    endangered.Visible = false;


                    SqlConnection conn = new SqlConnection(sql_conn_str);
                    conn.Open();

                    string cmd_str = $"SELECT z.\"data_wysyłki\", z.\"data_otrzymania\", p.\"zwierze_id\", p.\"pojemnik_id\", p.\"narzedzie_id\" FROM \"Zamówienie\" as z, \"Przedmioty\" as p WHERE p.\"id\" = {id} AND p.\"zamówienie_id\" = z.\"id\"";
                    SqlCommand cmd = new SqlCommand (cmd_str, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int animal_id, enclosure_id, tool_id;

                    if (reader.Read()) 
                    {
                        name.Text = "Date shipped: " + (string)reader[0];
                        type.Text = "Date arrived: " + ((!reader.IsDBNull(1)) ? (string)reader[1] : "NULL");
                        gender.Text = "Animal: NULL";
                        maturity.Text = "Enclosure: NULL";
                        danger.Text = "Tool: NULL";

                        animal_id = (!reader.IsDBNull(2)) ? (int)reader[2] : 0;
                        enclosure_id = (!reader.IsDBNull(3)) ? (int)reader[3] : 0;
                        tool_id = (!reader.IsDBNull(4)) ? (int)reader[4] : 0;
                        int sum_price = 0;

                        if(animal_id != 0)
                        {
                            reader.Close();
                            cmd_str = $"SELECT \"zwierzak\".ToString(), \"cena\" FROM \"Zwierzę\" WHERE \"id\" = {animal_id}";
                            cmd = new SqlCommand (cmd_str, conn);
                            reader = cmd.ExecuteReader();

                            if(reader.Read()) 
                            {
                                gender.Text = "Animal: " + (string)reader[0];
                                sum_price += (int)reader[1];
                            }
                            reader.Close();
                        }
                        if(enclosure_id != 0)
                        {
                            reader.Close();
                            cmd_str = $"SELECT \"pojemnik\".ToString(), \"cena\" FROM \"Pojemnik\" WHERE \"id\" = {enclosure_id}";
                            cmd = new SqlCommand(cmd_str, conn);
                            reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                maturity.Text = "Enclosure: " + (string)reader[0];
                                sum_price += (int)reader[1];
                            }    
                            reader.Close();
                        }
                        if(tool_id != 0) 
                        {
                            reader.Close();
                            cmd_str = $"SELECT (\"nazwa\" + ' ' + \"szczegóły\") as tool, \"price\" FROM \"Narzędzie\" WHERE \"id\" = {tool_id}";
                            cmd = new SqlCommand(cmd_str, conn);
                            reader = cmd.ExecuteReader();

                            if(reader.Read())
                            {
                                danger.Text = "Tool: " + (string)reader[0];
                                sum_price += (int)reader[1];
                            }
                        }

                        price.Text += " " + sum_price + "zł";
                    }
                    if(!reader.IsClosed) reader.Close();
                    conn.Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void amount_Click(object sender, EventArgs e)
        {

        }
    }
}

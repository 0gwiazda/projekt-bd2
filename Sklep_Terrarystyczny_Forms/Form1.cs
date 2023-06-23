using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;

namespace Sklep_Terrarystyczny_Forms
{
    public partial class Form1 : Form
    {
        public static string sql_conn_str = Environment.GetEnvironmentVariable("CONN_STRING", EnvironmentVariableTarget.User);

        public static int ClientID { get; set; }
        public static string? FilterString { get; set; }
        private string[]? filterItem;
        private List<string>? CITESlist;
        private List<string>? DangerList;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(sql_conn_str);
            conn.Open();

            string cmd_str = "SELECT \"id\", \"zwierzak\".Family, \"zwierzak\".Species, \"zwierzak\".decodeGender(), \"zwierzak\".decodeMaturity() FROM \"Zwierzê\"";
            SqlCommand cmd = new SqlCommand(cmd_str, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            BindingList<Basic> animalList = new BindingList<Basic>();

            while (reader.Read())
            {
                string str_info = (string)reader[1] + " " + (string)reader[2] + ", " + (string)reader[3] + ", " + (string)reader[4];
                animalList.Add(new Basic { Info = str_info, Id = (int)reader[0] });
            }
            reader.Close();

            animalDisplay.DataSource = animalList;
            animalDisplay.DisplayMember = "Info";
            animalDisplay.ValueMember = "Id";

            cmd_str = "SELECT \"id\", \"pojemnik\".ToString() FROM \"Pojemnik\"";
            cmd = new SqlCommand(cmd_str, conn);
            reader = cmd.ExecuteReader();

            BindingList<Basic> enclosureList = new BindingList<Basic>();

            while (reader.Read())
            {
                string str_info = (string)reader[1];
                enclosureList.Add(new Basic { Info = str_info, Id = (int)reader[0] });
            }
            reader.Close();

            enclosureDisplay.DataSource = enclosureList;
            enclosureDisplay.DisplayMember = "Info";
            enclosureDisplay.ValueMember = "Id";

            cmd_str = "SELECT \"id\", \"nazwa\", \"szczegó³y\" FROM \"Narzêdzie\"";
            cmd = new SqlCommand(cmd_str, conn);
            reader = cmd.ExecuteReader();

            BindingList<Basic> toolList = new BindingList<Basic>();

            while (reader.Read())
            {
                string str_info = (string)reader[1] + " " + ((string)reader[2]).Split(",")[0];
                toolList.Add(new Basic() { Info = str_info, Id = (int)reader[0] });
            }
            reader.Close();

            toolDisplay.DataSource = toolList;
            toolDisplay.DisplayMember = "Info";
            toolDisplay.ValueMember = "Id";

            petDisplay.DisplayMember = "Info";
            petDisplay.ValueMember = "Id";


            addAnimalButton.Visible = false;
            addEnclosureButton.Visible = false;
            addToolButton.Visible = false;
            viewClients.Visible = false;
        }

        public class Basic
        {
            public string? Info { get; set; }
            public int? Id { get; set; }

            public override string ToString()
            {
                if (Info == null) return "NULL";

                return Info;
            }
        }

        private void animalButton_Click(object sender, EventArgs e)
        {
            Details detail = new Details() { id = (animalDisplay.SelectedValue != null) ? (int)animalDisplay.SelectedValue : 0, toDisplay = "Zwierzê" };

            detail.Show();
        }
        private void enclosureButton_Click(object sender, EventArgs e)
        {
            Details detail = new Details() { id = (enclosureDisplay.SelectedValue != null) ? (int)enclosureDisplay.SelectedValue : 0, toDisplay = "Pojemnik" };

            detail.Show();
        }

        private void toolButton_Click(object sender, EventArgs e)
        {
            Details detail = new Details() { id = (toolDisplay.SelectedValue != null) ? (int)toolDisplay.SelectedValue : 0, toDisplay = "Narzêdzie" };

            detail.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            if (adres1Text.Text != "" && cityText.Text != "" && codeText.Text != "")
            {
                SqlConnection conn = new SqlConnection(sql_conn_str);
                conn.Open();

                string date_start = DateTime.Now.ToString("dd.MM.yyyy");
                string date_end = DateTime.Now.AddDays(3).ToString("dd.MM.yyyy");
                int klient_id = 0;

                string str_cmd;
                string address_str = adres1Text.Text + "," + adres2Text.Text + "," + codeText.Text + "," + cityText.Text;

                str_cmd = $"SELECT \"id\" FROM \"Klient\" WHERE \"adres\" = CONVERT(Address, '{address_str}')";

                SqlCommand cmd = new SqlCommand(str_cmd, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    klient_id = (int)reader[0];
                }
                reader.Close();

                if (klient_id != 0)
                {
                    str_cmd = $"INSERT INTO \"Zamówienie\"(\"klient_id\", \"iloœæ\", \"data_wysy³ki\", \"data_otrzymania\") VALUES ({klient_id}, 1, '{date_start}', '{date_end}')";
                    cmd = new SqlCommand(str_cmd, conn);
                    cmd.ExecuteNonQuery();

                    int animal_id = (int)animalDisplay.SelectedValue;
                    int enclosure_id = (int)enclosureDisplay.SelectedValue;
                    int tool_id = (int)toolDisplay.SelectedValue;
                    int order_id = 0;

                    str_cmd = "SELECT MAX(\"id\") FROM \"Zamówienie\"";
                    cmd = new SqlCommand(str_cmd, conn);
                    reader = cmd.ExecuteReader();

                    if (reader.Read()) { order_id = (int)reader[0]; }
                    reader.Close();

                    try
                    {
                        int isClientAble = 0;

                        if (animalCheck.Checked)
                        {
                            str_cmd = $"SELECT \"zwierzak\".Danger FROM \"Zwierzê\" WHERE \"id\" = {animal_id}";
                            cmd = new SqlCommand(str_cmd, conn);
                            reader = cmd.ExecuteReader();

                            int animal_danger = 0;

                            if (reader.Read()) { animal_danger = (int)reader[0]; }
                            reader.Close();

                            str_cmd = $"SELECT dbo.CheckClientAbility({klient_id},{animal_danger});";
                            cmd = new SqlCommand(str_cmd, conn);
                            reader = cmd.ExecuteReader();

                            if (reader.Read()) { isClientAble = (int)reader[0]; }
                            reader.Close();

                            if (isClientAble != 1)
                            {
                                throw new Exception("Client is not albe to handle keeping this animal.");
                            }
                        }


                        str_cmd = $"INSERT INTO \"Przedmioty\"(\"zamówienie_id\", \"zwierze_id\", \"pojemnik_id\", \"narzedzie_id\") VALUES ({order_id},{((animalCheck.Checked) ? animal_id : "NULL")},{((enclosureCheck.Checked) ? enclosure_id : "NULL")},{((toolCheck.Checked) ? tool_id : "NULL")})";
                        cmd = new SqlCommand(str_cmd, conn);
                        cmd.ExecuteNonQuery();

                        SuccessError err = new SuccessError();
                        err.Success = true;
                        err.Message = "Purchase completed.\nYour product has been sent.";

                        err.Show();
                    }
                    catch (Exception ex)
                    {
                        SuccessError err = new SuccessError();
                        err.Success = false;
                        err.Message = ex.Message.Contains("RemoveItem") ? "Not enough items in shop" : ex.Message;

                        err.Show();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    SuccessError err = new SuccessError();
                    err.Success = false;
                    err.Message = "Couldn't find client.\nPlease consider registering.";

                    err.Show();

                    conn.Close();
                }

            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            RegisterLogin registerLogin = new RegisterLogin();
            registerLogin.IsLogin = false;
            registerLogin.Show();
        }

        private void login_Click(object sender, EventArgs e)
        {
            RegisterLogin registerLogin = new RegisterLogin();
            registerLogin.IsLogin = true;
            registerLogin.Show();
        }

        private void hodowlaDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (petDisplay.Items.Count != 0)
            {
                int index = (int)petDisplay.SelectedIndex;
                citesText.Text = "CITES: " + ((CITESlist != null) ? CITESlist[index] : "");
                dangerText.Text = "Danger: " + ((DangerList != null) ? DangerList[index] : "");
            }
            else 
            {
                citesText.Text = "CITES: ";
                dangerText.Text = "Danger: ";
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(sql_conn_str);
            conn.Open();

            string cmd_str = "SELECT \"id\", \"zwierzak\".Family, \"zwierzak\".Species, \"zwierzak\".decodeGender(), \"zwierzak\".decodeMaturity() FROM \"Zwierzê\"";
            SqlCommand cmd = new SqlCommand(cmd_str, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            BindingList<Basic> animalList = new BindingList<Basic>();

            while (reader.Read())
            {
                string str_info = (string)reader[1] + " " + (string)reader[2] + ", " + (string)reader[3] + ", " + (string)reader[4];
                animalList.Add(new Basic { Info = str_info, Id = (int)reader[0] });
            }
            reader.Close();

            animalDisplay.DataSource = animalList;
            animalDisplay.DisplayMember = "Info";
            animalDisplay.ValueMember = "Id";

            cmd_str = "SELECT \"id\", \"pojemnik\".ToString() FROM \"Pojemnik\"";
            cmd = new SqlCommand(cmd_str, conn);
            reader = cmd.ExecuteReader();

            BindingList<Basic> enclosureList = new BindingList<Basic>();

            while (reader.Read())
            {
                string str_info = (string)reader[1];
                enclosureList.Add(new Basic { Info = str_info, Id = (int)reader[0] });
            }
            reader.Close();

            enclosureDisplay.DataSource = enclosureList;
            enclosureDisplay.DisplayMember = "Info";
            enclosureDisplay.ValueMember = "Id";

            cmd_str = "SELECT \"id\", \"nazwa\", \"szczegó³y\" FROM \"Narzêdzie\"";
            cmd = new SqlCommand(cmd_str, conn);
            reader = cmd.ExecuteReader();

            BindingList<Basic> toolList = new BindingList<Basic>();

            while (reader.Read())
            {
                string str_info = (string)reader[1] + " " + ((string)reader[2]).Split(",")[0];
                toolList.Add(new Basic() { Info = str_info, Id = (int)reader[0] });
            }
            reader.Close();

            toolDisplay.DataSource = toolList;
            toolDisplay.DisplayMember = "Info";
            toolDisplay.ValueMember = "Id";

            petDisplay.DisplayMember = "Info";
            petDisplay.ValueMember = "Id";


            addAnimalButton.Visible = false;
            addEnclosureButton.Visible = false;
            addToolButton.Visible = false;
            viewClients.Visible = false;

            if (ClientID != 0)
            {
                conn = new SqlConnection(sql_conn_str);
                conn.Open();

                BindingList<Basic> hodowlaList = new BindingList<Basic>();

                cmd_str = $"SELECT \"id\", \"zwierzak\".ToString(), \"CITES\".ToString(), \"DangerDocument\".ToString() FROM \"Hodowla\" WHERE \"klient_id\" = {ClientID}";
                cmd = new SqlCommand(cmd_str, conn);
                reader = cmd.ExecuteReader();

                CITESlist = new List<string>();
                DangerList = new List<string>();

                while (reader.Read())
                {
                    string[] str = ((string)reader[1]).Split(',');
                    hodowlaList.Add(new Basic() { Info = str[0] + ", " + str[4], Id = (int)reader[0] });
                    CITESlist.Add((!reader.IsDBNull(2)) ? (string)reader[2] : "NULL");
                    DangerList.Add((!reader.IsDBNull(3)) ? (string)reader[3] : "NULL");
                }
                reader.Close();

                petDisplay.DataSource = hodowlaList;
                petDisplay.DisplayMember = "Info";
                petDisplay.ValueMember = "Id";

                if (petDisplay.Items.Count == 0)
                {
                    citesText.Text = "CITES: ";
                    dangerText.Text = "Danger: ";
                }

                cmd_str = $"SELECT \"imie\", \"nazwisko\", \"adres\".ToString() FROM \"Klient\" WHERE \"id\" = {ClientID}";
                cmd = new SqlCommand(cmd_str, conn);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    nameLabel.Text = "First name: " + (string)reader[0];
                    lastNameLabel.Text = "Last name: " + (string)reader[1];
                    string[] data = ((string)reader[2]).Split(',');

                    adres1Label.Text = "Address 1: " + data[0];
                    adres2Label.Text = "Address 2: " + data[1].Trim();
                    codeLabel.Text = "Code: " + data[2].Trim().Split(" ")[0];
                    cityLabel.Text = "City: " + data[2].Trim().Split(" ")[1];
                }

                reader.Close();
                conn.Close();
            }


            if (FilterString != null)
            {
                conn = new SqlConnection(sql_conn_str);
                conn.Open();

                filterItem = FilterString.Split(";");

                if (filterItem[0] == "Zwierzê")
                {
                    filterAnimal.Text = "Clear filter";

                    conn = new SqlConnection(sql_conn_str);
                    conn.Open();

                    filterItem = FilterString.Split(";");

                    cmd_str = $"SELECT \"id\", \"zwierzak\".Family, \"zwierzak\".Species, \"zwierzak\".decodeGender(), \"zwierzak\".decodeMaturity() FROM \"Zwierzê\" WHERE \"zwierzak\".Filter('{filterItem[1]}','{filterItem[2]}') = 1";
                    cmd = new SqlCommand(cmd_str, conn);
                    reader = cmd.ExecuteReader();

                    animalList.Clear();

                    while (reader.Read())
                    {
                        string str_info = (string)reader[1] + " " + (string)reader[2] + ", " + (string)reader[3] + ", " + (string)reader[4];
                        animalList.Add(new Basic { Info = str_info, Id = (int)reader[0] });
                    }
                    reader.Close();

                    animalDisplay.DataSource = animalList;
                    animalDisplay.DisplayMember = "Info";
                    animalDisplay.ValueMember = "Id";

                    conn.Close();
                }
                if (filterItem[0] == "Zwierzê")
                {
                    filterAnimal.Text = "Clear filter";

                    conn = new SqlConnection(sql_conn_str);
                    conn.Open();

                    filterItem = FilterString.Split(";");

                    cmd_str = $"SELECT \"id\", \"zwierzak\".Family, \"zwierzak\".Species, \"zwierzak\".decodeGender(), \"zwierzak\".decodeMaturity() FROM \"Zwierzê\" WHERE \"zwierzak\".Filter('{filterItem[1]}','{filterItem[2]}') = 1";
                    cmd = new SqlCommand(cmd_str, conn);
                    reader = cmd.ExecuteReader();

                    animalList.Clear();

                    while (reader.Read())
                    {
                        string str_info = (string)reader[1] + " " + (string)reader[2] + ", " + (string)reader[3] + ", " + (string)reader[4];
                        animalList.Add(new Basic { Info = str_info, Id = (int)reader[0] });
                    }
                    reader.Close();

                    animalDisplay.DataSource = animalList;
                    animalDisplay.DisplayMember = "Info";
                    animalDisplay.ValueMember = "Id";

                    conn.Close();
                }
                if (filterItem[0] == "Pojemnik")
                {
                    filterEnclosure.Text = "Clear filter";

                    cmd_str = $"SELECT \"id\", \"pojemnik\".ToString() FROM \"Pojemnik\" WHERE \"pojemnik\".Filter('{filterItem[1]}','{filterItem[2]}') = 1";
                    cmd = new SqlCommand(cmd_str, conn);
                    reader = cmd.ExecuteReader();

                    enclosureList.Clear();

                    while (reader.Read())
                    {
                        string str_info = (string)reader[1];
                        enclosureList.Add(new Basic { Info = str_info, Id = (int)reader[0] });
                    }

                    enclosureDisplay.DataSource = enclosureList;
                    enclosureDisplay.DisplayMember = "Info";
                    enclosureDisplay.ValueMember = "Id";

                    conn.Close();
                }
                if (filterItem[0] == "Narzêdzie")
                {
                    filterTool.Text = "Clear";

                    cmd_str = $"SELECT \"id\", \"nazwa\", \"szczegó³y\" FROM \"Narzêdzie\" WHERE {filterItem[1]} = '{filterItem[2]}'";
                    cmd = new SqlCommand(cmd_str, conn);
                    reader = cmd.ExecuteReader();

                    toolList.Clear();

                    while (reader.Read())
                    {
                        string str_info = (string)reader[1] + " " + ((string)reader[2]).Split(",")[0];
                        toolList.Add(new Basic() { Info = str_info, Id = (int)reader[0] });
                    }
                    reader.Close();

                    toolDisplay.DataSource = toolList;
                    toolDisplay.DisplayMember = "Info";
                    toolDisplay.ValueMember = "Id";
                }
            }
        }

        private void citesText_Click(object sender, EventArgs e)
        {

        }

        private void hodowlaButton_Click(object sender, EventArgs e)
        {
            Details detail = new Details() { id = (petDisplay.SelectedValue != null) ? (int)petDisplay.SelectedValue : 0, toDisplay = "Hodowla" };

            detail.Show();
        }

        private void adminView_Click(object sender, EventArgs e)
        {
            addAnimalButton.Visible = !addAnimalButton.Visible;
            addEnclosureButton.Visible = !addEnclosureButton.Visible;
            addToolButton.Visible = !addToolButton.Visible;
            viewClients.Visible = !viewClients.Visible;
        }

        private void addAnimalButton_Click(object sender, EventArgs e)
        {
            AddAmountOrNew addWindow = new AddAmountOrNew() { id = (int)animalDisplay.SelectedValue, toChange = "Zwierzê", item = animalDisplay.SelectedItem.ToString() };
            addWindow.Show();
        }

        private void addEnclosureButton_Click(object sender, EventArgs e)
        {
            AddAmountOrNew addWindow = new AddAmountOrNew() { id = (int)enclosureDisplay.SelectedValue, toChange = "Pojemnik", item = enclosureDisplay.SelectedItem.ToString() };
            addWindow.Show();
        }

        private void addToolButton_Click(object sender, EventArgs e)
        {
            AddAmountOrNew addWindow = new AddAmountOrNew() { id = (int)toolDisplay.SelectedValue, toChange = "Narzêdzie", item = toolDisplay.SelectedItem.ToString() };
            addWindow.Show();
        }

        private void filterAnimal_Click(object sender, EventArgs e)
        {
            if (filterAnimal.Text == "Filter")
            {
                FilterData filterData = new FilterData();
                filterData.toFilter = "Zwierzê";
                filterData.Show();
            }
            else
            {
                FilterString = null;
                filterItem = null;
                filterAnimal.Text = "Filter";
            }
        }

        private void filterEnclosure_Click(object sender, EventArgs e)
        {
            if (filterEnclosure.Text == "Filter")
            {
                FilterData filterData = new FilterData();
                filterData.toFilter = "Pojemnik";
                filterData.Show();
            }
            else
            {
                FilterString = null;
                filterItem = null;
                filterEnclosure.Text = "Filter";
            }
        }

        private void filterTool_Click(object sender, EventArgs e)
        {
            if (filterTool.Text == "Filter")
            {
                FilterData filterData = new FilterData();
                filterData.toFilter = "Narzêdzie";
                filterData.Show();
            }
            else
            {
                FilterString = null;
                filterItem = null;
                filterTool.Text = "Filter";
            }
        }

        private void viewClients_Click(object sender, EventArgs e)
        {
            ViewClientsForm viewClientsForm = new ViewClientsForm();
            viewClientsForm.Show();
        }
    }
}
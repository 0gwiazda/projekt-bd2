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
    public partial class AddAmountOrNew : Form
    {
        public string sql_conn_str = Form1.sql_conn_str;
        public int id { get; set; }
        public string toChange { get; set; }
        public string item { get; set; }
        public AddAmountOrNew()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddAmountOrNew_Load(object sender, EventArgs e)
        {
            titleLabelR.Visible = false;

            panel1.Visible = false;
            panel2.Visible = false;

            lengthText.Visible = false;
            widthText.Visible = false;
            widthLabel.Visible = false;
            heightText.Visible = false;
            heightLabel.Visible = false;
            enviromentText.Visible = false;

        }

        private void addItem_Click(object sender, EventArgs e)
        {
            if (toChange.Equals("Zwierzę"))
            {

                SqlConnection conn = new SqlConnection(sql_conn_str);
                conn.Open();

                int dangerLvl;
                bool check = Int32.TryParse(dangerText.Text, out dangerLvl);

                if (!check)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Danger has to be an integer!!";
                    err.Success = false;
                    Close();
                }

                int numOfChildren;
                check = Int32.TryParse(numOfChildText.Text, out numOfChildren);

                if (!check)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Number of children has to be an integer!!";
                    err.Success = false;
                    Close();
                }



                string animal = familyText.Text + "," + speciesText.Text + "," +
                                typeCombo.SelectedIndex + "," + genderCombo.SelectedIndex + "," +
                                maturityCombo.SelectedIndex + "," + numOfChildren + "," +
                                dangerLvl + "," + ((endangeredCheck.Checked) ? "true" : "false");

                int price;
                check = Int32.TryParse(priceText.Text, out price);

                if (!check || price <= 0)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Price has to be a greater than zero integer!!";
                    err.Success = false;
                    Close();
                }

                int amount;
                check = Int32.TryParse(amountTextR.Text, out amount);

                if (!check || amount <= 0)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Amount has to be a greater than zero integer!!";
                    err.Success = false;
                    Close();
                }

                try
                {
                    string str_cmd = $"INSERT INTO \"{toChange}\"(\"zwierzak\", \"cena\", \"ilosc\") VALUES ('{animal}',{price},{amount})";
                    SqlCommand cmd = new SqlCommand(str_cmd, conn);
                    cmd.ExecuteNonQuery();

                    SuccessError succ = new SuccessError();
                    succ.Message = "Added new animal.";
                    succ.Success = true;
                    succ.Show();
                }
                catch (Exception ex)
                {
                    SuccessError err = new SuccessError();
                    err.Message = (ex.Message.Contains("Animal")) ? "ERROR: Invalid animal" : ex.Message;
                    err.Success = false;
                    err.Show();
                }
                finally
                {
                    conn.Close();
                    Close();
                }
            }
            if (toChange.Equals("Pojemnik"))
            {

                SqlConnection conn = new SqlConnection(sql_conn_str);
                conn.Open();

                int price;
                bool check = Int32.TryParse(priceText.Text, out price);

                if (!check || price <= 0)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Price has to be greater than zero integer!!";
                    err.Success = false;
                    Close();
                }

                int amount;
                check = Int32.TryParse(amountTextR.Text, out amount);

                if (!check || amount <= 0)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Amount has to be a greater than zero integer!!";
                    err.Success = false;
                    Close();
                }

                double length;
                check = Double.TryParse(lengthText.Text, out length);

                if (!check)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Length has to be a double!!";
                    err.Success = false;
                    Close();
                }

                double width;
                check = Double.TryParse(widthText.Text, out width);

                if (!check)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Width has to be a double!!";
                    err.Success = false;
                    Close();
                }

                double height;
                check = Double.TryParse(heightText.Text, out height);

                if (!check)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Height has to be a double!!";
                    err.Success = false;
                    Close();
                }

                string enclosure_str = typeCombo.Text + "," + length + "x" + width + "x" + height + "," +
                                       ((endangeredCheck.Checked) ? "true" : "false") + "," +
                                       ((endangeredCheck.Checked) ? enviromentText.Text : "");

                try
                {
                    string str_cmd = $"INSERT INTO \"{toChange}\"(\"pojemnik\", \"cena\", \"ilosc\") VALUES ('{enclosure_str}',{price},{amount})";
                    SqlCommand cmd = new SqlCommand(str_cmd, conn);
                    cmd.ExecuteNonQuery();

                    SuccessError succ = new SuccessError();
                    succ.Message = "Added new enclosure.";
                    succ.Success = true;
                    succ.Show();
                }
                catch (Exception ex)
                {
                    SuccessError err = new SuccessError();
                    err.Message = (ex.Message.Contains("Enclosure")) ? "ERROR: Invalid enclosure" : ex.Message;
                    err.Success = false;
                    err.Show();
                }
                finally
                {
                    conn.Close();
                    Close();
                }

            }
            if (toChange.Equals("Narzędzie"))
            {

                SqlConnection conn = new SqlConnection(sql_conn_str);
                conn.Open();

                int price;
                bool check = Int32.TryParse(priceText.Text, out price);

                if (!check || price <= 0)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Price has to be a greater than zero integer!!";
                    err.Success = false;
                    Close();
                }

                int amount;
                check = Int32.TryParse(amountTextR.Text, out amount);

                if (!check || amount <= 0)
                {
                    SuccessError err = new SuccessError();
                    err.Message = "Amount has to be a greater than zero integer!!";
                    err.Success = false;
                    Close();
                }

                try
                {
                    string str_cmd = $"INSERT INTO \"{toChange}\"(\"nazwa\", \"szczegóły\", \"price\", \"ilosc\") VALUES ('{familyText.Text}','{speciesText.Text}',{price},{amount})";
                    SqlCommand cmd = new SqlCommand(str_cmd, conn);
                    cmd.ExecuteNonQuery();

                    SuccessError succ = new SuccessError();
                    succ.Message = "Added new tool.";
                    succ.Success = true;
                    succ.Show();
                }
                catch (Exception ex)
                {
                    SuccessError err = new SuccessError();
                    err.Message = ex.Message;
                    err.Success = false;
                    err.Show();
                }
                finally
                {
                    conn.Close();
                    Close();
                }
            }
        }

        private void addNew_Click(object sender, EventArgs e)
        {
            if (toChange.Equals("Zwierzę"))
            {
                titleLabelR.Text = "Add new animal";

                titleLabelR.Visible = true;
                panel2.Visible = true;

                addNew.Visible = false;
                addAmount.Visible = false;
            }
            if (toChange.Equals("Pojemnik"))
            {
                titleLabelR.Text = "Add new enclosure";
                panel2.Visible = true;

                familyLabel.Visible = false;
                familyText.Visible = false;

                speciesLabel.Text = "Length:";
                endangeredCheck.Text = "Decorated";
                typeCombo.Items.Clear();
                typeCombo.Items.Add("terrarium");
                typeCombo.Items.Add("faunarium");
                typeCombo.Items.Add("aquarium");
                speciesText.Visible = false;
                lengthText.Visible = true;
                widthLabel.Visible = true;
                widthText.Visible = true;
                heightLabel.Visible = true;
                heightText.Visible = true;

                maturityCombo.Visible = false;
                maturityLabel.Visible = false;
                genderCombo.Visible = false;
                genderLabel.Visible = false;

                dangerText.Visible = false;
                dangerLabel.Visible = false;
                numOfChildLabel.Visible = false;
                numOfChildText.Visible = false;

                dangerLabel.Text = "Enviroment: ";
            }
            if (toChange.Equals("Narzędzie"))
            {
                titleLabelR.Text = "Add new tool";

                titleLabelR.Visible = true;
                panel2.Visible = true;

                familyLabel.Text = "Name:";
                speciesLabel.Text = "Details:";

                typeCombo.Visible = false;
                typeLabel.Visible = false;
                maturityCombo.Visible = false;
                maturityLabel.Visible = false;
                genderCombo.Visible = false;
                genderLabel.Visible = false;
                numOfChildLabel.Visible = false;
                numOfChildText.Visible = false;

                dangerText.Visible = false;
                dangerLabel.Visible = false;
                endangeredCheck.Visible = false;

                addNew.Visible = false;
                addAmount.Visible = false;
            }
        }

        private void addAmount_Click(object sender, EventArgs e)
        {
            addAmountLabelL.Text += " " + item;

            panel1.Visible = true;
            addAmount.Visible = false;
            addNew.Visible = false;
        }

        private void addAmountButton_Click(object sender, EventArgs e)
        {
            string sql_conn_str = "DATA SOURCE=DESKTOP-R7JHO89\\SQLEXPRESS;INITIAL CATALOG=Projekt_CLR_UDT;USER ID=DESKTOP-R7JHO89\\Wojciech;INTEGRATED SECURITY=True;TRUSTED_CONNECTION=TRUE;ENCRYPT=FALSE;";
            SqlConnection conn = new SqlConnection(sql_conn_str);
            conn.Open();

            int amount;
            bool check = Int32.TryParse(amountText.Text, out amount);

            if (!check || amount < 0)
            {
                SuccessError err = new SuccessError();
                err.Message = "Invalid value of amount!! Amount must be larger than zero and an integer.";
                err.Success = false;
                err.Show();

                conn.Close();
                Close();
            }
            else
            {
                try
                {
                    string str_cmd = $"UPDATE \"{toChange}\" SET \"ilosc\" = \"ilosc\" + {amount} WHERE \"id\" = {id}";
                    SqlCommand cmd = new SqlCommand(str_cmd, conn);
                    cmd.ExecuteNonQuery();

                    SuccessError succ = new SuccessError();
                    succ.Message = $"Added {amount} to {item}";
                    succ.Success = true;
                    succ.Show();
                }
                catch (Exception ex)
                {
                    SuccessError err = new SuccessError();
                    err.Message = ex.Message;
                    err.Success = false;
                    err.Show();
                }
                finally
                {
                    conn.Close();
                    Close();
                }
            }
        }

        private void endangeredCheck_CheckedChanged(object sender, EventArgs e)
        {
            dangerLabel.Visible = !dangerLabel.Visible;
            enviromentText.Visible = !enviromentText.Visible;
        }
    }
}

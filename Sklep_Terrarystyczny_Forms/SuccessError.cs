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
    public partial class SuccessError : Form
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public SuccessError()
        {
            InitializeComponent();
        }

        private void SuccessError_Load(object sender, EventArgs e)
        {
            this.Text = (Success) ? "Success" : "Error";
            messageLabel.Text = Message;

            messageLabel.ForeColor = (!Success) ? Color.Red : Color.Green;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

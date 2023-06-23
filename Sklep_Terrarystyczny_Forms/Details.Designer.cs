namespace Sklep_Terrarystyczny_Forms
{
    partial class Details
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Close = new Button();
            name = new Label();
            type = new Label();
            gender = new Label();
            maturity = new Label();
            numOfChild = new Label();
            danger = new Label();
            endangered = new Label();
            price = new Label();
            amount = new Label();
            SuspendLayout();
            // 
            // Close
            // 
            Close.Location = new Point(353, 386);
            Close.Name = "Close";
            Close.Size = new Size(109, 34);
            Close.TabIndex = 0;
            Close.Text = "Close";
            Close.UseVisualStyleBackColor = true;
            Close.Click += button1_Click;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Location = new Point(75, 57);
            name.Name = "name";
            name.Size = new Size(42, 15);
            name.TabIndex = 1;
            name.Text = "Name:";
            name.Click += label1_Click;
            // 
            // type
            // 
            type.AutoSize = true;
            type.Location = new Point(74, 92);
            type.Name = "type";
            type.Size = new Size(34, 15);
            type.TabIndex = 1;
            type.Text = "Type:";
            type.Click += label1_Click;
            // 
            // gender
            // 
            gender.AutoSize = true;
            gender.Location = new Point(75, 128);
            gender.Name = "gender";
            gender.Size = new Size(48, 15);
            gender.TabIndex = 1;
            gender.Text = "Gender:";
            gender.Click += label1_Click;
            // 
            // maturity
            // 
            maturity.AutoSize = true;
            maturity.Location = new Point(75, 163);
            maturity.Name = "maturity";
            maturity.Size = new Size(55, 15);
            maturity.TabIndex = 1;
            maturity.Text = "Maturity:";
            maturity.Click += label1_Click;
            // 
            // numOfChild
            // 
            numOfChild.AutoSize = true;
            numOfChild.Location = new Point(259, 128);
            numOfChild.Name = "numOfChild";
            numOfChild.Size = new Size(114, 15);
            numOfChild.TabIndex = 1;
            numOfChild.Text = "Number of children:";
            numOfChild.Click += label1_Click;
            // 
            // danger
            // 
            danger.AutoSize = true;
            danger.Location = new Point(75, 202);
            danger.Name = "danger";
            danger.Size = new Size(48, 15);
            danger.TabIndex = 1;
            danger.Text = "Danger:";
            danger.Click += label1_Click;
            // 
            // endangered
            // 
            endangered.AutoSize = true;
            endangered.Location = new Point(75, 244);
            endangered.Name = "endangered";
            endangered.Size = new Size(73, 15);
            endangered.TabIndex = 1;
            endangered.Text = "Endangered:";
            endangered.Click += label1_Click;
            // 
            // price
            // 
            price.AutoSize = true;
            price.Location = new Point(550, 244);
            price.Name = "price";
            price.Size = new Size(36, 15);
            price.TabIndex = 2;
            price.Text = "Price:";
            price.Click += label1_Click_1;
            // 
            // amount
            // 
            amount.AutoSize = true;
            amount.Location = new Point(550, 220);
            amount.Name = "amount";
            amount.Size = new Size(54, 15);
            amount.TabIndex = 3;
            amount.Text = "Amount:";
            amount.Click += amount_Click;
            // 
            // Details
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 449);
            Controls.Add(amount);
            Controls.Add(price);
            Controls.Add(endangered);
            Controls.Add(danger);
            Controls.Add(numOfChild);
            Controls.Add(maturity);
            Controls.Add(gender);
            Controls.Add(type);
            Controls.Add(name);
            Controls.Add(Close);
            Name = "Details";
            Text = "Details";
            Load += Details_animals_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Close;
        private Label name;
        private Label type;
        private Label gender;
        private Label maturity;
        private Label numOfChild;
        private Label danger;
        private Label endangered;
        private Label price;
        private Label amount;
    }
}
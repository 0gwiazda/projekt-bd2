namespace Sklep_Terrarystyczny_Forms
{
    partial class RegisterLogin
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
            regLogButton = new Button();
            nameText = new TextBox();
            lastNameText = new TextBox();
            emailText = new TextBox();
            adres1Text = new TextBox();
            cityText = new TextBox();
            adres2Text = new TextBox();
            codeText = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            adres1Label = new Label();
            cityLabel = new Label();
            adres2Label = new Label();
            codeLabel = new Label();
            SuspendLayout();
            // 
            // regLogButton
            // 
            regLogButton.Location = new Point(310, 340);
            regLogButton.Name = "regLogButton";
            regLogButton.Size = new Size(97, 25);
            regLogButton.TabIndex = 0;
            regLogButton.Text = "button1";
            regLogButton.UseVisualStyleBackColor = true;
            regLogButton.Click += regLogButton_Click;
            // 
            // nameText
            // 
            nameText.Location = new Point(48, 53);
            nameText.Name = "nameText";
            nameText.Size = new Size(199, 23);
            nameText.TabIndex = 1;
            // 
            // lastNameText
            // 
            lastNameText.Location = new Point(291, 53);
            lastNameText.Name = "lastNameText";
            lastNameText.Size = new Size(215, 23);
            lastNameText.TabIndex = 1;
            // 
            // emailText
            // 
            emailText.Location = new Point(545, 53);
            emailText.Name = "emailText";
            emailText.Size = new Size(191, 23);
            emailText.TabIndex = 1;
            // 
            // adres1Text
            // 
            adres1Text.Location = new Point(48, 147);
            adres1Text.Name = "adres1Text";
            adres1Text.Size = new Size(235, 23);
            adres1Text.TabIndex = 1;
            // 
            // cityText
            // 
            cityText.Location = new Point(339, 147);
            cityText.Name = "cityText";
            cityText.Size = new Size(141, 23);
            cityText.TabIndex = 1;
            // 
            // adres2Text
            // 
            adres2Text.Location = new Point(48, 231);
            adres2Text.Name = "adres2Text";
            adres2Text.Size = new Size(235, 23);
            adres2Text.TabIndex = 1;
            // 
            // codeText
            // 
            codeText.Location = new Point(339, 231);
            codeText.Name = "codeText";
            codeText.Size = new Size(141, 23);
            codeText.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 35);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 2;
            label1.Text = "First name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(291, 35);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 3;
            label2.Text = "Last name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(545, 35);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Email:";
            // 
            // adres1Label
            // 
            adres1Label.AutoSize = true;
            adres1Label.Location = new Point(48, 129);
            adres1Label.Name = "adres1Label";
            adres1Label.Size = new Size(61, 15);
            adres1Label.TabIndex = 5;
            adres1Label.Text = "Address 1:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new Point(339, 129);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(31, 15);
            cityLabel.TabIndex = 6;
            cityLabel.Text = "City:";
            // 
            // adres2Label
            // 
            adres2Label.AutoSize = true;
            adres2Label.Location = new Point(48, 213);
            adres2Label.Name = "adres2Label";
            adres2Label.Size = new Size(61, 15);
            adres2Label.TabIndex = 7;
            adres2Label.Text = "Address 2:";
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Location = new Point(339, 213);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new Size(38, 15);
            codeLabel.TabIndex = 8;
            codeLabel.Text = "Code:";
            // 
            // RegisterLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(756, 377);
            Controls.Add(codeLabel);
            Controls.Add(adres2Label);
            Controls.Add(cityLabel);
            Controls.Add(adres1Label);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cityText);
            Controls.Add(emailText);
            Controls.Add(codeText);
            Controls.Add(adres2Text);
            Controls.Add(adres1Text);
            Controls.Add(lastNameText);
            Controls.Add(nameText);
            Controls.Add(regLogButton);
            Name = "RegisterLogin";
            Text = "RegisterLogin";
            Load += RegisterLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button regLogButton;
        private TextBox nameText;
        private TextBox lastNameText;
        private TextBox emailText;
        private TextBox adres1Text;
        private TextBox cityText;
        private TextBox adres2Text;
        private TextBox codeText;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label adres1Label;
        private Label cityLabel;
        private Label adres2Label;
        private Label codeLabel;
    }
}
namespace Sklep_Terrarystyczny_Forms
{
    partial class AddAmountOrNew
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
            addAmount = new Button();
            addNew = new Button();
            panel1 = new Panel();
            addAmountLabelL = new Label();
            amountLabelL = new Label();
            addAmountButton = new Button();
            amountText = new TextBox();
            panel2 = new Panel();
            heightLabel = new Label();
            widthLabel = new Label();
            enviromentText = new TextBox();
            heightText = new TextBox();
            widthText = new TextBox();
            lengthText = new TextBox();
            numOfChildLabel = new Label();
            numOfChildText = new TextBox();
            amountLabelR = new Label();
            priceLabel = new Label();
            dangerLabel = new Label();
            genderLabel = new Label();
            maturityLabel = new Label();
            typeLabel = new Label();
            speciesLabel = new Label();
            familyLabel = new Label();
            addItem = new Button();
            amountTextR = new TextBox();
            priceText = new TextBox();
            endangeredCheck = new CheckBox();
            dangerText = new TextBox();
            genderCombo = new ComboBox();
            maturityCombo = new ComboBox();
            typeCombo = new ComboBox();
            speciesText = new TextBox();
            familyText = new TextBox();
            titleLabelR = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // addAmount
            // 
            addAmount.Location = new Point(148, 39);
            addAmount.Name = "addAmount";
            addAmount.Size = new Size(94, 28);
            addAmount.TabIndex = 0;
            addAmount.Text = "Add amount";
            addAmount.UseVisualStyleBackColor = true;
            addAmount.Click += addAmount_Click;
            // 
            // addNew
            // 
            addNew.Location = new Point(560, 39);
            addNew.Name = "addNew";
            addNew.Size = new Size(94, 28);
            addNew.TabIndex = 0;
            addNew.Text = "Add new";
            addNew.UseVisualStyleBackColor = true;
            addNew.Click += addNew_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(addAmountLabelL);
            panel1.Controls.Add(amountLabelL);
            panel1.Controls.Add(addAmountButton);
            panel1.Controls.Add(amountText);
            panel1.Location = new Point(13, 73);
            panel1.Name = "panel1";
            panel1.Size = new Size(359, 365);
            panel1.TabIndex = 1;
            // 
            // addAmountLabelL
            // 
            addAmountLabelL.Dock = DockStyle.Top;
            addAmountLabelL.Location = new Point(0, 0);
            addAmountLabelL.Name = "addAmountLabelL";
            addAmountLabelL.Size = new Size(359, 115);
            addAmountLabelL.TabIndex = 3;
            addAmountLabelL.Text = "Add amount to";
            addAmountLabelL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // amountLabelL
            // 
            amountLabelL.AutoSize = true;
            amountLabelL.Location = new Point(91, 115);
            amountLabelL.Name = "amountLabelL";
            amountLabelL.Size = new Size(54, 15);
            amountLabelL.TabIndex = 2;
            amountLabelL.Text = "Amount:";
            // 
            // addAmountButton
            // 
            addAmountButton.Location = new Point(135, 173);
            addAmountButton.Name = "addAmountButton";
            addAmountButton.Size = new Size(75, 23);
            addAmountButton.TabIndex = 1;
            addAmountButton.Text = "Add";
            addAmountButton.UseVisualStyleBackColor = true;
            addAmountButton.Click += addAmountButton_Click;
            // 
            // amountText
            // 
            amountText.Location = new Point(91, 133);
            amountText.Name = "amountText";
            amountText.Size = new Size(168, 23);
            amountText.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(heightLabel);
            panel2.Controls.Add(widthLabel);
            panel2.Controls.Add(enviromentText);
            panel2.Controls.Add(heightText);
            panel2.Controls.Add(widthText);
            panel2.Controls.Add(lengthText);
            panel2.Controls.Add(numOfChildLabel);
            panel2.Controls.Add(numOfChildText);
            panel2.Controls.Add(amountLabelR);
            panel2.Controls.Add(priceLabel);
            panel2.Controls.Add(dangerLabel);
            panel2.Controls.Add(genderLabel);
            panel2.Controls.Add(maturityLabel);
            panel2.Controls.Add(typeLabel);
            panel2.Controls.Add(speciesLabel);
            panel2.Controls.Add(familyLabel);
            panel2.Controls.Add(addItem);
            panel2.Controls.Add(amountTextR);
            panel2.Controls.Add(priceText);
            panel2.Controls.Add(endangeredCheck);
            panel2.Controls.Add(dangerText);
            panel2.Controls.Add(genderCombo);
            panel2.Controls.Add(maturityCombo);
            panel2.Controls.Add(typeCombo);
            panel2.Controls.Add(speciesText);
            panel2.Controls.Add(familyText);
            panel2.Location = new Point(429, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(359, 365);
            panel2.TabIndex = 1;
            // 
            // heightLabel
            // 
            heightLabel.AutoSize = true;
            heightLabel.Location = new Point(250, 51);
            heightLabel.Name = "heightLabel";
            heightLabel.Size = new Size(46, 15);
            heightLabel.TabIndex = 20;
            heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            widthLabel.AutoSize = true;
            widthLabel.Location = new Point(163, 51);
            widthLabel.Name = "widthLabel";
            widthLabel.Size = new Size(42, 15);
            widthLabel.TabIndex = 19;
            widthLabel.Text = "Width:";
            // 
            // enviromentText
            // 
            enviromentText.Location = new Point(75, 243);
            enviromentText.Name = "enviromentText";
            enviromentText.Size = new Size(241, 23);
            enviromentText.TabIndex = 18;
            // 
            // heightText
            // 
            heightText.Location = new Point(250, 69);
            heightText.Name = "heightText";
            heightText.Size = new Size(66, 23);
            heightText.TabIndex = 17;
            // 
            // widthText
            // 
            widthText.Location = new Point(163, 69);
            widthText.Name = "widthText";
            widthText.Size = new Size(66, 23);
            widthText.TabIndex = 16;
            // 
            // lengthText
            // 
            lengthText.Location = new Point(75, 69);
            lengthText.Name = "lengthText";
            lengthText.Size = new Size(66, 23);
            lengthText.TabIndex = 15;
            // 
            // numOfChildLabel
            // 
            numOfChildLabel.AutoSize = true;
            numOfChildLabel.Location = new Point(200, 225);
            numOfChildLabel.Name = "numOfChildLabel";
            numOfChildLabel.Size = new Size(116, 15);
            numOfChildLabel.TabIndex = 14;
            numOfChildLabel.Text = "Number of Children:";
            // 
            // numOfChildText
            // 
            numOfChildText.Location = new Point(200, 243);
            numOfChildText.Name = "numOfChildText";
            numOfChildText.Size = new Size(116, 23);
            numOfChildText.TabIndex = 13;
            // 
            // amountLabelR
            // 
            amountLabelR.AutoSize = true;
            amountLabelR.Location = new Point(200, 276);
            amountLabelR.Name = "amountLabelR";
            amountLabelR.Size = new Size(54, 15);
            amountLabelR.TabIndex = 12;
            amountLabelR.Text = "Amount:";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(75, 276);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(36, 15);
            priceLabel.TabIndex = 11;
            priceLabel.Text = "Price:";
            // 
            // dangerLabel
            // 
            dangerLabel.AutoSize = true;
            dangerLabel.Location = new Point(75, 225);
            dangerLabel.Name = "dangerLabel";
            dangerLabel.Size = new Size(82, 15);
            dangerLabel.TabIndex = 10;
            dangerLabel.Text = "Danger (0-10):";
            // 
            // genderLabel
            // 
            genderLabel.AutoSize = true;
            genderLabel.Location = new Point(200, 146);
            genderLabel.Name = "genderLabel";
            genderLabel.Size = new Size(48, 15);
            genderLabel.TabIndex = 9;
            genderLabel.Text = "Gender:";
            // 
            // maturityLabel
            // 
            maturityLabel.AutoSize = true;
            maturityLabel.Location = new Point(75, 146);
            maturityLabel.Name = "maturityLabel";
            maturityLabel.Size = new Size(55, 15);
            maturityLabel.TabIndex = 8;
            maturityLabel.Text = "Maturity:";
            // 
            // typeLabel
            // 
            typeLabel.AutoSize = true;
            typeLabel.Location = new Point(75, 100);
            typeLabel.Name = "typeLabel";
            typeLabel.Size = new Size(34, 15);
            typeLabel.TabIndex = 7;
            typeLabel.Text = "Type:";
            // 
            // speciesLabel
            // 
            speciesLabel.AutoSize = true;
            speciesLabel.Location = new Point(75, 51);
            speciesLabel.Name = "speciesLabel";
            speciesLabel.Size = new Size(49, 15);
            speciesLabel.TabIndex = 6;
            speciesLabel.Text = "Species:";
            // 
            // familyLabel
            // 
            familyLabel.AutoSize = true;
            familyLabel.Location = new Point(75, 4);
            familyLabel.Name = "familyLabel";
            familyLabel.Size = new Size(42, 15);
            familyLabel.TabIndex = 2;
            familyLabel.Text = "Family";
            // 
            // addItem
            // 
            addItem.Location = new Point(131, 336);
            addItem.Name = "addItem";
            addItem.Size = new Size(94, 26);
            addItem.TabIndex = 5;
            addItem.Text = "Dodaj";
            addItem.UseVisualStyleBackColor = true;
            addItem.Click += addItem_Click;
            // 
            // amountTextR
            // 
            amountTextR.Location = new Point(200, 294);
            amountTextR.Name = "amountTextR";
            amountTextR.Size = new Size(116, 23);
            amountTextR.TabIndex = 4;
            // 
            // priceText
            // 
            priceText.Location = new Point(75, 294);
            priceText.Name = "priceText";
            priceText.Size = new Size(88, 23);
            priceText.TabIndex = 4;
            // 
            // endangeredCheck
            // 
            endangeredCheck.AutoSize = true;
            endangeredCheck.Location = new Point(143, 203);
            endangeredCheck.Name = "endangeredCheck";
            endangeredCheck.Size = new Size(89, 19);
            endangeredCheck.TabIndex = 3;
            endangeredCheck.Text = "Endangered";
            endangeredCheck.UseVisualStyleBackColor = true;
            endangeredCheck.CheckedChanged += endangeredCheck_CheckedChanged;
            // 
            // dangerText
            // 
            dangerText.Location = new Point(75, 243);
            dangerText.Name = "dangerText";
            dangerText.Size = new Size(88, 23);
            dangerText.TabIndex = 2;
            // 
            // genderCombo
            // 
            genderCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            genderCombo.FormattingEnabled = true;
            genderCombo.Items.AddRange(new object[] { "NS", "Male", "Female" });
            genderCombo.Location = new Point(200, 164);
            genderCombo.Name = "genderCombo";
            genderCombo.Size = new Size(116, 23);
            genderCombo.TabIndex = 1;
            // 
            // maturityCombo
            // 
            maturityCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            maturityCombo.FormattingEnabled = true;
            maturityCombo.Items.AddRange(new object[] { "Hatchling", "Juvenile", "Subadult", "Adult" });
            maturityCombo.Location = new Point(75, 164);
            maturityCombo.Name = "maturityCombo";
            maturityCombo.Size = new Size(104, 23);
            maturityCombo.TabIndex = 1;
            maturityCombo.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // typeCombo
            // 
            typeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            typeCombo.FormattingEnabled = true;
            typeCombo.Items.AddRange(new object[] { "Spider", "Scorpion", "Solifugae", "Amblypygid", "Uropygid", "Tortoise", "Lizard", "Snake" });
            typeCombo.Location = new Point(75, 118);
            typeCombo.Name = "typeCombo";
            typeCombo.Size = new Size(241, 23);
            typeCombo.TabIndex = 1;
            // 
            // speciesText
            // 
            speciesText.Location = new Point(75, 69);
            speciesText.Name = "speciesText";
            speciesText.Size = new Size(241, 23);
            speciesText.TabIndex = 0;
            speciesText.TextChanged += textBox3_TextChanged;
            // 
            // familyText
            // 
            familyText.Location = new Point(75, 22);
            familyText.Name = "familyText";
            familyText.Size = new Size(241, 23);
            familyText.TabIndex = 0;
            // 
            // titleLabelR
            // 
            titleLabelR.AutoSize = true;
            titleLabelR.Location = new Point(560, 46);
            titleLabelR.Name = "titleLabelR";
            titleLabelR.Size = new Size(54, 15);
            titleLabelR.TabIndex = 2;
            titleLabelR.Text = "Add new";
            // 
            // AddAmountOrNew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(titleLabelR);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(addNew);
            Controls.Add(addAmount);
            Name = "AddAmountOrNew";
            Text = "AddAmountOrNew";
            Load += AddAmountOrNew_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addAmount;
        private Button addNew;
        private Panel panel1;
        private Panel panel2;
        private Button addAmountButton;
        private TextBox amountText;
        private TextBox speciesText;
        private TextBox familyText;
        private ComboBox maturityCombo;
        private ComboBox typeCombo;
        private ComboBox genderCombo;
        private Button addItem;
        private TextBox amountTextR;
        private TextBox priceText;
        private CheckBox endangeredCheck;
        private TextBox dangerText;
        private Label amountLabelL;
        private Label maturityLabel;
        private Label typeLabel;
        private Label speciesLabel;
        private Label familyLabel;
        private Label genderLabel;
        private Label amountLabelR;
        private Label priceLabel;
        private Label dangerLabel;
        private Label titleLabelR;
        private Label numOfChildLabel;
        private TextBox numOfChildText;
        private TextBox enviromentText;
        private TextBox heightText;
        private TextBox widthText;
        private TextBox lengthText;
        private Label heightLabel;
        private Label widthLabel;
        private Label addAmountLabelL;
    }
}
namespace Sklep_Terrarystyczny_Forms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            animalDisplay = new ListBox();
            animalButton = new Button();
            enclosureDisplay = new ListBox();
            toolDisplay = new ListBox();
            enclosureButton = new Button();
            toolButton = new Button();
            animalCheck = new CheckBox();
            enclosureCheck = new CheckBox();
            toolCheck = new CheckBox();
            panel1 = new Panel();
            buyButton = new Button();
            codeText = new TextBox();
            cityText = new TextBox();
            adres2Text = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            labeladres = new Label();
            adres1Text = new TextBox();
            label1 = new Label();
            errorLabel = new Label();
            register = new Button();
            login = new Button();
            petDisplay = new ListBox();
            citesText = new Label();
            dangerText = new Label();
            load = new Button();
            nameLabel = new Label();
            lastNameLabel = new Label();
            adres1Label = new Label();
            adres2Label = new Label();
            codeLabel = new Label();
            cityLabel = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            hodowlaButton = new Button();
            adminView = new Button();
            addAnimalButton = new Button();
            addEnclosureButton = new Button();
            addToolButton = new Button();
            filterAnimal = new Button();
            filterEnclosure = new Button();
            filterTool = new Button();
            viewClients = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // animalDisplay
            // 
            animalDisplay.AllowDrop = true;
            animalDisplay.FormattingEnabled = true;
            animalDisplay.ItemHeight = 15;
            animalDisplay.Location = new Point(793, 49);
            animalDisplay.Name = "animalDisplay";
            animalDisplay.ScrollAlwaysVisible = true;
            animalDisplay.Size = new Size(358, 124);
            animalDisplay.TabIndex = 2;
            // 
            // animalButton
            // 
            animalButton.Location = new Point(793, 179);
            animalButton.Name = "animalButton";
            animalButton.Size = new Size(123, 23);
            animalButton.TabIndex = 3;
            animalButton.Text = "Show details";
            animalButton.UseVisualStyleBackColor = true;
            animalButton.Click += animalButton_Click;
            // 
            // enclosureDisplay
            // 
            enclosureDisplay.AllowDrop = true;
            enclosureDisplay.FormattingEnabled = true;
            enclosureDisplay.ItemHeight = 15;
            enclosureDisplay.Location = new Point(793, 247);
            enclosureDisplay.Name = "enclosureDisplay";
            enclosureDisplay.ScrollAlwaysVisible = true;
            enclosureDisplay.Size = new Size(358, 124);
            enclosureDisplay.TabIndex = 2;
            // 
            // toolDisplay
            // 
            toolDisplay.AllowDrop = true;
            toolDisplay.FormattingEnabled = true;
            toolDisplay.ItemHeight = 15;
            toolDisplay.Location = new Point(793, 454);
            toolDisplay.Name = "toolDisplay";
            toolDisplay.ScrollAlwaysVisible = true;
            toolDisplay.Size = new Size(358, 124);
            toolDisplay.TabIndex = 2;
            // 
            // enclosureButton
            // 
            enclosureButton.Location = new Point(793, 377);
            enclosureButton.Name = "enclosureButton";
            enclosureButton.Size = new Size(123, 23);
            enclosureButton.TabIndex = 4;
            enclosureButton.Text = "Show details";
            enclosureButton.UseVisualStyleBackColor = true;
            enclosureButton.Click += enclosureButton_Click;
            // 
            // toolButton
            // 
            toolButton.Location = new Point(793, 584);
            toolButton.Name = "toolButton";
            toolButton.Size = new Size(123, 23);
            toolButton.TabIndex = 5;
            toolButton.Text = "Show details";
            toolButton.UseVisualStyleBackColor = true;
            toolButton.Click += toolButton_Click;
            // 
            // animalCheck
            // 
            animalCheck.AutoSize = true;
            animalCheck.Location = new Point(263, 37);
            animalCheck.Name = "animalCheck";
            animalCheck.Size = new Size(64, 19);
            animalCheck.TabIndex = 7;
            animalCheck.Text = "Animal";
            animalCheck.UseVisualStyleBackColor = true;
            // 
            // enclosureCheck
            // 
            enclosureCheck.AutoSize = true;
            enclosureCheck.Location = new Point(263, 116);
            enclosureCheck.Name = "enclosureCheck";
            enclosureCheck.Size = new Size(77, 19);
            enclosureCheck.TabIndex = 7;
            enclosureCheck.Text = "Enclosure";
            enclosureCheck.UseVisualStyleBackColor = true;
            // 
            // toolCheck
            // 
            toolCheck.AutoSize = true;
            toolCheck.Location = new Point(262, 76);
            toolCheck.Name = "toolCheck";
            toolCheck.Size = new Size(48, 19);
            toolCheck.TabIndex = 7;
            toolCheck.Text = "Tool";
            toolCheck.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(buyButton);
            panel1.Controls.Add(codeText);
            panel1.Controls.Add(cityText);
            panel1.Controls.Add(adres2Text);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(labeladres);
            panel1.Controls.Add(adres1Text);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(toolCheck);
            panel1.Controls.Add(enclosureCheck);
            panel1.Controls.Add(animalCheck);
            panel1.Location = new Point(43, 49);
            panel1.Name = "panel1";
            panel1.Size = new Size(365, 304);
            panel1.TabIndex = 8;
            // 
            // buyButton
            // 
            buyButton.Location = new Point(127, 266);
            buyButton.Name = "buyButton";
            buyButton.Size = new Size(120, 25);
            buyButton.TabIndex = 15;
            buyButton.Text = "Order";
            buyButton.UseVisualStyleBackColor = true;
            buyButton.Click += buyButton_Click;
            // 
            // codeText
            // 
            codeText.Location = new Point(22, 142);
            codeText.Name = "codeText";
            codeText.Size = new Size(136, 23);
            codeText.TabIndex = 14;
            // 
            // cityText
            // 
            cityText.Location = new Point(22, 198);
            cityText.Name = "cityText";
            cityText.Size = new Size(136, 23);
            cityText.TabIndex = 13;
            // 
            // adres2Text
            // 
            adres2Text.Location = new Point(22, 87);
            adres2Text.Name = "adres2Text";
            adres2Text.Size = new Size(136, 23);
            adres2Text.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 124);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 11;
            label4.Text = "Code";
            label4.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 180);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 11;
            label3.Text = "City";
            label3.Click += label2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 69);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 11;
            label2.Text = "Address 2";
            label2.Click += label2_Click;
            // 
            // labeladres
            // 
            labeladres.AutoSize = true;
            labeladres.Location = new Point(22, 19);
            labeladres.Name = "labeladres";
            labeladres.Size = new Size(58, 15);
            labeladres.TabIndex = 11;
            labeladres.Text = "Address 1";
            // 
            // adres1Text
            // 
            adres1Text.Location = new Point(22, 37);
            adres1Text.Name = "adres1Text";
            adres1Text.Size = new Size(136, 23);
            adres1Text.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Location = new Point(170, 0);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 9;
            label1.Text = "Order";
            // 
            // errorLabel
            // 
            errorLabel.AutoEllipsis = true;
            errorLabel.AutoSize = true;
            errorLabel.BackColor = SystemColors.ActiveCaptionText;
            errorLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(104, 438);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 25);
            errorLabel.TabIndex = 9;
            // 
            // register
            // 
            register.Location = new Point(427, 315);
            register.Name = "register";
            register.Size = new Size(105, 38);
            register.TabIndex = 10;
            register.Text = "Register";
            register.UseVisualStyleBackColor = true;
            register.Click += register_Click;
            // 
            // login
            // 
            login.Location = new Point(675, 314);
            login.Name = "login";
            login.Size = new Size(102, 39);
            login.TabIndex = 11;
            login.Text = "Log in";
            login.UseVisualStyleBackColor = true;
            login.Click += login_Click;
            // 
            // petDisplay
            // 
            petDisplay.AllowDrop = true;
            petDisplay.FormattingEnabled = true;
            petDisplay.ItemHeight = 15;
            petDisplay.Location = new Point(43, 454);
            petDisplay.Name = "petDisplay";
            petDisplay.ScrollAlwaysVisible = true;
            petDisplay.Size = new Size(365, 139);
            petDisplay.TabIndex = 2;
            petDisplay.SelectedIndexChanged += hodowlaDisplay_SelectedIndexChanged;
            // 
            // citesText
            // 
            citesText.AutoSize = true;
            citesText.Location = new Point(43, 608);
            citesText.Name = "citesText";
            citesText.Size = new Size(39, 15);
            citesText.TabIndex = 12;
            citesText.Text = "CITES:";
            citesText.Click += citesText_Click;
            // 
            // dangerText
            // 
            dangerText.AutoSize = true;
            dangerText.Location = new Point(43, 638);
            dangerText.Name = "dangerText";
            dangerText.Size = new Size(104, 15);
            dangerText.TabIndex = 12;
            dangerText.Text = "DangerDocument:";
            // 
            // load
            // 
            load.Location = new Point(560, 314);
            load.Name = "load";
            load.Size = new Size(89, 39);
            load.TabIndex = 13;
            load.Text = "Load / Refresh";
            load.UseVisualStyleBackColor = true;
            load.Click += load_Click;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(440, 68);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(65, 15);
            nameLabel.TabIndex = 14;
            nameLabel.Text = "First name:";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(440, 106);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(64, 15);
            lastNameLabel.TabIndex = 14;
            lastNameLabel.Text = "Last name:";
            // 
            // adres1Label
            // 
            adres1Label.AutoSize = true;
            adres1Label.Location = new Point(440, 144);
            adres1Label.Name = "adres1Label";
            adres1Label.Size = new Size(61, 15);
            adres1Label.TabIndex = 15;
            adres1Label.Text = "Address 1:";
            // 
            // adres2Label
            // 
            adres2Label.AutoSize = true;
            adres2Label.Location = new Point(440, 179);
            adres2Label.Name = "adres2Label";
            adres2Label.Size = new Size(61, 15);
            adres2Label.TabIndex = 16;
            adres2Label.Text = "Address 2:";
            // 
            // codeLabel
            // 
            codeLabel.AutoSize = true;
            codeLabel.Location = new Point(440, 214);
            codeLabel.Name = "codeLabel";
            codeLabel.Size = new Size(38, 15);
            codeLabel.TabIndex = 17;
            codeLabel.Text = "Code:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new Point(440, 250);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(31, 15);
            cityLabel.TabIndex = 18;
            cityLabel.Text = "City:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(793, 31);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 19;
            label5.Text = "Animals:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(793, 229);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 19;
            label6.Text = "Enclosures:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(793, 436);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 19;
            label7.Text = "Tools:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(43, 438);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 19;
            label8.Text = "Client's pets:";
            // 
            // hodowlaButton
            // 
            hodowlaButton.Location = new Point(322, 604);
            hodowlaButton.Name = "hodowlaButton";
            hodowlaButton.Size = new Size(86, 23);
            hodowlaButton.TabIndex = 20;
            hodowlaButton.Text = "Show details";
            hodowlaButton.UseVisualStyleBackColor = true;
            hodowlaButton.Click += hodowlaButton_Click;
            // 
            // adminView
            // 
            adminView.Location = new Point(560, 498);
            adminView.Name = "adminView";
            adminView.Size = new Size(111, 36);
            adminView.TabIndex = 21;
            adminView.Text = "Admin view";
            adminView.UseVisualStyleBackColor = true;
            adminView.Click += adminView_Click;
            // 
            // addAnimalButton
            // 
            addAnimalButton.Location = new Point(932, 179);
            addAnimalButton.Name = "addAnimalButton";
            addAnimalButton.Size = new Size(110, 23);
            addAnimalButton.TabIndex = 22;
            addAnimalButton.Text = "Add animal";
            addAnimalButton.UseVisualStyleBackColor = true;
            addAnimalButton.Click += addAnimalButton_Click;
            // 
            // addEnclosureButton
            // 
            addEnclosureButton.Location = new Point(932, 377);
            addEnclosureButton.Name = "addEnclosureButton";
            addEnclosureButton.Size = new Size(110, 23);
            addEnclosureButton.TabIndex = 23;
            addEnclosureButton.Text = "Add enclosure";
            addEnclosureButton.UseVisualStyleBackColor = true;
            addEnclosureButton.Click += addEnclosureButton_Click;
            // 
            // addToolButton
            // 
            addToolButton.Location = new Point(932, 584);
            addToolButton.Name = "addToolButton";
            addToolButton.Size = new Size(110, 23);
            addToolButton.TabIndex = 24;
            addToolButton.Text = "Add tool";
            addToolButton.UseVisualStyleBackColor = true;
            addToolButton.Click += addToolButton_Click;
            // 
            // filterAnimal
            // 
            filterAnimal.Location = new Point(1060, 179);
            filterAnimal.Name = "filterAnimal";
            filterAnimal.Size = new Size(91, 23);
            filterAnimal.TabIndex = 25;
            filterAnimal.Text = "Filter";
            filterAnimal.UseVisualStyleBackColor = true;
            filterAnimal.Click += filterAnimal_Click;
            // 
            // filterEnclosure
            // 
            filterEnclosure.Location = new Point(1060, 377);
            filterEnclosure.Name = "filterEnclosure";
            filterEnclosure.Size = new Size(91, 23);
            filterEnclosure.TabIndex = 26;
            filterEnclosure.Text = "Filter";
            filterEnclosure.UseVisualStyleBackColor = true;
            filterEnclosure.Click += filterEnclosure_Click;
            // 
            // filterTool
            // 
            filterTool.Location = new Point(1060, 585);
            filterTool.Name = "filterTool";
            filterTool.Size = new Size(91, 23);
            filterTool.TabIndex = 27;
            filterTool.Text = "Filter";
            filterTool.UseVisualStyleBackColor = true;
            filterTool.Click += filterTool_Click;
            // 
            // viewClients
            // 
            viewClients.Location = new Point(560, 561);
            viewClients.Name = "viewClients";
            viewClients.Size = new Size(111, 32);
            viewClients.TabIndex = 28;
            viewClients.Text = "View clients";
            viewClients.UseVisualStyleBackColor = true;
            viewClients.Click += viewClients_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1163, 685);
            Controls.Add(viewClients);
            Controls.Add(filterTool);
            Controls.Add(filterEnclosure);
            Controls.Add(filterAnimal);
            Controls.Add(addToolButton);
            Controls.Add(addEnclosureButton);
            Controls.Add(addAnimalButton);
            Controls.Add(adminView);
            Controls.Add(hodowlaButton);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cityLabel);
            Controls.Add(codeLabel);
            Controls.Add(adres2Label);
            Controls.Add(adres1Label);
            Controls.Add(lastNameLabel);
            Controls.Add(nameLabel);
            Controls.Add(load);
            Controls.Add(dangerText);
            Controls.Add(citesText);
            Controls.Add(login);
            Controls.Add(register);
            Controls.Add(errorLabel);
            Controls.Add(panel1);
            Controls.Add(toolButton);
            Controls.Add(enclosureButton);
            Controls.Add(animalButton);
            Controls.Add(toolDisplay);
            Controls.Add(enclosureDisplay);
            Controls.Add(petDisplay);
            Controls.Add(animalDisplay);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox animalDisplay;
        private Button animalButton;
        private ListBox enclosureDisplay;
        private ListBox toolDisplay;
        private Button enclosureButton;
        private Button toolButton;
        private CheckBox animalCheck;
        private CheckBox enclosureCheck;
        private CheckBox toolCheck;
        private Panel panel1;
        private Label label1;
        private TextBox adres1Text;
        private TextBox adres2Text;
        private Label label2;
        private Label labeladres;
        private TextBox cityText;
        private TextBox codeText;
        private Label label4;
        private Label label3;
        private Button buyButton;
        private Label errorLabel;
        private Button register;
        private Button login;
        private ListBox petDisplay;
        private Label citesText;
        private Label dangerText;
        private Button load;
        private Label nameLabel;
        private Label lastNameLabel;
        private Label adres1Label;
        private Label adres2Label;
        private Label codeLabel;
        private Label cityLabel;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button hodowlaButton;
        private Button adminView;
        private Button addAnimalButton;
        private Button addEnclosureButton;
        private Button addToolButton;
        private Button filterAnimal;
        private Button filterEnclosure;
        private Button filterTool;
        private Button viewClients;
    }
}
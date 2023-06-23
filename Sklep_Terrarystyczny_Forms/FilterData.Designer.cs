namespace Sklep_Terrarystyczny_Forms
{
    partial class FilterData
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
            filterButton = new Button();
            filterCombo = new ComboBox();
            filterText = new TextBox();
            filterLabel = new Label();
            typeCombo = new ComboBox();
            SuspendLayout();
            // 
            // filterButton
            // 
            filterButton.Location = new Point(211, 230);
            filterButton.Name = "filterButton";
            filterButton.Size = new Size(137, 40);
            filterButton.TabIndex = 0;
            filterButton.Text = "Filter";
            filterButton.UseVisualStyleBackColor = true;
            filterButton.Click += filterButton_Click;
            // 
            // filterCombo
            // 
            filterCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            filterCombo.FormattingEnabled = true;
            filterCombo.Location = new Point(24, 127);
            filterCombo.Name = "filterCombo";
            filterCombo.Size = new Size(201, 23);
            filterCombo.TabIndex = 1;
            filterCombo.SelectedIndexChanged += filterCombo_SelectedIndexChanged;
            // 
            // filterText
            // 
            filterText.Location = new Point(346, 127);
            filterText.Name = "filterText";
            filterText.Size = new Size(196, 23);
            filterText.TabIndex = 2;
            // 
            // filterLabel
            // 
            filterLabel.AutoSize = true;
            filterLabel.Location = new Point(261, 61);
            filterLabel.Name = "filterLabel";
            filterLabel.Size = new Size(38, 15);
            filterLabel.TabIndex = 3;
            filterLabel.Text = "label1";
            // 
            // typeCombo
            // 
            typeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            typeCombo.FormattingEnabled = true;
            typeCombo.Location = new Point(346, 156);
            typeCombo.Name = "typeCombo";
            typeCombo.Size = new Size(196, 23);
            typeCombo.TabIndex = 4;
            // 
            // FilterData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 329);
            Controls.Add(typeCombo);
            Controls.Add(filterLabel);
            Controls.Add(filterText);
            Controls.Add(filterCombo);
            Controls.Add(filterButton);
            Name = "FilterData";
            Text = "FilterData";
            Load += FilterData_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button filterButton;
        private ComboBox filterCombo;
        private TextBox filterText;
        private Label filterLabel;
        private ComboBox typeCombo;
    }
}
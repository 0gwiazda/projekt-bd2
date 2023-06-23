namespace Sklep_Terrarystyczny_Forms
{
    partial class SuccessError
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
            button1 = new Button();
            messageLabel = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(158, 258);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // messageLabel
            // 
            messageLabel.Dock = DockStyle.Top;
            messageLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            messageLabel.Location = new Point(0, 0);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(404, 255);
            messageLabel.TabIndex = 1;
            messageLabel.Text = "label1";
            messageLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SuccessError
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 293);
            Controls.Add(messageLabel);
            Controls.Add(button1);
            Name = "SuccessError";
            Text = "SuccessError";
            Load += SuccessError_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label messageLabel;
    }
}
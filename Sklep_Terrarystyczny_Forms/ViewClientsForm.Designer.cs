namespace Sklep_Terrarystyczny_Forms
{
    partial class ViewClientsForm
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
            clientDisplay = new ListBox();
            orderDisplay = new ListBox();
            detailsClient = new Button();
            detailsOrder = new Button();
            label1 = new Label();
            label2 = new Label();
            closeButton = new Button();
            filterAddress = new Button();
            filterEmails = new Button();
            loadButton = new Button();
            SuspendLayout();
            // 
            // clientDisplay
            // 
            clientDisplay.FormattingEnabled = true;
            clientDisplay.ItemHeight = 15;
            clientDisplay.Location = new Point(45, 60);
            clientDisplay.Name = "clientDisplay";
            clientDisplay.Size = new Size(288, 124);
            clientDisplay.TabIndex = 0;
            clientDisplay.SelectedIndexChanged += clientDisplay_SelectedIndexChanged;
            // 
            // orderDisplay
            // 
            orderDisplay.FormattingEnabled = true;
            orderDisplay.ItemHeight = 15;
            orderDisplay.Location = new Point(417, 60);
            orderDisplay.Name = "orderDisplay";
            orderDisplay.Size = new Size(393, 124);
            orderDisplay.TabIndex = 1;
            // 
            // detailsClient
            // 
            detailsClient.Location = new Point(240, 190);
            detailsClient.Name = "detailsClient";
            detailsClient.Size = new Size(93, 40);
            detailsClient.TabIndex = 2;
            detailsClient.Text = "Show details";
            detailsClient.UseVisualStyleBackColor = true;
            detailsClient.Click += detailsClient_Click;
            // 
            // detailsOrder
            // 
            detailsOrder.Location = new Point(728, 190);
            detailsOrder.Name = "detailsOrder";
            detailsOrder.Size = new Size(82, 40);
            detailsOrder.TabIndex = 3;
            detailsOrder.Text = "Show details";
            detailsOrder.UseVisualStyleBackColor = true;
            detailsOrder.Click += detailsOrder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 42);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 4;
            label1.Text = "Clients:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(417, 42);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 5;
            label2.Text = "Orders:";
            // 
            // closeButton
            // 
            closeButton.Location = new Point(374, 294);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(97, 34);
            closeButton.TabIndex = 6;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // filterAddress
            // 
            filterAddress.Location = new Point(45, 190);
            filterAddress.Name = "filterAddress";
            filterAddress.Size = new Size(84, 40);
            filterAddress.TabIndex = 7;
            filterAddress.Text = "Filter by Address";
            filterAddress.UseVisualStyleBackColor = true;
            filterAddress.Click += filterAddress_Click;
            // 
            // filterEmails
            // 
            filterEmails.Location = new Point(146, 190);
            filterEmails.Name = "filterEmails";
            filterEmails.Size = new Size(77, 40);
            filterEmails.TabIndex = 8;
            filterEmails.Text = "Filter by Email";
            filterEmails.UseVisualStyleBackColor = true;
            filterEmails.Click += filterEmails_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(146, 270);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(77, 39);
            loadButton.TabIndex = 12;
            loadButton.Text = "Load / Refresh";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // ViewClientsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 340);
            Controls.Add(loadButton);
            Controls.Add(filterEmails);
            Controls.Add(filterAddress);
            Controls.Add(closeButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(detailsOrder);
            Controls.Add(detailsClient);
            Controls.Add(orderDisplay);
            Controls.Add(clientDisplay);
            Name = "ViewClientsForm";
            Text = "ViewClientsForm";
            Load += ViewClientsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox clientDisplay;
        private ListBox orderDisplay;
        private Button detailsClient;
        private Button detailsOrder;
        private Label label1;
        private Label label2;
        private Button closeButton;
        private Button filterAddress;
        private Button filterEmails;
        private Button loadButton;
    }
}
namespace LTDesigns
{
    partial class Main
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
            this.btnAddClients = new System.Windows.Forms.Button();
            this.btnViewClients = new System.Windows.Forms.Button();
            this.btnAddJobs = new System.Windows.Forms.Button();
            this.btnViewJobs = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSalesData = new System.Windows.Forms.Button();
            this.btnContracts = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddClients
            // 
            this.btnAddClients.Location = new System.Drawing.Point(12, 12);
            this.btnAddClients.Name = "btnAddClients";
            this.btnAddClients.Size = new System.Drawing.Size(75, 23);
            this.btnAddClients.TabIndex = 0;
            this.btnAddClients.Text = "&Add Clients";
            this.btnAddClients.UseVisualStyleBackColor = true;
            this.btnAddClients.Click += new System.EventHandler(this.btnAddClients_Click);
            // 
            // btnViewClients
            // 
            this.btnViewClients.Location = new System.Drawing.Point(93, 12);
            this.btnViewClients.Name = "btnViewClients";
            this.btnViewClients.Size = new System.Drawing.Size(75, 23);
            this.btnViewClients.TabIndex = 1;
            this.btnViewClients.Text = "&View Clients";
            this.btnViewClients.UseVisualStyleBackColor = true;
            this.btnViewClients.Click += new System.EventHandler(this.btnViewClients_Click);
            // 
            // btnAddJobs
            // 
            this.btnAddJobs.Location = new System.Drawing.Point(174, 12);
            this.btnAddJobs.Name = "btnAddJobs";
            this.btnAddJobs.Size = new System.Drawing.Size(75, 23);
            this.btnAddJobs.TabIndex = 2;
            this.btnAddJobs.Text = "&Add Jobs";
            this.btnAddJobs.UseVisualStyleBackColor = true;
            this.btnAddJobs.Click += new System.EventHandler(this.btnAddJobs_Click);
            // 
            // btnViewJobs
            // 
            this.btnViewJobs.Location = new System.Drawing.Point(255, 12);
            this.btnViewJobs.Name = "btnViewJobs";
            this.btnViewJobs.Size = new System.Drawing.Size(75, 23);
            this.btnViewJobs.TabIndex = 3;
            this.btnViewJobs.Text = "&View Jobs";
            this.btnViewJobs.UseVisualStyleBackColor = true;
            this.btnViewJobs.Click += new System.EventHandler(this.btnViewJobs_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(255, 41);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 7;
            this.btnQuit.Text = "&Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // btnSalesData
            // 
            this.btnSalesData.Location = new System.Drawing.Point(174, 41);
            this.btnSalesData.Name = "btnSalesData";
            this.btnSalesData.Size = new System.Drawing.Size(75, 23);
            this.btnSalesData.TabIndex = 6;
            this.btnSalesData.Text = "&Sales Data";
            this.btnSalesData.UseVisualStyleBackColor = true;
            this.btnSalesData.Click += new System.EventHandler(this.btnSalesData_Click);
            // 
            // btnContracts
            // 
            this.btnContracts.Location = new System.Drawing.Point(12, 41);
            this.btnContracts.Name = "btnContracts";
            this.btnContracts.Size = new System.Drawing.Size(75, 23);
            this.btnContracts.TabIndex = 4;
            this.btnContracts.Text = "&Contracts";
            this.btnContracts.UseVisualStyleBackColor = true;
            this.btnContracts.Click += new System.EventHandler(this.btnContracts_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Location = new System.Drawing.Point(93, 41);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnInvoice.TabIndex = 5;
            this.btnInvoice.Text = "&Invoices";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 71);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnContracts);
            this.Controls.Add(this.btnSalesData);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnViewJobs);
            this.Controls.Add(this.btnAddJobs);
            this.Controls.Add(this.btnViewClients);
            this.Controls.Add(this.btnAddClients);
            this.Name = "Main";
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddClients;
        private System.Windows.Forms.Button btnViewClients;
        private System.Windows.Forms.Button btnAddJobs;
        private System.Windows.Forms.Button btnViewJobs;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSalesData;
        private System.Windows.Forms.Button btnContracts;
        private System.Windows.Forms.Button btnInvoice;
    }
}
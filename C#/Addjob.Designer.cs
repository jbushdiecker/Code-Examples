namespace LTDesigns
{
    partial class Addjob
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
            this.lbJob = new System.Windows.Forms.Label();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.lbInvoice = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lbClient = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lbEngineering = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.NumericUpDown();
            this.txtEngineering = new System.Windows.Forms.NumericUpDown();
            this.txtInvoiceNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngineering)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // lbJob
            // 
            this.lbJob.AutoSize = true;
            this.lbJob.Location = new System.Drawing.Point(39, 13);
            this.lbJob.Name = "lbJob";
            this.lbJob.Size = new System.Drawing.Size(58, 13);
            this.lbJob.TabIndex = 0;
            this.lbJob.Text = "&Job Name:";
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(103, 10);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(100, 20);
            this.txtJobName.TabIndex = 1;
            // 
            // lbInvoice
            // 
            this.lbInvoice.AutoSize = true;
            this.lbInvoice.Location = new System.Drawing.Point(12, 66);
            this.lbInvoice.Name = "lbInvoice";
            this.lbInvoice.Size = new System.Drawing.Size(85, 13);
            this.lbInvoice.TabIndex = 2;
            this.lbInvoice.Text = "&Invoice Number:";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(63, 92);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(34, 13);
            this.lbPrice.TabIndex = 5;
            this.lbPrice.Text = "&Price:";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(103, 141);
            this.txtDate.Mask = "00/00/0000";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 6;
            this.txtDate.ValidatingType = typeof(System.DateTime);
            this.txtDate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtDate_MouseClick);
            this.txtDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtDate_Validating);
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(64, 144);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(33, 13);
            this.lbDate.TabIndex = 7;
            this.lbDate.Text = "&Date:";
            this.lbDate.Click += new System.EventHandler(this.label4_Click);
            // 
            // cbClient
            // 
            this.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClient.DropDownWidth = 125;
            this.cbClient.Location = new System.Drawing.Point(103, 36);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(100, 21);
            this.cbClient.TabIndex = 2;
            // 
            // lbClient
            // 
            this.lbClient.AutoSize = true;
            this.lbClient.Location = new System.Drawing.Point(61, 39);
            this.lbClient.Name = "lbClient";
            this.lbClient.Size = new System.Drawing.Size(36, 13);
            this.lbClient.TabIndex = 9;
            this.lbClient.Text = "&Client:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(128, 170);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(42, 170);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 11;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "&Close";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lbEngineering
            // 
            this.lbEngineering.AutoSize = true;
            this.lbEngineering.Location = new System.Drawing.Point(31, 118);
            this.lbEngineering.Name = "lbEngineering";
            this.lbEngineering.Size = new System.Drawing.Size(66, 13);
            this.lbEngineering.TabIndex = 29;
            this.lbEngineering.Text = "&Engineering:";
            // 
            // txtPrice
            // 
            this.txtPrice.DecimalPlaces = 2;
            this.txtPrice.Location = new System.Drawing.Point(103, 90);
            this.txtPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 4;
            // 
            // txtEngineering
            // 
            this.txtEngineering.DecimalPlaces = 2;
            this.txtEngineering.Location = new System.Drawing.Point(103, 115);
            this.txtEngineering.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtEngineering.Name = "txtEngineering";
            this.txtEngineering.Size = new System.Drawing.Size(100, 20);
            this.txtEngineering.TabIndex = 5;
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(103, 64);
            this.txtInvoiceNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(100, 20);
            this.txtInvoiceNumber.TabIndex = 3;
            // 
            // Addjob
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 199);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.txtEngineering);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lbEngineering);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbClient);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbInvoice);
            this.Controls.Add(this.txtJobName);
            this.Controls.Add(this.lbJob);
            this.Name = "Addjob";
            this.Text = "Add Job";
            this.Load += new System.EventHandler(this.Addjob_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngineering)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbJob;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label lbInvoice;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label lbClient;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lbEngineering;
        private System.Windows.Forms.NumericUpDown txtPrice;
        private System.Windows.Forms.NumericUpDown txtEngineering;
        private System.Windows.Forms.NumericUpDown txtInvoiceNumber;
    }
}
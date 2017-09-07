namespace LTDesigns
{
    partial class ViewJob
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbClient = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbInvoice = new System.Windows.Forms.Label();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.lbJob = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.MaskedTextBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lbRemainingBal = new System.Windows.Forms.Label();
            this.lbEngineering = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.NumericUpDown();
            this.txtEngineering = new System.Windows.Forms.NumericUpDown();
            this.txtRemainingBal = new System.Windows.Forms.NumericUpDown();
            this.txtInvoiceNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngineering)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingBal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(203, 331);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // lbClient
            // 
            this.lbClient.AutoSize = true;
            this.lbClient.Location = new System.Drawing.Point(287, 41);
            this.lbClient.Name = "lbClient";
            this.lbClient.Size = new System.Drawing.Size(36, 13);
            this.lbClient.TabIndex = 21;
            this.lbClient.Text = "&Client:";
            // 
            // cbClient
            // 
            this.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClient.DropDownWidth = 125;
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(329, 38);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(100, 21);
            this.cbClient.TabIndex = 14;
            this.cbClient.TextUpdate += new System.EventHandler(this.cbClient_TextUpdate);
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(289, 94);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(34, 13);
            this.lbPrice.TabIndex = 17;
            this.lbPrice.Text = "&Price:";
            // 
            // lbInvoice
            // 
            this.lbInvoice.AutoSize = true;
            this.lbInvoice.Location = new System.Drawing.Point(238, 68);
            this.lbInvoice.Name = "lbInvoice";
            this.lbInvoice.Size = new System.Drawing.Size(85, 13);
            this.lbInvoice.TabIndex = 14;
            this.lbInvoice.Text = "&Invoice Number:";
            // 
            // txtJobName
            // 
            this.txtJobName.Location = new System.Drawing.Point(329, 12);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(100, 20);
            this.txtJobName.TabIndex = 13;
            this.txtJobName.TextChanged += new System.EventHandler(this.txtJobName_TextChanged);
            // 
            // lbJob
            // 
            this.lbJob.AutoSize = true;
            this.lbJob.Location = new System.Drawing.Point(265, 15);
            this.lbJob.Name = "lbJob";
            this.lbJob.Size = new System.Drawing.Size(58, 13);
            this.lbJob.TabIndex = 12;
            this.lbJob.Text = "&Job Name:";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(329, 169);
            this.txtDate.Mask = "00/00/0000";
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 19;
            this.txtDate.ValidatingType = typeof(System.DateTime);
            this.txtDate.TextChanged += new System.EventHandler(this.txtDate_TextChanged);
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Location = new System.Drawing.Point(290, 172);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(33, 13);
            this.lbDate.TabIndex = 19;
            this.lbDate.Text = "&Date:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(354, 198);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(268, 198);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 23;
            this.btnQuit.TabStop = false;
            this.btnQuit.Text = "&Close";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lbRemainingBal
            // 
            this.lbRemainingBal.AutoSize = true;
            this.lbRemainingBal.Location = new System.Drawing.Point(221, 146);
            this.lbRemainingBal.Name = "lbRemainingBal";
            this.lbRemainingBal.Size = new System.Drawing.Size(102, 13);
            this.lbRemainingBal.TabIndex = 25;
            this.lbRemainingBal.Text = "&Remaining Balance:";
            // 
            // lbEngineering
            // 
            this.lbEngineering.AutoSize = true;
            this.lbEngineering.Location = new System.Drawing.Point(257, 120);
            this.lbEngineering.Name = "lbEngineering";
            this.lbEngineering.Size = new System.Drawing.Size(66, 13);
            this.lbEngineering.TabIndex = 27;
            this.lbEngineering.Text = "&Engineering:";
            // 
            // txtPrice
            // 
            this.txtPrice.DecimalPlaces = 2;
            this.txtPrice.Location = new System.Drawing.Point(329, 91);
            this.txtPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 16;
            this.txtPrice.ValueChanged += new System.EventHandler(this.txtPrice_ValueChanged);
            // 
            // txtEngineering
            // 
            this.txtEngineering.DecimalPlaces = 2;
            this.txtEngineering.Location = new System.Drawing.Point(329, 117);
            this.txtEngineering.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtEngineering.Name = "txtEngineering";
            this.txtEngineering.Size = new System.Drawing.Size(100, 20);
            this.txtEngineering.TabIndex = 17;
            this.txtEngineering.ValueChanged += new System.EventHandler(this.txtEngineering_ValueChanged);
            // 
            // txtRemainingBal
            // 
            this.txtRemainingBal.DecimalPlaces = 2;
            this.txtRemainingBal.Location = new System.Drawing.Point(329, 144);
            this.txtRemainingBal.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtRemainingBal.Name = "txtRemainingBal";
            this.txtRemainingBal.Size = new System.Drawing.Size(100, 20);
            this.txtRemainingBal.TabIndex = 18;
            this.txtRemainingBal.ValueChanged += new System.EventHandler(this.txtRemainingBal_ValueChanged);
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(329, 66);
            this.txtInvoiceNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(100, 20);
            this.txtInvoiceNumber.TabIndex = 15;
            this.txtInvoiceNumber.ValueChanged += new System.EventHandler(this.txtInvoiceNumber_ValueChanged);
            // 
            // ViewJob
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 350);
            this.Controls.Add(this.txtInvoiceNumber);
            this.Controls.Add(this.txtRemainingBal);
            this.Controls.Add(this.txtEngineering);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lbEngineering);
            this.Controls.Add(this.lbRemainingBal);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lbClient);
            this.Controls.Add(this.cbClient);
            this.Controls.Add(this.lbDate);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbInvoice);
            this.Controls.Add(this.txtJobName);
            this.Controls.Add(this.lbJob);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ViewJob";
            this.Text = "View Job";
            this.Load += new System.EventHandler(this.ViewJob_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEngineering)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemainingBal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoiceNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbClient;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbInvoice;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label lbJob;
        private System.Windows.Forms.MaskedTextBox txtDate;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lbRemainingBal;
        private System.Windows.Forms.Label lbEngineering;
        private System.Windows.Forms.NumericUpDown txtPrice;
        private System.Windows.Forms.NumericUpDown txtEngineering;
        private System.Windows.Forms.NumericUpDown txtRemainingBal;
        private System.Windows.Forms.NumericUpDown txtInvoiceNumber;
    }
}
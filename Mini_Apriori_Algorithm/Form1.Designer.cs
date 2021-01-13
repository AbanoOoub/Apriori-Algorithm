namespace Mini_Apriori_Algorithm
{
    partial class Form1
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
            this.Data_GV = new System.Windows.Forms.DataGridView();
            this.TID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Run_btn = new System.Windows.Forms.Button();
            this.MinCon_txtbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MinSup_txtbx = new System.Windows.Forms.TextBox();
            this.StrongRules_grid = new System.Windows.Forms.DataGridView();
            this.StrongRules_col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rule_Confidence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Data_GV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrongRules_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // Data_GV
            // 
            this.Data_GV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data_GV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TID,
            this.Trans});
            this.Data_GV.Location = new System.Drawing.Point(12, 12);
            this.Data_GV.Name = "Data_GV";
            this.Data_GV.RowHeadersWidth = 51;
            this.Data_GV.RowTemplate.Height = 26;
            this.Data_GV.Size = new System.Drawing.Size(323, 486);
            this.Data_GV.TabIndex = 0;
            // 
            // TID
            // 
            this.TID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TID.HeaderText = "TID";
            this.TID.MinimumWidth = 6;
            this.TID.Name = "TID";
            // 
            // Trans
            // 
            this.Trans.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Trans.HeaderText = "Trans";
            this.Trans.MinimumWidth = 6;
            this.Trans.Name = "Trans";
            // 
            // Run_btn
            // 
            this.Run_btn.Location = new System.Drawing.Point(235, 504);
            this.Run_btn.Name = "Run_btn";
            this.Run_btn.Size = new System.Drawing.Size(100, 49);
            this.Run_btn.TabIndex = 2;
            this.Run_btn.Text = "Run";
            this.Run_btn.UseVisualStyleBackColor = true;
            this.Run_btn.Click += new System.EventHandler(this.Run_btn_Click);
            // 
            // MinCon_txtbx
            // 
            this.MinCon_txtbx.Location = new System.Drawing.Point(152, 529);
            this.MinCon_txtbx.Name = "MinCon_txtbx";
            this.MinCon_txtbx.Size = new System.Drawing.Size(77, 24);
            this.MinCon_txtbx.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 507);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Minimum Support";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 532);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Minimum Confidence";
            // 
            // MinSup_txtbx
            // 
            this.MinSup_txtbx.Location = new System.Drawing.Point(152, 504);
            this.MinSup_txtbx.Name = "MinSup_txtbx";
            this.MinSup_txtbx.Size = new System.Drawing.Size(77, 24);
            this.MinSup_txtbx.TabIndex = 7;
            // 
            // StrongRules_grid
            // 
            this.StrongRules_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StrongRules_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StrongRules_col,
            this.Rule_Confidence});
            this.StrongRules_grid.Location = new System.Drawing.Point(351, 12);
            this.StrongRules_grid.Name = "StrongRules_grid";
            this.StrongRules_grid.RowHeadersWidth = 51;
            this.StrongRules_grid.RowTemplate.Height = 26;
            this.StrongRules_grid.Size = new System.Drawing.Size(424, 541);
            this.StrongRules_grid.TabIndex = 8;
            // 
            // StrongRules_col
            // 
            this.StrongRules_col.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StrongRules_col.HeaderText = "StrongRules";
            this.StrongRules_col.MinimumWidth = 6;
            this.StrongRules_col.Name = "StrongRules_col";
            this.StrongRules_col.ReadOnly = true;
            // 
            // Rule_Confidence
            // 
            this.Rule_Confidence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rule_Confidence.HeaderText = "Rule Confidence";
            this.Rule_Confidence.MinimumWidth = 6;
            this.Rule_Confidence.Name = "Rule_Confidence";
            this.Rule_Confidence.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 558);
            this.Controls.Add(this.StrongRules_grid);
            this.Controls.Add(this.MinSup_txtbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MinCon_txtbx);
            this.Controls.Add(this.Run_btn);
            this.Controls.Add(this.Data_GV);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Data_GV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrongRules_grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Data_GV;
        private System.Windows.Forms.Button Run_btn;
        private System.Windows.Forms.TextBox MinCon_txtbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MinSup_txtbx;
        private System.Windows.Forms.DataGridViewTextBoxColumn TID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trans;
        private System.Windows.Forms.DataGridView StrongRules_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn StrongRules_col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rule_Confidence;
    }
}


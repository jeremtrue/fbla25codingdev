namespace FinancingAppForms
{
    partial class formSpending
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
            this.panelDataGridView = new System.Windows.Forms.Panel();
            this.addbutt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(44)))), ((int)(((byte)(70)))));
            this.panelDataGridView.Location = new System.Drawing.Point(486, 23);
            this.panelDataGridView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(1068, 844);
            this.panelDataGridView.TabIndex = 9;
            this.panelDataGridView.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDataGridView_Paint);
            // 
            // addbutt
            // 
            this.addbutt.Location = new System.Drawing.Point(223, 140);
            this.addbutt.Name = "addbutt";
            this.addbutt.Size = new System.Drawing.Size(102, 46);
            this.addbutt.TabIndex = 10;
            this.addbutt.Text = "Add Purchase";
            this.addbutt.UseVisualStyleBackColor = true;
            this.addbutt.Click += new System.EventHandler(this.addbutt_Click);
            // 
            // formSpending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1578, 890);
            this.Controls.Add(this.addbutt);
            this.Controls.Add(this.panelDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "formSpending";
            this.Text = "formSpending";
            this.Load += new System.EventHandler(this.formSpending_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDataGridView;
        private System.Windows.Forms.Button addbutt;
    }
}
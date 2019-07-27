namespace AutoBaccarat
{
    partial class frmResultImageTester
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
            this.dgvCurrentResultImg = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentResultImg)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCurrentResultImg
            // 
            this.dgvCurrentResultImg.AllowUserToAddRows = false;
            this.dgvCurrentResultImg.AllowUserToDeleteRows = false;
            this.dgvCurrentResultImg.AllowUserToResizeColumns = false;
            this.dgvCurrentResultImg.AllowUserToResizeRows = false;
            this.dgvCurrentResultImg.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvCurrentResultImg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCurrentResultImg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentResultImg.ColumnHeadersVisible = false;
            this.dgvCurrentResultImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCurrentResultImg.Enabled = false;
            this.dgvCurrentResultImg.GridColor = System.Drawing.Color.DarkGray;
            this.dgvCurrentResultImg.Location = new System.Drawing.Point(0, 0);
            this.dgvCurrentResultImg.Name = "dgvCurrentResultImg";
            this.dgvCurrentResultImg.ReadOnly = true;
            this.dgvCurrentResultImg.RowHeadersVisible = false;
            this.dgvCurrentResultImg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCurrentResultImg.Size = new System.Drawing.Size(505, 240);
            this.dgvCurrentResultImg.TabIndex = 0;
            // 
            // frmResultImageTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 240);
            this.Controls.Add(this.dgvCurrentResultImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResultImageTester";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentResultImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCurrentResultImg;
    }
}
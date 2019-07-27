namespace AutoBaccarat
{
    partial class FrmDisplay
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
            this.tFiveTheme1 = new TFive.TFiveTheme();
            this.btCancel = new TFive.TFiveButton();
            this.btOK = new TFive.TFiveButton();
            this.lbValue = new TFive.TFiveLabel();
            this.tFiveTheme1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tFiveTheme1
            // 
            this.tFiveTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tFiveTheme1.Border = true;
            this.tFiveTheme1.Border2 = true;
            this.tFiveTheme1.ChangeText = false;
            this.tFiveTheme1.Controls.Add(this.btCancel);
            this.tFiveTheme1.Controls.Add(this.btOK);
            this.tFiveTheme1.Controls.Add(this.lbValue);
            this.tFiveTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFiveTheme1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tFiveTheme1.Location = new System.Drawing.Point(0, 0);
            this.tFiveTheme1.Name = "tFiveTheme1";
            this.tFiveTheme1.Padding = new System.Windows.Forms.Padding(20, 56, 20, 20);
            this.tFiveTheme1.RoundCorners = false;
            this.tFiveTheme1.ShowText = true;
            this.tFiveTheme1.Sizable = true;
            this.tFiveTheme1.Size = new System.Drawing.Size(275, 305);
            this.tFiveTheme1.SmartBounds = true;
            this.tFiveTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tFiveTheme1.TabControl = false;
            this.tFiveTheme1.TabIndex = 0;
            this.tFiveTheme1.Text = "Bet Settings";
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btCancel.Image = null;
            this.btCancel.Location = new System.Drawing.Point(142, 259);
            this.btCancel.Name = "btCancel";
            this.btCancel.NoRounding = false;
            this.btCancel.Size = new System.Drawing.Size(110, 23);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btOK.Image = null;
            this.btOK.Location = new System.Drawing.Point(23, 259);
            this.btOK.Name = "btOK";
            this.btOK.NoRounding = false;
            this.btOK.Size = new System.Drawing.Size(110, 23);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.BtOK_Click);
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.BackColor = System.Drawing.Color.Transparent;
            this.lbValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.lbValue.Location = new System.Drawing.Point(20, 56);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(180, 200);
            this.lbValue.TabIndex = 1;
            this.lbValue.Text = "Layout: \rMode: \r\nFormula: \r\nBetting System: \r\nBet Price \r\nStop at Round \r\nStop If" +
    " Wining at  Rounds\r\nStop If Lossing at  Rounds\r\nStop If Less Money \r\nStop If Mor" +
    "e Money ";
            // 
            // FrmDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 305);
            this.Controls.Add(this.tFiveTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "FrmDisplay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Display";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.FrmDisplay_Load);
            this.tFiveTheme1.ResumeLayout(false);
            this.tFiveTheme1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TFive.TFiveTheme tFiveTheme1;
        private TFive.TFiveLabel lbValue;
        private TFive.TFiveButton btCancel;
        private TFive.TFiveButton btOK;
    }
}
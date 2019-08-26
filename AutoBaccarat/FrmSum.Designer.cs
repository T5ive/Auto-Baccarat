namespace AutoBaccarat
{
    partial class FrmSum
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.king99GroupBox2 = new AutoBaccarat.King99GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvBigRoad = new System.Windows.Forms.DataGridView();
            this.DataScore = new Bunifu.DataViz.WinForms.BunifuDataViz();
            this.king99GroupBox4 = new AutoBaccarat.King99GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvWL = new System.Windows.Forms.DataGridView();
            this.DataWinLose = new Bunifu.DataViz.WinForms.BunifuDataViz();
            this.king99GroupBox3 = new AutoBaccarat.King99GroupBox();
            this.DataBalance = new Bunifu.DataViz.WinForms.BunifuDataViz();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.king99GroupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBigRoad)).BeginInit();
            this.king99GroupBox4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWL)).BeginInit();
            this.king99GroupBox3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.king99GroupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.king99GroupBox4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(728, 299);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // king99GroupBox2
            // 
            this.king99GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.king99GroupBox2.BgColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.king99GroupBox2.Controls.Add(this.tableLayoutPanel2);
            this.king99GroupBox2.Curv1 = 1;
            this.king99GroupBox2.Curv2 = 1;
            this.king99GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.king99GroupBox2.Font = new System.Drawing.Font("Kanit", 11F);
            this.king99GroupBox2.Location = new System.Drawing.Point(3, 3);
            this.king99GroupBox2.MinimumSize = new System.Drawing.Size(136, 50);
            this.king99GroupBox2.Name = "king99GroupBox2";
            this.king99GroupBox2.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.king99GroupBox2.Size = new System.Drawing.Size(358, 293);
            this.king99GroupBox2.TabIndex = 1;
            this.king99GroupBox2.Text = "Score Board";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgvBigRoad, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DataScore, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(348, 260);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvBigRoad
            // 
            this.dgvBigRoad.AllowUserToAddRows = false;
            this.dgvBigRoad.AllowUserToDeleteRows = false;
            this.dgvBigRoad.AllowUserToResizeColumns = false;
            this.dgvBigRoad.AllowUserToResizeRows = false;
            this.dgvBigRoad.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBigRoad.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBigRoad.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.dgvBigRoad.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvBigRoad.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBigRoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBigRoad.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Kanit", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBigRoad.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBigRoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBigRoad.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.dgvBigRoad.Location = new System.Drawing.Point(3, 3);
            this.dgvBigRoad.Name = "dgvBigRoad";
            this.dgvBigRoad.ReadOnly = true;
            this.dgvBigRoad.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBigRoad.RowHeadersVisible = false;
            this.dgvBigRoad.Size = new System.Drawing.Size(342, 72);
            this.dgvBigRoad.TabIndex = 44;
            this.dgvBigRoad.SelectionChanged += new System.EventHandler(this.DgvBigRoad_SelectionChanged);
            // 
            // DataScore
            // 
            this.DataScore.animationEnabled = false;
            this.DataScore.AxisLineColor = System.Drawing.Color.LightGray;
            this.DataScore.AxisXFontColor = System.Drawing.Color.Black;
            this.DataScore.AxisXGridColor = System.Drawing.Color.Gray;
            this.DataScore.AxisXGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataScore.AxisYFontColor = System.Drawing.Color.Black;
            this.DataScore.AxisYGridColor = System.Drawing.Color.Gray;
            this.DataScore.AxisYGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataScore.BackColor = System.Drawing.Color.White;
            this.DataScore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DataScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataScore.Location = new System.Drawing.Point(3, 81);
            this.DataScore.Name = "DataScore";
            this.DataScore.Size = new System.Drawing.Size(342, 176);
            this.DataScore.TabIndex = 45;
            this.DataScore.Theme = Bunifu.DataViz.WinForms.BunifuDataViz._theme.theme1;
            this.DataScore.Title = "";
            // 
            // king99GroupBox4
            // 
            this.king99GroupBox4.BackColor = System.Drawing.Color.Transparent;
            this.king99GroupBox4.BgColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.king99GroupBox4.Controls.Add(this.tableLayoutPanel3);
            this.king99GroupBox4.Curv1 = 1;
            this.king99GroupBox4.Curv2 = 1;
            this.king99GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.king99GroupBox4.Font = new System.Drawing.Font("Kanit", 11F);
            this.king99GroupBox4.Location = new System.Drawing.Point(367, 3);
            this.king99GroupBox4.MinimumSize = new System.Drawing.Size(136, 50);
            this.king99GroupBox4.Name = "king99GroupBox4";
            this.king99GroupBox4.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.king99GroupBox4.Size = new System.Drawing.Size(358, 293);
            this.king99GroupBox4.TabIndex = 2;
            this.king99GroupBox4.Text = "Win/Lose";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dgvWL, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.DataWinLose, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(5, 28);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(348, 260);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dgvWL
            // 
            this.dgvWL.AllowUserToAddRows = false;
            this.dgvWL.AllowUserToDeleteRows = false;
            this.dgvWL.AllowUserToResizeColumns = false;
            this.dgvWL.AllowUserToResizeRows = false;
            this.dgvWL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvWL.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvWL.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.dgvWL.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvWL.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvWL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWL.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Kanit", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWL.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWL.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.dgvWL.Location = new System.Drawing.Point(3, 3);
            this.dgvWL.Name = "dgvWL";
            this.dgvWL.ReadOnly = true;
            this.dgvWL.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvWL.RowHeadersVisible = false;
            this.dgvWL.Size = new System.Drawing.Size(342, 72);
            this.dgvWL.TabIndex = 44;
            this.dgvWL.SelectionChanged += new System.EventHandler(this.DgvWL_SelectionChanged);
            // 
            // DataWinLose
            // 
            this.DataWinLose.animationEnabled = false;
            this.DataWinLose.AxisLineColor = System.Drawing.Color.LightGray;
            this.DataWinLose.AxisXFontColor = System.Drawing.Color.Black;
            this.DataWinLose.AxisXGridColor = System.Drawing.Color.Gray;
            this.DataWinLose.AxisXGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataWinLose.AxisYFontColor = System.Drawing.Color.Black;
            this.DataWinLose.AxisYGridColor = System.Drawing.Color.Gray;
            this.DataWinLose.AxisYGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataWinLose.BackColor = System.Drawing.Color.White;
            this.DataWinLose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DataWinLose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataWinLose.Location = new System.Drawing.Point(3, 81);
            this.DataWinLose.Name = "DataWinLose";
            this.DataWinLose.Size = new System.Drawing.Size(342, 176);
            this.DataWinLose.TabIndex = 45;
            this.DataWinLose.Theme = Bunifu.DataViz.WinForms.BunifuDataViz._theme.theme1;
            this.DataWinLose.Title = "";
            // 
            // king99GroupBox3
            // 
            this.king99GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.king99GroupBox3.BgColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.king99GroupBox3.Controls.Add(this.DataBalance);
            this.king99GroupBox3.Curv1 = 1;
            this.king99GroupBox3.Curv2 = 1;
            this.king99GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.king99GroupBox3.Font = new System.Drawing.Font("Kanit", 11F);
            this.king99GroupBox3.Location = new System.Drawing.Point(3, 308);
            this.king99GroupBox3.MinimumSize = new System.Drawing.Size(136, 50);
            this.king99GroupBox3.Name = "king99GroupBox3";
            this.king99GroupBox3.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.king99GroupBox3.Size = new System.Drawing.Size(728, 300);
            this.king99GroupBox3.TabIndex = 4;
            this.king99GroupBox3.Text = "Balance";
            // 
            // DataBalance
            // 
            this.DataBalance.animationEnabled = false;
            this.DataBalance.AxisLineColor = System.Drawing.Color.LightGray;
            this.DataBalance.AxisXFontColor = System.Drawing.Color.Black;
            this.DataBalance.AxisXGridColor = System.Drawing.Color.Gray;
            this.DataBalance.AxisXGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataBalance.AxisYFontColor = System.Drawing.Color.Black;
            this.DataBalance.AxisYGridColor = System.Drawing.Color.Gray;
            this.DataBalance.AxisYGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DataBalance.BackColor = System.Drawing.Color.White;
            this.DataBalance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DataBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataBalance.Location = new System.Drawing.Point(5, 28);
            this.DataBalance.Name = "DataBalance";
            this.DataBalance.Size = new System.Drawing.Size(718, 267);
            this.DataBalance.TabIndex = 47;
            this.DataBalance.Theme = Bunifu.DataViz.WinForms.BunifuDataViz._theme.theme1;
            this.DataBalance.Title = "";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.king99GroupBox3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(734, 611);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // FrmSum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(734, 611);
            this.Controls.Add(this.tableLayoutPanel4);
            this.MinimumSize = new System.Drawing.Size(750, 650);
            this.Name = "FrmSum";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Summary";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSum_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.king99GroupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBigRoad)).EndInit();
            this.king99GroupBox4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWL)).EndInit();
            this.king99GroupBox3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private King99GroupBox king99GroupBox4;
        private King99GroupBox king99GroupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvBigRoad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvWL;
        private Bunifu.DataViz.WinForms.BunifuDataViz DataScore;
        private King99GroupBox king99GroupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Bunifu.DataViz.WinForms.BunifuDataViz DataWinLose;
        private Bunifu.DataViz.WinForms.BunifuDataViz DataBalance;
    }
}
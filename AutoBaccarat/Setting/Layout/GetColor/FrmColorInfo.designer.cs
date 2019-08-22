namespace AutoBaccarat
{
    partial class FrmColorInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmColorInfo));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tm_mouse = new System.Windows.Forms.Timer(this.components);
            this.tFive_HeaderLabel1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTarget = new System.Windows.Forms.PictureBox();
            this.txt_class = new King99.King99TextBox();
            this.btnSave = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txt_color = new King99.King99TextBox();
            this.tFive_Label5 = new System.Windows.Forms.Label();
            this.txt_posiY = new King99.King99TextBox();
            this.btnClose = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txt_posiX = new King99.King99TextBox();
            this.tFive_Label4 = new System.Windows.Forms.Label();
            this.txt_title = new King99.King99TextBox();
            this.lb_status = new System.Windows.Forms.Label();
            this.tFive_Label3 = new System.Windows.Forms.Label();
            this.panel_color = new System.Windows.Forms.Panel();
            this._tKing99Separator1 = new King99.King99Separator();
            this.tFive_Label2 = new System.Windows.Forms.Label();
            this.tFive_Label9 = new System.Windows.Forms.Label();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this._tKing99GroupBox1 = new King99.King99GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTarget)).BeginInit();
            this.bunifuCards1.SuspendLayout();
            this._tKing99GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            // 
            // tm_mouse
            // 
            this.tm_mouse.Tick += new System.EventHandler(this.tm_mouse_Tick);
            // 
            // tFive_HeaderLabel1
            // 
            this.tFive_HeaderLabel1.AutoSize = true;
            this.tFive_HeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tFive_HeaderLabel1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.tFive_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(255)))));
            this.tFive_HeaderLabel1.Location = new System.Drawing.Point(136, 364);
            this.tFive_HeaderLabel1.Name = "tFive_HeaderLabel1";
            this.tFive_HeaderLabel1.Size = new System.Drawing.Size(66, 20);
            this.tFive_HeaderLabel1.TabIndex = 31;
            this.tFive_HeaderLabel1.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.panel1.Controls.Add(this.picTarget);
            this.panel1.Controls.Add(this.txt_class);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.txt_color);
            this.panel1.Controls.Add(this.tFive_Label5);
            this.panel1.Controls.Add(this.txt_posiY);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.txt_posiX);
            this.panel1.Controls.Add(this.tFive_Label4);
            this.panel1.Controls.Add(this.txt_title);
            this.panel1.Controls.Add(this.lb_status);
            this.panel1.Controls.Add(this.tFive_Label3);
            this.panel1.Controls.Add(this.panel_color);
            this.panel1.Controls.Add(this._tKing99Separator1);
            this.panel1.Controls.Add(this.tFive_Label2);
            this.panel1.Controls.Add(this.tFive_Label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 310);
            this.panel1.TabIndex = 50;
            // 
            // picTarget
            // 
            this.picTarget.BackColor = System.Drawing.Color.White;
            this.picTarget.Image = ((System.Drawing.Image)(resources.GetObject("picTarget.Image")));
            this.picTarget.Location = new System.Drawing.Point(276, 115);
            this.picTarget.Name = "picTarget";
            this.picTarget.Size = new System.Drawing.Size(31, 28);
            this.picTarget.TabIndex = 19;
            this.picTarget.TabStop = false;
            this.picTarget.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTarget_MouseDown);
            this.picTarget.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picTarget_MouseUp);
            // 
            // txt_class
            // 
            this.txt_class.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_class.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.txt_class.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_class.Location = new System.Drawing.Point(118, 40);
            this.txt_class.MaxLength = 32767;
            this.txt_class.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_class.Multiline = false;
            this.txt_class.Name = "txt_class";
            this.txt_class.ReadOnly = false;
            this.txt_class.Size = new System.Drawing.Size(189, 31);
            this.txt_class.Style = King99.King99TextBox._Num.TextNum;
            this.txt_class.TabIndex = 42;
            this.txt_class.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_class.UseSystemPasswordChar = false;
            // 
            // btnSave
            // 
            this.btnSave.Active = false;
            this.btnSave.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.BorderRadius = 0;
            this.btnSave.ButtonText = "Save";
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledColor = System.Drawing.Color.Gray;
            this.btnSave.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSave.Iconimage = global::AutoBaccarat.Properties.Resources.save_64;
            this.btnSave.Iconimage_right = null;
            this.btnSave.Iconimage_right_Selected = null;
            this.btnSave.Iconimage_Selected = null;
            this.btnSave.IconMarginLeft = 0;
            this.btnSave.IconMarginRight = 0;
            this.btnSave.IconRightVisible = true;
            this.btnSave.IconRightZoom = 0D;
            this.btnSave.IconVisible = true;
            this.btnSave.IconZoom = 50D;
            this.btnSave.IsTab = false;
            this.btnSave.Location = new System.Drawing.Point(132, 275);
            this.btnSave.Margin = new System.Windows.Forms.Padding(16, 21, 16, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnSave.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSave.selected = false;
            this.btnSave.Size = new System.Drawing.Size(80, 32);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Textcolor = System.Drawing.Color.White;
            this.btnSave.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txt_color
            // 
            this.txt_color.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.txt_color.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_color.Location = new System.Drawing.Point(118, 114);
            this.txt_color.MaxLength = 32767;
            this.txt_color.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_color.Multiline = false;
            this.txt_color.Name = "txt_color";
            this.txt_color.ReadOnly = true;
            this.txt_color.Size = new System.Drawing.Size(150, 31);
            this.txt_color.Style = King99.King99TextBox._Num.TextNum;
            this.txt_color.TabIndex = 4;
            this.txt_color.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_color.UseSystemPasswordChar = false;
            // 
            // tFive_Label5
            // 
            this.tFive_Label5.AutoSize = true;
            this.tFive_Label5.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label5.ForeColor = System.Drawing.Color.White;
            this.tFive_Label5.Location = new System.Drawing.Point(69, 118);
            this.tFive_Label5.Name = "tFive_Label5";
            this.tFive_Label5.Size = new System.Drawing.Size(48, 20);
            this.tFive_Label5.TabIndex = 28;
            this.tFive_Label5.Text = "Color:";
            // 
            // txt_posiY
            // 
            this.txt_posiY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_posiY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.txt_posiY.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_posiY.Location = new System.Drawing.Point(247, 77);
            this.txt_posiY.MaxLength = 32767;
            this.txt_posiY.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_posiY.Multiline = false;
            this.txt_posiY.Name = "txt_posiY";
            this.txt_posiY.ReadOnly = false;
            this.txt_posiY.Size = new System.Drawing.Size(60, 31);
            this.txt_posiY.Style = King99.King99TextBox._Num.NumberOnly;
            this.txt_posiY.TabIndex = 3;
            this.txt_posiY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_posiY.UseSystemPasswordChar = false;
            // 
            // btnClose
            // 
            this.btnClose.Active = false;
            this.btnClose.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.BorderRadius = 0;
            this.btnClose.ButtonText = "Close";
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledColor = System.Drawing.Color.Gray;
            this.btnClose.Iconcolor = System.Drawing.Color.Transparent;
            this.btnClose.Iconimage = global::AutoBaccarat.Properties.Resources.close_window_64;
            this.btnClose.Iconimage_right = null;
            this.btnClose.Iconimage_right_Selected = null;
            this.btnClose.Iconimage_Selected = null;
            this.btnClose.IconMarginLeft = 0;
            this.btnClose.IconMarginRight = 0;
            this.btnClose.IconRightVisible = true;
            this.btnClose.IconRightZoom = 0D;
            this.btnClose.IconVisible = true;
            this.btnClose.IconZoom = 50D;
            this.btnClose.IsTab = false;
            this.btnClose.Location = new System.Drawing.Point(228, 275);
            this.btnClose.Margin = new System.Windows.Forms.Padding(24, 32, 24, 32);
            this.btnClose.Name = "btnClose";
            this.btnClose.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnClose.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.btnClose.OnHoverTextColor = System.Drawing.Color.White;
            this.btnClose.selected = false;
            this.btnClose.Size = new System.Drawing.Size(80, 32);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Textcolor = System.Drawing.Color.White;
            this.btnClose.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // txt_posiX
            // 
            this.txt_posiX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_posiX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.txt_posiX.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_posiX.Location = new System.Drawing.Point(118, 77);
            this.txt_posiX.MaxLength = 32767;
            this.txt_posiX.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_posiX.Multiline = false;
            this.txt_posiX.Name = "txt_posiX";
            this.txt_posiX.ReadOnly = false;
            this.txt_posiX.Size = new System.Drawing.Size(60, 31);
            this.txt_posiX.Style = King99.King99TextBox._Num.NumberOnly;
            this.txt_posiX.TabIndex = 2;
            this.txt_posiX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_posiX.UseSystemPasswordChar = false;
            // 
            // tFive_Label4
            // 
            this.tFive_Label4.AutoSize = true;
            this.tFive_Label4.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label4.ForeColor = System.Drawing.Color.White;
            this.tFive_Label4.Location = new System.Drawing.Point(226, 83);
            this.tFive_Label4.Name = "tFive_Label4";
            this.tFive_Label4.Size = new System.Drawing.Size(20, 20);
            this.tFive_Label4.TabIndex = 27;
            this.tFive_Label4.Text = "Y:";
            // 
            // txt_title
            // 
            this.txt_title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.txt_title.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_title.Location = new System.Drawing.Point(118, 3);
            this.txt_title.MaxLength = 32767;
            this.txt_title.MinimumSize = new System.Drawing.Size(0, 31);
            this.txt_title.Multiline = false;
            this.txt_title.Name = "txt_title";
            this.txt_title.ReadOnly = false;
            this.txt_title.Size = new System.Drawing.Size(189, 31);
            this.txt_title.Style = King99.King99TextBox._Num.TextNum;
            this.txt_title.TabIndex = 1;
            this.txt_title.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_title.UseSystemPasswordChar = false;
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.BackColor = System.Drawing.Color.Transparent;
            this.lb_status.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lb_status.ForeColor = System.Drawing.Color.White;
            this.lb_status.Location = new System.Drawing.Point(254, 243);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(33, 12);
            this.lb_status.TabIndex = 46;
            this.lb_status.Text = "Status:";
            // 
            // tFive_Label3
            // 
            this.tFive_Label3.AutoSize = true;
            this.tFive_Label3.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label3.ForeColor = System.Drawing.Color.White;
            this.tFive_Label3.Location = new System.Drawing.Point(40, 83);
            this.tFive_Label3.Name = "tFive_Label3";
            this.tFive_Label3.Size = new System.Drawing.Size(77, 20);
            this.tFive_Label3.TabIndex = 26;
            this.tFive_Label3.Text = "Position X:";
            // 
            // panel_color
            // 
            this.panel_color.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.panel_color.Location = new System.Drawing.Point(6, 151);
            this.panel_color.Name = "panel_color";
            this.panel_color.Size = new System.Drawing.Size(303, 89);
            this.panel_color.TabIndex = 44;
            // 
            // tFive_Separator1
            // 
            this._tKing99Separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this._tKing99Separator1.Location = new System.Drawing.Point(5, 248);
            this._tKing99Separator1.Name = "_tKing99Separator1";
            this._tKing99Separator1.Size = new System.Drawing.Size(303, 10);
            this._tKing99Separator1.TabIndex = 20;
            this._tKing99Separator1.Text = "tFive_Separator1";
            // 
            // tFive_Label2
            // 
            this.tFive_Label2.AutoSize = true;
            this.tFive_Label2.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label2.ForeColor = System.Drawing.Color.White;
            this.tFive_Label2.Location = new System.Drawing.Point(29, 9);
            this.tFive_Label2.Name = "tFive_Label2";
            this.tFive_Label2.Size = new System.Drawing.Size(85, 20);
            this.tFive_Label2.TabIndex = 25;
            this.tFive_Label2.Text = "Title Name:";
            // 
            // tFive_Label9
            // 
            this.tFive_Label9.AutoSize = true;
            this.tFive_Label9.BackColor = System.Drawing.Color.Transparent;
            this.tFive_Label9.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tFive_Label9.ForeColor = System.Drawing.Color.White;
            this.tFive_Label9.Location = new System.Drawing.Point(25, 46);
            this.tFive_Label9.Name = "tFive_Label9";
            this.tFive_Label9.Size = new System.Drawing.Size(89, 20);
            this.tFive_Label9.TabIndex = 43;
            this.tFive_Label9.Text = "Class Name:";
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = true;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.bunifuCards1.Controls.Add(this._tKing99GroupBox1);
            this.bunifuCards1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(0, 0);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = true;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(322, 351);
            this.bunifuCards1.TabIndex = 51;
            // 
            // tFiveGroupBox1
            // 
            this._tKing99GroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this._tKing99GroupBox1.BgColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this._tKing99GroupBox1.Controls.Add(this.panel1);
            this._tKing99GroupBox1.Curv1 = 1;
            this._tKing99GroupBox1.Curv2 = 1;
            this._tKing99GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tKing99GroupBox1.Location = new System.Drawing.Point(0, 5);
            this._tKing99GroupBox1.MinimumSize = new System.Drawing.Size(136, 50);
            this._tKing99GroupBox1.Name = "_tKing99GroupBox1";
            this._tKing99GroupBox1.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this._tKing99GroupBox1.Size = new System.Drawing.Size(320, 343);
            this._tKing99GroupBox1.TabIndex = 51;
            this._tKing99GroupBox1.Text = "Mode";
            // 
            // FrmColorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(322, 351);
            this.Controls.Add(this.bunifuCards1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(261, 65);
            this.Name = "FrmColorInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Get Color";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmColorInfo_FormClosing);
            this.Load += new System.EventHandler(this.GetColor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTarget)).EndInit();
            this.bunifuCards1.ResumeLayout(false);
            this._tKing99GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label tFive_HeaderLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer tm_mouse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTarget;
        private King99.King99TextBox txt_class;
        private Bunifu.Framework.UI.BunifuFlatButton btnSave;
        private King99.King99TextBox txt_color;
        private System.Windows.Forms.Label tFive_Label5;
        private King99.King99TextBox txt_posiY;
        private Bunifu.Framework.UI.BunifuFlatButton btnClose;
        private King99.King99TextBox txt_posiX;
        private System.Windows.Forms.Label tFive_Label4;
        private King99.King99TextBox txt_title;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.Label tFive_Label3;
        private System.Windows.Forms.Panel panel_color;
        private King99.King99Separator _tKing99Separator1;
        private System.Windows.Forms.Label tFive_Label2;
        private System.Windows.Forms.Label tFive_Label9;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
        private King99.King99GroupBox _tKing99GroupBox1;
    }
}
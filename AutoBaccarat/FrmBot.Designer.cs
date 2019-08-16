namespace AutoBaccarat
{
    partial class FrmBot
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            BunifuAnimatorNS.Animation animation5 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBot));
            BunifuAnimatorNS.Animation animation6 = new BunifuAnimatorNS.Animation();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle67 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle68 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle64 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle65 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle66 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop2 = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.btnSettings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnLogs = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnMain = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvLog = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBetSys = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelStart = new System.Windows.Forms.Panel();
            this.btnStart = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAddP = new System.Windows.Forms.Button();
            this.btnAddB = new System.Windows.Forms.Button();
            this.lbT = new System.Windows.Forms.Label();
            this.btnAddT = new System.Windows.Forms.Button();
            this.lbB = new System.Windows.Forms.Label();
            this.lbP = new System.Windows.Forms.Label();
            this.TransSettings = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.panelPage = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLine = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnBetSystem = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnFormula = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnLayout = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panelRight = new System.Windows.Forms.Panel();
            this.TransMain = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.TmDisplay = new System.Windows.Forms.Timer(this.components);
            this.Bots_Normal = new System.ComponentModel.BackgroundWorker();
            this.tmTimeRunning = new System.Windows.Forms.Timer(this.components);
            this.Bots_BackGround = new System.ComponentModel.BackgroundWorker();
            this.BaccaratScore = new TFive.TFiveGroupBox();
            this.dgvBigRoad = new System.Windows.Forms.DataGridView();
            this.BotStatus = new TFive.TFiveGroupBox();
            this.dgvStatus = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberStatus = new TFive.TFiveNotificationNumber();
            this.SettingProgram = new TFive.TFiveGroupBox();
            this.cbConfirmClick = new TFive.TFiveCheckbox();
            this.cbInvert = new TFive.TFiveCheckbox();
            this.cbLanguages = new TFive.TFiveComboBox();
            this.lbLanguages = new TFive.TFiveLabel();
            this.cbTopMost = new TFive.TFiveCheckbox();
            this.cbMove = new TFive.TFiveCheckbox();
            this.GoodLine = new TFive.TFiveGroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvGoodLine = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPV1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPV2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPV3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPV4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPV5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPV6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPVSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableGoodLine = new System.Windows.Forms.TableLayoutPanel();
            this.lbShowLine7 = new System.Windows.Forms.Label();
            this.lbShowLine6 = new System.Windows.Forms.Label();
            this.lbShowLine5 = new System.Windows.Forms.Label();
            this.lbShowLine4 = new System.Windows.Forms.Label();
            this.lbShowLine3 = new System.Windows.Forms.Label();
            this.lbShowLine2 = new System.Windows.Forms.Label();
            this.lbShowLine1 = new System.Windows.Forms.Label();
            this.lbline1 = new System.Windows.Forms.Label();
            this.lbline2 = new System.Windows.Forms.Label();
            this.lbline3 = new System.Windows.Forms.Label();
            this.lbline4 = new System.Windows.Forms.Label();
            this.lbline5 = new System.Windows.Forms.Label();
            this.lbline6 = new System.Windows.Forms.Label();
            this.lblineSum = new System.Windows.Forms.Label();
            this.BotSettings = new TFive.TFiveGroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbValueMode = new System.Windows.Forms.Label();
            this.lbMode = new System.Windows.Forms.Label();
            this.lbValueLayout = new System.Windows.Forms.Label();
            this.lbLayout = new System.Windows.Forms.Label();
            this.lbValueStopLess = new System.Windows.Forms.Label();
            this.lbStopLess = new System.Windows.Forms.Label();
            this.lbStopMore = new System.Windows.Forms.Label();
            this.lbValueStopMore = new System.Windows.Forms.Label();
            this.lbValueStopLose = new System.Windows.Forms.Label();
            this.lbStopLose = new System.Windows.Forms.Label();
            this.lbStopWin = new System.Windows.Forms.Label();
            this.lbValueStopWin = new System.Windows.Forms.Label();
            this.lbValueStop = new System.Windows.Forms.Label();
            this.lbStopRound = new System.Windows.Forms.Label();
            this.lbChip = new System.Windows.Forms.Label();
            this.lbValueChip = new System.Windows.Forms.Label();
            this.lbValueBet = new System.Windows.Forms.Label();
            this.lbBet = new System.Windows.Forms.Label();
            this.lbFormula = new System.Windows.Forms.Label();
            this.lbValueFormula = new System.Windows.Forms.Label();
            this.tFivePictureBox1 = new TFive_Theme.TFivePictureBox();
            this.panelTop2.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.panelStart.SuspendLayout();
            this.panelPage.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.BaccaratScore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBigRoad)).BeginInit();
            this.BotStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            this.SettingProgram.SuspendLayout();
            this.GoodLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodLine)).BeginInit();
            this.tableGoodLine.SuspendLayout();
            this.BotSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop2
            // 
            this.panelTop2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelTop2.Controls.Add(this.tFivePictureBox1);
            this.TransMain.SetDecoration(this.panelTop2, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.panelTop2, BunifuAnimatorNS.DecorationType.None);
            this.panelTop2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop2.Location = new System.Drawing.Point(0, 0);
            this.panelTop2.Margin = new System.Windows.Forms.Padding(0);
            this.panelTop2.Name = "panelTop2";
            this.panelTop2.Size = new System.Drawing.Size(719, 40);
            this.panelTop2.TabIndex = 4;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.panelLeft.Controls.Add(this.btnSettings);
            this.panelLeft.Controls.Add(this.btnLogs);
            this.panelLeft.Controls.Add(this.btnMain);
            this.TransMain.SetDecoration(this.panelLeft, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.panelLeft, BunifuAnimatorNS.DecorationType.None);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 40);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.panelLeft.Size = new System.Drawing.Size(40, 646);
            this.panelLeft.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Active = false;
            this.btnSettings.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.BorderRadius = 0;
            this.btnSettings.ButtonText = "";
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransSettings.SetDecoration(this.btnSettings, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.btnSettings, BunifuAnimatorNS.DecorationType.None);
            this.btnSettings.DisabledColor = System.Drawing.Color.Gray;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSettings.Iconimage = global::AutoBaccarat.Properties.Resources.settings_17_64;
            this.btnSettings.Iconimage_right = null;
            this.btnSettings.Iconimage_right_Selected = null;
            this.btnSettings.Iconimage_Selected = null;
            this.btnSettings.IconMarginLeft = 0;
            this.btnSettings.IconMarginRight = 0;
            this.btnSettings.IconRightVisible = true;
            this.btnSettings.IconRightZoom = 0D;
            this.btnSettings.IconVisible = true;
            this.btnSettings.IconZoom = 50D;
            this.btnSettings.IsTab = false;
            this.btnSettings.Location = new System.Drawing.Point(0, 81);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.btnSettings.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnSettings.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSettings.selected = false;
            this.btnSettings.Size = new System.Drawing.Size(40, 40);
            this.btnSettings.TabIndex = 8;
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Textcolor = System.Drawing.Color.White;
            this.btnSettings.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.Active = false;
            this.btnLogs.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.btnLogs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogs.BorderRadius = 0;
            this.btnLogs.ButtonText = "";
            this.btnLogs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransSettings.SetDecoration(this.btnLogs, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.btnLogs, BunifuAnimatorNS.DecorationType.None);
            this.btnLogs.DisabledColor = System.Drawing.Color.Gray;
            this.btnLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogs.Enabled = false;
            this.btnLogs.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLogs.Iconimage = global::AutoBaccarat.Properties.Resources.note_2_64;
            this.btnLogs.Iconimage_right = null;
            this.btnLogs.Iconimage_right_Selected = null;
            this.btnLogs.Iconimage_Selected = null;
            this.btnLogs.IconMarginLeft = 0;
            this.btnLogs.IconMarginRight = 0;
            this.btnLogs.IconRightVisible = true;
            this.btnLogs.IconRightZoom = 0D;
            this.btnLogs.IconVisible = true;
            this.btnLogs.IconZoom = 50D;
            this.btnLogs.IsTab = false;
            this.btnLogs.Location = new System.Drawing.Point(0, 41);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.btnLogs.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnLogs.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLogs.selected = false;
            this.btnLogs.Size = new System.Drawing.Size(40, 40);
            this.btnLogs.TabIndex = 7;
            this.btnLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogs.Textcolor = System.Drawing.Color.White;
            this.btnLogs.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogs.Visible = false;
            this.btnLogs.Click += new System.EventHandler(this.BtnLogs_Click);
            // 
            // btnMain
            // 
            this.btnMain.Active = false;
            this.btnMain.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.btnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMain.BorderRadius = 0;
            this.btnMain.ButtonText = "";
            this.btnMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransSettings.SetDecoration(this.btnMain, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.btnMain, BunifuAnimatorNS.DecorationType.None);
            this.btnMain.DisabledColor = System.Drawing.Color.Gray;
            this.btnMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMain.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMain.Iconimage = global::AutoBaccarat.Properties.Resources.start_64;
            this.btnMain.Iconimage_right = null;
            this.btnMain.Iconimage_right_Selected = null;
            this.btnMain.Iconimage_Selected = null;
            this.btnMain.IconMarginLeft = 0;
            this.btnMain.IconMarginRight = 0;
            this.btnMain.IconRightVisible = true;
            this.btnMain.IconRightZoom = 0D;
            this.btnMain.IconVisible = true;
            this.btnMain.IconZoom = 50D;
            this.btnMain.IsTab = false;
            this.btnMain.Location = new System.Drawing.Point(0, 1);
            this.btnMain.Name = "btnMain";
            this.btnMain.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.btnMain.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnMain.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMain.selected = false;
            this.btnMain.Size = new System.Drawing.Size(40, 40);
            this.btnMain.TabIndex = 6;
            this.btnMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMain.Textcolor = System.Drawing.Color.White;
            this.btnMain.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.Click += new System.EventHandler(this.BtnMain_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dgvLog);
            this.panelMain.Controls.Add(this.BaccaratScore);
            this.panelMain.Controls.Add(this.BotStatus);
            this.panelMain.Controls.Add(this.panelStart);
            this.TransMain.SetDecoration(this.panelMain, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.panelMain, BunifuAnimatorNS.DecorationType.None);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(359, 646);
            this.panelMain.TabIndex = 5;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AllowUserToResizeColumns = false;
            this.dgvLog.AllowUserToResizeRows = false;
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle47.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLog.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle47;
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLog.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLog.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle48.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle48;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colTime,
            this.colBet,
            this.colResult,
            this.colWL,
            this.colCost,
            this.colBalance,
            this.colPatt,
            this.colBetSys,
            this.colChip,
            this.colUnit,
            this.colMode,
            this.colStep});
            this.TransSettings.SetDecoration(this.dgvLog, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.dgvLog, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLog.DefaultCellStyle = dataGridViewCellStyle50;
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.DoubleBuffered = false;
            this.dgvLog.EnableHeadersVisualStyles = false;
            this.dgvLog.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.dgvLog.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.dgvLog.HeaderForeColor = System.Drawing.Color.White;
            this.dgvLog.Location = new System.Drawing.Point(0, 369);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle51.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle51.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle51;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle52.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle52.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle52.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLog.RowsDefaultCellStyle = dataGridViewCellStyle52;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLog.ShowCellErrors = false;
            this.dgvLog.ShowCellToolTips = false;
            this.dgvLog.ShowEditingIcon = false;
            this.dgvLog.ShowRowErrors = false;
            this.dgvLog.Size = new System.Drawing.Size(359, 190);
            this.dgvLog.TabIndex = 564;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "No";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNo.Width = 29;
            // 
            // colTime
            // 
            this.colTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTime.HeaderText = "Time";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTime.Width = 39;
            // 
            // colBet
            // 
            this.colBet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colBet.HeaderText = "Bet";
            this.colBet.Name = "colBet";
            this.colBet.ReadOnly = true;
            this.colBet.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBet.Width = 32;
            // 
            // colResult
            // 
            this.colResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colResult.HeaderText = "Result";
            this.colResult.Name = "colResult";
            this.colResult.ReadOnly = true;
            this.colResult.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colResult.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colResult.Width = 47;
            // 
            // colWL
            // 
            this.colWL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.colWL.DefaultCellStyle = dataGridViewCellStyle49;
            this.colWL.HeaderText = "WL";
            this.colWL.Name = "colWL";
            this.colWL.ReadOnly = true;
            this.colWL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colWL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colWL.Width = 31;
            // 
            // colCost
            // 
            this.colCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colCost.HeaderText = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            this.colCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colCost.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCost.Width = 39;
            // 
            // colBalance
            // 
            this.colBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            this.colBalance.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBalance.Width = 61;
            // 
            // colPatt
            // 
            this.colPatt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPatt.HeaderText = "Patt";
            this.colPatt.Name = "colPatt";
            this.colPatt.ReadOnly = true;
            this.colPatt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPatt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPatt.Visible = false;
            this.colPatt.Width = 37;
            // 
            // colBetSys
            // 
            this.colBetSys.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colBetSys.HeaderText = "BetSys";
            this.colBetSys.Name = "colBetSys";
            this.colBetSys.ReadOnly = true;
            this.colBetSys.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colBetSys.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBetSys.Visible = false;
            this.colBetSys.Width = 50;
            // 
            // colChip
            // 
            this.colChip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colChip.HeaderText = "Chip";
            this.colChip.Name = "colChip";
            this.colChip.ReadOnly = true;
            this.colChip.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colChip.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colChip.Width = 39;
            // 
            // colUnit
            // 
            this.colUnit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colUnit.HeaderText = "x Chip";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colUnit.Width = 48;
            // 
            // colMode
            // 
            this.colMode.HeaderText = "Mode";
            this.colMode.Name = "colMode";
            this.colMode.ReadOnly = true;
            this.colMode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMode.Visible = false;
            this.colMode.Width = 47;
            // 
            // colStep
            // 
            this.colStep.HeaderText = "Step";
            this.colStep.Name = "colStep";
            this.colStep.ReadOnly = true;
            this.colStep.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStep.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStep.Width = 40;
            // 
            // panelStart
            // 
            this.panelStart.Controls.Add(this.btnStart);
            this.panelStart.Controls.Add(this.numberStatus);
            this.panelStart.Controls.Add(this.btnClear);
            this.panelStart.Controls.Add(this.lblStatus);
            this.panelStart.Controls.Add(this.btnAddP);
            this.panelStart.Controls.Add(this.btnAddB);
            this.panelStart.Controls.Add(this.lbT);
            this.panelStart.Controls.Add(this.btnAddT);
            this.panelStart.Controls.Add(this.lbB);
            this.panelStart.Controls.Add(this.lbP);
            this.TransMain.SetDecoration(this.panelStart, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.panelStart, BunifuAnimatorNS.DecorationType.None);
            this.panelStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStart.Location = new System.Drawing.Point(0, 559);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(359, 87);
            this.panelStart.TabIndex = 563;
            // 
            // btnStart
            // 
            this.btnStart.Active = false;
            this.btnStart.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.BorderRadius = 0;
            this.btnStart.ButtonText = "Start";
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransSettings.SetDecoration(this.btnStart, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.btnStart, BunifuAnimatorNS.DecorationType.None);
            this.btnStart.DisabledColor = System.Drawing.Color.Gray;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnStart.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStart.Iconimage = null;
            this.btnStart.Iconimage_right = null;
            this.btnStart.Iconimage_right_Selected = null;
            this.btnStart.Iconimage_Selected = null;
            this.btnStart.IconMarginLeft = 0;
            this.btnStart.IconMarginRight = 0;
            this.btnStart.IconRightVisible = false;
            this.btnStart.IconRightZoom = 0D;
            this.btnStart.IconVisible = false;
            this.btnStart.IconZoom = 0D;
            this.btnStart.IsTab = false;
            this.btnStart.Location = new System.Drawing.Point(0, 52);
            this.btnStart.Name = "btnStart";
            this.btnStart.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnStart.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.btnStart.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStart.selected = false;
            this.btnStart.Size = new System.Drawing.Size(359, 35);
            this.btnStart.TabIndex = 562;
            this.btnStart.Text = "Start";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStart.Textcolor = System.Drawing.Color.White;
            this.btnStart.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Black;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransSettings.SetDecoration(this.btnClear, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.btnClear, BunifuAnimatorNS.DecorationType.None);
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(324, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(30, 30);
            this.btnClear.TabIndex = 555;
            this.btnClear.Text = "C";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.TransSettings.SetDecoration(this.lblStatus, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.lblStatus, BunifuAnimatorNS.DecorationType.None);
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(30, 14);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 20);
            this.lblStatus.TabIndex = 560;
            this.lblStatus.Text = "Ready";
            // 
            // btnAddP
            // 
            this.btnAddP.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAddP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransSettings.SetDecoration(this.btnAddP, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.btnAddP, BunifuAnimatorNS.DecorationType.None);
            this.btnAddP.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnAddP.FlatAppearance.BorderSize = 0;
            this.btnAddP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddP.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnAddP.ForeColor = System.Drawing.Color.White;
            this.btnAddP.Location = new System.Drawing.Point(216, 5);
            this.btnAddP.Name = "btnAddP";
            this.btnAddP.Size = new System.Drawing.Size(30, 30);
            this.btnAddP.TabIndex = 552;
            this.btnAddP.Text = "P";
            this.btnAddP.UseVisualStyleBackColor = false;
            this.btnAddP.Click += new System.EventHandler(this.ButtonAddValue2BigRoad);
            // 
            // btnAddB
            // 
            this.btnAddB.BackColor = System.Drawing.Color.Red;
            this.btnAddB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransSettings.SetDecoration(this.btnAddB, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.btnAddB, BunifuAnimatorNS.DecorationType.None);
            this.btnAddB.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnAddB.FlatAppearance.BorderSize = 0;
            this.btnAddB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddB.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnAddB.ForeColor = System.Drawing.Color.White;
            this.btnAddB.Location = new System.Drawing.Point(252, 5);
            this.btnAddB.Name = "btnAddB";
            this.btnAddB.Size = new System.Drawing.Size(30, 30);
            this.btnAddB.TabIndex = 553;
            this.btnAddB.Text = "B";
            this.btnAddB.UseVisualStyleBackColor = false;
            this.btnAddB.Click += new System.EventHandler(this.ButtonAddValue2BigRoad);
            // 
            // lbT
            // 
            this.lbT.AutoSize = true;
            this.TransSettings.SetDecoration(this.lbT, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.lbT, BunifuAnimatorNS.DecorationType.None);
            this.lbT.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lbT.ForeColor = System.Drawing.Color.White;
            this.lbT.Location = new System.Drawing.Point(187, 7);
            this.lbT.Name = "lbT";
            this.lbT.Size = new System.Drawing.Size(23, 28);
            this.lbT.TabIndex = 558;
            this.lbT.Text = "0";
            // 
            // btnAddT
            // 
            this.btnAddT.BackColor = System.Drawing.Color.Lime;
            this.btnAddT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransSettings.SetDecoration(this.btnAddT, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.btnAddT, BunifuAnimatorNS.DecorationType.None);
            this.btnAddT.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnAddT.FlatAppearance.BorderSize = 0;
            this.btnAddT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddT.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.btnAddT.ForeColor = System.Drawing.Color.White;
            this.btnAddT.Location = new System.Drawing.Point(288, 5);
            this.btnAddT.Name = "btnAddT";
            this.btnAddT.Size = new System.Drawing.Size(30, 30);
            this.btnAddT.TabIndex = 554;
            this.btnAddT.Text = "T";
            this.btnAddT.UseVisualStyleBackColor = false;
            this.btnAddT.Click += new System.EventHandler(this.ButtonAddValue2BigRoad);
            // 
            // lbB
            // 
            this.lbB.AutoSize = true;
            this.TransSettings.SetDecoration(this.lbB, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.lbB, BunifuAnimatorNS.DecorationType.None);
            this.lbB.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lbB.ForeColor = System.Drawing.Color.White;
            this.lbB.Location = new System.Drawing.Point(158, 7);
            this.lbB.Name = "lbB";
            this.lbB.Size = new System.Drawing.Size(23, 28);
            this.lbB.TabIndex = 557;
            this.lbB.Text = "0";
            // 
            // lbP
            // 
            this.lbP.AutoSize = true;
            this.TransSettings.SetDecoration(this.lbP, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.lbP, BunifuAnimatorNS.DecorationType.None);
            this.lbP.Font = new System.Drawing.Font("Segoe UI Semibold", 15F);
            this.lbP.ForeColor = System.Drawing.Color.White;
            this.lbP.Location = new System.Drawing.Point(129, 7);
            this.lbP.Name = "lbP";
            this.lbP.Size = new System.Drawing.Size(23, 28);
            this.lbP.TabIndex = 556;
            this.lbP.Text = "0";
            // 
            // TransSettings
            // 
            this.TransSettings.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.TransSettings.Cursor = null;
            animation5.AnimateOnlyDifferences = true;
            animation5.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.BlindCoeff")));
            animation5.LeafCoeff = 0F;
            animation5.MaxTime = 1F;
            animation5.MinTime = 0F;
            animation5.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicCoeff")));
            animation5.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation5.MosaicShift")));
            animation5.MosaicSize = 0;
            animation5.Padding = new System.Windows.Forms.Padding(0);
            animation5.RotateCoeff = 0F;
            animation5.RotateLimit = 0F;
            animation5.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.ScaleCoeff")));
            animation5.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation5.SlideCoeff")));
            animation5.TimeCoeff = 0F;
            animation5.TransparencyCoeff = 0F;
            this.TransSettings.DefaultAnimation = animation5;
            // 
            // panelPage
            // 
            this.panelPage.Controls.Add(this.panelMain);
            this.panelPage.Controls.Add(this.panelSettings);
            this.TransMain.SetDecoration(this.panelPage, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.panelPage, BunifuAnimatorNS.DecorationType.None);
            this.panelPage.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelPage.Location = new System.Drawing.Point(40, 40);
            this.panelPage.Name = "panelPage";
            this.panelPage.Size = new System.Drawing.Size(359, 646);
            this.panelPage.TabIndex = 566;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.tableLayoutPanel1);
            this.panelSettings.Controls.Add(this.SettingProgram);
            this.TransMain.SetDecoration(this.panelSettings, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.panelSettings, BunifuAnimatorNS.DecorationType.None);
            this.panelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettings.Location = new System.Drawing.Point(0, 0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(359, 646);
            this.panelSettings.TabIndex = 47;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnLine, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBetSystem, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnFormula, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLayout, 0, 0);
            this.TransMain.SetDecoration(this.tableLayoutPanel1, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.tableLayoutPanel1, BunifuAnimatorNS.DecorationType.None);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 184);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(359, 105);
            this.tableLayoutPanel1.TabIndex = 45;
            // 
            // btnLine
            // 
            this.btnLine.Active = false;
            this.btnLine.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.btnLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLine.BorderRadius = 0;
            this.btnLine.ButtonText = "Line Report";
            this.btnLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransMain.SetDecoration(this.btnLine, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.btnLine, BunifuAnimatorNS.DecorationType.None);
            this.btnLine.DisabledColor = System.Drawing.Color.Gray;
            this.btnLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLine.Enabled = false;
            this.btnLine.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLine.Iconimage = global::AutoBaccarat.Properties.Resources.line_icon_png_transparent_3_1_;
            this.btnLine.Iconimage_right = null;
            this.btnLine.Iconimage_right_Selected = null;
            this.btnLine.Iconimage_Selected = null;
            this.btnLine.IconMarginLeft = 0;
            this.btnLine.IconMarginRight = 0;
            this.btnLine.IconRightVisible = true;
            this.btnLine.IconRightZoom = 0D;
            this.btnLine.IconVisible = true;
            this.btnLine.IconZoom = 90D;
            this.btnLine.IsTab = false;
            this.btnLine.Location = new System.Drawing.Point(182, 55);
            this.btnLine.Name = "btnLine";
            this.btnLine.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.btnLine.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.btnLine.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLine.selected = false;
            this.btnLine.Size = new System.Drawing.Size(174, 47);
            this.btnLine.TabIndex = 48;
            this.btnLine.Text = "Line Report";
            this.btnLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLine.Textcolor = System.Drawing.Color.White;
            this.btnLine.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLine.Click += new System.EventHandler(this.BtnLine_Click);
            // 
            // btnBetSystem
            // 
            this.btnBetSystem.Active = false;
            this.btnBetSystem.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnBetSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnBetSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBetSystem.BorderRadius = 0;
            this.btnBetSystem.ButtonText = "Bet System";
            this.btnBetSystem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransMain.SetDecoration(this.btnBetSystem, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.btnBetSystem, BunifuAnimatorNS.DecorationType.None);
            this.btnBetSystem.DisabledColor = System.Drawing.Color.Gray;
            this.btnBetSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBetSystem.Iconcolor = System.Drawing.Color.Transparent;
            this.btnBetSystem.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnBetSystem.Iconimage")));
            this.btnBetSystem.Iconimage_right = null;
            this.btnBetSystem.Iconimage_right_Selected = null;
            this.btnBetSystem.Iconimage_Selected = null;
            this.btnBetSystem.IconMarginLeft = 0;
            this.btnBetSystem.IconMarginRight = 0;
            this.btnBetSystem.IconRightVisible = true;
            this.btnBetSystem.IconRightZoom = 0D;
            this.btnBetSystem.IconVisible = true;
            this.btnBetSystem.IconZoom = 50D;
            this.btnBetSystem.IsTab = false;
            this.btnBetSystem.Location = new System.Drawing.Point(3, 55);
            this.btnBetSystem.Name = "btnBetSystem";
            this.btnBetSystem.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnBetSystem.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.btnBetSystem.OnHoverTextColor = System.Drawing.Color.White;
            this.btnBetSystem.selected = false;
            this.btnBetSystem.Size = new System.Drawing.Size(173, 47);
            this.btnBetSystem.TabIndex = 47;
            this.btnBetSystem.Text = "Bet System";
            this.btnBetSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBetSystem.Textcolor = System.Drawing.Color.White;
            this.btnBetSystem.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBetSystem.Click += new System.EventHandler(this.BtnBetSystem_Click);
            // 
            // btnFormula
            // 
            this.btnFormula.Active = false;
            this.btnFormula.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnFormula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnFormula.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFormula.BorderRadius = 0;
            this.btnFormula.ButtonText = "Formula";
            this.btnFormula.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransMain.SetDecoration(this.btnFormula, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.btnFormula, BunifuAnimatorNS.DecorationType.None);
            this.btnFormula.DisabledColor = System.Drawing.Color.Gray;
            this.btnFormula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFormula.Iconcolor = System.Drawing.Color.Transparent;
            this.btnFormula.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnFormula.Iconimage")));
            this.btnFormula.Iconimage_right = null;
            this.btnFormula.Iconimage_right_Selected = null;
            this.btnFormula.Iconimage_Selected = null;
            this.btnFormula.IconMarginLeft = 0;
            this.btnFormula.IconMarginRight = 0;
            this.btnFormula.IconRightVisible = true;
            this.btnFormula.IconRightZoom = 0D;
            this.btnFormula.IconVisible = true;
            this.btnFormula.IconZoom = 50D;
            this.btnFormula.IsTab = false;
            this.btnFormula.Location = new System.Drawing.Point(182, 3);
            this.btnFormula.Name = "btnFormula";
            this.btnFormula.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnFormula.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.btnFormula.OnHoverTextColor = System.Drawing.Color.White;
            this.btnFormula.selected = false;
            this.btnFormula.Size = new System.Drawing.Size(174, 46);
            this.btnFormula.TabIndex = 46;
            this.btnFormula.Text = "Formula";
            this.btnFormula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFormula.Textcolor = System.Drawing.Color.White;
            this.btnFormula.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormula.Click += new System.EventHandler(this.BtnFormula_Click);
            // 
            // btnLayout
            // 
            this.btnLayout.Active = false;
            this.btnLayout.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLayout.BorderRadius = 0;
            this.btnLayout.ButtonText = "Layout";
            this.btnLayout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransMain.SetDecoration(this.btnLayout, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.btnLayout, BunifuAnimatorNS.DecorationType.None);
            this.btnLayout.DisabledColor = System.Drawing.Color.Gray;
            this.btnLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLayout.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLayout.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnLayout.Iconimage")));
            this.btnLayout.Iconimage_right = null;
            this.btnLayout.Iconimage_right_Selected = null;
            this.btnLayout.Iconimage_Selected = null;
            this.btnLayout.IconMarginLeft = 0;
            this.btnLayout.IconMarginRight = 0;
            this.btnLayout.IconRightVisible = true;
            this.btnLayout.IconRightZoom = 0D;
            this.btnLayout.IconVisible = true;
            this.btnLayout.IconZoom = 50D;
            this.btnLayout.IsTab = false;
            this.btnLayout.Location = new System.Drawing.Point(3, 3);
            this.btnLayout.Name = "btnLayout";
            this.btnLayout.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.btnLayout.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.btnLayout.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLayout.selected = false;
            this.btnLayout.Size = new System.Drawing.Size(173, 46);
            this.btnLayout.TabIndex = 45;
            this.btnLayout.Text = "Layout";
            this.btnLayout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLayout.Textcolor = System.Drawing.Color.White;
            this.btnLayout.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLayout.Click += new System.EventHandler(this.BtnLayout_Click);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.GoodLine);
            this.panelRight.Controls.Add(this.BotSettings);
            this.TransMain.SetDecoration(this.panelRight, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.panelRight, BunifuAnimatorNS.DecorationType.None);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(405, 40);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(314, 646);
            this.panelRight.TabIndex = 569;
            // 
            // TransMain
            // 
            this.TransMain.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.TransMain.Cursor = null;
            animation6.AnimateOnlyDifferences = true;
            animation6.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.BlindCoeff")));
            animation6.LeafCoeff = 0F;
            animation6.MaxTime = 1F;
            animation6.MinTime = 0F;
            animation6.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.MosaicCoeff")));
            animation6.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation6.MosaicShift")));
            animation6.MosaicSize = 0;
            animation6.Padding = new System.Windows.Forms.Padding(0);
            animation6.RotateCoeff = 0F;
            animation6.RotateLimit = 0F;
            animation6.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.ScaleCoeff")));
            animation6.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation6.SlideCoeff")));
            animation6.TimeCoeff = 0F;
            animation6.TransparencyCoeff = 0F;
            this.TransMain.DefaultAnimation = animation6;
            // 
            // TmDisplay
            // 
            this.TmDisplay.Enabled = true;
            this.TmDisplay.Interval = 300;
            this.TmDisplay.Tick += new System.EventHandler(this.TmDisplay_Tick);
            // 
            // Bots_Normal
            // 
            this.Bots_Normal.WorkerReportsProgress = true;
            this.Bots_Normal.WorkerSupportsCancellation = true;
            this.Bots_Normal.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bots_Normal_DoWork);
            // 
            // tmTimeRunning
            // 
            this.tmTimeRunning.Interval = 1000;
            this.tmTimeRunning.Tick += new System.EventHandler(this.TmTimeRunning_Tick);
            // 
            // Bots_BackGround
            // 
            this.Bots_BackGround.WorkerReportsProgress = true;
            this.Bots_BackGround.WorkerSupportsCancellation = true;
            this.Bots_BackGround.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Bots_BackGround_DoWork);
            // 
            // BaccaratScore
            // 
            this.BaccaratScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.BaccaratScore.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.BaccaratScore.Controls.Add(this.dgvBigRoad);
            this.BaccaratScore.Curv1 = 1;
            this.BaccaratScore.Curv2 = 1;
            this.TransMain.SetDecoration(this.BaccaratScore, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.BaccaratScore, BunifuAnimatorNS.DecorationType.None);
            this.BaccaratScore.Dock = System.Windows.Forms.DockStyle.Top;
            this.BaccaratScore.Location = new System.Drawing.Point(0, 185);
            this.BaccaratScore.MinimumSize = new System.Drawing.Size(136, 50);
            this.BaccaratScore.Name = "BaccaratScore";
            this.BaccaratScore.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.BaccaratScore.Size = new System.Drawing.Size(359, 184);
            this.BaccaratScore.TabIndex = 559;
            this.BaccaratScore.Text = "Baccarat Score";
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
            this.dgvBigRoad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBigRoad.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvBigRoad.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBigRoad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBigRoad.ColumnHeadersVisible = false;
            this.TransMain.SetDecoration(this.dgvBigRoad, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.dgvBigRoad, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle53.Font = new System.Drawing.Font("Segoe UI Semibold", 12F);
            dataGridViewCellStyle53.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBigRoad.DefaultCellStyle = dataGridViewCellStyle53;
            this.dgvBigRoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBigRoad.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.dgvBigRoad.Location = new System.Drawing.Point(5, 28);
            this.dgvBigRoad.Name = "dgvBigRoad";
            this.dgvBigRoad.ReadOnly = true;
            this.dgvBigRoad.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvBigRoad.RowHeadersVisible = false;
            this.dgvBigRoad.Size = new System.Drawing.Size(349, 151);
            this.dgvBigRoad.TabIndex = 43;
            this.dgvBigRoad.SelectionChanged += new System.EventHandler(this.ClearSelected);
            // 
            // BotStatus
            // 
            this.BotStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.BotStatus.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.BotStatus.Controls.Add(this.dgvStatus);
            this.BotStatus.Curv1 = 1;
            this.BotStatus.Curv2 = 1;
            this.TransMain.SetDecoration(this.BotStatus, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.BotStatus, BunifuAnimatorNS.DecorationType.None);
            this.BotStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.BotStatus.Location = new System.Drawing.Point(0, 0);
            this.BotStatus.MinimumSize = new System.Drawing.Size(136, 50);
            this.BotStatus.Name = "BotStatus";
            this.BotStatus.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.BotStatus.Size = new System.Drawing.Size(359, 185);
            this.BotStatus.TabIndex = 1;
            this.BotStatus.Text = "Bot Status";
            // 
            // dgvStatus
            // 
            this.dgvStatus.AllowUserToAddRows = false;
            this.dgvStatus.AllowUserToDeleteRows = false;
            this.dgvStatus.AllowUserToOrderColumns = true;
            this.dgvStatus.AllowUserToResizeColumns = false;
            this.dgvStatus.AllowUserToResizeRows = false;
            this.dgvStatus.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.dgvStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle54.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle54;
            this.dgvStatus.ColumnHeadersVisible = false;
            this.dgvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.TransMain.SetDecoration(this.dgvStatus, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.dgvStatus, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle57.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle57.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle57.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStatus.DefaultCellStyle = dataGridViewCellStyle57;
            this.dgvStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatus.EnableHeadersVisualStyles = false;
            this.dgvStatus.Location = new System.Drawing.Point(5, 28);
            this.dgvStatus.MultiSelect = false;
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.ReadOnly = true;
            this.dgvStatus.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStatus.RowHeadersVisible = false;
            this.dgvStatus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStatus.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvStatus.Size = new System.Drawing.Size(349, 152);
            this.dgvStatus.TabIndex = 38;
            this.dgvStatus.SelectionChanged += new System.EventHandler(this.ClearSelected);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle55.ForeColor = System.Drawing.Color.White;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle55;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 30;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle56.ForeColor = System.Drawing.Color.White;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle56;
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // numberStatus
            // 
            this.TransSettings.SetDecoration(this.numberStatus, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.numberStatus, BunifuAnimatorNS.DecorationType.None);
            this.numberStatus.Location = new System.Drawing.Point(4, 8);
            this.numberStatus.Maximum = 4;
            this.numberStatus.Name = "numberStatus";
            this.numberStatus.Size = new System.Drawing.Size(27, 27);
            this.numberStatus.TabIndex = 561;
            this.numberStatus.Text = "tFiveNotificationNumber1";
            this.numberStatus.Value = 1;
            // 
            // SettingProgram
            // 
            this.SettingProgram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.SettingProgram.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.SettingProgram.Controls.Add(this.cbConfirmClick);
            this.SettingProgram.Controls.Add(this.cbInvert);
            this.SettingProgram.Controls.Add(this.cbLanguages);
            this.SettingProgram.Controls.Add(this.lbLanguages);
            this.SettingProgram.Controls.Add(this.cbTopMost);
            this.SettingProgram.Controls.Add(this.cbMove);
            this.SettingProgram.Curv1 = 1;
            this.SettingProgram.Curv2 = 1;
            this.TransMain.SetDecoration(this.SettingProgram, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.SettingProgram, BunifuAnimatorNS.DecorationType.None);
            this.SettingProgram.Dock = System.Windows.Forms.DockStyle.Top;
            this.SettingProgram.Location = new System.Drawing.Point(0, 0);
            this.SettingProgram.MinimumSize = new System.Drawing.Size(136, 50);
            this.SettingProgram.Name = "SettingProgram";
            this.SettingProgram.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.SettingProgram.Size = new System.Drawing.Size(359, 184);
            this.SettingProgram.TabIndex = 41;
            this.SettingProgram.Text = "Program Settings";
            // 
            // cbConfirmClick
            // 
            this.cbConfirmClick.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.cbConfirmClick.CheckedState = false;
            this.cbConfirmClick.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransMain.SetDecoration(this.cbConfirmClick, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.cbConfirmClick, BunifuAnimatorNS.DecorationType.None);
            this.cbConfirmClick.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbConfirmClick.Image = null;
            this.cbConfirmClick.Location = new System.Drawing.Point(225, 101);
            this.cbConfirmClick.MinimumSize = new System.Drawing.Size(16, 16);
            this.cbConfirmClick.Name = "cbConfirmClick";
            this.cbConfirmClick.NoRounding = false;
            this.cbConfirmClick.Size = new System.Drawing.Size(120, 19);
            this.cbConfirmClick.TabIndex = 39;
            this.cbConfirmClick.Text = "Confirm Click";
            // 
            // cbInvert
            // 
            this.cbInvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.cbInvert.CheckedState = false;
            this.cbInvert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransMain.SetDecoration(this.cbInvert, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.cbInvert, BunifuAnimatorNS.DecorationType.None);
            this.cbInvert.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbInvert.Image = null;
            this.cbInvert.Location = new System.Drawing.Point(225, 67);
            this.cbInvert.MinimumSize = new System.Drawing.Size(16, 16);
            this.cbInvert.Name = "cbInvert";
            this.cbInvert.NoRounding = false;
            this.cbInvert.Size = new System.Drawing.Size(120, 19);
            this.cbInvert.TabIndex = 38;
            this.cbInvert.Text = "Bet Invert";
            // 
            // cbLanguages
            // 
            this.cbLanguages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.cbLanguages.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.cbLanguages.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbLanguages.Curv = 1;
            this.TransMain.SetDecoration(this.cbLanguages, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.cbLanguages, BunifuAnimatorNS.DecorationType.None);
            this.cbLanguages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbLanguages.DropDownHeight = 100;
            this.cbLanguages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbLanguages.ForeColor = System.Drawing.Color.White;
            this.cbLanguages.FormattingEnabled = true;
            this.cbLanguages.HoverSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            this.cbLanguages.IntegralHeight = false;
            this.cbLanguages.ItemHeight = 20;
            this.cbLanguages.Location = new System.Drawing.Point(97, 31);
            this.cbLanguages.Name = "cbLanguages";
            this.cbLanguages.Size = new System.Drawing.Size(146, 26);
            this.cbLanguages.StartIndex = 0;
            this.cbLanguages.TabIndex = 13;
            this.cbLanguages.SelectionChangeCommitted += new System.EventHandler(this.CbLanguages_SelectionChangeCommitted);
            // 
            // lbLanguages
            // 
            this.lbLanguages.AutoSize = true;
            this.lbLanguages.BackColor = System.Drawing.Color.Transparent;
            this.TransSettings.SetDecoration(this.lbLanguages, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.lbLanguages, BunifuAnimatorNS.DecorationType.None);
            this.lbLanguages.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbLanguages.ForeColor = System.Drawing.Color.White;
            this.lbLanguages.Location = new System.Drawing.Point(8, 33);
            this.lbLanguages.Name = "lbLanguages";
            this.lbLanguages.Size = new System.Drawing.Size(80, 20);
            this.lbLanguages.TabIndex = 12;
            this.lbLanguages.Text = "Languages";
            // 
            // cbTopMost
            // 
            this.cbTopMost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.cbTopMost.CheckedState = false;
            this.cbTopMost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransMain.SetDecoration(this.cbTopMost, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.cbTopMost, BunifuAnimatorNS.DecorationType.None);
            this.cbTopMost.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbTopMost.Image = null;
            this.cbTopMost.Location = new System.Drawing.Point(12, 67);
            this.cbTopMost.MinimumSize = new System.Drawing.Size(16, 16);
            this.cbTopMost.Name = "cbTopMost";
            this.cbTopMost.NoRounding = false;
            this.cbTopMost.Size = new System.Drawing.Size(90, 19);
            this.cbTopMost.TabIndex = 0;
            this.cbTopMost.Text = "Top Most";
            this.cbTopMost.Click += new System.EventHandler(this.CbTopMost_Click);
            // 
            // cbMove
            // 
            this.cbMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.cbMove.CheckedState = false;
            this.cbMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransMain.SetDecoration(this.cbMove, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.cbMove, BunifuAnimatorNS.DecorationType.None);
            this.cbMove.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbMove.Image = null;
            this.cbMove.Location = new System.Drawing.Point(12, 101);
            this.cbMove.MinimumSize = new System.Drawing.Size(16, 16);
            this.cbMove.Name = "cbMove";
            this.cbMove.NoRounding = false;
            this.cbMove.Size = new System.Drawing.Size(231, 19);
            this.cbMove.TabIndex = 35;
            this.cbMove.Text = "Move Cursor After Bet";
            // 
            // GoodLine
            // 
            this.GoodLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.GoodLine.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.GoodLine.Controls.Add(this.button1);
            this.GoodLine.Controls.Add(this.dgvGoodLine);
            this.GoodLine.Controls.Add(this.tableGoodLine);
            this.GoodLine.Curv1 = 1;
            this.GoodLine.Curv2 = 1;
            this.TransMain.SetDecoration(this.GoodLine, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.GoodLine, BunifuAnimatorNS.DecorationType.None);
            this.GoodLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GoodLine.Location = new System.Drawing.Point(0, 185);
            this.GoodLine.MinimumSize = new System.Drawing.Size(136, 50);
            this.GoodLine.Name = "GoodLine";
            this.GoodLine.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.GoodLine.Size = new System.Drawing.Size(314, 461);
            this.GoodLine.TabIndex = 567;
            this.GoodLine.Text = "Good Line";
            // 
            // button1
            // 
            this.TransSettings.SetDecoration(this.button1, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.button1, BunifuAnimatorNS.DecorationType.None);
            this.button1.Location = new System.Drawing.Point(231, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 563;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dgvGoodLine
            // 
            this.dgvGoodLine.AllowUserToAddRows = false;
            this.dgvGoodLine.AllowUserToDeleteRows = false;
            this.dgvGoodLine.AllowUserToResizeColumns = false;
            this.dgvGoodLine.AllowUserToResizeRows = false;
            dataGridViewCellStyle58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle58.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.Color.White;
            this.dgvGoodLine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle58;
            this.dgvGoodLine.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGoodLine.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.dgvGoodLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGoodLine.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoodLine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle59;
            this.dgvGoodLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoodLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumn1,
            this.DataGridViewTextBoxColumn2,
            this.colPV1,
            this.colPV2,
            this.colPV3,
            this.colPV4,
            this.colPV5,
            this.colPV6,
            this.colPVSum});
            this.TransSettings.SetDecoration(this.dgvGoodLine, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.dgvGoodLine, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle67.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle67.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle67.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle67.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle67.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGoodLine.DefaultCellStyle = dataGridViewCellStyle67;
            this.dgvGoodLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGoodLine.DoubleBuffered = false;
            this.dgvGoodLine.EnableHeadersVisualStyles = false;
            this.dgvGoodLine.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.dgvGoodLine.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.dgvGoodLine.HeaderForeColor = System.Drawing.Color.White;
            this.dgvGoodLine.Location = new System.Drawing.Point(5, 67);
            this.dgvGoodLine.MultiSelect = false;
            this.dgvGoodLine.Name = "dgvGoodLine";
            this.dgvGoodLine.ReadOnly = true;
            this.dgvGoodLine.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle68.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle68.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle68.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle68.ForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle68.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle68.SelectionForeColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle68.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGoodLine.RowHeadersDefaultCellStyle = dataGridViewCellStyle68;
            this.dgvGoodLine.RowHeadersVisible = false;
            this.dgvGoodLine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle69.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle69.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(62)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle69.SelectionForeColor = System.Drawing.Color.White;
            this.dgvGoodLine.RowsDefaultCellStyle = dataGridViewCellStyle69;
            this.dgvGoodLine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvGoodLine.ShowCellErrors = false;
            this.dgvGoodLine.ShowCellToolTips = false;
            this.dgvGoodLine.ShowEditingIcon = false;
            this.dgvGoodLine.ShowRowErrors = false;
            this.dgvGoodLine.Size = new System.Drawing.Size(304, 389);
            this.dgvGoodLine.TabIndex = 2;
            this.dgvGoodLine.SelectionChanged += new System.EventHandler(this.ClearSelected);
            // 
            // DataGridViewTextBoxColumn1
            // 
            this.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewTextBoxColumn1.HeaderText = "No. ";
            this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            this.DataGridViewTextBoxColumn1.ReadOnly = true;
            this.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataGridViewTextBoxColumn1.Width = 35;
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewTextBoxColumn2.HeaderText = "Result";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            this.DataGridViewTextBoxColumn2.ReadOnly = true;
            this.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataGridViewTextBoxColumn2.Width = 47;
            // 
            // colPV1
            // 
            dataGridViewCellStyle60.ForeColor = System.Drawing.Color.White;
            this.colPV1.DefaultCellStyle = dataGridViewCellStyle60;
            this.colPV1.HeaderText = "L1";
            this.colPV1.Name = "colPV1";
            this.colPV1.ReadOnly = true;
            this.colPV1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPV1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPV1.Width = 30;
            // 
            // colPV2
            // 
            dataGridViewCellStyle61.ForeColor = System.Drawing.Color.White;
            this.colPV2.DefaultCellStyle = dataGridViewCellStyle61;
            this.colPV2.HeaderText = "L2";
            this.colPV2.Name = "colPV2";
            this.colPV2.ReadOnly = true;
            this.colPV2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPV2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPV2.Width = 30;
            // 
            // colPV3
            // 
            dataGridViewCellStyle62.ForeColor = System.Drawing.Color.White;
            this.colPV3.DefaultCellStyle = dataGridViewCellStyle62;
            this.colPV3.HeaderText = "L3";
            this.colPV3.Name = "colPV3";
            this.colPV3.ReadOnly = true;
            this.colPV3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPV3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPV3.Width = 30;
            // 
            // colPV4
            // 
            dataGridViewCellStyle63.ForeColor = System.Drawing.Color.White;
            this.colPV4.DefaultCellStyle = dataGridViewCellStyle63;
            this.colPV4.HeaderText = "L4";
            this.colPV4.Name = "colPV4";
            this.colPV4.ReadOnly = true;
            this.colPV4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPV4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPV4.Width = 30;
            // 
            // colPV5
            // 
            dataGridViewCellStyle64.ForeColor = System.Drawing.Color.White;
            this.colPV5.DefaultCellStyle = dataGridViewCellStyle64;
            this.colPV5.HeaderText = "L5";
            this.colPV5.Name = "colPV5";
            this.colPV5.ReadOnly = true;
            this.colPV5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPV5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPV5.Width = 30;
            // 
            // colPV6
            // 
            dataGridViewCellStyle65.ForeColor = System.Drawing.Color.White;
            this.colPV6.DefaultCellStyle = dataGridViewCellStyle65;
            this.colPV6.HeaderText = "L6";
            this.colPV6.Name = "colPV6";
            this.colPV6.ReadOnly = true;
            this.colPV6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPV6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPV6.Width = 30;
            // 
            // colPVSum
            // 
            this.colPVSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle66.ForeColor = System.Drawing.Color.White;
            this.colPVSum.DefaultCellStyle = dataGridViewCellStyle66;
            this.colPVSum.HeaderText = "GL";
            this.colPVSum.Name = "colPVSum";
            this.colPVSum.ReadOnly = true;
            this.colPVSum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPVSum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tableGoodLine
            // 
            this.tableGoodLine.ColumnCount = 9;
            this.tableGoodLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableGoodLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableGoodLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableGoodLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableGoodLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableGoodLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableGoodLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableGoodLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableGoodLine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableGoodLine.Controls.Add(this.lbShowLine7, 8, 0);
            this.tableGoodLine.Controls.Add(this.lbShowLine6, 7, 0);
            this.tableGoodLine.Controls.Add(this.lbShowLine5, 6, 0);
            this.tableGoodLine.Controls.Add(this.lbShowLine4, 5, 0);
            this.tableGoodLine.Controls.Add(this.lbShowLine3, 4, 0);
            this.tableGoodLine.Controls.Add(this.lbShowLine2, 3, 0);
            this.tableGoodLine.Controls.Add(this.lbShowLine1, 2, 0);
            this.tableGoodLine.Controls.Add(this.lbline1, 2, 1);
            this.tableGoodLine.Controls.Add(this.lbline2, 3, 1);
            this.tableGoodLine.Controls.Add(this.lbline3, 4, 1);
            this.tableGoodLine.Controls.Add(this.lbline4, 5, 1);
            this.tableGoodLine.Controls.Add(this.lbline5, 6, 1);
            this.tableGoodLine.Controls.Add(this.lbline6, 7, 1);
            this.tableGoodLine.Controls.Add(this.lblineSum, 8, 1);
            this.TransMain.SetDecoration(this.tableGoodLine, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.tableGoodLine, BunifuAnimatorNS.DecorationType.None);
            this.tableGoodLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableGoodLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tableGoodLine.Location = new System.Drawing.Point(5, 28);
            this.tableGoodLine.Name = "tableGoodLine";
            this.tableGoodLine.RowCount = 2;
            this.tableGoodLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableGoodLine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableGoodLine.Size = new System.Drawing.Size(304, 39);
            this.tableGoodLine.TabIndex = 3;
            // 
            // lbShowLine7
            // 
            this.lbShowLine7.AutoSize = true;
            this.TransMain.SetDecoration(this.lbShowLine7, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbShowLine7, BunifuAnimatorNS.DecorationType.None);
            this.lbShowLine7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShowLine7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbShowLine7.ForeColor = System.Drawing.Color.White;
            this.lbShowLine7.Location = new System.Drawing.Point(265, 0);
            this.lbShowLine7.Name = "lbShowLine7";
            this.lbShowLine7.Size = new System.Drawing.Size(36, 19);
            this.lbShowLine7.TabIndex = 550;
            this.lbShowLine7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbShowLine6
            // 
            this.lbShowLine6.AutoSize = true;
            this.TransMain.SetDecoration(this.lbShowLine6, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbShowLine6, BunifuAnimatorNS.DecorationType.None);
            this.lbShowLine6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShowLine6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbShowLine6.ForeColor = System.Drawing.Color.White;
            this.lbShowLine6.Location = new System.Drawing.Point(235, 0);
            this.lbShowLine6.Name = "lbShowLine6";
            this.lbShowLine6.Size = new System.Drawing.Size(24, 19);
            this.lbShowLine6.TabIndex = 549;
            this.lbShowLine6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbShowLine5
            // 
            this.lbShowLine5.AutoSize = true;
            this.TransMain.SetDecoration(this.lbShowLine5, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbShowLine5, BunifuAnimatorNS.DecorationType.None);
            this.lbShowLine5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShowLine5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbShowLine5.ForeColor = System.Drawing.Color.White;
            this.lbShowLine5.Location = new System.Drawing.Point(205, 0);
            this.lbShowLine5.Name = "lbShowLine5";
            this.lbShowLine5.Size = new System.Drawing.Size(24, 19);
            this.lbShowLine5.TabIndex = 548;
            this.lbShowLine5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbShowLine4
            // 
            this.lbShowLine4.AutoSize = true;
            this.TransMain.SetDecoration(this.lbShowLine4, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbShowLine4, BunifuAnimatorNS.DecorationType.None);
            this.lbShowLine4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShowLine4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbShowLine4.ForeColor = System.Drawing.Color.White;
            this.lbShowLine4.Location = new System.Drawing.Point(175, 0);
            this.lbShowLine4.Name = "lbShowLine4";
            this.lbShowLine4.Size = new System.Drawing.Size(24, 19);
            this.lbShowLine4.TabIndex = 547;
            this.lbShowLine4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbShowLine3
            // 
            this.lbShowLine3.AutoSize = true;
            this.TransMain.SetDecoration(this.lbShowLine3, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbShowLine3, BunifuAnimatorNS.DecorationType.None);
            this.lbShowLine3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShowLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbShowLine3.ForeColor = System.Drawing.Color.White;
            this.lbShowLine3.Location = new System.Drawing.Point(145, 0);
            this.lbShowLine3.Name = "lbShowLine3";
            this.lbShowLine3.Size = new System.Drawing.Size(24, 19);
            this.lbShowLine3.TabIndex = 546;
            this.lbShowLine3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbShowLine2
            // 
            this.lbShowLine2.AutoSize = true;
            this.TransMain.SetDecoration(this.lbShowLine2, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbShowLine2, BunifuAnimatorNS.DecorationType.None);
            this.lbShowLine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShowLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbShowLine2.ForeColor = System.Drawing.Color.White;
            this.lbShowLine2.Location = new System.Drawing.Point(115, 0);
            this.lbShowLine2.Name = "lbShowLine2";
            this.lbShowLine2.Size = new System.Drawing.Size(24, 19);
            this.lbShowLine2.TabIndex = 545;
            this.lbShowLine2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbShowLine1
            // 
            this.lbShowLine1.AutoSize = true;
            this.TransMain.SetDecoration(this.lbShowLine1, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbShowLine1, BunifuAnimatorNS.DecorationType.None);
            this.lbShowLine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbShowLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbShowLine1.ForeColor = System.Drawing.Color.White;
            this.lbShowLine1.Location = new System.Drawing.Point(85, 0);
            this.lbShowLine1.Name = "lbShowLine1";
            this.lbShowLine1.Size = new System.Drawing.Size(24, 19);
            this.lbShowLine1.TabIndex = 544;
            this.lbShowLine1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbline1
            // 
            this.lbline1.AutoSize = true;
            this.TransMain.SetDecoration(this.lbline1, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbline1, BunifuAnimatorNS.DecorationType.None);
            this.lbline1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbline1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbline1.ForeColor = System.Drawing.Color.White;
            this.lbline1.Location = new System.Drawing.Point(85, 19);
            this.lbline1.Name = "lbline1";
            this.lbline1.Size = new System.Drawing.Size(24, 20);
            this.lbline1.TabIndex = 528;
            this.lbline1.Text = "0";
            this.lbline1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbline2
            // 
            this.lbline2.AutoSize = true;
            this.TransMain.SetDecoration(this.lbline2, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbline2, BunifuAnimatorNS.DecorationType.None);
            this.lbline2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbline2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbline2.ForeColor = System.Drawing.Color.White;
            this.lbline2.Location = new System.Drawing.Point(115, 19);
            this.lbline2.Name = "lbline2";
            this.lbline2.Size = new System.Drawing.Size(24, 20);
            this.lbline2.TabIndex = 529;
            this.lbline2.Text = "0";
            this.lbline2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbline3
            // 
            this.lbline3.AutoSize = true;
            this.TransMain.SetDecoration(this.lbline3, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbline3, BunifuAnimatorNS.DecorationType.None);
            this.lbline3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbline3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbline3.ForeColor = System.Drawing.Color.White;
            this.lbline3.Location = new System.Drawing.Point(145, 19);
            this.lbline3.Name = "lbline3";
            this.lbline3.Size = new System.Drawing.Size(24, 20);
            this.lbline3.TabIndex = 530;
            this.lbline3.Text = "0";
            this.lbline3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbline4
            // 
            this.lbline4.AutoSize = true;
            this.TransMain.SetDecoration(this.lbline4, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbline4, BunifuAnimatorNS.DecorationType.None);
            this.lbline4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbline4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbline4.ForeColor = System.Drawing.Color.White;
            this.lbline4.Location = new System.Drawing.Point(175, 19);
            this.lbline4.Name = "lbline4";
            this.lbline4.Size = new System.Drawing.Size(24, 20);
            this.lbline4.TabIndex = 531;
            this.lbline4.Text = "0";
            this.lbline4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbline5
            // 
            this.lbline5.AutoSize = true;
            this.TransMain.SetDecoration(this.lbline5, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbline5, BunifuAnimatorNS.DecorationType.None);
            this.lbline5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbline5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbline5.ForeColor = System.Drawing.Color.White;
            this.lbline5.Location = new System.Drawing.Point(205, 19);
            this.lbline5.Name = "lbline5";
            this.lbline5.Size = new System.Drawing.Size(24, 20);
            this.lbline5.TabIndex = 532;
            this.lbline5.Text = "0";
            this.lbline5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbline6
            // 
            this.lbline6.AutoSize = true;
            this.TransMain.SetDecoration(this.lbline6, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbline6, BunifuAnimatorNS.DecorationType.None);
            this.lbline6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbline6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lbline6.ForeColor = System.Drawing.Color.White;
            this.lbline6.Location = new System.Drawing.Point(235, 19);
            this.lbline6.Name = "lbline6";
            this.lbline6.Size = new System.Drawing.Size(24, 20);
            this.lbline6.TabIndex = 533;
            this.lbline6.Text = "0";
            this.lbline6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblineSum
            // 
            this.lblineSum.AutoSize = true;
            this.TransMain.SetDecoration(this.lblineSum, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lblineSum, BunifuAnimatorNS.DecorationType.None);
            this.lblineSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblineSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.lblineSum.ForeColor = System.Drawing.Color.White;
            this.lblineSum.Location = new System.Drawing.Point(265, 19);
            this.lblineSum.Name = "lblineSum";
            this.lblineSum.Size = new System.Drawing.Size(36, 20);
            this.lblineSum.TabIndex = 534;
            this.lblineSum.Text = "0";
            this.lblineSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BotSettings
            // 
            this.BotSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.BotSettings.BGColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.BotSettings.Controls.Add(this.tableLayoutPanel2);
            this.BotSettings.Curv1 = 1;
            this.BotSettings.Curv2 = 1;
            this.TransMain.SetDecoration(this.BotSettings, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.BotSettings, BunifuAnimatorNS.DecorationType.None);
            this.BotSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.BotSettings.Location = new System.Drawing.Point(0, 0);
            this.BotSettings.MinimumSize = new System.Drawing.Size(136, 50);
            this.BotSettings.Name = "BotSettings";
            this.BotSettings.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.BotSettings.Size = new System.Drawing.Size(314, 185);
            this.BotSettings.TabIndex = 568;
            this.BotSettings.Text = "Bot Settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.Controls.Add(this.lbValueMode, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbMode, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbValueLayout, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbLayout, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbValueStopLess, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbStopLess, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbStopMore, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbValueStopMore, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbValueStopLose, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbStopLose, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbStopWin, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbValueStopWin, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbValueStop, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbStopRound, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbChip, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbValueChip, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbValueBet, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbBet, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbFormula, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbValueFormula, 1, 1);
            this.TransMain.SetDecoration(this.tableLayoutPanel2, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.tableLayoutPanel2, BunifuAnimatorNS.DecorationType.None);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(304, 152);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lbValueMode
            // 
            this.lbValueMode.AutoSize = true;
            this.TransMain.SetDecoration(this.lbValueMode, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbValueMode, BunifuAnimatorNS.DecorationType.None);
            this.lbValueMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValueMode.ForeColor = System.Drawing.Color.White;
            this.lbValueMode.Location = new System.Drawing.Point(260, 0);
            this.lbValueMode.Name = "lbValueMode";
            this.lbValueMode.Size = new System.Drawing.Size(41, 30);
            this.lbValueMode.TabIndex = 30;
            this.lbValueMode.Text = "Value";
            this.lbValueMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbMode
            // 
            this.lbMode.AutoSize = true;
            this.TransMain.SetDecoration(this.lbMode, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbMode, BunifuAnimatorNS.DecorationType.None);
            this.lbMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMode.ForeColor = System.Drawing.Color.White;
            this.lbMode.Location = new System.Drawing.Point(154, 0);
            this.lbMode.Name = "lbMode";
            this.lbMode.Size = new System.Drawing.Size(100, 30);
            this.lbMode.TabIndex = 29;
            this.lbMode.Text = "Mode:";
            this.lbMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbValueLayout
            // 
            this.lbValueLayout.AutoSize = true;
            this.TransMain.SetDecoration(this.lbValueLayout, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbValueLayout, BunifuAnimatorNS.DecorationType.None);
            this.lbValueLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValueLayout.ForeColor = System.Drawing.Color.White;
            this.lbValueLayout.Location = new System.Drawing.Point(109, 0);
            this.lbValueLayout.Name = "lbValueLayout";
            this.lbValueLayout.Size = new System.Drawing.Size(39, 30);
            this.lbValueLayout.TabIndex = 18;
            this.lbValueLayout.Text = "Value";
            this.lbValueLayout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbLayout
            // 
            this.lbLayout.AutoSize = true;
            this.TransMain.SetDecoration(this.lbLayout, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbLayout, BunifuAnimatorNS.DecorationType.None);
            this.lbLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLayout.ForeColor = System.Drawing.Color.White;
            this.lbLayout.Location = new System.Drawing.Point(3, 0);
            this.lbLayout.Name = "lbLayout";
            this.lbLayout.Size = new System.Drawing.Size(100, 30);
            this.lbLayout.TabIndex = 19;
            this.lbLayout.Text = "Layout:";
            this.lbLayout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbValueStopLess
            // 
            this.lbValueStopLess.AutoSize = true;
            this.TransMain.SetDecoration(this.lbValueStopLess, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbValueStopLess, BunifuAnimatorNS.DecorationType.None);
            this.lbValueStopLess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValueStopLess.ForeColor = System.Drawing.Color.White;
            this.lbValueStopLess.Location = new System.Drawing.Point(260, 120);
            this.lbValueStopLess.Name = "lbValueStopLess";
            this.lbValueStopLess.Size = new System.Drawing.Size(41, 32);
            this.lbValueStopLess.TabIndex = 28;
            this.lbValueStopLess.Text = "Value";
            this.lbValueStopLess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStopLess
            // 
            this.lbStopLess.AutoSize = true;
            this.TransMain.SetDecoration(this.lbStopLess, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbStopLess, BunifuAnimatorNS.DecorationType.None);
            this.lbStopLess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStopLess.ForeColor = System.Drawing.Color.White;
            this.lbStopLess.Location = new System.Drawing.Point(154, 120);
            this.lbStopLess.Name = "lbStopLess";
            this.lbStopLess.Size = new System.Drawing.Size(100, 32);
            this.lbStopLess.TabIndex = 27;
            this.lbStopLess.Text = "Stop If Money Less:";
            this.lbStopLess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStopMore
            // 
            this.lbStopMore.AutoSize = true;
            this.TransMain.SetDecoration(this.lbStopMore, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbStopMore, BunifuAnimatorNS.DecorationType.None);
            this.lbStopMore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStopMore.ForeColor = System.Drawing.Color.White;
            this.lbStopMore.Location = new System.Drawing.Point(3, 120);
            this.lbStopMore.Name = "lbStopMore";
            this.lbStopMore.Size = new System.Drawing.Size(100, 32);
            this.lbStopMore.TabIndex = 26;
            this.lbStopMore.Text = "Stop If Money More:";
            this.lbStopMore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbValueStopMore
            // 
            this.lbValueStopMore.AutoSize = true;
            this.TransMain.SetDecoration(this.lbValueStopMore, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbValueStopMore, BunifuAnimatorNS.DecorationType.None);
            this.lbValueStopMore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValueStopMore.ForeColor = System.Drawing.Color.White;
            this.lbValueStopMore.Location = new System.Drawing.Point(109, 120);
            this.lbValueStopMore.Name = "lbValueStopMore";
            this.lbValueStopMore.Size = new System.Drawing.Size(39, 32);
            this.lbValueStopMore.TabIndex = 9;
            this.lbValueStopMore.Text = "Value";
            this.lbValueStopMore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbValueStopLose
            // 
            this.lbValueStopLose.AutoSize = true;
            this.TransMain.SetDecoration(this.lbValueStopLose, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbValueStopLose, BunifuAnimatorNS.DecorationType.None);
            this.lbValueStopLose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValueStopLose.ForeColor = System.Drawing.Color.White;
            this.lbValueStopLose.Location = new System.Drawing.Point(260, 90);
            this.lbValueStopLose.Name = "lbValueStopLose";
            this.lbValueStopLose.Size = new System.Drawing.Size(41, 30);
            this.lbValueStopLose.TabIndex = 8;
            this.lbValueStopLose.Text = "Value";
            this.lbValueStopLose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStopLose
            // 
            this.lbStopLose.AutoSize = true;
            this.TransMain.SetDecoration(this.lbStopLose, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbStopLose, BunifuAnimatorNS.DecorationType.None);
            this.lbStopLose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStopLose.ForeColor = System.Drawing.Color.White;
            this.lbStopLose.Location = new System.Drawing.Point(154, 90);
            this.lbStopLose.Name = "lbStopLose";
            this.lbStopLose.Size = new System.Drawing.Size(100, 30);
            this.lbStopLose.TabIndex = 25;
            this.lbStopLose.Text = "Stop If Lossing:";
            this.lbStopLose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStopWin
            // 
            this.lbStopWin.AutoSize = true;
            this.TransMain.SetDecoration(this.lbStopWin, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbStopWin, BunifuAnimatorNS.DecorationType.None);
            this.lbStopWin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStopWin.ForeColor = System.Drawing.Color.White;
            this.lbStopWin.Location = new System.Drawing.Point(3, 90);
            this.lbStopWin.Name = "lbStopWin";
            this.lbStopWin.Size = new System.Drawing.Size(100, 30);
            this.lbStopWin.TabIndex = 24;
            this.lbStopWin.Text = "Stop If Wining:";
            this.lbStopWin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbValueStopWin
            // 
            this.lbValueStopWin.AutoSize = true;
            this.TransMain.SetDecoration(this.lbValueStopWin, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbValueStopWin, BunifuAnimatorNS.DecorationType.None);
            this.lbValueStopWin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValueStopWin.ForeColor = System.Drawing.Color.White;
            this.lbValueStopWin.Location = new System.Drawing.Point(109, 90);
            this.lbValueStopWin.Name = "lbValueStopWin";
            this.lbValueStopWin.Size = new System.Drawing.Size(39, 30);
            this.lbValueStopWin.TabIndex = 7;
            this.lbValueStopWin.Text = "Value";
            this.lbValueStopWin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbValueStop
            // 
            this.lbValueStop.AutoSize = true;
            this.TransMain.SetDecoration(this.lbValueStop, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbValueStop, BunifuAnimatorNS.DecorationType.None);
            this.lbValueStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValueStop.ForeColor = System.Drawing.Color.White;
            this.lbValueStop.Location = new System.Drawing.Point(260, 60);
            this.lbValueStop.Name = "lbValueStop";
            this.lbValueStop.Size = new System.Drawing.Size(41, 30);
            this.lbValueStop.TabIndex = 6;
            this.lbValueStop.Text = "Value";
            this.lbValueStop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStopRound
            // 
            this.lbStopRound.AutoSize = true;
            this.TransMain.SetDecoration(this.lbStopRound, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbStopRound, BunifuAnimatorNS.DecorationType.None);
            this.lbStopRound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStopRound.ForeColor = System.Drawing.Color.White;
            this.lbStopRound.Location = new System.Drawing.Point(154, 60);
            this.lbStopRound.Name = "lbStopRound";
            this.lbStopRound.Size = new System.Drawing.Size(100, 30);
            this.lbStopRound.TabIndex = 23;
            this.lbStopRound.Text = "Stop at Round:";
            this.lbStopRound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbChip
            // 
            this.lbChip.AutoSize = true;
            this.TransMain.SetDecoration(this.lbChip, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbChip, BunifuAnimatorNS.DecorationType.None);
            this.lbChip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbChip.ForeColor = System.Drawing.Color.White;
            this.lbChip.Location = new System.Drawing.Point(3, 60);
            this.lbChip.Name = "lbChip";
            this.lbChip.Size = new System.Drawing.Size(100, 30);
            this.lbChip.TabIndex = 22;
            this.lbChip.Text = "Chip Amount:";
            this.lbChip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbValueChip
            // 
            this.lbValueChip.AutoSize = true;
            this.TransMain.SetDecoration(this.lbValueChip, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbValueChip, BunifuAnimatorNS.DecorationType.None);
            this.lbValueChip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValueChip.ForeColor = System.Drawing.Color.White;
            this.lbValueChip.Location = new System.Drawing.Point(109, 60);
            this.lbValueChip.Name = "lbValueChip";
            this.lbValueChip.Size = new System.Drawing.Size(39, 30);
            this.lbValueChip.TabIndex = 5;
            this.lbValueChip.Text = "Value";
            this.lbValueChip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbValueBet
            // 
            this.lbValueBet.AutoSize = true;
            this.TransMain.SetDecoration(this.lbValueBet, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbValueBet, BunifuAnimatorNS.DecorationType.None);
            this.lbValueBet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValueBet.ForeColor = System.Drawing.Color.White;
            this.lbValueBet.Location = new System.Drawing.Point(260, 30);
            this.lbValueBet.Name = "lbValueBet";
            this.lbValueBet.Size = new System.Drawing.Size(41, 30);
            this.lbValueBet.TabIndex = 4;
            this.lbValueBet.Text = "Value";
            this.lbValueBet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbBet
            // 
            this.lbBet.AutoSize = true;
            this.TransMain.SetDecoration(this.lbBet, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbBet, BunifuAnimatorNS.DecorationType.None);
            this.lbBet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBet.ForeColor = System.Drawing.Color.White;
            this.lbBet.Location = new System.Drawing.Point(154, 30);
            this.lbBet.Name = "lbBet";
            this.lbBet.Size = new System.Drawing.Size(100, 30);
            this.lbBet.TabIndex = 21;
            this.lbBet.Text = "Bet System:";
            this.lbBet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbFormula
            // 
            this.lbFormula.AutoSize = true;
            this.TransMain.SetDecoration(this.lbFormula, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbFormula, BunifuAnimatorNS.DecorationType.None);
            this.lbFormula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFormula.ForeColor = System.Drawing.Color.White;
            this.lbFormula.Location = new System.Drawing.Point(3, 30);
            this.lbFormula.Name = "lbFormula";
            this.lbFormula.Size = new System.Drawing.Size(100, 30);
            this.lbFormula.TabIndex = 20;
            this.lbFormula.Text = "Formula:";
            this.lbFormula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbValueFormula
            // 
            this.lbValueFormula.AutoSize = true;
            this.TransMain.SetDecoration(this.lbValueFormula, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this.lbValueFormula, BunifuAnimatorNS.DecorationType.None);
            this.lbValueFormula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbValueFormula.ForeColor = System.Drawing.Color.White;
            this.lbValueFormula.Location = new System.Drawing.Point(109, 30);
            this.lbValueFormula.Name = "lbValueFormula";
            this.lbValueFormula.Size = new System.Drawing.Size(39, 30);
            this.lbValueFormula.TabIndex = 3;
            this.lbValueFormula.Text = "Value";
            this.lbValueFormula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tFivePictureBox1
            // 
            this.tFivePictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.TransSettings.SetDecoration(this.tFivePictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.TransMain.SetDecoration(this.tFivePictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.tFivePictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tFivePictureBox1.Image = global::AutoBaccarat.Properties.Resources.logo;
            this.tFivePictureBox1.Location = new System.Drawing.Point(0, 0);
            this.tFivePictureBox1.Name = "tFivePictureBox1";
            this.tFivePictureBox1.Size = new System.Drawing.Size(719, 40);
            this.tFivePictureBox1.TabIndex = 5;
            this.tFivePictureBox1.Text = "tFivePictureBox1";
            // 
            // FrmBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(719, 686);
            this.Controls.Add(this.panelPage);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelTop2);
            this.TransMain.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.TransSettings.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(735, 835);
            this.MinimumSize = new System.Drawing.Size(415, 535);
            this.Name = "FrmBot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Auto Baccarat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBot_FormClosing);
            this.Load += new System.EventHandler(this.FrmBot_Load);
            this.panelTop2.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.panelStart.ResumeLayout(false);
            this.panelStart.PerformLayout();
            this.panelPage.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.BaccaratScore.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBigRoad)).EndInit();
            this.BotStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
            this.SettingProgram.ResumeLayout(false);
            this.SettingProgram.PerformLayout();
            this.GoodLine.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoodLine)).EndInit();
            this.tableGoodLine.ResumeLayout(false);
            this.tableGoodLine.PerformLayout();
            this.BotSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop2;
        private System.Windows.Forms.Panel panelLeft;
        private TFive_Theme.TFivePictureBox tFivePictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton btnMain;
        private Bunifu.Framework.UI.BunifuFlatButton btnSettings;
        private Bunifu.Framework.UI.BunifuFlatButton btnLogs;
        private System.Windows.Forms.Panel panelMain;
        private TFive.TFiveGroupBox BotStatus;
        private System.Windows.Forms.DataGridView dgvStatus;
        private System.Windows.Forms.Label lblStatus;
        private TFive.TFiveGroupBox BaccaratScore;
        private System.Windows.Forms.DataGridView dgvBigRoad;
        private System.Windows.Forms.Label lbT;
        private System.Windows.Forms.Label lbB;
        private System.Windows.Forms.Label lbP;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddT;
        private System.Windows.Forms.Button btnAddB;
        private System.Windows.Forms.Button btnAddP;
        private TFive.TFiveNotificationNumber numberStatus;
        private Bunifu.Framework.UI.BunifuFlatButton btnStart;
        private System.Windows.Forms.Panel panelStart;
        private BunifuAnimatorNS.BunifuTransition TransSettings;
        private BunifuAnimatorNS.BunifuTransition TransMain;
        public Bunifu.Framework.UI.BunifuCustomDataGrid dgvGoodLine;
        private System.Windows.Forms.Panel panelPage;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnLine;
        private Bunifu.Framework.UI.BunifuFlatButton btnBetSystem;
        private Bunifu.Framework.UI.BunifuFlatButton btnFormula;
        private Bunifu.Framework.UI.BunifuFlatButton btnLayout;
        private TFive.TFiveGroupBox SettingProgram;
        private TFive.TFiveCheckbox cbConfirmClick;
        private TFive.TFiveCheckbox cbInvert;
        private TFive.TFiveComboBox cbLanguages;
        private TFive.TFiveLabel lbLanguages;
        private TFive.TFiveCheckbox cbTopMost;
        private TFive.TFiveCheckbox cbMove;
        private TFive.TFiveGroupBox GoodLine;
        private System.Windows.Forms.TableLayoutPanel tableGoodLine;
        private System.Windows.Forms.Label lbline1;
        private System.Windows.Forms.Label lbline2;
        private System.Windows.Forms.Label lbline3;
        private System.Windows.Forms.Label lbline4;
        private System.Windows.Forms.Label lbline5;
        private System.Windows.Forms.Label lbline6;
        private System.Windows.Forms.Label lblineSum;
        private System.Windows.Forms.Label lbShowLine7;
        private System.Windows.Forms.Label lbShowLine6;
        private System.Windows.Forms.Label lbShowLine5;
        private System.Windows.Forms.Label lbShowLine4;
        private System.Windows.Forms.Label lbShowLine3;
        private System.Windows.Forms.Label lbShowLine2;
        private System.Windows.Forms.Label lbShowLine1;
        private TFive.TFiveGroupBox BotSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbValueStopMore;
        private System.Windows.Forms.Label lbValueStopLose;
        private System.Windows.Forms.Label lbValueStopWin;
        private System.Windows.Forms.Label lbValueStop;
        private System.Windows.Forms.Label lbValueChip;
        private System.Windows.Forms.Label lbValueBet;
        private System.Windows.Forms.Label lbValueFormula;
        private System.Windows.Forms.Label lbValueLayout;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPV1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPV2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPV3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPV4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPV5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPV6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPVSum;
        private System.Windows.Forms.Timer TmDisplay;
        private System.Windows.Forms.Label lbStopLess;
        private System.Windows.Forms.Label lbStopMore;
        private System.Windows.Forms.Label lbStopLose;
        private System.Windows.Forms.Label lbStopWin;
        private System.Windows.Forms.Label lbStopRound;
        private System.Windows.Forms.Label lbChip;
        private System.Windows.Forms.Label lbBet;
        private System.Windows.Forms.Label lbFormula;
        private System.Windows.Forms.Label lbLayout;
        private System.Windows.Forms.Label lbValueMode;
        private System.Windows.Forms.Label lbMode;
        private System.Windows.Forms.Label lbValueStopLess;
        private System.Windows.Forms.Panel panelRight;
        public System.ComponentModel.BackgroundWorker Bots_Normal;
        private System.Windows.Forms.Timer tmTimeRunning;
        public System.ComponentModel.BackgroundWorker Bots_BackGround;
        private System.Windows.Forms.Button button1;
        public Bunifu.Framework.UI.BunifuCustomDataGrid dgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBetSys;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChip;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}
namespace MC_Client
{
    partial class Form_ER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ER));
            this.comboBox_Versions = new System.Windows.Forms.ComboBox();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.button_Path = new System.Windows.Forms.Button();
            this.button_Install = new System.Windows.Forms.Button();
            this.checkBox_Dev = new System.Windows.Forms.CheckBox();
            this.checkBox_Log = new System.Windows.Forms.CheckBox();
            this.checkBox_Biome = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button_SetMenu = new System.Windows.Forms.Button();
            this.button_ToTray = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_OpenOptionalM = new System.Windows.Forms.Button();
            this.checkBox_Fresh = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button_Modpack = new System.Windows.Forms.Button();
            this.ERnotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.Settings_panel = new System.Windows.Forms.Panel();
            this.label_RAM = new System.Windows.Forms.Label();
            this.comboBox_RAM = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox_Pack = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.temp_name = new System.Windows.Forms.Label();
            this.pictureBox_ERlogo = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_version = new System.Windows.Forms.Label();
            this.label_InstalledV = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_OpenMC = new System.Windows.Forms.Button();
            this.pictureBox_PackLogo = new System.Windows.Forms.PictureBox();
            this.Button_panel = new System.Windows.Forms.Panel();
            this.OptionalM_Panel = new System.Windows.Forms.Panel();
            this.CheckedList_OptionalMods = new System.Windows.Forms.CheckedListBox();
            this.panel_Packs = new System.Windows.Forms.Panel();
            this.listBox_Packs = new System.Windows.Forms.ListBox();
            this.Settings_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ERlogo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PackLogo)).BeginInit();
            this.Button_panel.SuspendLayout();
            this.OptionalM_Panel.SuspendLayout();
            this.panel_Packs.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Versions
            // 
            this.comboBox_Versions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Versions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Versions.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.comboBox_Versions.Location = new System.Drawing.Point(94, 14);
            this.comboBox_Versions.Name = "comboBox_Versions";
            this.comboBox_Versions.Size = new System.Drawing.Size(142, 23);
            this.comboBox_Versions.TabIndex = 2;
            this.comboBox_Versions.SelectedIndexChanged += new System.EventHandler(this.comboBox_Versions_SelectedIndexChanged);
            // 
            // textBox_Path
            // 
            this.textBox_Path.Enabled = false;
            this.textBox_Path.Location = new System.Drawing.Point(9, 489);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(198, 20);
            this.textBox_Path.TabIndex = 3;
            this.textBox_Path.Text = "%appdata%\\.minecraft\\ElementalRealms";
            this.textBox_Path.Visible = false;
            // 
            // button_Path
            // 
            this.button_Path.BackColor = System.Drawing.Color.Transparent;
            this.button_Path.Enabled = false;
            this.button_Path.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Path.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.button_Path.Location = new System.Drawing.Point(213, 488);
            this.button_Path.Name = "button_Path";
            this.button_Path.Size = new System.Drawing.Size(25, 25);
            this.button_Path.TabIndex = 4;
            this.button_Path.Text = "..";
            this.button_Path.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Path.UseVisualStyleBackColor = false;
            this.button_Path.Click += new System.EventHandler(this.button_Path_Click);
            // 
            // button_Install
            // 
            this.button_Install.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(147)))), ((int)(((byte)(147)))));
            this.button_Install.Enabled = false;
            this.button_Install.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Install.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F);
            this.button_Install.Location = new System.Drawing.Point(940, 10);
            this.button_Install.Name = "button_Install";
            this.button_Install.Size = new System.Drawing.Size(90, 30);
            this.button_Install.TabIndex = 6;
            this.button_Install.Text = "Install/Update";
            this.button_Install.UseVisualStyleBackColor = false;
            this.button_Install.Click += new System.EventHandler(this.button_Install_Click);
            // 
            // checkBox_Dev
            // 
            this.checkBox_Dev.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_Dev.AutoSize = true;
            this.checkBox_Dev.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Dev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_Dev.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.checkBox_Dev.Location = new System.Drawing.Point(66, 313);
            this.checkBox_Dev.Name = "checkBox_Dev";
            this.checkBox_Dev.Size = new System.Drawing.Size(144, 19);
            this.checkBox_Dev.TabIndex = 7;
            this.checkBox_Dev.Text = "Enable Dev Pack Builds";
            this.checkBox_Dev.UseVisualStyleBackColor = false;
            this.checkBox_Dev.CheckedChanged += new System.EventHandler(this.checkBox_Dev_CheckedChanged);
            // 
            // checkBox_Log
            // 
            this.checkBox_Log.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_Log.AutoSize = true;
            this.checkBox_Log.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Log.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_Log.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.checkBox_Log.Location = new System.Drawing.Point(66, 336);
            this.checkBox_Log.Name = "checkBox_Log";
            this.checkBox_Log.Size = new System.Drawing.Size(117, 19);
            this.checkBox_Log.TabIndex = 8;
            this.checkBox_Log.Text = "Launcher Console";
            this.checkBox_Log.UseVisualStyleBackColor = false;
            this.checkBox_Log.CheckedChanged += new System.EventHandler(this.checkBox_Log_CheckedChanged);
            // 
            // checkBox_Biome
            // 
            this.checkBox_Biome.AccessibleDescription = "";
            this.checkBox_Biome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_Biome.AutoSize = true;
            this.checkBox_Biome.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Biome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_Biome.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.checkBox_Biome.Location = new System.Drawing.Point(66, 290);
            this.checkBox_Biome.Name = "checkBox_Biome";
            this.checkBox_Biome.Size = new System.Drawing.Size(128, 19);
            this.checkBox_Biome.TabIndex = 10;
            this.checkBox_Biome.Text = "Custom Biomes (SP)";
            this.checkBox_Biome.UseVisualStyleBackColor = false;
            this.checkBox_Biome.CheckedChanged += new System.EventHandler(this.checkBox_Biome_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 0;
            this.toolTip1.InitialDelay = 900;
            this.toolTip1.ReshowDelay = 0;
            this.toolTip1.ShowAlways = true;
            // 
            // button_SetMenu
            // 
            this.button_SetMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_SetMenu.BackColor = System.Drawing.Color.Transparent;
            this.button_SetMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_SetMenu.BackgroundImage")));
            this.button_SetMenu.FlatAppearance.BorderSize = 0;
            this.button_SetMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SetMenu.Location = new System.Drawing.Point(4, 15);
            this.button_SetMenu.Name = "button_SetMenu";
            this.button_SetMenu.Size = new System.Drawing.Size(50, 50);
            this.button_SetMenu.TabIndex = 30;
            this.toolTip1.SetToolTip(this.button_SetMenu, "Options");
            this.button_SetMenu.UseVisualStyleBackColor = false;
            this.button_SetMenu.Click += new System.EventHandler(this.button_SetMenu_Click);
            // 
            // button_ToTray
            // 
            this.button_ToTray.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_ToTray.BackColor = System.Drawing.Color.Transparent;
            this.button_ToTray.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_ToTray.BackgroundImage")));
            this.button_ToTray.FlatAppearance.BorderSize = 0;
            this.button_ToTray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ToTray.Location = new System.Drawing.Point(963, 5);
            this.button_ToTray.Name = "button_ToTray";
            this.button_ToTray.Size = new System.Drawing.Size(50, 50);
            this.button_ToTray.TabIndex = 27;
            this.toolTip1.SetToolTip(this.button_ToTray, "Minimize to tray");
            this.button_ToTray.UseVisualStyleBackColor = false;
            this.button_ToTray.Click += new System.EventHandler(this.button_ToTray_Click_1);
            // 
            // button_Close
            // 
            this.button_Close.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Close.BackColor = System.Drawing.Color.Transparent;
            this.button_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Close.BackgroundImage")));
            this.button_Close.FlatAppearance.BorderSize = 0;
            this.button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Close.Location = new System.Drawing.Point(1022, 5);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(50, 50);
            this.button_Close.TabIndex = 29;
            this.toolTip1.SetToolTip(this.button_Close, "Exit");
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_OpenOptionalM
            // 
            this.button_OpenOptionalM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_OpenOptionalM.BackColor = System.Drawing.Color.Transparent;
            this.button_OpenOptionalM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_OpenOptionalM.BackgroundImage")));
            this.button_OpenOptionalM.FlatAppearance.BorderSize = 0;
            this.button_OpenOptionalM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_OpenOptionalM.Location = new System.Drawing.Point(4, 70);
            this.button_OpenOptionalM.Name = "button_OpenOptionalM";
            this.button_OpenOptionalM.Size = new System.Drawing.Size(50, 50);
            this.button_OpenOptionalM.TabIndex = 31;
            this.toolTip1.SetToolTip(this.button_OpenOptionalM, "Optional mods");
            this.button_OpenOptionalM.UseVisualStyleBackColor = false;
            this.button_OpenOptionalM.Click += new System.EventHandler(this.button_OpenOptionalM_Click);
            // 
            // checkBox_Fresh
            // 
            this.checkBox_Fresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox_Fresh.AutoSize = true;
            this.checkBox_Fresh.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Fresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_Fresh.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.checkBox_Fresh.Location = new System.Drawing.Point(66, 359);
            this.checkBox_Fresh.Name = "checkBox_Fresh";
            this.checkBox_Fresh.Size = new System.Drawing.Size(86, 19);
            this.checkBox_Fresh.TabIndex = 11;
            this.checkBox_Fresh.Text = "Clean Install";
            this.checkBox_Fresh.UseVisualStyleBackColor = false;
            this.checkBox_Fresh.CheckedChanged += new System.EventHandler(this.checkBox_Fresh_CheckedChanged);
            // 
            // button_Modpack
            // 
            this.button_Modpack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Modpack.BackColor = System.Drawing.Color.Transparent;
            this.button_Modpack.FlatAppearance.BorderSize = 0;
            this.button_Modpack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Modpack.Font = new System.Drawing.Font("Segoe UI Emoji", 8.5F);
            this.button_Modpack.Location = new System.Drawing.Point(4, 125);
            this.button_Modpack.Name = "button_Modpack";
            this.button_Modpack.Size = new System.Drawing.Size(50, 50);
            this.button_Modpack.TabIndex = 15;
            this.button_Modpack.Text = "Mod pack";
            this.button_Modpack.UseVisualStyleBackColor = false;
            this.button_Modpack.Click += new System.EventHandler(this.button_Modpack_Click);
            // 
            // ERnotifyIcon
            // 
            this.ERnotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ERnotifyIcon.Icon")));
            this.ERnotifyIcon.Click += new System.EventHandler(this.ERnotifyIcon_Click);
            // 
            // Settings_panel
            // 
            this.Settings_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.Settings_panel.Controls.Add(this.label_RAM);
            this.Settings_panel.Controls.Add(this.comboBox_RAM);
            this.Settings_panel.Controls.Add(this.tableLayoutPanel2);
            this.Settings_panel.Controls.Add(this.checkBox_Dev);
            this.Settings_panel.Controls.Add(this.checkBox_Log);
            this.Settings_panel.Controls.Add(this.checkBox_Fresh);
            this.Settings_panel.Controls.Add(this.checkBox_Biome);
            this.Settings_panel.Controls.Add(this.textBox_Path);
            this.Settings_panel.Controls.Add(this.button_Path);
            this.Settings_panel.Location = new System.Drawing.Point(1040, 80);
            this.Settings_panel.Name = "Settings_panel";
            this.Settings_panel.Size = new System.Drawing.Size(260, 520);
            this.Settings_panel.TabIndex = 18;
            // 
            // label_RAM
            // 
            this.label_RAM.AutoSize = true;
            this.label_RAM.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.label_RAM.Location = new System.Drawing.Point(49, 426);
            this.label_RAM.Name = "label_RAM";
            this.label_RAM.Size = new System.Drawing.Size(61, 15);
            this.label_RAM.TabIndex = 17;
            this.label_RAM.Text = "Pack Ram:";
            // 
            // comboBox_RAM
            // 
            this.comboBox_RAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_RAM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_RAM.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.comboBox_RAM.FormattingEnabled = true;
            this.comboBox_RAM.Items.AddRange(new object[] {
            "3"});
            this.comboBox_RAM.Location = new System.Drawing.Point(141, 423);
            this.comboBox_RAM.Name = "comboBox_RAM";
            this.comboBox_RAM.Size = new System.Drawing.Size(63, 23);
            this.comboBox_RAM.TabIndex = 15;
            this.comboBox_RAM.SelectedIndexChanged += new System.EventHandler(this.comboBox_RAM_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(189, 254);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // comboBox_Pack
            // 
            this.comboBox_Pack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Pack.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_Pack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Pack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_Pack.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.comboBox_Pack.FormattingEnabled = true;
            this.comboBox_Pack.Location = new System.Drawing.Point(263, 18);
            this.comboBox_Pack.Name = "comboBox_Pack";
            this.comboBox_Pack.Size = new System.Drawing.Size(174, 23);
            this.comboBox_Pack.TabIndex = 14;
            this.comboBox_Pack.SelectedIndexChanged += new System.EventHandler(this.comboBox_Pack_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 80);
            this.panel2.TabIndex = 19;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 190F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Controls.Add(this.comboBox_Pack, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_ToTray, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Close, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.temp_name, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_ERlogo, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1087, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseDown);
            this.tableLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseMove);
            this.tableLayoutPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseUp);
            // 
            // temp_name
            // 
            this.temp_name.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.temp_name.AutoSize = true;
            this.temp_name.BackColor = System.Drawing.Color.Transparent;
            this.temp_name.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temp_name.ForeColor = System.Drawing.Color.SeaShell;
            this.temp_name.Location = new System.Drawing.Point(73, 17);
            this.temp_name.Name = "temp_name";
            this.temp_name.Size = new System.Drawing.Size(179, 25);
            this.temp_name.TabIndex = 15;
            this.temp_name.Text = "Elemental launcher ";
            // 
            // pictureBox_ERlogo
            // 
            this.pictureBox_ERlogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ERlogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_ERlogo.Image")));
            this.pictureBox_ERlogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_ERlogo.MaximumSize = new System.Drawing.Size(64, 64);
            this.pictureBox_ERlogo.MinimumSize = new System.Drawing.Size(64, 64);
            this.pictureBox_ERlogo.Name = "pictureBox_ERlogo";
            this.pictureBox_ERlogo.Size = new System.Drawing.Size(64, 64);
            this.pictureBox_ERlogo.TabIndex = 26;
            this.pictureBox_ERlogo.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.progressBar1.Location = new System.Drawing.Point(0, 528);
            this.progressBar1.Maximum = 1200;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1040, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 24;
            this.progressBar1.Visible = false;
            // 
            // label_version
            // 
            this.label_version.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_version.AutoSize = true;
            this.label_version.BackColor = System.Drawing.Color.Transparent;
            this.label_version.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_version.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_version.Location = new System.Drawing.Point(8, 10);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(80, 25);
            this.label_version.TabIndex = 25;
            this.label_version.Text = "Version:";
            // 
            // label_InstalledV
            // 
            this.label_InstalledV.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_InstalledV.AutoSize = true;
            this.label_InstalledV.BackColor = System.Drawing.Color.Transparent;
            this.label_InstalledV.Font = new System.Drawing.Font("Segoe UI Emoji", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_InstalledV.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label_InstalledV.Location = new System.Drawing.Point(242, 14);
            this.label_InstalledV.Name = "label_InstalledV";
            this.label_InstalledV.Size = new System.Drawing.Size(111, 19);
            this.label_InstalledV.TabIndex = 26;
            this.label_InstalledV.Text = "Installed version:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel1.Controls.Add(this.button_OpenMC);
            this.panel1.Controls.Add(this.label_version);
            this.panel1.Controls.Add(this.label_InstalledV);
            this.panel1.Controls.Add(this.comboBox_Versions);
            this.panel1.Controls.Add(this.button_Install);
            this.panel1.Location = new System.Drawing.Point(0, 550);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 50);
            this.panel1.TabIndex = 28;
            // 
            // button_OpenMC
            // 
            this.button_OpenMC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_OpenMC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.button_OpenMC.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_OpenMC.BackgroundImage")));
            this.button_OpenMC.FlatAppearance.BorderSize = 0;
            this.button_OpenMC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_OpenMC.Location = new System.Drawing.Point(902, 8);
            this.button_OpenMC.Name = "button_OpenMC";
            this.button_OpenMC.Size = new System.Drawing.Size(32, 32);
            this.button_OpenMC.TabIndex = 32;
            this.button_OpenMC.UseVisualStyleBackColor = false;
            this.button_OpenMC.Visible = false;
            this.button_OpenMC.Click += new System.EventHandler(this.button_OpenMC_Click);
            // 
            // pictureBox_PackLogo
            // 
            this.pictureBox_PackLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_PackLogo.Location = new System.Drawing.Point(12, 90);
            this.pictureBox_PackLogo.Name = "pictureBox_PackLogo";
            this.pictureBox_PackLogo.Size = new System.Drawing.Size(240, 240);
            this.pictureBox_PackLogo.TabIndex = 27;
            this.pictureBox_PackLogo.TabStop = false;
            // 
            // Button_panel
            // 
            this.Button_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.Button_panel.Controls.Add(this.button_OpenOptionalM);
            this.Button_panel.Controls.Add(this.button_SetMenu);
            this.Button_panel.Controls.Add(this.button_Modpack);
            this.Button_panel.Location = new System.Drawing.Point(1042, 80);
            this.Button_panel.Name = "Button_panel";
            this.Button_panel.Size = new System.Drawing.Size(57, 183);
            this.Button_panel.TabIndex = 29;
            // 
            // OptionalM_Panel
            // 
            this.OptionalM_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.OptionalM_Panel.Controls.Add(this.CheckedList_OptionalMods);
            this.OptionalM_Panel.Location = new System.Drawing.Point(1040, 80);
            this.OptionalM_Panel.Name = "OptionalM_Panel";
            this.OptionalM_Panel.Size = new System.Drawing.Size(260, 520);
            this.OptionalM_Panel.TabIndex = 30;
            // 
            // CheckedList_OptionalMods
            // 
            this.CheckedList_OptionalMods.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CheckedList_OptionalMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.CheckedList_OptionalMods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckedList_OptionalMods.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F);
            this.CheckedList_OptionalMods.Location = new System.Drawing.Point(63, 15);
            this.CheckedList_OptionalMods.Name = "CheckedList_OptionalMods";
            this.CheckedList_OptionalMods.Size = new System.Drawing.Size(181, 493);
            this.CheckedList_OptionalMods.Sorted = true;
            this.CheckedList_OptionalMods.TabIndex = 0;
            this.CheckedList_OptionalMods.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedList_OptionalMods_ItemCheck);
            // 
            // panel_Packs
            // 
            this.panel_Packs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.panel_Packs.Controls.Add(this.listBox_Packs);
            this.panel_Packs.Location = new System.Drawing.Point(533, 80);
            this.panel_Packs.Name = "panel_Packs";
            this.panel_Packs.Size = new System.Drawing.Size(260, 520);
            this.panel_Packs.TabIndex = 31;
            // 
            // listBox_Packs
            // 
            this.listBox_Packs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.listBox_Packs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.listBox_Packs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_Packs.Font = new System.Drawing.Font("Segoe UI Emoji", 8.25F);
            this.listBox_Packs.FormattingEnabled = true;
            this.listBox_Packs.Location = new System.Drawing.Point(63, 15);
            this.listBox_Packs.Name = "listBox_Packs";
            this.listBox_Packs.Size = new System.Drawing.Size(181, 481);
            this.listBox_Packs.TabIndex = 1;
            // 
            // Form_ER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.panel_Packs);
            this.Controls.Add(this.Button_panel);
            this.Controls.Add(this.OptionalM_Panel);
            this.Controls.Add(this.pictureBox_PackLogo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Settings_panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1100, 600);
            this.MinimumSize = new System.Drawing.Size(1100, 600);
            this.Name = "Form_ER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elemental Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ER_FormClosing);
            this.Load += new System.EventHandler(this.Form_ER_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form_ER_MouseClick);
            this.Settings_panel.ResumeLayout(false);
            this.Settings_panel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ERlogo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PackLogo)).EndInit();
            this.Button_panel.ResumeLayout(false);
            this.OptionalM_Panel.ResumeLayout(false);
            this.panel_Packs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox_Versions;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.Button button_Path;
        private System.Windows.Forms.Button button_Install;
        private System.Windows.Forms.CheckBox checkBox_Dev;
        private System.Windows.Forms.CheckBox checkBox_Log;
        private System.Windows.Forms.CheckBox checkBox_Biome;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox_Fresh;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button_Modpack;
        private System.Windows.Forms.NotifyIcon ERnotifyIcon;
        private System.Windows.Forms.Panel Settings_panel;
        private System.Windows.Forms.ComboBox comboBox_Pack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label temp_name;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_version;
        private System.Windows.Forms.Label label_InstalledV;
        private System.Windows.Forms.PictureBox pictureBox_ERlogo;
        private System.Windows.Forms.PictureBox pictureBox_PackLogo;
        private System.Windows.Forms.ComboBox comboBox_RAM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_ToTray;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_SetMenu;
        private System.Windows.Forms.Label label_RAM;
        private System.Windows.Forms.Panel Button_panel;
        private System.Windows.Forms.Button button_OpenOptionalM;
        private System.Windows.Forms.Panel OptionalM_Panel;
        private System.Windows.Forms.CheckedListBox CheckedList_OptionalMods;
        private System.Windows.Forms.Button button_OpenMC;
        private System.Windows.Forms.Panel panel_Packs;
        private System.Windows.Forms.ListBox listBox_Packs;
    }
}


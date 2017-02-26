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
            this.checkBox_Fresh = new System.Windows.Forms.CheckBox();
            this.checkBox_Timer = new System.Windows.Forms.CheckBox();
            this.textBox1_time = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.comboBox_Pack = new System.Windows.Forms.ComboBox();
            this.button_Modpack = new System.Windows.Forms.Button();
            this.ERnotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_Versions
            // 
            this.comboBox_Versions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Versions.Location = new System.Drawing.Point(63, 47);
            this.comboBox_Versions.Name = "comboBox_Versions";
            this.comboBox_Versions.Size = new System.Drawing.Size(142, 21);
            this.comboBox_Versions.TabIndex = 2;
            this.comboBox_Versions.SelectedIndexChanged += new System.EventHandler(this.comboBox_Versions_SelectedIndexChanged);
            // 
            // textBox_Path
            // 
            this.textBox_Path.Enabled = false;
            this.textBox_Path.Location = new System.Drawing.Point(12, 206);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(312, 20);
            this.textBox_Path.TabIndex = 3;
            this.textBox_Path.Text = "%appdata%\\.minecraft\\ElementalRealms";
            this.textBox_Path.TextChanged += new System.EventHandler(this.textBox_Path_TextChanged);
            // 
            // button_Path
            // 
            this.button_Path.Enabled = false;
            this.button_Path.Location = new System.Drawing.Point(330, 205);
            this.button_Path.Name = "button_Path";
            this.button_Path.Size = new System.Drawing.Size(25, 25);
            this.button_Path.TabIndex = 4;
            this.button_Path.Text = "..";
            this.button_Path.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Path.UseVisualStyleBackColor = true;
            this.button_Path.Click += new System.EventHandler(this.button_Path_Click);
            // 
            // button_Install
            // 
            this.button_Install.Enabled = false;
            this.button_Install.Location = new System.Drawing.Point(215, 48);
            this.button_Install.Name = "button_Install";
            this.button_Install.Size = new System.Drawing.Size(140, 62);
            this.button_Install.TabIndex = 6;
            this.button_Install.Text = "Install/Update";
            this.button_Install.UseVisualStyleBackColor = true;
            this.button_Install.Click += new System.EventHandler(this.button_Install_Click);
            // 
            // checkBox_Dev
            // 
            this.checkBox_Dev.AutoSize = true;
            this.checkBox_Dev.Location = new System.Drawing.Point(46, 115);
            this.checkBox_Dev.Name = "checkBox_Dev";
            this.checkBox_Dev.Size = new System.Drawing.Size(141, 17);
            this.checkBox_Dev.TabIndex = 7;
            this.checkBox_Dev.Text = "Enable Dev Pack Builds";
            this.checkBox_Dev.UseVisualStyleBackColor = true;
            this.checkBox_Dev.CheckedChanged += new System.EventHandler(this.checkBox_Dev_CheckedChanged);
            // 
            // checkBox_Log
            // 
            this.checkBox_Log.AutoSize = true;
            this.checkBox_Log.Location = new System.Drawing.Point(46, 138);
            this.checkBox_Log.Name = "checkBox_Log";
            this.checkBox_Log.Size = new System.Drawing.Size(112, 17);
            this.checkBox_Log.TabIndex = 8;
            this.checkBox_Log.Text = "Launcher Console";
            this.checkBox_Log.UseVisualStyleBackColor = true;
            this.checkBox_Log.CheckedChanged += new System.EventHandler(this.checkBox_Log_CheckedChanged);
            // 
            // checkBox_Biome
            // 
            this.checkBox_Biome.AccessibleDescription = "";
            this.checkBox_Biome.AutoSize = true;
            this.checkBox_Biome.Location = new System.Drawing.Point(46, 92);
            this.checkBox_Biome.Name = "checkBox_Biome";
            this.checkBox_Biome.Size = new System.Drawing.Size(121, 17);
            this.checkBox_Biome.TabIndex = 10;
            this.checkBox_Biome.Text = "Custom Biomes (SP)";
            this.checkBox_Biome.UseVisualStyleBackColor = true;
            this.checkBox_Biome.CheckedChanged += new System.EventHandler(this.checkBox_Biome_CheckedChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 100;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ShowAlways = true;
            // 
            // checkBox_Fresh
            // 
            this.checkBox_Fresh.AutoSize = true;
            this.checkBox_Fresh.Enabled = false;
            this.checkBox_Fresh.Location = new System.Drawing.Point(46, 161);
            this.checkBox_Fresh.Name = "checkBox_Fresh";
            this.checkBox_Fresh.Size = new System.Drawing.Size(83, 17);
            this.checkBox_Fresh.TabIndex = 11;
            this.checkBox_Fresh.Text = "Clean Install";
            this.checkBox_Fresh.UseVisualStyleBackColor = true;
            this.checkBox_Fresh.CheckedChanged += new System.EventHandler(this.checkBox_Fresh_CheckedChanged);
            // 
            // checkBox_Timer
            // 
            this.checkBox_Timer.AutoSize = true;
            this.checkBox_Timer.Location = new System.Drawing.Point(233, 138);
            this.checkBox_Timer.Name = "checkBox_Timer";
            this.checkBox_Timer.Size = new System.Drawing.Size(89, 17);
            this.checkBox_Timer.TabIndex = 12;
            this.checkBox_Timer.Text = "Auto Update:";
            this.checkBox_Timer.UseVisualStyleBackColor = true;
            this.checkBox_Timer.CheckedChanged += new System.EventHandler(this.checkBox_Timer_CheckedChanged);
            // 
            // textBox1_time
            // 
            this.textBox1_time.Location = new System.Drawing.Point(245, 159);
            this.textBox1_time.Name = "textBox1_time";
            this.textBox1_time.Size = new System.Drawing.Size(63, 20);
            this.textBox1_time.TabIndex = 13;
            this.textBox1_time.Text = "30";
            this.textBox1_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1_time.TextChanged += new System.EventHandler(this.textBox1_time_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // comboBox_Pack
            // 
            this.comboBox_Pack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Pack.FormattingEnabled = true;
            this.comboBox_Pack.Location = new System.Drawing.Point(63, 17);
            this.comboBox_Pack.Name = "comboBox_Pack";
            this.comboBox_Pack.Size = new System.Drawing.Size(163, 21);
            this.comboBox_Pack.TabIndex = 14;
            this.comboBox_Pack.SelectedIndexChanged += new System.EventHandler(this.comboBox_Pack_SelectedIndexChanged);
            // 
            // button_Modpack
            // 
            this.button_Modpack.Location = new System.Drawing.Point(233, 17);
            this.button_Modpack.Name = "button_Modpack";
            this.button_Modpack.Size = new System.Drawing.Size(122, 25);
            this.button_Modpack.TabIndex = 15;
            this.button_Modpack.Text = "Add Modpack";
            this.button_Modpack.UseVisualStyleBackColor = true;
            this.button_Modpack.Click += new System.EventHandler(this.button_Modpack_Click);
            // 
            // ERnotifyIcon
            // 
            this.ERnotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ERnotifyIcon.Icon")));
            this.ERnotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ERnotifyIcon_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Pack:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Version:";
            // 
            // Form_ER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 241);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Modpack);
            this.Controls.Add(this.comboBox_Pack);
            this.Controls.Add(this.textBox1_time);
            this.Controls.Add(this.checkBox_Timer);
            this.Controls.Add(this.checkBox_Fresh);
            this.Controls.Add(this.checkBox_Biome);
            this.Controls.Add(this.checkBox_Log);
            this.Controls.Add(this.checkBox_Dev);
            this.Controls.Add(this.button_Install);
            this.Controls.Add(this.button_Path);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.comboBox_Versions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 280);
            this.MinimumSize = new System.Drawing.Size(380, 280);
            this.Name = "Form_ER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elemental Installer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ER_FormClosing);
            this.Load += new System.EventHandler(this.Form_ER_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form_ER_MouseClick);
            this.Resize += new System.EventHandler(this.Form_ER_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_Timer;
        private System.Windows.Forms.TextBox textBox1_time;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox comboBox_Pack;
        private System.Windows.Forms.Button button_Modpack;
        private System.Windows.Forms.NotifyIcon ERnotifyIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


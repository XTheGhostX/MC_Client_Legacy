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
            resources.ApplyResources(this.comboBox_Versions, "comboBox_Versions");
            this.comboBox_Versions.Name = "comboBox_Versions";
            this.comboBox_Versions.SelectedIndexChanged += new System.EventHandler(this.comboBox_Versions_SelectedIndexChanged);
            // 
            // textBox_Path
            // 
            resources.ApplyResources(this.textBox_Path, "textBox_Path");
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.TextChanged += new System.EventHandler(this.textBox_Path_TextChanged);
            // 
            // button_Path
            // 
            resources.ApplyResources(this.button_Path, "button_Path");
            this.button_Path.Name = "button_Path";
            this.button_Path.UseVisualStyleBackColor = true;
            this.button_Path.Click += new System.EventHandler(this.button_Path_Click);
            // 
            // button_Install
            // 
            resources.ApplyResources(this.button_Install, "button_Install");
            this.button_Install.Name = "button_Install";
            this.button_Install.UseVisualStyleBackColor = true;
            this.button_Install.Click += new System.EventHandler(this.button_Install_Click);
            // 
            // checkBox_Dev
            // 
            resources.ApplyResources(this.checkBox_Dev, "checkBox_Dev");
            this.checkBox_Dev.Name = "checkBox_Dev";
            this.checkBox_Dev.UseVisualStyleBackColor = true;
            this.checkBox_Dev.CheckedChanged += new System.EventHandler(this.checkBox_Dev_CheckedChanged);
            // 
            // checkBox_Log
            // 
            resources.ApplyResources(this.checkBox_Log, "checkBox_Log");
            this.checkBox_Log.Name = "checkBox_Log";
            this.checkBox_Log.UseVisualStyleBackColor = true;
            this.checkBox_Log.CheckedChanged += new System.EventHandler(this.checkBox_Log_CheckedChanged);
            // 
            // checkBox_Biome
            // 
            resources.ApplyResources(this.checkBox_Biome, "checkBox_Biome");
            this.checkBox_Biome.Name = "checkBox_Biome";
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
            resources.ApplyResources(this.checkBox_Fresh, "checkBox_Fresh");
            this.checkBox_Fresh.Name = "checkBox_Fresh";
            this.checkBox_Fresh.UseVisualStyleBackColor = true;
            this.checkBox_Fresh.CheckedChanged += new System.EventHandler(this.checkBox_Fresh_CheckedChanged);
            // 
            // checkBox_Timer
            // 
            resources.ApplyResources(this.checkBox_Timer, "checkBox_Timer");
            this.checkBox_Timer.Name = "checkBox_Timer";
            this.checkBox_Timer.UseVisualStyleBackColor = true;
            this.checkBox_Timer.CheckedChanged += new System.EventHandler(this.checkBox_Timer_CheckedChanged);
            // 
            // textBox1_time
            // 
            resources.ApplyResources(this.textBox1_time, "textBox1_time");
            this.textBox1_time.Name = "textBox1_time";
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
            resources.ApplyResources(this.comboBox_Pack, "comboBox_Pack");
            this.comboBox_Pack.Name = "comboBox_Pack";
            this.comboBox_Pack.SelectedIndexChanged += new System.EventHandler(this.comboBox_Pack_SelectedIndexChanged);
            // 
            // button_Modpack
            // 
            resources.ApplyResources(this.button_Modpack, "button_Modpack");
            this.button_Modpack.Name = "button_Modpack";
            this.button_Modpack.UseVisualStyleBackColor = true;
            this.button_Modpack.Click += new System.EventHandler(this.button_Modpack_Click);
            // 
            // ERnotifyIcon
            // 
            resources.ApplyResources(this.ERnotifyIcon, "ERnotifyIcon");
            this.ERnotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ERnotifyIcon_MouseDoubleClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Form_ER
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.MaximizeBox = false;
            this.Name = "Form_ER";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ER_FormClosing);
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


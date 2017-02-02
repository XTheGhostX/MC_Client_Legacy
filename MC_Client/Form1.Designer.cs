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
            this.button_update = new System.Windows.Forms.Button();
            this.label_time = new System.Windows.Forms.Label();
            this.comboBox_Versions = new System.Windows.Forms.ComboBox();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.button_Path = new System.Windows.Forms.Button();
            this.label_admin = new System.Windows.Forms.Label();
            this.button_Install = new System.Windows.Forms.Button();
            this.checkBox_Dev = new System.Windows.Forms.CheckBox();
            this.checkBox_Log = new System.Windows.Forms.CheckBox();
            this.Log_Box = new System.Windows.Forms.ListBox();
            this.checkBox_Biome = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox_Fresh = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox_Timer = new System.Windows.Forms.CheckBox();
            this.textBox1_time = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // button_update
            // 
            resources.ApplyResources(this.button_update, "button_update");
            this.button_update.Name = "button_update";
            this.toolTip1.SetToolTip(this.button_update, resources.GetString("button_update.ToolTip"));
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_time
            // 
            resources.ApplyResources(this.label_time, "label_time");
            this.label_time.Name = "label_time";
            this.toolTip1.SetToolTip(this.label_time, resources.GetString("label_time.ToolTip"));
            // 
            // comboBox_Versions
            // 
            resources.ApplyResources(this.comboBox_Versions, "comboBox_Versions");
            this.comboBox_Versions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Versions.Name = "comboBox_Versions";
            this.toolTip1.SetToolTip(this.comboBox_Versions, resources.GetString("comboBox_Versions.ToolTip"));
            this.comboBox_Versions.SelectedIndexChanged += new System.EventHandler(this.comboBox_Versions_SelectedIndexChanged);
            // 
            // textBox_Path
            // 
            resources.ApplyResources(this.textBox_Path, "textBox_Path");
            this.textBox_Path.Name = "textBox_Path";
            this.toolTip1.SetToolTip(this.textBox_Path, resources.GetString("textBox_Path.ToolTip"));
            this.textBox_Path.TextChanged += new System.EventHandler(this.textBox_Path_TextChanged);
            // 
            // button_Path
            // 
            resources.ApplyResources(this.button_Path, "button_Path");
            this.button_Path.Name = "button_Path";
            this.toolTip1.SetToolTip(this.button_Path, resources.GetString("button_Path.ToolTip"));
            this.button_Path.UseVisualStyleBackColor = true;
            this.button_Path.Click += new System.EventHandler(this.button_Path_Click);
            // 
            // label_admin
            // 
            resources.ApplyResources(this.label_admin, "label_admin");
            this.label_admin.Name = "label_admin";
            this.toolTip1.SetToolTip(this.label_admin, resources.GetString("label_admin.ToolTip"));
            // 
            // button_Install
            // 
            resources.ApplyResources(this.button_Install, "button_Install");
            this.button_Install.Name = "button_Install";
            this.toolTip1.SetToolTip(this.button_Install, resources.GetString("button_Install.ToolTip"));
            this.button_Install.UseVisualStyleBackColor = true;
            this.button_Install.Click += new System.EventHandler(this.button_Install_Click);
            // 
            // checkBox_Dev
            // 
            resources.ApplyResources(this.checkBox_Dev, "checkBox_Dev");
            this.checkBox_Dev.Name = "checkBox_Dev";
            this.toolTip1.SetToolTip(this.checkBox_Dev, resources.GetString("checkBox_Dev.ToolTip"));
            this.checkBox_Dev.UseVisualStyleBackColor = true;
            this.checkBox_Dev.CheckedChanged += new System.EventHandler(this.checkBox_Dev_CheckedChanged);
            // 
            // checkBox_Log
            // 
            resources.ApplyResources(this.checkBox_Log, "checkBox_Log");
            this.checkBox_Log.Name = "checkBox_Log";
            this.toolTip1.SetToolTip(this.checkBox_Log, resources.GetString("checkBox_Log.ToolTip"));
            this.checkBox_Log.UseVisualStyleBackColor = true;
            this.checkBox_Log.CheckedChanged += new System.EventHandler(this.checkBox_Log_CheckedChanged);
            // 
            // Log_Box
            // 
            resources.ApplyResources(this.Log_Box, "Log_Box");
            this.Log_Box.FormattingEnabled = true;
            this.Log_Box.Name = "Log_Box";
            this.Log_Box.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.toolTip1.SetToolTip(this.Log_Box, resources.GetString("Log_Box.ToolTip"));
            // 
            // checkBox_Biome
            // 
            resources.ApplyResources(this.checkBox_Biome, "checkBox_Biome");
            this.checkBox_Biome.Name = "checkBox_Biome";
            this.toolTip1.SetToolTip(this.checkBox_Biome, resources.GetString("checkBox_Biome.ToolTip"));
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
            this.toolTip1.SetToolTip(this.checkBox_Fresh, resources.GetString("checkBox_Fresh.ToolTip"));
            this.checkBox_Fresh.UseVisualStyleBackColor = true;
            this.checkBox_Fresh.CheckedChanged += new System.EventHandler(this.checkBox_Fresh_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox_Timer
            // 
            resources.ApplyResources(this.checkBox_Timer, "checkBox_Timer");
            this.checkBox_Timer.Name = "checkBox_Timer";
            this.toolTip1.SetToolTip(this.checkBox_Timer, resources.GetString("checkBox_Timer.ToolTip"));
            this.checkBox_Timer.UseVisualStyleBackColor = true;
            this.checkBox_Timer.CheckedChanged += new System.EventHandler(this.checkBox_Timer_CheckedChanged);
            // 
            // textBox1_time
            // 
            resources.ApplyResources(this.textBox1_time, "textBox1_time");
            this.textBox1_time.Name = "textBox1_time";
            this.toolTip1.SetToolTip(this.textBox1_time, resources.GetString("textBox1_time.ToolTip"));
            this.textBox1_time.TextChanged += new System.EventHandler(this.textBox1_time_TextChanged);
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // Form_ER
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1_time);
            this.Controls.Add(this.checkBox_Timer);
            this.Controls.Add(this.checkBox_Fresh);
            this.Controls.Add(this.checkBox_Biome);
            this.Controls.Add(this.Log_Box);
            this.Controls.Add(this.checkBox_Log);
            this.Controls.Add(this.checkBox_Dev);
            this.Controls.Add(this.button_Install);
            this.Controls.Add(this.label_admin);
            this.Controls.Add(this.button_Path);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.comboBox_Versions);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.button_update);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form_ER";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_ER_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.ComboBox comboBox_Versions;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.Button button_Path;
        private System.Windows.Forms.Label label_admin;
        private System.Windows.Forms.Button button_Install;
        private System.Windows.Forms.CheckBox checkBox_Dev;
        private System.Windows.Forms.CheckBox checkBox_Log;
        private System.Windows.Forms.ListBox Log_Box;
        private System.Windows.Forms.CheckBox checkBox_Biome;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox_Fresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_Timer;
        private System.Windows.Forms.TextBox textBox1_time;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}


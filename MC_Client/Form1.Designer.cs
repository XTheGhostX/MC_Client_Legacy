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
            this.button_update.Location = new System.Drawing.Point(151, 9);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(121, 23);
            this.button_update.TabIndex = 0;
            this.button_update.Text = "Check For updates";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(10, 210);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(101, 13);
            this.label_time.TabIndex = 1;
            this.label_time.Text = "Update every x min:";
            // 
            // comboBox_Versions
            // 
            this.comboBox_Versions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Versions.Location = new System.Drawing.Point(151, 38);
            this.comboBox_Versions.Name = "comboBox_Versions";
            this.comboBox_Versions.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Versions.TabIndex = 2;
            this.comboBox_Versions.SelectedIndexChanged += new System.EventHandler(this.comboBox_Versions_SelectedIndexChanged);
            // 
            // textBox_Path
            // 
            this.textBox_Path.Enabled = false;
            this.textBox_Path.Location = new System.Drawing.Point(151, 229);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(92, 20);
            this.textBox_Path.TabIndex = 3;
            this.textBox_Path.Text = "%appdata%\\.minecraft\\ElementalRealms";
            this.textBox_Path.TextChanged += new System.EventHandler(this.textBox_Path_TextChanged);
            // 
            // button_Path
            // 
            this.button_Path.Enabled = false;
            this.button_Path.Location = new System.Drawing.Point(249, 228);
            this.button_Path.Name = "button_Path";
            this.button_Path.Size = new System.Drawing.Size(23, 23);
            this.button_Path.TabIndex = 4;
            this.button_Path.Text = "..";
            this.button_Path.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Path.UseVisualStyleBackColor = true;
            this.button_Path.Click += new System.EventHandler(this.button_Path_Click);
            // 
            // label_admin
            // 
            this.label_admin.AutoSize = true;
            this.label_admin.Enabled = false;
            this.label_admin.Location = new System.Drawing.Point(148, 212);
            this.label_admin.Name = "label_admin";
            this.label_admin.Size = new System.Drawing.Size(137, 13);
            this.label_admin.TabIndex = 5;
            this.label_admin.Text = "To change dir run as Admin";
            // 
            // button_Install
            // 
            this.button_Install.Enabled = false;
            this.button_Install.Location = new System.Drawing.Point(151, 66);
            this.button_Install.Name = "button_Install";
            this.button_Install.Size = new System.Drawing.Size(121, 23);
            this.button_Install.TabIndex = 6;
            this.button_Install.Text = "Install";
            this.button_Install.UseVisualStyleBackColor = true;
            this.button_Install.Click += new System.EventHandler(this.button_Install_Click);
            // 
            // checkBox_Dev
            // 
            this.checkBox_Dev.AutoSize = true;
            this.checkBox_Dev.Location = new System.Drawing.Point(175, 115);
            this.checkBox_Dev.Name = "checkBox_Dev";
            this.checkBox_Dev.Size = new System.Drawing.Size(88, 17);
            this.checkBox_Dev.TabIndex = 7;
            this.checkBox_Dev.Text = "Dev versions";
            this.checkBox_Dev.UseVisualStyleBackColor = true;
            this.checkBox_Dev.CheckedChanged += new System.EventHandler(this.checkBox_Dev_CheckedChanged);
            // 
            // checkBox_Log
            // 
            this.checkBox_Log.AutoSize = true;
            this.checkBox_Log.Location = new System.Drawing.Point(175, 135);
            this.checkBox_Log.Name = "checkBox_Log";
            this.checkBox_Log.Size = new System.Drawing.Size(44, 17);
            this.checkBox_Log.TabIndex = 8;
            this.checkBox_Log.Text = "Log";
            this.checkBox_Log.UseVisualStyleBackColor = true;
            this.checkBox_Log.CheckedChanged += new System.EventHandler(this.checkBox_Log_CheckedChanged);
            // 
            // Log_Box
            // 
            this.Log_Box.FormattingEnabled = true;
            this.Log_Box.Location = new System.Drawing.Point(291, 9);
            this.Log_Box.Name = "Log_Box";
            this.Log_Box.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.Log_Box.Size = new System.Drawing.Size(131, 238);
            this.Log_Box.TabIndex = 9;
            // 
            // checkBox_Biome
            // 
            this.checkBox_Biome.AccessibleDescription = "";
            this.checkBox_Biome.AutoSize = true;
            this.checkBox_Biome.Location = new System.Drawing.Point(175, 95);
            this.checkBox_Biome.Name = "checkBox_Biome";
            this.checkBox_Biome.Size = new System.Drawing.Size(98, 17);
            this.checkBox_Biome.TabIndex = 10;
            this.checkBox_Biome.Text = "Custom Biomes";
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
            this.checkBox_Fresh.Location = new System.Drawing.Point(175, 159);
            this.checkBox_Fresh.Name = "checkBox_Fresh";
            this.checkBox_Fresh.Size = new System.Drawing.Size(82, 17);
            this.checkBox_Fresh.TabIndex = 11;
            this.checkBox_Fresh.Text = "Fresh Install";
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
            this.checkBox_Timer.AutoSize = true;
            this.checkBox_Timer.Location = new System.Drawing.Point(13, 229);
            this.checkBox_Timer.Name = "checkBox_Timer";
            this.checkBox_Timer.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Timer.TabIndex = 12;
            this.checkBox_Timer.UseVisualStyleBackColor = true;
            this.checkBox_Timer.CheckedChanged += new System.EventHandler(this.checkBox_Timer_CheckedChanged);
            // 
            // textBox1_time
            // 
            this.textBox1_time.Location = new System.Drawing.Point(34, 226);
            this.textBox1_time.Name = "textBox1_time";
            this.textBox1_time.Size = new System.Drawing.Size(77, 20);
            this.textBox1_time.TabIndex = 13;
            this.textBox1_time.Text = "30";
            this.textBox1_time.TextChanged += new System.EventHandler(this.textBox1_time_TextChanged);
            // 
            // Form_ER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
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
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form_ER";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elemental Realms Installer";
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


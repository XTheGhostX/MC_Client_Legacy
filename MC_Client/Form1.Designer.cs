namespace MC_Client
{
    partial class Form1
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
            this.button_update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Versions = new System.Windows.Forms.ComboBox();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.button_Path = new System.Windows.Forms.Button();
            this.label_admin = new System.Windows.Forms.Label();
            this.button_Install = new System.Windows.Forms.Button();
            this.checkBox_Dev = new System.Windows.Forms.CheckBox();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Test text";
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
            this.checkBox_Dev.Location = new System.Drawing.Point(184, 95);
            this.checkBox_Dev.Name = "checkBox_Dev";
            this.checkBox_Dev.Size = new System.Drawing.Size(88, 17);
            this.checkBox_Dev.TabIndex = 7;
            this.checkBox_Dev.Text = "Dev versions";
            this.checkBox_Dev.UseVisualStyleBackColor = true;
            this.checkBox_Dev.CheckedChanged += new System.EventHandler(this.checkBox_Dev_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.checkBox_Dev);
            this.Controls.Add(this.button_Install);
            this.Controls.Add(this.label_admin);
            this.Controls.Add(this.button_Path);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.comboBox_Versions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_update);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Versions;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.Button button_Path;
        private System.Windows.Forms.Label label_admin;
        private System.Windows.Forms.Button button_Install;
        private System.Windows.Forms.CheckBox checkBox_Dev;
    }
}


using MySql.Data.MySqlClient;
using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.IO.Compression;
using Microsoft.VisualBasic.FileIO;

namespace MC_Client
{
    public partial class Form_ER : Form
    {
        //Add method of writing and reading custom install 
        public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string Path = AppData+"\\.minecraft\\ElementalRealms";
        public string ERConnectionString = "server=51.255.41.80;uid=ermlpublicread;" +
                "pwd=hmDmxuhheilgKXUWTjzC;database=ElementalRealms_ModdedLauncher;";
        public string MCProfile_Path = AppData + "\\.minecraft\\launcher_profiles.json";
        public string Temp = Path +"\\TMP";
        public string Path_Config = Path + "\\Config";
        public int IsDev = 0;
        public bool IsFresh = true;

        public Form_ER()
        {
            InitializeComponent();
            bool HasAdminPrivliges;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            HasAdminPrivliges = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (HasAdminPrivliges)
            {
                textBox_Path.Enabled = true;
                button_Path.Enabled = true;
                label_admin.Visible = false;
            }
            toolTip1.SetToolTip(checkBox_Biome, "May make Downloading/loading times a lot longer");
            toolTip1.SetToolTip(checkBox_Dev, "May couse crashing and instability");
//ADD CONFIGS
            if (File.Exists(AppData + "\\.minecraft\\ERealms.ini"))
            {
                checkBox_Fresh.Enabled = true;
            }
            else
            {
                checkBox_Fresh.Checked = true;
            }
            if (!File.Exists(MCProfile_Path))
            {
                MessageBox.Show("You must open the Minecraft launcher atleast once before installing the pack", "ERealms user error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_update.Enabled = false;
            button_update.Text = "Loading";
            comboBox_Versions.Text = "";

            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection(ERConnectionString);

            string query = "SELECT * FROM ElementalRealms_ModdedLauncher.Version";
            MySqlCommand cmd = new MySqlCommand(query, conn);


            try
            {
                conn.OpenAsync();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }
            MySqlDataReader dataReader = cmd.ExecuteReader();
            comboBox_Versions.Items.Clear();
            if (IsDev == 1)
            {
                Log_Box.Items.Add("Obtaining Dev pack versions");
                while (dataReader.Read())
                {
                    int Tmp456 = Convert.ToInt32(dataReader["Visable"]);
                    if ((Tmp456 == 1))
                    {
                        comboBox_Versions.Items.Add(dataReader["Version_UID"].ToString());
                        comboBox_Versions.Text = (dataReader["Version_UID"].ToString());
                    }

                }
            }
            else {
        Log_Box.Items.Add("Obtaining pack versions");
                while (dataReader.Read())
                {
                    int Tmp456 = Convert.ToInt32(dataReader["Visable"]);
                    int Tmp455 = Convert.ToInt32(dataReader["Dev"]);

                    if ((Tmp456 == 1) && (Tmp455 == 0)) {
                        comboBox_Versions.Items.Add(dataReader["Version_UID"].ToString());
                        comboBox_Versions.Text = (dataReader["Version_UID"].ToString());
                    }

                }
            }

            if (comboBox_Versions.Text!=null)
            {
        Log_Box.Items.Add("Sucess please select a version");
                button_Install.Enabled = true;
            }

            conn.CloseAsync();
            button_update.Enabled = true;
            button_update.Text = "Check For updates";
        }



        private void comboBox_Versions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void textBox_Path_TextChanged(object sender, EventArgs e)
        {
            
        }
        
        private void button_Path_Click(object sender, EventArgs e)
        {
            
        }

        private void button_Install_Click(object sender, EventArgs e)
        {
            Log_Box.Items.Clear();
            button_Install.Enabled = false;
            comboBox_Versions.Enabled = false;
            button_update.Enabled = false;
            checkBox_Biome.Enabled = false;
            Log_Box.Items.Add("Starting installation");

    //stuff Connection
            MySql.Data.MySqlClient.MySqlConnection conn;
            conn = new MySql.Data.MySqlClient.MySqlConnection(ERConnectionString);
            try
            {
                conn.OpenAsync();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Log_Box.Items.Add(ex.Message);
            }

            string query = "SELECT * FROM ElementalRealms_ModdedLauncher.Version WHERE Version_UID='" + comboBox_Versions.Text+ "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            WebClient webClient = new WebClient();
            Directory.CreateDirectory(Temp);
             
    //stuff Config
                string Temp_ConfigPath = (Temp +"\\"+ comboBox_Versions.Text + "_Config.zip");
            Log_Box.Items.Add("Downloading Configs");
                try
                {
                    webClient.DownloadFile(new Uri("https://github.com/ElementalRealms/MC_Configs/archive/" + comboBox_Versions.Text + ".zip"), Temp_ConfigPath);
                }
                catch (Exception ex)
                {
            Log_Box.Items.Add("Download failed");
                Console.WriteLine("The process failed: {0}", ex.ToString());
                }

                Directory.CreateDirectory(Path_Config);

                string[] Tmp122 = Directory.GetFiles(Path_Config);
                foreach (string filePath in Tmp122)
                {
                        File.Delete(filePath);
                }
                string[] Tmp582 = Directory.GetDirectories(Path_Config);
                foreach (string filePath in Tmp582)
                {
                    var name = new FileInfo(filePath).Name.ToLower();
                    if (name != "terraincontrol")
                    {
                        Directory.Delete(filePath, true);
                    }
                }
            Log_Box.Items.Add("Installing configs");
                Directory.CreateDirectory(Path_Config);
                   ZipFile.ExtractToDirectory(Temp_ConfigPath, Path_Config);
                    File.Delete(Temp_ConfigPath);

                FileSystem.MoveDirectory((Path_Config + "\\MC_Configs-" + comboBox_Versions.Text), Path_Config, true);



            //stuff Biome
            string BiomeLink = "null";
            while (dataReader.Read()){
                BiomeLink = dataReader["Biome"].ToString();
            }
            if (BiomeLink.ToLower() != "null" && checkBox_Biome.Checked ==true)
            {
                Log_Box.Items.Add("Installing Biome configurations");
                //Need A ACTUAL copy if the biome folders
                //(dataReader["Biome"].ToString());
            }


            //stuff Forge

            //Still need to look into how it is installed nowdays :P
            //(dataReader["Forge"].ToString());

            //stuff Scripts

            //Not sure how it handles with custom directories
            //(dataReader["Script"].ToString());

            //stuff Mods

            //Some one else can deal with mods
            //(dataReader["Mods"].ToString());

            //stuff MC launcher profile
            string[] MCP_Text = File.ReadAllLines(MCProfile_Path);

            bool  isERProfile = false;
                for (int currentLine = 3; currentLine <= MCP_Text.Length -1; ++currentLine)
                {
                if (MCP_Text[currentLine].Contains("ERealms"))
                {
                    isERProfile = true;
                }
                if (MCP_Text[currentLine].Contains("\"selectedProfile\""))
                    {
                        MCP_Text[currentLine] = "  \"selectedProfile\": \"ERealms\",";
                    }
                }
            if (IsFresh == true) isERProfile = false;
            if(isERProfile == false)
            {
                int tmp302 = MCP_Text.Length;
                Array.Resize(ref MCP_Text, MCP_Text.Length + 6);
                for(int currentLine =1; currentLine < tmp302-1; ++currentLine)
                {
                    MCP_Text[tmp302 + 6 - currentLine] = MCP_Text[tmp302 - currentLine];
                }
                MCP_Text[2] = "    \"ERealms\": {";
                MCP_Text[3] = "      \"name\": \"ERealms\",";
                string Tmp391 = "      \"gameDir\": \"" + (Path.Replace(@"\", @"\\"))+"\",";
                MCP_Text[4] = Tmp391;
                //Add vorge version!
                MCP_Text[5] = "      \"lastVersionId\": \"1.10.2 - forge1.10.2 - 12.18.2.2151\",";
                MCP_Text[6] = "      \"javaArgs\": \" - Xmx3G - XX:+UseConcMarkSweepGC - XX:+CMSIncrementalMode - XX:-UseAdaptiveSizePolicy - Xmn128M\"";
                MCP_Text[7] = "    },";

            }
                Log_Box.Items.Add("Made ERealms profile");
            File.WriteAllLines(MCProfile_Path,MCP_Text);



            //stuff end
            Directory.Delete(Temp, true);
            conn.CloseAsync();
            button_Install.Enabled = true;
            checkBox_Biome.Enabled = true;
            comboBox_Versions.Enabled = true;
            button_update.Enabled = true;

        }

        private void checkBox_Dev_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Dev.Checked == true)
            {
                IsDev = 1;
            }
            else
            {
                IsDev = 0;
            }
            //Get triggered
            button_update.PerformClick();
        }

        private void checkBox_Log_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_Log.Checked == true)
            {
                this.Width = 450;
            }else
            {
                this.Width = 300;
            }
        }
        //stuff timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            button_update.PerformClick();
        }

        private void checkBox_Timer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Timer.Checked == true)
                timer1.Start();
            else
                timer1.Stop();
        }

        private void textBox1_time_TextChanged(object sender, EventArgs e)
        {
            checkBox_Timer.Checked = false;
            timer1.Interval = int.Parse(textBox1_time.Text)* 60000;
        }
    }
}

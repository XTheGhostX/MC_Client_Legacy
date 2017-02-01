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
        public string Path = AppData+"\\.minecraft\\ElementalRealms";
        public string ERConnectionString = "server=51.255.41.80;uid=ermlpublicread;" +
                "pwd=hmDmxuhheilgKXUWTjzC;database=ElementalRealms_ModdedLauncher;";
        public string MCProfile_Path = AppData + "\\.minecraft\\launcher_profiles.json";
        public string Temp;
        public string Path_Config, Path_mod, Path_Change, Path_Settings;
        public string Installed_Config, Installed_Forge, Installed_Biome, Installed_Script;
        public string[] ModLibName =new string[0];
        public string[] ModLibLink = new string[0];
        public int IsDev = 0;
        public bool IsFresh;
        public string ForgeName="Forge-Name";
        public string MCF_version="1.10.2-forge";
            public string Version_Script = "Script_V";
            public string Version_Biome = "Biome_V";
            public string Version_Cfg = "Config_V";
            public string Version_Forge = "Forge_V";
            public string SList_Mods = "Mods list";
        //if one of you want to just do .add(Value(in config saving)) instead of ER_Settings[Line]=Value
        //You can change it so it uses a list instead of a array
        public string[] ER_Settings;

        public Form_ER()
        {
            string tmp999=Environment.GetEnvironmentVariable("ERealms", EnvironmentVariableTarget.User);
            if (tmp999 != null)
            {
                Path = tmp999;
            }
            Temp = Path + "\\TMP";
            Path_Config = Path + "\\Config";
            Path_mod =Path + "\\mods";
            Path_Settings =Path + "\\ERealms.ini";
            InitializeComponent();

            textBox_Path.Text=Path;
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
            if (File.Exists(Path_Settings))
            {
                checkBox_Fresh.Enabled = true;
            }
            else
            {
                checkBox_Fresh.Checked = true;
                if (!Directory.Exists(Path_mod)) Directory.CreateDirectory(Path_mod);
                File.Create(Path_Settings);
            }
            if (!File.Exists(MCProfile_Path))
            {
                MessageBox.Show("You must open the Minecraft launcher atleast once before installing the pack", "ERealms user error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            ER_Settings = File.ReadAllLines(Path_Settings);
            Array.Resize(ref ER_Settings, ER_Settings.Length + 8);
            string tmp152;
            tmp152 = AfterP(ER_Settings, "Biomes:");
            if (tmp152 != null) checkBox_Biome.Checked = bool.Parse(tmp152);
            //Could change Dev value to be bool but Database
            tmp152 = AfterP(ER_Settings, "IsDev:");
            if (tmp152 != null) checkBox_Dev.Checked = bool.Parse(tmp152);
            tmp152 = AfterP(ER_Settings, "Log:");
            if (tmp152 != null) checkBox_Log.Checked = bool.Parse(tmp152);
            tmp152 = AfterP(ER_Settings, "UpdateChecker:");
            if (tmp152 != null) checkBox_Timer.Checked = bool.Parse(tmp152);
            tmp152 = AfterP(ER_Settings, "UpdateCheckerMin:");
            if (tmp152 != null) textBox1_time.Text = tmp152;
            tmp152 = AfterP(ER_Settings, "Cfg:");
            if (tmp152 != null) Installed_Config = tmp152;
            tmp152 = AfterP(ER_Settings, "Forge:");
            if (tmp152 != null) Installed_Forge = tmp152;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_update.Enabled = false;
            button_update.Text = "Loading";
            comboBox_Versions.Text = "";

            MySqlConnection conn = new MySqlConnection(ERConnectionString);

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

            query = "SELECT * FROM ElementalRealms_ModdedLauncher.Version WHERE Version_UID='" + comboBox_Versions.Text + "'";
            cmd = new MySqlCommand(query, conn);
            dataReader.Close();
            dataReader = cmd.ExecuteReader();

            Log_Box.Items.Add("Obtaining Refrences");
            while (dataReader.Read())
            {
                Version_Script = (dataReader["Script"].ToString());
                Version_Biome = (dataReader["Biome"].ToString());
                Version_Cfg = (dataReader["Config"].ToString());
                Version_Forge = (dataReader["Forge"].ToString());
                SList_Mods = (dataReader["Mods"].ToString());
            }
            Log_Box.Items.Add("Biome version:"+Version_Biome);
            Log_Box.Items.Add("Config version:"+Version_Cfg);
            Log_Box.Items.Add("Forge_Version:"+Version_Forge);
            Log_Box.Items.Add("Version:"+Version_Script);
            //Remove after testing is done
            Log_Box.Items.Add("Mod list:"+SList_Mods);

            if (comboBox_Versions.Text!=null)
            {
        Log_Box.Items.Add("Sucess please select a version");
                button_Install.Enabled = true;
            }

            conn.CloseAsync();
            dataReader.Close();
            button_update.Enabled = true;
            button_update.Text = "Check For updates";
        }


        private void textBox_Path_TextChanged(object sender, EventArgs e)
        {
            textBox_Path.Enabled = false;
            button_Path.Enabled = false;
            //Maybe promp the user if they are absolutley sure
            Path_Change = textBox_Path.Text;
            if(Path != Path_Change){ 
            string text = File.ReadAllText(MCProfile_Path);
            text = text.Replace(Path.Replace(@"\", @"\\"), Path_Change.Replace(@"\", @"\\"));
            File.WriteAllText(MCProfile_Path, text);

                Directory.CreateDirectory(Path);
            FileSystem.MoveDirectory(Path, Path_Change, true);
        }
            Path = Path_Change;
            System.Environment.SetEnvironmentVariable("ERealms", Path_Change, EnvironmentVariableTarget.User);
            textBox_Path.Enabled = true;
            button_Path.Enabled = true;
        }

        private void button_Path_Click(object sender, EventArgs e)
        {
            DialogResult tmp310 = folderBrowserDialog1.ShowDialog();
            if (tmp310 == DialogResult.OK)
            {
                textBox_Path.Enabled = false;
                button_Path.Enabled = false;
                if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                   textBox_Path.Text= folderBrowserDialog1.SelectedPath;

                }
                else
                    MessageBox.Show("Please select a valid install destination", "ERealms user error",
MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Path.Enabled = true;
                button_Path.Enabled = true;
            }

        }

        private void button_Install_Click(object sender, EventArgs e)
        {
            Log_Box.Items.Clear();
            button_Install.Enabled = false;
            comboBox_Versions.Enabled = false;
            button_update.Enabled = false;
            checkBox_Biome.Enabled = false;
            Log_Box.Items.Add("Starting installation");
            if (Directory.Exists(Temp)) FileSystem.DeleteDirectory(Temp, DeleteDirectoryOption.DeleteAllContents);



            WebClient webClient = new WebClient();
            Directory.CreateDirectory(Temp);
            //stuff Config
            if (Version_Cfg != Installed_Config || IsFresh) {
                string Temp_ConfigPath = (Temp + "\\" + Version_Cfg + "_Config.zip");
                Log_Box.Items.Add("Downloading Configs");
                try
                {
                    webClient.DownloadFile(new Uri("https://github.com/ElementalRealms/MC_Configs/archive/" + Version_Cfg + ".zip"), Temp_ConfigPath);
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
                FileSystem.MoveDirectory((Path_Config + "\\MC_Configs-" + Version_Cfg), Path_Config, true);
                ER_Settings[7] = "Cfg:" + Version_Cfg;
            }

            //stuff Biome

            Log_Box.Items.Add("Installing Biome configurations");
            //Deleate biomes instalation if it is not checked
            //Need A ACTUAL copy if the biome folders
            //Using githu DB entry Biome probably getting removed
            //(dataReader["Biome"].ToString());


            //stuff Forge
            if (Version_Forge != Installed_Forge || IsFresh) {
                string Temp_ForgePath = (Temp + "\\" + Version_Forge + "_Forge.zip");
                Log_Box.Items.Add("Downloading Forge");
                try
                {
                    webClient.DownloadFile(new Uri("https://github.com/ElementalRealms/MC_Forge/archive/" + Version_Forge + ".zip"), Temp_ForgePath);
                }
                catch (Exception ex)
                {
                    Log_Box.Items.Add("Download failed");
                    Console.WriteLine("The process failed: {0}", ex.ToString());
                }
                ZipFile.ExtractToDirectory(Temp_ForgePath, Temp);
                string tmp021 = Directory.GetDirectories(Temp + "\\MC_Forge-" + Version_Forge + "\\versions")[0];
                ForgeName = tmp021.Remove(0, tmp021.LastIndexOf(MCF_version));
                FileSystem.MoveDirectory((Temp + "\\MC_Forge-" + Version_Forge), AppData + "\\.minecraft", true);
                ER_Settings[6] = "Forge:" + Version_Forge;
            }

            //stuff Scripts

            //Not sure how it handles with custom directories
            //(dataReader["Script"].ToString());


            //stuff Mods
            MySqlConnection conn = new MySqlConnection(ERConnectionString);
            string query = "SELECT * FROM ElementalRealms_ModdedLauncher.Mods";
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

            Log_Box.Items.Add("Obtaining Mod links");

            int Tmp451 = 0;
            while (dataReader.Read())
            {
                Array.Resize(ref ModLibLink, ModLibLink.Length + 1);
                Array.Resize(ref ModLibName, ModLibName.Length + 1);
                ModLibName[Tmp451] = dataReader["FileName"].ToString();
                ModLibLink[Tmp451] = dataReader["URL"].ToString();
                Tmp451++;
            }


            dataReader.Close();
            conn.CloseAsync();


            Log_Box.Items.Add("Installing Mods...");

            string[] mods = SList_Mods.Split(",".ToCharArray());

            if (!Directory.Exists(Path_mod)) Directory.CreateDirectory(Path_mod);
            if (IsFresh)
            {
                FileSystem.DeleteDirectory(Path_mod, DeleteDirectoryOption.DeleteAllContents);
                Directory.CreateDirectory(Path_mod);
                for (int modNum = 0; modNum <= mods.Length - 1; ++modNum)
                {
                    for (int i = 0; i <= ModLibName.Length - 1; ++i)
                    {
                        if (ModLibName[i] == mods[modNum])
                        {
                            try
                            {
                                webClient.DownloadFile(new Uri(ModLibLink[i]), Path_mod + "\\" + ModLibName[i]);
                            }
                            catch (Exception ex)
                            {
                                Log_Box.Items.Add("Downloading" + ModLibName[i] + " failed..." + ex);
                            }
                        }
                    }
                }
            }
            else
            {
                string[] CurrentMods = Directory.GetFiles(Path_mod);
                for (int modNum = 0; modNum <= CurrentMods.Length - 1; ++modNum)
                {
                    int modsIndex = Array.IndexOf(mods, CurrentMods[modNum].Remove(0, Path_mod.Length + 1));
                    if (modsIndex == -1)
                        File.Delete(CurrentMods[modNum]);
                    else 
                    mods[modsIndex] = null;

                }
                mods = mods.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                for (int modNum = 0; modNum <= mods.Length - 1; ++modNum)
                {
                    for (int i = 0; i <= ModLibName.Length - 1; ++i)
                    {
                        if (ModLibName[i] == mods[modNum])
                        {
                            try
                            {
                                webClient.DownloadFile(new Uri(ModLibLink[i]), Path_mod + "\\" + ModLibName[i]);
                            }
                            catch (Exception ex)
                            {
                                Log_Box.Items.Add("Downloading" + ModLibName[i] + " failed..." + ex);
                            }
                        }
                    }
                }
            }
        

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
            //Finnish isERProfile
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
                MCP_Text[5] = "      \"lastVersionId\": \""+ForgeName+"\",";
                MCP_Text[6] = "      \"javaArgs\": \" -Xmx3G -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -Xmn128M\"";
                MCP_Text[7] = "    },";

            }
                Log_Box.Items.Add("Made ERealms profile");
            File.WriteAllLines(MCProfile_Path,MCP_Text);



            //stuff end
            FileSystem.DeleteDirectory(Temp, DeleteDirectoryOption.DeleteAllContents);
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
            ER_Settings[1] = "IsDev:"+checkBox_Dev.Checked;
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
            ER_Settings[2] = "Log:"+checkBox_Log.Checked;
        }

        private void checkBox_Fresh_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Fresh.Checked)
                IsFresh = true;
            else
                IsFresh = false;
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
            ER_Settings[3] = "UpdateChecker:" + checkBox_Timer.Checked;
        }

        private void textBox1_time_TextChanged(object sender, EventArgs e)
        {
            //Make sure the user is not a idiot(null value, or to big to store)
            checkBox_Timer.Checked = false;
            timer1.Interval = int.Parse(textBox1_time.Text)* 60000;
            ER_Settings[4] = "UpdateCheckerMin:" + textBox1_time.Text;
        }

        private void Form_ER_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllLines(Path_Settings,ER_Settings);
        }

        private void checkBox_Biome_CheckedChanged(object sender, EventArgs e)
        {
            ER_Settings[5] ="Biomes:"+checkBox_Biome.Checked;
        }

        public string AfterP(string[] Arrayy, string word)
        {
            string tmp142=null;
            for (int currentLine = 0; currentLine <= Arrayy.Length - 1; ++currentLine)
            {
                if (Arrayy[currentLine] != null)
                {
                    if (Arrayy[currentLine].Contains(word))
                    {
                        tmp142 = Arrayy[currentLine].Remove(0, word.Length);
                        break;
                    }
                }
            }
            if (tmp142 == null) return null; else return tmp142;
        }
    }
}

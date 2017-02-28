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
using System.Runtime.InteropServices;



namespace MC_Client
{
    public partial class Form_ER : Form
    {
        //Add feedback that the program is installing (Change mouse cursor or something IDK)
        //Add method of writing and reading custom install
        public bool HasAdminPrivliges = (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator); 
        public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public string Path = AppData+"\\.minecraft\\ElementalRealms";
        public string ERConnectionString;
        public string MCProfile_Path = AppData + "\\.minecraft\\launcher_profiles.json";
        public string Temp;
        public string Path_Config, Path_mod, Path_Change, Path_Settings,Path_PackV, Path_Script, Path_Biome, Path_Pack;
        public string Installed_Config, Installed_Forge, Installed_Biome, Installed_Script,Installed_PackV , Pack_Name, Path_Packs, raw_Mod;
        public bool IsRaw = false, IsGit=true;
        public string[] raw_Version = new string[0];
        public string[] ModLibName =new string[0];
        public string[] ModLibLink = new string[0];
        public int IsDev = 0;
        public bool IsFresh;
        string[] Pack_List =new string[0];
        public string ForgeName="Forge-Name";
        public string MCF_version="1.10.2-forge";
        public string Version_Script = "Script_V";
        public string Version_Biome = "Biome_V";
        public string Version_Cfg = "Config_V";
        public string Version_Forge = "Forge_V";
        public string SList_Mods = "Mods list";
        //if one of you want to just do .add(Value(in config saving)) instead of ER_Settings[Line]=Value
        //You can change it so it uses a list instead of a array
        public string[] ER_Settings, Pack_Settings;

        public Form_ER()
        {
            string tmp999=Environment.GetEnvironmentVariable("ERealms", EnvironmentVariableTarget.User);
            if (tmp999 != null)
            {
                Path = tmp999;
            }
            Temp = Path + "\\TMP";
            Path_Pack = Path;
            Path_PackV = Path_Pack + "\\Pack.ini";
            Path_Settings =Path + "\\ERealms.ini";
            Path_Packs = Path + "\\ER_Packs.ini";
            InitializeComponent();
            PackList();

            textBox_Path.Text=Path;
            if (HasAdminPrivliges)
            {
                textBox_Path.Enabled = true;
                button_Path.Enabled = true;
            }
            else
            {
                toolTip1.SetToolTip(textBox_Path, "To change dir Run as admin");
                toolTip1.SetToolTip(button_Path, "To change dir Run as admin");
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
            if (Directory.Exists(Temp)) FileSystem.DeleteDirectory(Temp, DeleteDirectoryOption.DeleteAllContents);
            if (!File.Exists(MCProfile_Path))
            {
                MessageBox.Show("You must open the Minecraft launcher atleast once before installing the pack", "ERealms user error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
            if (!Directory.Exists(Path_Pack)) Directory.CreateDirectory(Path_Pack);
            if (!File.Exists(Path_PackV)) File.Create(Path_PackV).Close();

            ER_Settings = File.ReadAllLines(Path_Settings);
            Pack_Settings = File.ReadAllLines(Path_PackV);
            Array.Resize(ref ER_Settings, 10);
            Array.Resize(ref Pack_Settings, 10);
            string tmp152;

            if ((tmp152= AfterP(ER_Settings, "Biomes:")) != null) checkBox_Biome.Checked = bool.Parse(tmp152);
            //Could change Dev value to be bool but Database
            if ((tmp152= AfterP(ER_Settings, "IsDev:")) != null) checkBox_Dev.Checked = bool.Parse(tmp152);
            if ((tmp152= AfterP(ER_Settings, "Log:")) != null) checkBox_Log.Checked = bool.Parse(tmp152);
            if ((tmp152= AfterP(ER_Settings, "UpdateChecker:")) != null) checkBox_Timer.Checked = bool.Parse(tmp152);
            if ((tmp152= AfterP(ER_Settings, "UpdateCheckerMin:")) != null) textBox1_time.Text = tmp152;
            if ((tmp152= AfterP(Pack_Settings, "Cfg:")) != null) Installed_Config = tmp152;
            if ((tmp152= AfterP(Pack_Settings, "Forge:")) != null) Installed_Forge = tmp152;
            if ((tmp152= AfterP(Pack_Settings, "ForgeName:")) != null) ForgeName = tmp152;
            if ((tmp152= AfterP(Pack_Settings, "Script:")) != null) Installed_Script = tmp152;
            if ((tmp152= AfterP(Pack_Settings, "Biome:")) != null) Installed_Biome = tmp152;
            if ((tmp152= AfterP(Pack_Settings, "Version:")) != null) Installed_PackV = tmp152;


            output_c("Launcher start up successful");
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF060, 0x00000000);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF020, 0x00000000);
        }

        private void CheckV()
        {
            comboBox_Versions.Text = "";
            comboBox_Versions.Items.Clear();
            string tmp119=null;
            if (IsRaw) {
                for (int i=0;i <raw_Version.Length;i++)
                {
                    string[] tmp307 = raw_Version[i].Split('@');
                    if (IsDev == 1)
                        if(Convert.ToInt32(tmp307[5]) == 1)
                        {
                            comboBox_Versions.Items.Add(tmp307[0]);
                            comboBox_Versions.Text = tmp307[0];
                        }

                    else

                        if(Convert.ToInt32(tmp307[5])==1 && Convert.ToInt32(tmp307[6]) == 0)
                        {
                            comboBox_Versions.Items.Add(tmp307[0]);
                            tmp119 = tmp307[0];
                        }
                    comboBox_Versions.Text = tmp119;
                }
            }
            else{
                MySqlConnection conn = new MySqlConnection(ERConnectionString);
                string query = "SELECT * FROM " + Pack_Name + ".Version";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    Console.Write(ex.Message);
                    MessageBox.Show(ex.Message, "ERealms connection error",
       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (IsDev == 1)
                {
                    output_c("Obtaining Dev pack versions");
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
                    output_c("Obtaining pack versions");
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
                conn.CloseAsync();
                dataReader.Close();
            }
            if (comboBox_Versions.Text!=null)
            {
        output_c("Sucess please select a version");
                button_Install.Enabled = true;
            }
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

            if (HasAdminPrivliges)
            {
                textBox_Path.Enabled = true;
                button_Path.Enabled = true;
            }
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
            button_Install.Enabled = false;
            comboBox_Versions.Enabled = false;
            checkBox_Biome.Enabled = false;
            output_c("Starting installation");
            if (Directory.Exists(Temp)) FileSystem.DeleteDirectory(Temp, DeleteDirectoryOption.DeleteAllContents);
            if (!Directory.Exists(Path_Pack)) Directory.CreateDirectory(Path_Pack);
            if (!File.Exists(Path_PackV)) File.Create(Path_PackV);


            WebClient webClient = new WebClient();
            Directory.CreateDirectory(Temp);
            //stuff Config
            if (Version_Cfg != "null")
            {
                if (Version_Cfg != Installed_Config || IsFresh)
                {
                    string Temp_ConfigPath = (Temp + "\\" + Pack_Name + "_Config.zip");
                    output_c("Downloading Configs");
                    try
                    {
                        if (Version_Cfg.Contains("http"))
                        {
                            webClient.DownloadFile(new Uri(Version_Cfg), Temp_ConfigPath);
                            IsGit = false;
                        }
                        else
                        {
                            webClient.DownloadFile(new Uri("https://github.com/" + Pack_Name + "/MC_Configs/archive/" + Version_Cfg + ".zip"), Temp_ConfigPath);
                            IsGit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        output_c("Download failed");
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
                    output_c("Installing configs");
                    Directory.CreateDirectory(Path_Config);
                    ZipFile.ExtractToDirectory(Temp_ConfigPath, Path_Config);
                    if (IsGit)
                        FileSystem.MoveDirectory((Path_Config + "\\MC_Configs-" + Version_Cfg), Path_Config, true);
                    else
                        FileSystem.MoveDirectory((Path_Config + "\\MC_Configs"), Path_Config, true);
                    Pack_Settings[0] = "Cfg:" + Version_Cfg;
                    Installed_Config = Version_Cfg;
                }
            }
            //else FileSystem.DeleteDirectory(Path_Config, DeleteDirectoryOption.DeleteAllContents);

            //stuff Biome
            if (!Directory.Exists(Path_Biome)) Directory.CreateDirectory(Path_Biome);
                if (checkBox_Biome.Checked == true)
                {
                    //Need A ACTUAL copy if the biome folders
                    output_c("Installing Biome configurations");

                if (Version_Biome != Installed_Biome || IsFresh)
                {
                    string Temp_BiomePath = (Temp + "\\" + Pack_Name + "_Biome.zip");
                    output_c("Downloading Biome");
                    try
                    {
                        if (Version_Biome.Contains("http"))
                        {
                            IsGit = false;
                            webClient.DownloadFile(new Uri(Version_Biome), Temp_BiomePath);
                        }
                        else{
                            IsGit = true;
                            webClient.DownloadFile(new Uri("https://github.com/" + Pack_Name + "/MC_Biome/archive/" + Version_Biome + ".zip"), Temp_BiomePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        output_c("Download failed");
                        Console.WriteLine("The process failed: {0}", ex.ToString());
                    }

                    FileSystem.DeleteDirectory(Path_Biome, DeleteDirectoryOption.DeleteAllContents);
                    output_c("Installing scripts");
                    Directory.CreateDirectory(Path_Biome);
                    ZipFile.ExtractToDirectory(Temp_BiomePath, Temp);
                    if(IsGit)
                    FileSystem.MoveDirectory((Temp + "\\MC_Biome-" + Version_Biome), Path_Biome, true);
                    else
                    FileSystem.MoveDirectory((Temp + "\\MC_Biome"), Path_Biome, true);
                    Pack_Settings[1] = "Biome:" + Version_Biome;
                    Installed_Biome = Version_Biome;
                }
            }
                else
                if (Installed_Biome != Version_Biome) FileSystem.DeleteDirectory(Path_Biome, DeleteDirectoryOption.DeleteAllContents);

            


            //stuff Forge
            if (Version_Forge != Installed_Forge || IsFresh) {
                string Temp_ForgePath = (Temp + "\\" + Pack_Name + "_Forge.zip");
                output_c("Downloading Forge");
                try
                {
                    if (Version_Forge.Contains("http"))
                    {
                        IsGit = false;
                        webClient.DownloadFile(new Uri(Version_Forge), Temp_ForgePath);
                    }
                    else{
                        IsGit = true;
                        webClient.DownloadFile(new Uri("https://github.com/" + Pack_Name + "/MC_Forge/archive/" + Version_Forge + ".zip"), Temp_ForgePath);
                    }
                }
                catch (Exception ex)
                {
                    output_c("Download failed");
                    Console.WriteLine("The process failed: {0}", ex.ToString());
                }
                ZipFile.ExtractToDirectory(Temp_ForgePath, Temp);
                string tmp021;
                if (IsGit)
                {
                    tmp021 = Directory.GetDirectories(Temp + "\\MC_Forge-" + Version_Forge + "\\versions")[0];
                    FileSystem.MoveDirectory((Temp + "\\MC_Forge-" + Version_Forge), AppData + "\\.minecraft", true);
                }
                else
                {
                    tmp021 = Directory.GetDirectories(Temp + "\\MC_Forge" + "\\versions")[0];
                    FileSystem.MoveDirectory((Temp + "\\MC_Forge"), AppData + "\\.minecraft", true);
                }
                ForgeName = tmp021.Remove(0, tmp021.LastIndexOf(MCF_version));
                Pack_Settings[2] = "Forge:" + Version_Forge;
                Pack_Settings[3]= "ForgeName:"+ForgeName;
                Installed_Forge = Version_Forge;
            }

            //stuff Scripts
            if (!Directory.Exists(Path_Script)) Directory.CreateDirectory(Path_Script);
            if (Version_Script != "null")
            {
                if (Version_Script != Installed_Script || IsFresh)
                {
                    string Temp_ScriptPath = (Temp + "\\" + Pack_Name + "_Script.zip");
                    output_c("Downloading Configs");
                    try
                    {
                        if (Version_Script.Contains("http"))
                        {
                            IsGit = false;
                            webClient.DownloadFile(new Uri(Version_Script), Temp_ScriptPath);
                        }
                        else{
                            IsGit = true;
                            webClient.DownloadFile(new Uri("https://github.com/" + Pack_Name + "/MC_Script/archive/" + Version_Script + ".zip"), Temp_ScriptPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        output_c("Download failed");
                        Console.WriteLine("The process failed: {0}", ex.ToString());
                    }
                    FileSystem.DeleteDirectory(Path_Script, DeleteDirectoryOption.DeleteAllContents);
                    output_c("Installing scripts");
                    Directory.CreateDirectory(Path_Script);
                    ZipFile.ExtractToDirectory(Temp_ScriptPath, Temp);
                    if(IsGit)
                    FileSystem.MoveDirectory((Temp + "\\MC_Script-" + Version_Script), Path_Script, true);
                    else
                    FileSystem.MoveDirectory((Temp + "\\MC_Script"), Path_Script, true);
                    Pack_Settings[4] = "Script:" + Version_Script;
                    Installed_Script = Version_Script;
                }
            }
            else FileSystem.DeleteDirectory(Path_Script, DeleteDirectoryOption.DeleteAllContents);



            //stuff Mods
            if (IsRaw) {
                string[] tmp129= raw_Mod.Split(',');
                for(int i=0;i< tmp129.Length;i++)
                {
                    Array.Resize(ref ModLibLink, ModLibLink.Length + 1);
                    Array.Resize(ref ModLibName, ModLibName.Length + 1);
                    ModLibLink[i] = tmp129[i].Split('@')[1];
                    ModLibName[i] = tmp129[i].Split('@')[0];
                }
            }
            else {
                MySqlConnection conn = new MySqlConnection(ERConnectionString);
                string query = "SELECT * FROM " + Pack_Name + ".Mods";
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

                output_c("Obtaining Mod links");

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
            }
            


            output_c("Installing Mods...");

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
                                output_c("Downloading " + ModLibName[i]+ " successful");                        
                            }
                            catch (Exception ex)
                            {
                                output_c("Downloading " + ModLibName[i] + " failed..." + ex);
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
                                output_c("Downloading " + ModLibName[i] + " successful");
                            }
                            catch (Exception ex)
                            {
                                output_c("Downloading " + ModLibName[i] + " failed..." + ex);
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
                if (MCP_Text[currentLine].Contains(Pack_Name))
                {
                    isERProfile = true;
                }
                if (MCP_Text[currentLine].Contains("\"selectedProfile\""))
                    {
                        MCP_Text[currentLine] = "  \"selectedProfile\": \""+Pack_Name+"\",";
                    }
                }
            if (IsFresh == true) isERProfile = false;
            //Finnish isERProfile
            int InsertionLine = 0;
            for(int currentLine=InsertionLine;currentLine <= MCP_Text.Length - 1; ++currentLine)
            {
                InsertionLine = currentLine;
                if (MCP_Text[currentLine].Contains("\"profiles\":")) break;
            }
           if(isERProfile == false)
            {
                int tmp302 = MCP_Text.Length;
                Array.Resize(ref MCP_Text, MCP_Text.Length + 14);
                for(int currentLine =InsertionLine-1; currentLine < tmp302; ++currentLine)
                {
                    MCP_Text[(tmp302 + InsertionLine - currentLine)+5] = MCP_Text[tmp302 - currentLine];
                }
                MCP_Text[InsertionLine+ 1] = "    \"ERealms\": {";
                MCP_Text[InsertionLine + 2] = "      \"name\": \"ERealms\",";
                MCP_Text[InsertionLine + 3] = "      \"gameDir\": \"" + (Path_Pack.Replace(@"\", @"\\")) + "\",";
                MCP_Text[InsertionLine + 4] = "      \"lastVersionId\": \""+ForgeName+"\",";
                MCP_Text[InsertionLine + 5] = "      \"javaArgs\": \" -Xmx3G -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -Xmn128M\"";
                MCP_Text[InsertionLine + 6] = "    },";

                output_c("Made ERealms profile");
            }
            File.WriteAllLines(MCProfile_Path,MCP_Text);



            //stuff end
            Pack_Settings[6] = "Version:" + comboBox_Versions.Text;
            output_c("Installation Finished");
            MessageBox.Show("Installation Finished", "Elemental Installer");
            File.WriteAllLines(Path_PackV, Pack_Settings);
            FileSystem.DeleteDirectory(Temp, DeleteDirectoryOption.DeleteAllContents);
            button_Install.Enabled = true;
            if(Version_Biome != "null")
            checkBox_Biome.Enabled = true;
            comboBox_Versions.Enabled = true;

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
            CheckV();
        }

        private void button_Modpack_Click(object sender, EventArgs e)
        {
            var OpenEditText =System.Diagnostics.Process.Start(Path_Packs);
            OpenEditText.WaitForExit();
            PackList();
        }

        private void checkBox_Log_CheckedChanged(object sender, EventArgs e)
        {
            output_c(null);            
            ER_Settings[2] = "Log:"+checkBox_Log.Checked;
            if (!checkBox_Log.Checked) Close();
        }


        private void checkBox_Fresh_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Fresh.Checked)
                IsFresh = true;
            else
                IsFresh = false;
        }

        private void comboBox_Versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsRaw)
            {
                string[] tmp910=new string[9];
                int i;
                for (i = 0; i < raw_Version.Length; i++)
                {
                    tmp910 = raw_Version[i].Split('@');
                    if (tmp910[0] == comboBox_Versions.Text)
                        break;
                }
                Version_Script = tmp910[3];
                Version_Biome = tmp910[2];
                Version_Cfg = tmp910[1];
                Version_Forge = tmp910[4];
                SList_Mods = tmp910[8];
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(ERConnectionString);
                string query = "SELECT * FROM " + Pack_Name + ".Version WHERE Version_UID='" + comboBox_Versions.Text + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);


                try
                {
                    conn.OpenAsync();
                }
                catch (MySqlException ex)
                {
                    Console.Write(ex.Message);
                }
                MySqlDataReader dataReader = cmd.ExecuteReader();

                output_c("Obtaining Refrences");
                while (dataReader.Read())
                {
                    Version_Script = (dataReader["Script"].ToString());
                    Version_Biome = (dataReader["Biome"].ToString());
                    Version_Cfg = (dataReader["Config"].ToString());
                    Version_Forge = (dataReader["Forge"].ToString());
                    SList_Mods = (dataReader["Mods"].ToString());
                }
                dataReader.Close();
                conn.CloseAsync();
            }
            output_c("Version selected");
            output_c("##################");
            output_c(comboBox_Pack.Text+": "+comboBox_Versions.Text);
            output_c("##################");
            output_c("Biome Version:" + Version_Biome);
            output_c("Config version:" + Version_Cfg);
            output_c("Forge Version:" + Version_Forge);
            output_c("Script Version:" + Version_Script);
            output_c("##################");
            if (Version_Biome == "null")
            {
                checkBox_Biome.Checked = false;
                checkBox_Biome.Enabled = false;
                toolTip1.SetToolTip(checkBox_Biome, "This version does not support Custom biomes");
            }
            else
            {
                toolTip1.SetToolTip(checkBox_Biome, "May make Downloading/loading times a lot longer");
                checkBox_Biome.Enabled = true;
            }
        }

        private void Form_ER_MouseClick(object sender, MouseEventArgs e)
        {
            Control control = GetChildAtPoint(e.Location);
            if (control == null) toolTip1.ShowAlways = false;else
            {
                string toolTipString = toolTip1.GetToolTip(control);
                toolTip1.ShowAlways = true;
                toolTip1.Show(toolTipString, control, control.Width / 2, control.Height / 2);
            }
        }

        private void Form_ER_Load(object sender, EventArgs e)
        {
            if (checkBox_Timer.Checked)
            {
                var CWindow = GetConsoleWindow();
                ERnotifyIcon.Visible = true;
                ShowWindow(CWindow, 0);
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
        }

        //temp close button
        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //window movement control 
        private bool mouseDown;
        private Point lastLocation;

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void button_Totray_Click(object sender, EventArgs e)
        {
            Hide();
            ERnotifyIcon.Visible = true;
            ShowWindow(GetConsoleWindow(), 0);
        }

        private void ERnotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            ERnotifyIcon.Visible = false;
            ShowWindow(GetConsoleWindow(), 5);
        }

        
        //stuff timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckV();
            if (comboBox_Versions.Text != Installed_PackV)
                MessageBox.Show(comboBox_Pack.Text + ": " + comboBox_Versions.Text + "\n Is the latest pack version", "ER Pack update");
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
            if(textBox1_time.Text!="")
            try
            {
                timer1.Interval = int.Parse(textBox1_time.Text) * 60000;
                ER_Settings[4] = "UpdateCheckerMin:" + textBox1_time.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form_ER_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllLines(Path_Settings,ER_Settings);
            File.WriteAllLines(Path_PackV, Pack_Settings);
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
        public void PackList()
        {
            Pack_List= new string[0];
            Array.Resize(ref Pack_List, Pack_List.Length + 1);
            Pack_List[0] = "[51.255.41.80][ElementalRealms][ermlpublicread][hmDmxuhheilgKXUWTjzC]";
            if (!File.Exists(Path_Packs)) File.Create(Path_Packs); else
            Pack_List = Pack_List.Concat(File.ReadAllLines(Path_Packs)).ToArray().Where(c => c != null).ToArray();
            comboBox_Pack.Items.Clear();
            for (int i=0;i<Pack_List.Length; i++)
                comboBox_Pack.Items.Add(Pack_List[i].Split('[', ']')[3]);
            comboBox_Pack.Text=Pack_List[0].Split('[', ']')[3];
        }

        private void comboBox_Pack_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pack_Name = comboBox_Pack.Text;
            Path_Pack = Path + "\\" + Pack_Name;
            string[] tmp105 =new string[8];
            int i;
            for(i = 0; i < Pack_List.Length; i++)
            {
                tmp105 = Pack_List[i].Split('[', ']');
                if (tmp105[3] == Pack_Name)
                    break;
            }
            if (tmp105[i] == "raw" || tmp105[i]=="link")
            {
                IsRaw = true;
                if (tmp105[i] == "link")
                {
                    WebClient wc = new WebClient();
                    string webData = wc.DownloadString(tmp105[5]);
                    raw_Version = webData.Split('[', ']')[1].Split(',');
                    raw_Mod = webData.Split('[', ']')[3];
                }
                else
                {
                    raw_Mod = tmp105[7];
                    raw_Version = tmp105[5].Split(',');
                }
            }
            else
            {
                IsRaw = false;
                ERConnectionString = "server=" + tmp105[1] + ";uid=" + tmp105[5] + ";" +
                        "pwd=" + tmp105[7] + ";database=" + tmp105[3] + ";";
            }
            Path_PackV = Path_Pack + "\\Pack.ini";
            Path_Config = Path_Pack + "\\Config";
            Path_Biome = Path_Config + "\\TerrainControl";
            Path_Script = Path_Pack + "\\scripts";
            Path_mod = Path_Pack + "\\mods";
            CheckV();
        }
        public void output_c(string text)
        {
            if(text==null)
            AllocConsole();
            if (checkBox_Log.Checked)
            {
                Console.WriteLine(text);
            }

        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}

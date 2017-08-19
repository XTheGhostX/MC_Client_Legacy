using MySql.Data.MySqlClient;
using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.Devices;
using Octokit;
using System.Diagnostics;

namespace MC_Client
{
    public partial class Form_ER : Form
    {
        //Add feedback that the program is installing (Change mouse cursor or something IDK)
        //Add method of writing and reading custom install
        static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public string Path = AppData + "\\.minecraft\\ElementalRealms";
        public bool HasAdminPrivliges = (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator); 
        public string ERConnectionString;
        public string MCProfile_Path = AppData + "\\.minecraft\\launcher_profiles.json";
        public string Temp;
        public string Path_Config, Path_mod, Path_Change, Path_Settings,Path_PackV, Path_Script, Path_Biome, Path_Pack;
        public string Installed_Config, Installed_Forge, Installed_Biome, Installed_Script,Installed_PackV , Pack_Name, Path_Packs, raw_Mod, Installed_Badge, LastClientVNotification;
        public bool IsRaw = false, IsGit=true, UserSelectedMod=false;
        public string[] raw_Version = new string[0];
        public string[] ModLibName =new string[0];
        public string[] ModLibLink = new string[0];
        public int IsDev = 0;
        public bool IsFresh;
        string[] Pack_List =new string[0];
        public string ForgeName="Forge-Name";
        public string Version_Script = "Script_V";
        public string Version_Biome = "Biome_V";
        public string Version_Cfg = "Config_V";
        public string Version_Forge = "Forge_V";
        public string Version_Badge = "Badge_V";
        public string List_Client = "Client Mod List";
        public string SList_Mods = "Mods List";
        public int PackRAM = 3;
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
            if (File.Exists(AppData + "\\.minecraft\\ER_PathChange.tmp"))
            {
                if (HasAdminPrivliges)
                {
                    Path_Change = File.ReadAllText(AppData + "\\.minecraft\\ER_PathChange.tmp");
                    MessageBox.Show("The Elemental Realms directory is about to update,please be patient this can take a wile and the launcher will not respond while it is updating and MAKE SURE MINECRAFT IS NOT OPEN");
                    if (Path != Path_Change)
                    {
                        string text = File.ReadAllText(MCProfile_Path);
                        text = text.Replace(Path.Replace(@"\", @"\\"), Path_Change.Replace(@"\", @"\\"));
                        File.WriteAllText(MCProfile_Path, text);
                        Directory.CreateDirectory(Path);
                        FileSystem.MoveDirectory(Path, Path_Change, true);
                        File.Delete(AppData + "\\.minecraft\\ER_PathChange.tmp");
                    }
                    Environment.SetEnvironmentVariable("ERealms", Path_Change, EnvironmentVariableTarget.User);
                    Path = Path_Change;
                }
                else
                {
                    MessageBox.Show("Please reopen the launcher as a Admin in order to finnish updating the Directory");
                    this.Close();
                    return;
                }
            }
            Temp = Path + "\\TMP";
            Path_Pack = Path;
            Path_PackV = Path_Pack + "\\Pack.ini";
            Path_Settings = Path + "\\ERealms.ini";
            Path_Packs = Path + "\\ER_Packs.ini";
            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);
            InitializeComponent();
            if (File.Exists(AppData + "\\.minecraft\\launcher.jar")) button_OpenMC.Visible = true;
            PackList();

            textBox_Path.Text=Path;
            if (HasAdminPrivliges)
            {
                button_Path.Enabled = true;
            }
            else
            {
                toolTip1.SetToolTip(textBox_Path, "To change dir Run as admin");
                toolTip1.SetToolTip(button_Path, "To change dir Run as admin");
            }
            toolTip1.SetToolTip(checkBox_Biome, "May make Downloading/loading times a lot longer");
            toolTip1.SetToolTip(checkBox_Dev, "May couse crashing and instability");
            if (!File.Exists(Path_Settings))
            {
                checkBox_Fresh.Checked = true;
                if (!Directory.Exists(Path_mod)) Directory.CreateDirectory(Path_mod);
                File.Create(Path_Settings).Close();
            }
            if (Directory.Exists(Temp)) FileSystem.DeleteDirectory(Temp, DeleteDirectoryOption.DeleteAllContents);
            if (!File.Exists(MCProfile_Path))
            {
                MessageBox.Show("You must open the Minecraft launcher atleast once before installing the pack", "ERealms user error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            if (!Directory.Exists(Path_Pack)) Directory.CreateDirectory(Path_Pack);
            if (!File.Exists(Path_PackV)) File.Create(Path_PackV).Close();

            ER_Settings = File.ReadAllLines(Path_Settings);
            Pack_Settings = File.ReadAllLines(Path_PackV);
            Array.Resize(ref ER_Settings, 10);
            Array.Resize(ref Pack_Settings, 10);
            string tmp152;
            int TotalRAM = int.Parse(((ulong.Parse((new ComputerInfo()).TotalPhysicalMemory.ToString())) / 1073741824).ToString());
            for (int i = 4; i <= TotalRAM; i++)
            {
                comboBox_RAM.Items.Add(i);
            }
            ReloadPackSet();
            if ((tmp152= AfterP(ER_Settings, "Biomes:")) != null) checkBox_Biome.Checked = bool.Parse(tmp152);
            if ((tmp152= AfterP(ER_Settings, "IsDev:")) != null) checkBox_Dev.Checked = bool.Parse(tmp152);
            if ((tmp152= AfterP(ER_Settings, "Log:")) != null) checkBox_Log.Checked = bool.Parse(tmp152);
            if ((tmp152 = AfterP(ER_Settings, "LastClientCheck:")) != null) LastClientVNotification = tmp152;
            label_InstalledV.Text = "Installed version: "+Installed_PackV;
            
            output_c("Launcher start up successful");
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF060, 0x00000000);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF020, 0x00000000);

            
            /*----Does not look good
            //System colors
            panel2.BackColor = SystemColors.WindowFrame;
            BackColor = SystemColors.Control;
            Settings_panel.BackColor = SystemColors.ActiveBorder;
            comboBox_Pack.BackColor =SystemColors.ScrollBar;
            comboBox_Versions.BackColor =SystemColors.ScrollBar;
            progressBar1.BackColor = SystemColors.WindowFrame;
            //text colors
            temp_name.ForeColor = SystemColors.WindowText;
            comboBox_Pack.ForeColor= SystemColors.WindowText;
            button_Modpack.ForeColor= SystemColors.WindowText;
            label_InstalledV.ForeColor= SystemColors.WindowText;
            label_version.ForeColor= SystemColors.WindowText;
            button_Install.ForeColor= SystemColors.WindowText;
            checkBox_Biome.ForeColor= SystemColors.WindowText;
            checkBox_Dev.ForeColor=SystemColors.WindowText;
            checkBox_Fresh.ForeColor= SystemColors.WindowText;
            checkBox_Log.ForeColor= SystemColors.WindowText;
            comboBox_Versions.ForeColor= SystemColors.WindowText;
            textBox1_time.ForeColor= SystemColors.WindowText;
            textBox_Path.ForeColor= SystemColors.WindowText;
            button_Path.ForeColor= SystemColors.WindowText;
            */
            RefreshBadge();
        }
        public void ReloadPackSet()
        {
            string tmp153;
            if ((tmp153 = AfterP(Pack_Settings, "Cfg:")) != null) Installed_Config = tmp153;
            if ((tmp153 = AfterP(Pack_Settings, "Forge:")) != null) Installed_Forge = tmp153;
            if ((tmp153 = AfterP(Pack_Settings, "ForgeName:")) != null) ForgeName = tmp153;
            if ((tmp153 = AfterP(Pack_Settings, "Script:")) != null) Installed_Script = tmp153;
            if ((tmp153 = AfterP(Pack_Settings, "Biome:")) != null) Installed_Biome = tmp153;
            if ((tmp153 = AfterP(Pack_Settings, "Version:")) != null) Installed_PackV = tmp153;
            if ((tmp153 = AfterP(Pack_Settings, "Badge:")) != null) Installed_Badge = tmp153;
            if ((tmp153 = AfterP(Pack_Settings, "RAM:")) != null) comboBox_RAM.Text = tmp153;
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
                catch (MySqlException ex)
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


        private void button_Path_Click(object sender, EventArgs e)
        {
            DialogResult tmp310 = folderBrowserDialog1.ShowDialog();
            if (tmp310 == DialogResult.OK)
            {
                button_Path.Enabled = false;
                if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
                {
                   textBox_Path.Text= folderBrowserDialog1.SelectedPath;
                    Path_Change = textBox_Path.Text;
                    if (!File.Exists(AppData + "\\.minecraft\\ER_PathChange.tmp")) File.Create(AppData + "\\.minecraft\\ER_PathChange.tmp").Close();
                    File.WriteAllText(AppData + "\\.minecraft\\ER_PathChange.tmp", folderBrowserDialog1.SelectedPath);
                    this.Close();
                    return;
                }
                else
                    MessageBox.Show("Please select a valid install destination", "ERealms user error",
MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (HasAdminPrivliges)button_Path.Enabled = true;
        }


        private async void button_Install_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            button_Install.Enabled = false;
            comboBox_Versions.Enabled = false;
            checkBox_Biome.Enabled = false;

            //stuff Mods
            if (IsRaw)
            {
                string[] tmp129 = raw_Mod.Split(',');
                for (int i = 0; i < tmp129.Length; i++)
                {
                    Array.Resize(ref ModLibLink, ModLibLink.Length + 1);
                    Array.Resize(ref ModLibName, ModLibName.Length + 1);
                    ModLibLink[i] = tmp129[i].Split('@')[1];
                    ModLibName[i] = tmp129[i].Split('@')[0];
                }
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(ERConnectionString);
                string query = "SELECT * FROM " + Pack_Name + ".Mods";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                try
                {
                    await conn.OpenAsync();
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
                await conn.CloseAsync();
            }

                output_c("Starting Async installation");
                if (Directory.Exists(Temp))
                    FileSystem.DeleteDirectory(Temp, DeleteDirectoryOption.DeleteAllContents);
                if (!Directory.Exists(Path_Pack))
                    Directory.CreateDirectory(Path_Pack);
                if (!File.Exists(Path_PackV))
                    File.Create(Path_PackV);

                Directory.CreateDirectory(Temp);
                output_c("Installing Mods...");
                //Client mods
                string[] mods = SList_Mods.Split(',').Concat(CheckedList_OptionalMods.CheckedItems.OfType<string>().ToArray()).ToArray();

                progressBar1.Maximum = 0;
                if ((Version_Biome != Installed_Biome || IsFresh) && checkBox_Biome.Checked)        progressBar1.Maximum += 20;
                if (Version_Forge != Installed_Forge || IsFresh)                                    progressBar1.Maximum += 20;
                if ((Version_Script != Installed_Script || IsFresh) && Version_Script != "null")    progressBar1.Maximum += 20;
                if ((Version_Badge != Installed_Badge || IsFresh) && Version_Badge != "null")       progressBar1.Maximum += 20;
                if ((Version_Cfg != Installed_Config || IsFresh) && Version_Cfg != "null")          progressBar1.Maximum += 20;

                //stuff Mods
                if (!Directory.Exists(Path_mod))
                    Directory.CreateDirectory(Path_mod);

                Task[] ModTasks;
                Task[] OtherTasks = new Task[5];

                if (IsFresh)
                {
                    FileSystem.DeleteDirectory(Path_mod, DeleteDirectoryOption.DeleteAllContents);
                    Directory.CreateDirectory(Path_mod);
                    ModTasks = new Task[mods.Length];
                    progressBar1.Maximum += mods.Length;
                    for (int modNum = 0; modNum <= mods.Length - 1; ++modNum)
                    {
                        for (int i = 0; i <= ModLibName.Length - 1; ++i)
                        {
                            if (ModLibName[i] == mods[modNum])
                            {
                                ModTasks[modNum] =
                                 new AsyncMod().DownloadMod(ModLibLink[i], ModLibName[i]);
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
                        {
                            File.Delete(CurrentMods[modNum]);
                            output_c("Deleated: " + CurrentMods[modNum].Remove(0, Path_mod.Length + 1));
                        }
                        else
                            mods[modsIndex] = null;

                    }
                    mods = mods.Where(s => !string.IsNullOrEmpty(s)).ToArray();
                    progressBar1.Maximum += mods.Length;
                    ModTasks = new Task[mods.Length];
                    if (mods.Length == 0)
                    {
                        output_c("No mods to install");
                    }else
                    for (int modNum = 0; modNum <= mods.Length - 1; ++modNum)
                    {
                        for (int i = 0; i <= ModLibName.Length - 1; ++i)
                        {
                            if (ModLibName[i] == mods[modNum])
                            {
                                ModTasks[modNum]=
                                 new AsyncMod().DownloadMod(ModLibLink[i], ModLibName[i]);
                            }
                        }
                    }
                }

                //stuff Config
                if (Version_Cfg != "null")
                {
                    if (Version_Cfg != Installed_Config || IsFresh)
                    {
                        OtherTasks[0] =
                            new AsyncMod().DownloadConfig();
                    }
                }
                //stuff Biome
                if (!Directory.Exists(Path_Biome)) Directory.CreateDirectory(Path_Biome);
                if (checkBox_Biome.Checked == true)
                {
                    if (Version_Biome != Installed_Biome || IsFresh)
                    {
                        OtherTasks[1] =
                            new AsyncMod().DownloadBiome();
                    }
                }
                else
                if (Installed_Biome != Version_Biome) FileSystem.DeleteDirectory(Path_Biome, DeleteDirectoryOption.DeleteAllContents);


                //stuff Forge
                if (Version_Forge != Installed_Forge || IsFresh)
                {
                    OtherTasks[2] =
                        new AsyncMod().DownloadForge();
                }

                //stuff Scripts
                if (!Directory.Exists(Path_Script)) Directory.CreateDirectory(Path_Script);
                if (Version_Script != "null")
                {
                    if (Version_Script != Installed_Script || IsFresh)
                    {
                        OtherTasks[3] =
                            new AsyncMod().DownloadScripts();
                    }
                }
                else FileSystem.DeleteDirectory(Path_Script, DeleteDirectoryOption.DeleteAllContents);

                //stuff Badge
                if (Version_Badge != "null")
                {
                    if (Version_Badge != Installed_Badge || IsFresh)
                    {
                        OtherTasks[4] =
                            new AsyncMod().DownloadBadge();
                    }
                }
                await Task.WhenAll(ModTasks.Concat((OtherTasks.Where(t => t != null).ToArray())));

            //stuff MC launcher profile
            string[] MCP_Text = File.ReadAllLines(MCProfile_Path);

            bool isERProfile = false;
            for (int currentLine = 3; currentLine <= MCP_Text.Length - 1; ++currentLine)
            {
                if (MCP_Text[currentLine].Contains(Pack_Name)) isERProfile = true;
                if (MCP_Text[currentLine].Contains("\"selectedProfile\""))
                {
                    MCP_Text[currentLine] = "  \"selectedProfile\": \"" + Pack_Name + "\",";
                }
            }
            //Finnish isERProfile
            int InsertionLine = 0;
            for (int currentLine = InsertionLine; currentLine <= MCP_Text.Length - 1; ++currentLine)
            {
                InsertionLine = currentLine;
                if (MCP_Text[currentLine].Contains("\"profiles\": {}"))
                {
                    MCP_Text[InsertionLine] = "    \"profiles\": {";
                    List<string> tmp910 = MCP_Text.ToList();
                    tmp910.Insert(InsertionLine + 1, "    \"" + Pack_Name + "\": {");
                    tmp910.Insert(InsertionLine + 2, "      \"name\": \"" + Pack_Name + "\",");
                    tmp910.Insert(InsertionLine + 3, "      \"gameDir\": \"" + (Path_Pack.Replace(@"\", @"\\")) + "\",");
                    tmp910.Insert(InsertionLine + 4, "      \"lastVersionId\": \"" + ForgeName + "\",");
                    tmp910.Insert(InsertionLine + 5, "      \"javaArgs\": \" -Xmx" + PackRAM + "G -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -Xmn128M\"");
                    tmp910.Insert(InsertionLine + 6, "    }");
                    tmp910.Insert(InsertionLine + 7, "  },");
                    MCP_Text = tmp910.ToArray();
                    output_c("Made ERealms profile");
                    isERProfile = true;
                    break;
                }
                else
                if (MCP_Text[currentLine].Contains("\"profiles\":")) break;
            }
            if (!isERProfile)
            {
                List<string> tmp010 = MCP_Text.ToList();
                tmp010.Insert(InsertionLine + 1, "    \"" + Pack_Name + "\": {");
                tmp010.Insert(InsertionLine + 2, "      \"name\": \"" + Pack_Name + "\",");
                tmp010.Insert(InsertionLine + 3, "      \"gameDir\": \"" + (Path_Pack.Replace(@"\", @"\\")) + "\",");
                tmp010.Insert(InsertionLine + 4, "      \"lastVersionId\": \"" + ForgeName + "\",");
                tmp010.Insert(InsertionLine + 5, "      \"javaArgs\": \" -Xmx" + PackRAM + "G -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -Xmn128M\"");
                tmp010.Insert(InsertionLine + 6, "    },");
                MCP_Text = tmp010.ToArray();
                output_c("Made ERealms profile");
            }
            else
            {
                for (int currentLine = 3; currentLine <= MCP_Text.Length - 1; ++currentLine)
                {
                    if (MCP_Text[currentLine].Contains("\"" + Pack_Name + "\": {"))
                    {
                        MCP_Text[currentLine + 2] = "      \"gameDir\": \"" + (Path_Pack.Replace(@"\", @"\\")) + "\",";
                        MCP_Text[currentLine + 3] = "      \"lastVersionId\": \"" + ForgeName + "\",";
                        if (MCP_Text[currentLine + 5].Contains("},"))
                            MCP_Text[currentLine + 4] = "      \"javaArgs\": \" -Xmx" + PackRAM + "G -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -Xmn128M\"";
                        else
                            MCP_Text[currentLine + 4] = "      \"javaArgs\": \" -Xmx" + PackRAM + "G -XX:+UseConcMarkSweepGC -XX:+CMSIncrementalMode -XX:-UseAdaptiveSizePolicy -Xmn128M\",";
                        break;
                    }
                }
            }
            File.WriteAllLines(MCProfile_Path, MCP_Text);

            //ClassCacheTweaker Support
            if (File.Exists(Path_Pack + "\\" + "classCache.dat")) File.Delete(Path_Pack + "\\" + "classCache.dat");
            //stuff end
            Installed_PackV = comboBox_Versions.Text;
            label_InstalledV.Text = "Installed version: " + Installed_PackV;
            Pack_Settings[6] = "Version:" + Installed_PackV;
            output_c("Installation Finished");
            File.WriteAllLines(Path_PackV, Pack_Settings);
            FileSystem.DeleteDirectory(Temp, DeleteDirectoryOption.DeleteAllContents);

            button_Install.Enabled = true;
            if (Version_Biome != "null")
                checkBox_Biome.Enabled = true;
            comboBox_Versions.Enabled = true;
            progressBar1.Visible = false;
            checkBox_Fresh.Checked = false;
            MessageBox.Show("Installation Finished", "Elemental Installer");
        }
        private void EndInstall()
        {

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
                Version_Badge = tmp910[7];
                Version_Script = tmp910[3];
                Version_Biome = tmp910[2];
                Version_Cfg = tmp910[1];
                Version_Forge = tmp910[4];
                SList_Mods = tmp910[8];
                List_Client = tmp910[9];
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
                    Version_Badge = (dataReader["Badge"].ToString());
                    Version_Script = (dataReader["Script"].ToString());
                    Version_Biome = (dataReader["Biome"].ToString());
                    Version_Cfg = (dataReader["Config"].ToString());
                    Version_Forge = (dataReader["Forge"].ToString());
                    SList_Mods = (dataReader["Mods"].ToString());
                    List_Client = (dataReader["Client"].ToString());
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
            output_c("Badge Version:" + Version_Badge);
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
            
            if (List_Client == "null")
            {
                CheckedList_OptionalMods.Enabled = false;
                button_OpenOptionalM.Visible = false;
                CheckedList_OptionalMods.Items.Clear();
            }
            else
            {
                CheckedList_OptionalMods.Enabled = true;
                button_OpenOptionalM.Visible = true;
                CheckedList_OptionalMods.Items.Clear();
                CheckedList_OptionalMods.Items.AddRange(List_Client.Split(','));
                //DEV Load checked mods/ Custom ones
                UserSelectedMod = false;
                if (File.Exists(Path_Pack + "\\OptionalMods.list"))
                {
                    string[] LoadOptionalMods = File.ReadAllText(Path_Pack + "\\OptionalMods.list").Split(',');
                    for (int modNum = 0; modNum <= LoadOptionalMods.Length - 1; ++modNum)
                    {
                        for (int i = 0; i <= CheckedList_OptionalMods.Items.Count - 1; i++)
                        {
                            if (LoadOptionalMods[modNum] == CheckedList_OptionalMods.Items.OfType<string>().ToArray()[i])
                            {
                                CheckedList_OptionalMods.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
            UserSelectedMod = true;
            RefreshBadge();
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
            try
            {
                var MC_client = new GitHubClient(new ProductHeaderValue("Elemental_Client")).Repository.Release.GetLatest("ElementalRealms", "MC_Client");
                string LatestVersion = MC_client.Result.TagName;

                if (LastClientVNotification != LatestVersion)
                {
                    ER_Settings[6] = "LastClientCheck:" + LatestVersion;
                    File.WriteAllLines(Path_Settings, ER_Settings);
                    if (MessageBox.Show(MC_client.Result.Name + ":/n"+MC_client.Result.Body + "\n Open releases?",
                        "Update Notification",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                        System.Diagnostics.Process.Start("https://github.com/ElementalRealms/MC_Client/releases");
                }
            }
            catch (AggregateException) { }
        }

        //window movement control 
        private bool mouseDown;
        private Point lastLocation;

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }


        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void tableLayoutPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void ERnotifyIcon_Click(object sender, EventArgs e)
        {
            ERnotifyIcon.Visible = false;
            ShowWindow(GetConsoleWindow(), 5);
            Show();
        }

        private void comboBox_RAM_SelectedIndexChanged(object sender, EventArgs e)
        {
            PackRAM = int.Parse(comboBox_RAM.Text);
            Pack_Settings[7] = "RAM:" + PackRAM;
            File.WriteAllLines(Path_PackV, Pack_Settings);
        }

        private void button_Install_MouseEnter(object sender, EventArgs e)
        {
            button_Install.UseVisualStyleBackColor = false;
            button_Install.BackColor = Color.CadetBlue;
        }

        private void button_Install_MouseLeave(object sender, EventArgs e)
        {
            button_Install.BackColor = Color.FromArgb(80, 39, 174, 185);
            button_Install.UseVisualStyleBackColor = true;
        }

        private void button_SetMenu_Click(object sender, EventArgs e)
        {
            Settings_panel.BringToFront();
            Button_panel.BringToFront();
            if (Settings_panel.Location.X == 840)
            {
                OptionsPanelSwitch();
            }
            else
            {
               if(Button_panel.Location.X!=842) OptionsPanelSwitch();
                Settings_panel.Location = new Point(840, Settings_panel.Location.Y);
                OptionalM_Panel.Location = new Point(1040, OptionalM_Panel.Location.Y);
                textBox_Path.Visible = true;
                label_RAM.Visible = true;
            }
        }

        private void button_OpenOptionalM_Click(object sender, EventArgs e)
        {
            OptionalM_Panel.BringToFront();
            Button_panel.BringToFront();
            if (OptionalM_Panel.Location.X == 840)
            {
                OptionsPanelSwitch();
            }
            else
            {
                if (Button_panel.Location.X != 842) OptionsPanelSwitch();
                OptionalM_Panel.Location = new Point(840, OptionalM_Panel.Location.Y);
                Settings_panel.Location = new Point(1040, Settings_panel.Location.Y);
            }
        }

        private void button_OpenMC_Click(object sender, EventArgs e)
        {
            if(File.Exists(AppData + "\\.minecraft\\launcher.jar"))
            Process.Start(AppData + "\\.minecraft\\launcher.jar");
        }

        private void OptionsPanelSwitch()
        {
            if (Button_panel.Location.X == 842)
            {
                Button_panel.Location = new Point(Button_panel.Location.X + 200, Button_panel.Location.Y);
                OptionalM_Panel.Location = new Point(OptionalM_Panel.Location.X + 200, OptionalM_Panel.Location.Y);
                Settings_panel.Location = new Point(Settings_panel.Location.X + 200, Settings_panel.Location.Y);
                button_Install.Location = new Point(button_Install.Location.X + 200, button_Install.Location.Y);
                progressBar1.Size = new Size(progressBar1.Size.Width + 200, progressBar1.Size.Height);
                textBox_Path.Visible = false;
                label_RAM.Visible = false;
            }
            else
            {
                    Button_panel.Location = new Point(Button_panel.Location.X- 200, Button_panel.Location.Y);
                    OptionalM_Panel.Location = new Point(OptionalM_Panel.Location.X- 200, OptionalM_Panel.Location.Y);
                    Settings_panel.Location = new Point(Settings_panel.Location.X - 200, Settings_panel.Location.Y);
                    button_Install.Location = new Point(button_Install.Location.X - 200, button_Install.Location.Y);
                    progressBar1.Size = new Size(progressBar1.Size.Width- 200, progressBar1.Size.Height);
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ToTray_Click_1(object sender, EventArgs e)
        {
            Hide();
            ERnotifyIcon.Visible = true;
            ShowWindow(GetConsoleWindow(), 0);
        }

        private void CheckedList_OptionalMods_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (UserSelectedMod)
            {
                this.BeginInvoke((MethodInvoker)(() => File.WriteAllText(Path_Pack + "\\OptionalMods.list", string.Join(",", CheckedList_OptionalMods.CheckedItems.OfType<string>().ToArray()))));
                output_c("Updated optional mods");
            }
        }


        //end of window move code 
        private void button_Totray_Click(object sender, EventArgs e)
        {
            Hide();
            ERnotifyIcon.Visible = true;
            ShowWindow(GetConsoleWindow(), 0);
        }

        private void Form_ER_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllLines(Path_Settings,ER_Settings);
            if(File.Exists(Path_PackV))
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
            Pack_List[0] = "[db.elementalrealms.net][ElementalRealms][ermlpublicread][hmDmxuhheilgKXUWTjzC]";
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
            if (File.Exists(Path_PackV))
            {
                Pack_Settings = File.ReadAllLines(Path_PackV);
                ReloadPackSet();
                label_InstalledV.Text = "Installed version: " + Installed_PackV;
            }
            else
                label_InstalledV.Text = "No version installed";
            CheckV();
            RefreshBadge();
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

        private void DownloadM(string ModLibLink,string ModLibName)
        {
            try
            {
                using (WebClient webClient =new WebClient()) {
                    webClient.DownloadFile(new Uri(ModLibLink), Path_mod + "\\" + ModLibName);
                    output_c("Downloading " + ModLibName + " successful");
                }
            }
            catch (Exception ex)
            {
                output_c("Downloading " + ModLibName + " failed..." + ex);
            }
        }
        public void RefreshBadge()
        {
            if (File.Exists(Path_Pack + "\\ER_resources\\Background" + Version_Badge + ".png")) BackgroundImage = Image.FromFile(Path_Pack + "\\ER_resources\\Background" + Version_Badge + ".png");
            else BackgroundImage = null;
            if (File.Exists(Path_Pack + "\\ER_resources\\Icon" + Version_Badge + ".png"))
            {
                Image PackLog = Image.FromFile(Path_Pack + "\\ER_resources\\Icon" + Version_Badge + ".png");
                pictureBox_PackLogo.Size = new Size(PackLog.Width, PackLog.Height);
                pictureBox_PackLogo.Image = PackLog;
            }
            else pictureBox_PackLogo.Image = null;
        }

        public void AsyncDone(int Value)
        {
            progressBar1.Increment(Value);
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

using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MC_Client
{
    class AsyncMod
    {
        static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //#######################################################################################################################################
        public async Task DownloadMod(string ModLibLink, string ModLibName)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    await webClient.DownloadFileTaskAsync(new Uri(ModLibLink), Program.erForm.Path_mod + "\\" + ModLibName);
                    Program.erForm.output_c("Downloading " + ModLibName + " successful");
                }
            }
            catch (Exception ex)
            {
                Program.erForm.output_c("Downloading " + ModLibName + " failed...\n" + ex);
                File.Delete(Program.erForm.Path_mod + "\\" + ModLibName);
            }
            Program.erForm.AsyncDone(1);
        }
        //#######################################################################################################################################
        public async Task DownloadConfig()
        {
            string Temp_ConfigPath = (Program.erForm.Temp + "\\" + Program.erForm.Pack_Name + "_Config.zip");
            Program.erForm.output_c("Downloading Configs");
            bool IsGit=true;
            try
            {
                using(WebClient webClient = new WebClient())
                if (Program.erForm.Version_Cfg.Contains("http"))
                {
                    await webClient.DownloadFileTaskAsync(new Uri(Program.erForm.Version_Cfg), Temp_ConfigPath);
                    IsGit = false;
                }
                else
                {
                    await webClient.DownloadFileTaskAsync(new Uri("https://github.com/" + Program.erForm.Pack_Name + "/MC_Configs/archive/" + Program.erForm.Version_Cfg + ".zip"), Temp_ConfigPath);
                    IsGit = true;
                }
            }
            catch (Exception ex)
            {
                Program.erForm.output_c("Config Download failed: "+ ex.ToString());
            }
            Directory.CreateDirectory(Program.erForm.Path_Config);

            string[] Tmp122 = Directory.GetFiles(Program.erForm.Path_Config);
            foreach (string filePath in Tmp122)
            {
                File.Delete(filePath);
            }
            string[] Tmp582 = Directory.GetDirectories(Program.erForm.Path_Config);
            foreach (string filePath in Tmp582)
            {
                var name = new FileInfo(filePath).Name.ToLower();
                if (name != "terraincontrol")
                {
                    Directory.Delete(filePath, true);
                }
            }
            Program.erForm.output_c("Installing configs");
            Directory.CreateDirectory(Program.erForm.Path_Config);
            ZipFile.ExtractToDirectory(Temp_ConfigPath, Program.erForm.Path_Config);
            if (IsGit)
                FileSystem.MoveDirectory((Program.erForm.Path_Config + "\\MC_Configs-" + Program.erForm.Version_Cfg), Program.erForm.Path_Config, true);
            else
                FileSystem.MoveDirectory((Program.erForm.Path_Config + "\\MC_Configs"), Program.erForm.Path_Config, true);
            Program.erForm.Pack_Settings[0] = "Cfg:" + Program.erForm.Version_Cfg;
            Program.erForm.Installed_Config = Program.erForm.Version_Cfg;

            Program.erForm.AsyncDone(20);
        }
        //#######################################################################################################################################
        public async Task DownloadBiome()
        {
            string Temp_BiomePath = (Program.erForm.Temp + "\\" + Program.erForm.Pack_Name + "_Biome.zip");
            Program.erForm.output_c("Downloading Biome");
            bool IsGit = true;
            try
            {
                using(WebClient webClient = new WebClient())
                if (Program.erForm.Version_Biome.Contains("http"))
                {
                    IsGit = false;
                    await webClient.DownloadFileTaskAsync(new Uri(Program.erForm.Version_Biome), Temp_BiomePath);
                }
                else
                {
                    IsGit = true;
                    await webClient.DownloadFileTaskAsync(new Uri("https://github.com/" + Program.erForm.Pack_Name + "/MC_Biome/archive/" + Program.erForm.Version_Biome + ".zip"), Temp_BiomePath);
                }
            }
            catch (Exception ex)
            {
                Program.erForm.output_c("Download failed");
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }

            FileSystem.DeleteDirectory(Program.erForm.Path_Biome, DeleteDirectoryOption.DeleteAllContents);
            Program.erForm.output_c("Installing scripts");
            Directory.CreateDirectory(Program.erForm.Path_Biome);
            ZipFile.ExtractToDirectory(Temp_BiomePath, Program.erForm.Temp);
            if (IsGit)
                FileSystem.MoveDirectory((Program.erForm.Temp + "\\MC_Biome-" + Program.erForm.Version_Biome), Program.erForm.Path_Biome, true);
            else
                FileSystem.MoveDirectory((Program.erForm.Temp + "\\MC_Biome"), Program.erForm.Path_Biome, true);
            Program.erForm.Pack_Settings[1] = "Biome:" + Program.erForm.Version_Biome;
            Program.erForm.Installed_Biome = Program.erForm.Version_Biome;
        }
        //#######################################################################################################################################
        public async Task DownloadForge()
        {
            string Temp_ForgePath = (Program.erForm.Temp + "\\" + Program.erForm.Pack_Name + "_Forge.zip");
            Program.erForm.output_c("Downloading Forge");
            bool IsGit = true;
            try
            {
                using (WebClient webClient = new WebClient())
                if (Program.erForm.Version_Forge.Contains("http"))
                {
                    IsGit = false;
                        await webClient.DownloadFileTaskAsync(new Uri(Program.erForm.Version_Forge), Temp_ForgePath);
                }
                else
                {
                    IsGit = true;
                        await webClient.DownloadFileTaskAsync(new Uri("https://github.com/" + Program.erForm.Pack_Name + "/MC_Forge/archive/" + Program.erForm.Version_Forge + ".zip"), Temp_ForgePath);
                }
            }
            catch (Exception ex)
            {
                Program.erForm.output_c("Download failed");
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            ZipFile.ExtractToDirectory(Temp_ForgePath, Program.erForm.Temp);
            string tmp021;
            if (IsGit)
            {
                tmp021 = Directory.GetDirectories(Program.erForm.Temp + "\\MC_Forge-" + Program.erForm.Version_Forge + "\\versions")[0];
                FileSystem.MoveDirectory((Program.erForm.Temp + "\\MC_Forge-" + Program.erForm.Version_Forge), AppData + "\\.minecraft", true);
            }
            else
            {
                tmp021 = Directory.GetDirectories(Program.erForm.Temp + "\\MC_Forge" + "\\versions")[0];
                FileSystem.MoveDirectory((Program.erForm.Temp + "\\MC_Forge"), AppData + "\\.minecraft", true);
            }
            Program.erForm.ForgeName = tmp021.Split('\\').LastOrDefault();
            Program.erForm.Pack_Settings[2] = "Forge:" + Program.erForm.Version_Forge;
            Program.erForm.Pack_Settings[3] = "ForgeName:" + Program.erForm.ForgeName;
            Program.erForm.Installed_Forge = Program.erForm.Version_Forge;
        }
        //#######################################################################################################################################
        public async Task DownloadScripts()
        {
            string Temp_ScriptPath = (Program.erForm.Temp + "\\" + Program.erForm.Pack_Name + "_Script.zip");
            Program.erForm.output_c("Downloading Script");
            bool IsGit = true;
            try
            {
                using(WebClient webClient = new WebClient())
                if (Program.erForm.Version_Script.Contains("http"))
                {
                    IsGit = false;
                    await webClient.DownloadFileTaskAsync(new Uri(Program.erForm.Version_Script), Temp_ScriptPath);
                }
                else
                {
                    IsGit = true;
                    await webClient.DownloadFileTaskAsync(new Uri("https://github.com/" + Program.erForm.Pack_Name + "/MC_Script/archive/" + Program.erForm.Version_Script + ".zip"), Temp_ScriptPath);
                }
            }
            catch (Exception ex)
            {
                Program.erForm.output_c("Download failed");
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            FileSystem.DeleteDirectory(Program.erForm.Path_Script, DeleteDirectoryOption.DeleteAllContents);
            Program.erForm.output_c("Installing scripts");
            Directory.CreateDirectory(Program.erForm.Path_Script);
            ZipFile.ExtractToDirectory(Temp_ScriptPath, Program.erForm.Temp);
            if (IsGit)
                FileSystem.MoveDirectory((Program.erForm.Temp + "\\MC_Script-" + Program.erForm.Version_Script), Program.erForm.Path_Script, true);
            else
                FileSystem.MoveDirectory((Program.erForm.Temp + "\\MC_Script"), Program.erForm.Path_Script, true);
            Program.erForm.Pack_Settings[4] = "Script:" + Program.erForm.Version_Script;
            Program.erForm.Installed_Script = Program.erForm.Version_Script;
        }
        //#######################################################################################################################################
        public async Task DownloadBadge()
        {
            string Temp_BadgePath = (Program.erForm.Temp + "\\" + Program.erForm.Pack_Name + "_Badge.zip");
            Program.erForm.output_c("Downloading Badge");
            bool IsGit = true;
            try
            {
                using (WebClient webClient = new WebClient())
                if (Program.erForm.Version_Badge.Contains("http"))
                {
                    IsGit = false;
                    await webClient.DownloadFileTaskAsync(new Uri(Program.erForm.Version_Badge), Temp_BadgePath);
                }
                else
                {
                    IsGit = true;
                    await webClient.DownloadFileTaskAsync(new Uri("https://github.com/" + Program.erForm.Pack_Name + "/MC_Badge/archive/" + Program.erForm.Version_Badge + ".zip"), Temp_BadgePath);
                }
            }
            catch (Exception ex)
            {
                Program.erForm.output_c("Download failed" + ex.ToString());
            }
            Program.erForm.output_c("Installing badge");
            ZipFile.ExtractToDirectory(Temp_BadgePath, Program.erForm.Temp);
            string tmpBadgeExPath = "";
            if (IsGit)
                tmpBadgeExPath = Program.erForm.Temp + "\\MC_Badge-" + Program.erForm.Version_Badge;
            else
                tmpBadgeExPath = Program.erForm.Temp + "\\MC_Badge";
            FileSystem.MoveDirectory((tmpBadgeExPath), Program.erForm.Path_Pack, true);
            Program.erForm.Pack_Settings[5] = "Badge:" + Program.erForm.Version_Badge;
            Program.erForm.Installed_Badge = Program.erForm.Version_Badge;
            Program.erForm.RefreshBadge();
        }
        //#######################################################################################################################################
    }
}

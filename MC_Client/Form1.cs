using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_update.Enabled = false;
            button_update.Text = "Loading";

            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=51.255.41.80;uid=ermlpublicread;" +
                "pwd=hmDmxuhheilgKXUWTjzC;database=ElementalRealms_ModdedLauncher;";
            conn = new MySql.Data.MySqlClient.MySqlConnection(myConnectionString);
            

            try
            {
                
                conn.OpenAsync();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.Write(ex.Message);
            }

            
            conn.CloseAsync();
            button_update.Enabled = true;
            button_update.Text = "Check For updates";
        }
    }
}

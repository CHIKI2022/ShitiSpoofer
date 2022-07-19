using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;



namespace ShitiFivemSpoofer_
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public int Randomnum()
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }

        private void btnmac_Click(object sender, EventArgs e)
        {
            string value = "00" + Helpers.GenerateString(10);
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\0012", true);
            registryKey.SetValue("NetworkAddress", value);
            registryKey.Close();


            MessageBox.Show("New MacAddress : " + Helpers.CurrentMAC());


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = Guid.NewGuid().ToString();
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
            registryKey.SetValue("MachineGuid", value);



            MessageBox.Show("New GUID 1 : " + Helpers.CurrentGUID());

        }

        private void button2_Click(object sender, EventArgs e)
        {


            Console.Write("Current PC name: " + Helpers.CurrentPCName());
            Console.WriteLine("");
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            registryKey = registryKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true);
            registryKey.SetValue("ComputerName", "DESKTOP-" + Helpers.GenerateString(15));

            MessageBox.Show("New PcName : " + Helpers.CurrentPCName());


        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"GUID : {Helpers.CurrentGUID()}\nHWID : {Helpers.CurrentHwProfileGUID()}\nMacAddress : {Helpers.CurrentMAC()}\nPcName : {Helpers.CurrentPCName()} \nProductID : {Helpers.CurrentProductID()}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string value = string.Concat(new string[]
            {
                Helpers.GenerateString(5),
                "-",
                Helpers.GenerateString(5),
                "-",
                Helpers.GenerateString(5),
                "-",
                Helpers.GenerateString(5)
            });
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
            registryKey.SetValue("ProductID", value);
            registryKey.Close();
            MessageBox.Show("New ProductID : " + Helpers.CurrentProductID());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text = string.Concat(new string[]
            {
                Helpers.GenerateString(5),
                "-",
                Helpers.GenerateString(5),
                "-",
                Helpers.GenerateString(5),
                "-",
                Helpers.GenerateString(5)
            });
            MessageBox.Show(text);
            try
            {
                using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true))
                {
                    bool flag2 = registryKey != null;
                    if (flag2)
                    {
                        object value = registryKey.GetValue("HwProfileGuid");
                        bool flag3 = value != null;
                        if (flag3)
                        {
                            registryKey.SetValue("HwProfileGuid", text);
                            MessageBox.Show("HWID SET!", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("There doesn't appear to be a registry key with that name, please try again later!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("There doesn't appear to be a registry folder with that name, please try again later!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal application error!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            string value = "{" + Guid.NewGuid().ToString() + "}";
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            registryKey = registryKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true);
            registryKey.SetValue("HwProfileGUID", value);
            registryKey.Close();

            MessageBox.Show("New HWID : " + Helpers.CurrentHwProfileGUID());


        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            
            form2.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using MaterialSkin.Controls;
using System.Reflection;

namespace MTKImeiChanger
{
    public partial class MainForm : MaterialForm
    {
        #region CONSTANTS
        public readonly string ADB_PATH = "ResBin\\adb.exe";
        public readonly string IMEI_PATH = "ResBin\\imei.exe";

        public readonly string IMEI_NVR_PATH = "/data/nvram/md5/NVRAM/NVD_IMEI";
        public readonly string NVPATH = "/data/nvram";
        public readonly string IMEI_FNAME = "MP0B_001";

        public readonly string AND_TMP = "/data/local/tmp";
        #endregion

        #region GUI stuff
        public MainForm()
        {
            string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            Directory.SetCurrentDirectory(exeDir);

            if (!Directory.Exists("temp"))
                Directory.CreateDirectory("temp");

            InitializeComponent();
        }

        public void Log(string a)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => Log(a)));
            } else
            {
                string prefix = DateTime.Now.ToString("[HH:mm:ss]");
                listBox1.Items.Add(prefix + a);
                listBox1.TopIndex = listBox1.Items.Count - 1;
            }
        }

        public void LockButtons(bool a)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => LockButtons(a)));
            }
            else
            {
                mainPanel.Enabled = !a;
            }
        }

        private void dualSimChecked(object sender, EventArgs e)
        {
            secondImeiPanel.Visible = isDualSim.Checked;
        }

        private void formLoad(object sender, EventArgs e)
        {
            Log("Program loaded");
        }

        private void tbKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((((TextBox)sender).Text.Length == 15) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("rundll32", "url.dll,FileProtocolHandler https://leszczu8023.ovh");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void DoWorkClicked(object sender, EventArgs e)
        {
            if (imei1Field.Text.Length != 15)
            {
                Log("Invalid IMEI1 length!");
                return;
            }
            else if (imei2Field.Text.Length != 15)
            {
                if (isDualSim.Checked)
                {
                    Log("Invalid IMEI2 length!");
                    return;
                }
                else
                {
                    imei2Field.Text = "";
                }
            }
            LockButtons(true);
            Thread imeiWriteThread = new Thread(() => WriteImei(imei1Field.Text, imei2Field.Text));
            imeiWriteThread.SetApartmentState(ApartmentState.MTA);
            imeiWriteThread.Start();
        }
        #endregion

        #region Main logic
        public void WriteImei(string imei1, string imei2)
        {
            Log("Please plug a smartphone with USB debugging enabled. If phone ask for root permissions - press \"allow\".");
            RestartAdbDaemon();
            MakeImei(imei1, imei2);

            bool first = true;

            if (File.Exists("temp\\" + IMEI_FNAME + "_NEW"))
            {
                bool doWork = true;
                while (doWork)
                {
                    WaitForDevice();

                    RunAdbCommand("chmod -R 777 " + NVPATH);
                    RunAdbCommand("rm -r -f " + NVPATH + "/*");
                    int i = 0;
                    Thread.Sleep(1000);
                    Log("Waiting for radio start...");
                    while (GetProp("gsm.sim.state").Contains("NOT_READY"))
                    {
                        Thread.Sleep(1000);
                        i++;
                        if (i == 30)
                        {
                            Log("Timed out :(");
                            LockButtons(false);
                            return;
                        }
                    }

                    if (i > 0)
                    {
                        first = false;
                    }

                    RunAdbCommand("mkdir -p " + IMEI_NVR_PATH);
                    UploadFileToPhone("temp\\" + IMEI_FNAME + "_NEW", AND_TMP + "/" + IMEI_FNAME);
                    RunAdbCommand("cp " + AND_TMP + "/" + IMEI_FNAME + " " + IMEI_NVR_PATH + "/" + IMEI_FNAME);
                    Log("Waiting 4s...");
                    Thread.Sleep(1000 * 4);
                    RunAdbCommand("reboot");

                    if (!first)
                    {
                        Log("Operation completed successfully!");
                        doWork = false;
                    }
                    else
                    {
                        Log("Waiting for complete boot... Don't unplug smartphone!");
                        WaitForDevice();
                        while (!GetProp("sys.boot_completed").Trim().Equals("1"))
                        {
                            Thread.Sleep(1000);
                            i++;
                            if (i == 30)
                            {
                                Log("Timed out :(");
                                LockButtons(false);
                                return;
                            }
                        }
                        first = false;
                    }
                }              
            }
            else
            {
                Log("IMEI generation failed");
            }
            LockButtons(false);
        }
        #endregion

        #region ADB wrapper
        private void WaitForDevice()
        {
            Log("Waiting for device...");
            StartProcess(ADB_PATH, "wait-for-device", Application.StartupPath);
        }

        private void RestartAdbDaemon()
        {
            Log("Restarting adb daemon...");
            StartProcess(ADB_PATH, "kill-server", Application.StartupPath);
            StartProcess(ADB_PATH, "start-server", Application.StartupPath);
        }

        private void SetRoot()
        {
            StartProcess(ADB_PATH, "root", Application.StartupPath);
        }

        private void RunAdbCommand(string command)
        {
            Log("[ADB]Command: " + command);
            StartProcess(ADB_PATH, "shell su -c \"" + command + "\"", Application.StartupPath);
        }

        private void UploadFileToPhone(string path, string target)
        {
            StartProcess(ADB_PATH, "push \"" + path + "\" \"" + target + "\"", Application.StartupPath);
        }

        public string GetProp(string key)
        {
            var a = ReadProcess(ADB_PATH, "shell getprop " + key);
            Log("[ADB]getprop[" + key + "]=" + a);
            return a;
        }
        #endregion

        #region Imei wrapper
        public void MakeImei(string imei1, string imei2)
        {
            if (File.Exists("temp\\" + IMEI_FNAME + "_NEW"))
            {
                File.Delete("temp\\" + IMEI_FNAME + "_NEW");
            }
            StartProcess(IMEI_PATH, imei1 + ((string.IsNullOrEmpty(imei2)) ? "" : " " + imei2), System.IO.Path.GetFullPath("temp"));
        }
        #endregion

        #region Processing things

        static string ReadProcess(string app, string args)
        {
            var p = new Process();
            string line = "";

            p.StartInfo.FileName = app;
            p.StartInfo.Arguments = args;

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();

            while (!p.StandardOutput.EndOfStream)
            {
                line += p.StandardOutput.ReadLine() + "\n";
            }

            return line;
        }

        private void StartProcess(string app, string args, string work_dir)
        {
            var p = new Process();

            p.StartInfo.FileName = app;
            p.StartInfo.Arguments = args;
            p.StartInfo.WorkingDirectory = work_dir;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();

            while (!p.StandardOutput.EndOfStream)
            {
                Log(p.StandardOutput.ReadLine());
            }
        }

        #endregion
    }
}

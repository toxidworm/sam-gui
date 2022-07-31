using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Extracting S.A.M. (Software. Automatic. Mouth.)
            File.WriteAllBytes("sam.exe", Properties.Resources.sam);
            File.WriteAllBytes("SDL.dll", Properties.Resources.SDL);
            pictureBox1.Image = Properties.Resources.glitchtroll;

        }

        public void SAM(string command)
        {
            Task.Run(() => {
                ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process process = new Process();
                process.StartInfo = procStartInfo;
                process.Start();
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = $"{Environment.CurrentDirectory}\\sam.exe -pitch {textBox2.Text} -speed {textBox3.Text} \"{textBox1.Text}\"";
            SAM(command);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string savecommand = $"{Environment.CurrentDirectory}\\sam.exe -wav {textBox4.Text}.wav -pitch {textBox2.Text} -speed {textBox3.Text} \"{textBox1.Text}\"";
            SAM(savecommand);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VS2017LayoutCleanup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbLayoutDir.Text = Application.StartupPath;
        }

        private void bSelectDir_Click(object sender, EventArgs e)
        {
            fbdSelectDir.SelectedPath = tbLayoutDir.Text;
            if (fbdSelectDir.ShowDialog() == DialogResult.OK)
            {
                tbLayoutDir.Text = fbdSelectDir.SelectedPath;
            }
        }

        private void bCleanup_Click(object sender, EventArgs e)
        {
            Package pkg = new Package();
            List<PackageInfo> packages = pkg.GetPackages(tbLayoutDir.Text);
            if(packages.Count == 0)
            {
                MessageBox.Show("未发现离线包信息，请确认目录是否选择正确。");
                return;
            }
            string moveTo = "Backup" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string fullMoveTo = tbLayoutDir.Text + "\\" + moveTo;
            Directory.CreateDirectory(fullMoveTo);
            int moveCount = pkg.Cleanup(tbLayoutDir.Text, packages, fullMoveTo);
            if (moveCount > 0)
            {
                MessageBox.Show(string.Format("清理成功，共移动{0}个包，到目录：{1}", moveCount, moveTo));
            }
            else
            {
                Directory.Delete(fullMoveTo);
                MessageBox.Show("没有发现过期离线包 ~-~ ");
            }

        }
    }
}

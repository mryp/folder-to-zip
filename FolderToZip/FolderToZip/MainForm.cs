using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderToZip
{
    public partial class MainForm : Form
    {
        private class WorkerParam
        {
            public bool IsLevelZero { get; set; } = false;
            public string FolderPath { get; set; } = "";
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void folderPathRefButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                return;
            }

            var folderPath = folderPathTextBox.Text;
            if (string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("フォルダパスが指定されていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("フォルダパスが存在しません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            startButton.Enabled = false;
            bgWorker.RunWorkerAsync(new WorkerParam()
            {
                IsLevelZero = optionUseLevelZeroCheckBox.Checked,
                FolderPath = folderPath,
            });
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is not WorkerParam param)
            {
                return;
            }

            //param.FolderPath;
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startButton.Enabled = true;
        }
    }
}

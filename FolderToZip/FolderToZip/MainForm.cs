using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderToZip
{
    public partial class MainForm : Form
    {
        protected class WorkerParam
        {
            public CompressionLevel Level { get; set; } = CompressionLevel.NoCompression;
            public string FolderPath { get; set; } = "";

            public override string ToString()
            {
                return $"{FolderPath},{Level}";
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Log.Info("アプリケーション起動");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Info("アプリケーション終了");
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
                Level = optionUseLevelZeroCheckBox.Checked ? CompressionLevel.NoCompression : CompressionLevel.Fastest,
                FolderPath = folderPath,
            });
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (sender is not BackgroundWorker worker)
            {
                Log.Error("sender is not BackgroundWorker");
                e.Result = "処理パラメーターエラー";
                return;
            }
            if (e.Argument is not WorkerParam param)
            {
                Log.Error("e.Argument is not WorkerParam");
                e.Result = "処理パラメーターエラー";
                return;
            }

            Log.Info($"処理開始 param={param}");
            var dirPathList = Directory.GetDirectories(param.FolderPath);
            if (dirPathList.Length == 0)
            {
                Log.Error("フォルダ内にフォルダが見つからない");
                e.Result = "指定されたフォルダ内にフォルダが見つかりません";
                return;
            }

            worker.ReportProgress(dirPathList.Length);
            var pos = 0;
            foreach (var dirPath in dirPathList)
            {
                if (worker.CancellationPending)
                {
                    Log.Info($"処理キャンセル検知");
                    e.Cancel = true;
                    return;
                }

                Log.Info($"処理ファイル:{dirPath}");
                var result = zipFolder(dirPath, param.Level);
                pos++;

                worker.ReportProgress(pos, result + $"[{Path.GetFileName(dirPath)}]");
                Log.Info($"結果:{result}");
            }

            Log.Info("処理完了");
            e.Result = "処理が完了しました";
            return;
        }

        private string zipFolder(string dirPath, CompressionLevel level)
        {
            string outputPath = dirPath + ".zip";
            if (File.Exists(outputPath))
            {
                return $"NG 展開先に既にファイルが存在しています";
            }

            try
            {
                ZipFile.CreateFromDirectory(dirPath, outputPath, level, false);
            }
            catch (Exception e)
            {
                return $"NG 例外発生 {e.Message}";
            }

            return $"OK";
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var message = "";
            if (e.UserState != null)
            {
                message = e.UserState.ToString();
            }

            if (message == "")
            {
                progressBar.Maximum = e.ProgressPercentage;
                progressBar.Value = 0;
                progressStatusLabel.Text = "";
            }
            else
            {
                progressBar.Value = e.ProgressPercentage;
                progressStatusLabel.Text = message;
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            startButton.Enabled = true;
            if (e.Cancelled)
            {
                MessageBox.Show("キャンセルされました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                progressStatusLabel.Text = "キャンセルされました";
            }
            else if (e.Result == null)
            {
                MessageBox.Show("想定外のエラーが発生しました", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                progressStatusLabel.Text = "想定外のエラーが発生しました";
            }
            else
            {
                MessageBox.Show(e.Result.ToString(), "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progressStatusLabel.Text = e.Result.ToString();
            }
        }
    }
}

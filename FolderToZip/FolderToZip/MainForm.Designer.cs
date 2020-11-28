
namespace FolderToZip
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderPathRefButton = new System.Windows.Forms.Button();
            this.folderPathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.optionUseLevelZeroCheckBox = new System.Windows.Forms.CheckBox();
            this.startButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // folderPathRefButton
            // 
            this.folderPathRefButton.Location = new System.Drawing.Point(567, 11);
            this.folderPathRefButton.Name = "folderPathRefButton";
            this.folderPathRefButton.Size = new System.Drawing.Size(94, 29);
            this.folderPathRefButton.TabIndex = 0;
            this.folderPathRefButton.Text = "参照";
            this.folderPathRefButton.UseVisualStyleBackColor = true;
            this.folderPathRefButton.Click += new System.EventHandler(this.folderPathRefButton_Click);
            // 
            // folderPathTextBox
            // 
            this.folderPathTextBox.Location = new System.Drawing.Point(108, 12);
            this.folderPathTextBox.Name = "folderPathTextBox";
            this.folderPathTextBox.Size = new System.Drawing.Size(453, 27);
            this.folderPathTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "フォルダパス：";
            // 
            // optionUseLevelZeroCheckBox
            // 
            this.optionUseLevelZeroCheckBox.AutoSize = true;
            this.optionUseLevelZeroCheckBox.Checked = true;
            this.optionUseLevelZeroCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optionUseLevelZeroCheckBox.Location = new System.Drawing.Point(17, 55);
            this.optionUseLevelZeroCheckBox.Name = "optionUseLevelZeroCheckBox";
            this.optionUseLevelZeroCheckBox.Size = new System.Drawing.Size(182, 24);
            this.optionUseLevelZeroCheckBox.TabIndex = 3;
            this.optionUseLevelZeroCheckBox.Text = "無圧縮ファイルを作成する";
            this.optionUseLevelZeroCheckBox.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(17, 93);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(644, 44);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "処理開始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.WorkerSupportsCancellation = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(17, 143);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(644, 29);
            this.progressBar.TabIndex = 5;
            // 
            // progressStatusLabel
            // 
            this.progressStatusLabel.AutoSize = true;
            this.progressStatusLabel.Location = new System.Drawing.Point(17, 175);
            this.progressStatusLabel.Name = "progressStatusLabel";
            this.progressStatusLabel.Size = new System.Drawing.Size(54, 20);
            this.progressStatusLabel.TabIndex = 6;
            this.progressStatusLabel.Text = "未処理";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 212);
            this.Controls.Add(this.progressStatusLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.optionUseLevelZeroCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderPathTextBox);
            this.Controls.Add(this.folderPathRefButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Folder to Zip";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button folderPathRefButton;
        private System.Windows.Forms.TextBox folderPathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox optionUseLevelZeroCheckBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressStatusLabel;
    }
}


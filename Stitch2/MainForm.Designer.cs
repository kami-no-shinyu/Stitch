namespace Stitch
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.progName = new System.Windows.Forms.Label();
            this.stitch_button = new System.Windows.Forms.Button();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.progTagline = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.txtVersion = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblDrop = new System.Windows.Forms.Label();
            this.folder_icon = new System.Windows.Forms.PictureBox();
            this.pnlFolder = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.dependencyFolderLocator = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClearList = new System.Windows.Forms.PictureBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.chkReplacePaths = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folder_icon)).BeginInit();
            this.pnlFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearList)).BeginInit();
            this.SuspendLayout();
            // 
            // progName
            // 
            this.progName.AutoSize = true;
            this.progName.BackColor = System.Drawing.Color.White;
            this.progName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(144)))), ((int)(((byte)(225)))));
            this.progName.Location = new System.Drawing.Point(184, 9);
            this.progName.Name = "progName";
            this.progName.Size = new System.Drawing.Size(62, 28);
            this.progName.TabIndex = 0;
            this.progName.Text = "Stitch";
            // 
            // stitch_button
            // 
            this.stitch_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(144)))), ((int)(((byte)(225)))));
            this.stitch_button.FlatAppearance.BorderSize = 0;
            this.stitch_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stitch_button.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stitch_button.ForeColor = System.Drawing.Color.White;
            this.stitch_button.Location = new System.Drawing.Point(181, 363);
            this.stitch_button.Name = "stitch_button";
            this.stitch_button.Size = new System.Drawing.Size(101, 34);
            this.stitch_button.TabIndex = 2;
            this.stitch_button.Text = "Stitch";
            this.stitch_button.UseVisualStyleBackColor = false;
            this.stitch_button.Click += new System.EventHandler(this.Stitch_button_Click);
            // 
            // logoBox
            // 
            this.logoBox.Image = ((System.Drawing.Image)(resources.GetObject("logoBox.Image")));
            this.logoBox.Location = new System.Drawing.Point(8, 6);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(50, 50);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoBox.TabIndex = 4;
            this.logoBox.TabStop = false;
            // 
            // progTagline
            // 
            this.progTagline.AutoSize = true;
            this.progTagline.BackColor = System.Drawing.Color.White;
            this.progTagline.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progTagline.ForeColor = System.Drawing.Color.Black;
            this.progTagline.Location = new System.Drawing.Point(161, 37);
            this.progTagline.Name = "progTagline";
            this.progTagline.Size = new System.Drawing.Size(109, 19);
            this.progTagline.TabIndex = 5;
            this.progTagline.Text = "Auto Knit R Files";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.progTagline);
            this.headerPanel.Controls.Add(this.logoBox);
            this.headerPanel.Controls.Add(this.progName);
            this.headerPanel.Controls.Add(this.txtVersion);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(450, 62);
            this.headerPanel.TabIndex = 6;
            // 
            // txtVersion
            // 
            this.txtVersion.AutoSize = true;
            this.txtVersion.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtVersion.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersion.ForeColor = System.Drawing.Color.DarkGray;
            this.txtVersion.Location = new System.Drawing.Point(395, 0);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(10);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Padding = new System.Windows.Forms.Padding(10);
            this.txtVersion.Size = new System.Drawing.Size(55, 39);
            this.txtVersion.TabIndex = 10;
            this.txtVersion.Text = "v2.1";
            this.txtVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(78, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(291, 244);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            this.pictureBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragEnter);
            // 
            // lblDrop
            // 
            this.lblDrop.AllowDrop = true;
            this.lblDrop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDrop.BackColor = System.Drawing.Color.Transparent;
            this.lblDrop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrop.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDrop.Location = new System.Drawing.Point(20, 119);
            this.lblDrop.Name = "lblDrop";
            this.lblDrop.Size = new System.Drawing.Size(197, 23);
            this.lblDrop.TabIndex = 8;
            this.lblDrop.Text = "Drop Files / Folders Here";
            this.lblDrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            this.lblDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragEnter);
            // 
            // folder_icon
            // 
            this.folder_icon.Image = ((System.Drawing.Image)(resources.GetObject("folder_icon.Image")));
            this.folder_icon.Location = new System.Drawing.Point(51, 21);
            this.folder_icon.Name = "folder_icon";
            this.folder_icon.Size = new System.Drawing.Size(117, 105);
            this.folder_icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.folder_icon.TabIndex = 9;
            this.folder_icon.TabStop = false;
            this.folder_icon.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            this.folder_icon.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragEnter);
            // 
            // pnlFolder
            // 
            this.pnlFolder.AllowDrop = true;
            this.pnlFolder.BackColor = System.Drawing.Color.Transparent;
            this.pnlFolder.Controls.Add(this.lblCount);
            this.pnlFolder.Controls.Add(this.folder_icon);
            this.pnlFolder.Controls.Add(this.lblDrop);
            this.pnlFolder.Location = new System.Drawing.Point(110, 134);
            this.pnlFolder.Name = "pnlFolder";
            this.pnlFolder.Size = new System.Drawing.Size(238, 166);
            this.pnlFolder.TabIndex = 11;
            this.pnlFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            this.pnlFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragEnter);
            // 
            // lblCount
            // 
            this.lblCount.AllowDrop = true;
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(144)))), ((int)(((byte)(225)))));
            this.lblCount.Location = new System.Drawing.Point(42, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(91, 106);
            this.lblCount.TabIndex = 12;
            this.lblCount.Text = "1";
            this.lblCount.Visible = false;
            this.lblCount.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            this.lblCount.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragEnter);
            // 
            // dependencyFolderLocator
            // 
            this.dependencyFolderLocator.RootFolder = System.Environment.SpecialFolder.ProgramFiles;
            // 
            // btnClearList
            // 
            this.btnClearList.Image = ((System.Drawing.Image)(resources.GetObject("btnClearList.Image")));
            this.btnClearList.Location = new System.Drawing.Point(311, 114);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(30, 30);
            this.btnClearList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClearList.TabIndex = 12;
            this.btnClearList.TabStop = false;
            this.btnClearList.Click += new System.EventHandler(this.ClearList);
            this.btnClearList.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            this.btnClearList.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragEnter);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // chkReplacePaths
            // 
            this.chkReplacePaths.AutoSize = true;
            this.chkReplacePaths.Checked = true;
            this.chkReplacePaths.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReplacePaths.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReplacePaths.Location = new System.Drawing.Point(12, 373);
            this.chkReplacePaths.Name = "chkReplacePaths";
            this.chkReplacePaths.Size = new System.Drawing.Size(122, 24);
            this.chkReplacePaths.TabIndex = 13;
            this.chkReplacePaths.Text = "Replace Paths";
            this.chkReplacePaths.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(450, 415);
            this.Controls.Add(this.chkReplacePaths);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.pnlFolder);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.stitch_button);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Stitch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folder_icon)).EndInit();
            this.pnlFolder.ResumeLayout(false);
            this.pnlFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label progName;
        private System.Windows.Forms.Button stitch_button;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.Label progTagline;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblDrop;
        private System.Windows.Forms.PictureBox folder_icon;
        private System.Windows.Forms.Label txtVersion;
        private System.Windows.Forms.Panel pnlFolder;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.FolderBrowserDialog dependencyFolderLocator;
        private System.Windows.Forms.PictureBox btnClearList;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.CheckBox chkReplacePaths;
    }
}


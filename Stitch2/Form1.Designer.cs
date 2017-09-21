namespace Stitch2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.btnStitch = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstDrop = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblDrop = new System.Windows.Forms.Label();
            this.img_folder = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlFolder = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.dependencyFolderLocator = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClearList = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_folder)).BeginInit();
            this.pnlFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(144)))), ((int)(((byte)(225)))));
            this.label1.Location = new System.Drawing.Point(184, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stitch";
            // 
            // btnStitch
            // 
            this.btnStitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(144)))), ((int)(((byte)(225)))));
            this.btnStitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStitch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStitch.ForeColor = System.Drawing.Color.White;
            this.btnStitch.Location = new System.Drawing.Point(181, 363);
            this.btnStitch.Name = "btnStitch";
            this.btnStitch.Size = new System.Drawing.Size(101, 34);
            this.btnStitch.TabIndex = 2;
            this.btnStitch.Text = "Stitch";
            this.btnStitch.UseVisualStyleBackColor = false;
            this.btnStitch.Click += new System.EventHandler(this.BtnStitch_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(161, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Auto Knit R Files";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 62);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lstDrop
            // 
            this.lstDrop.AllowDrop = true;
            this.lstDrop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(221)))), ((int)(((byte)(224)))));
            this.lstDrop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDrop.FormattingEnabled = true;
            this.lstDrop.ItemHeight = 16;
            this.lstDrop.Location = new System.Drawing.Point(78, 90);
            this.lstDrop.Name = "lstDrop";
            this.lstDrop.Size = new System.Drawing.Size(291, 240);
            this.lstDrop.TabIndex = 1;
            this.lstDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            this.lstDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragEnter);
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
            // 
            // img_folder
            // 
            this.img_folder.Image = ((System.Drawing.Image)(resources.GetObject("img_folder.Image")));
            this.img_folder.Location = new System.Drawing.Point(51, 21);
            this.img_folder.Name = "img_folder";
            this.img_folder.Size = new System.Drawing.Size(117, 105);
            this.img_folder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_folder.TabIndex = 9;
            this.img_folder.TabStop = false;
            this.img_folder.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(386, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "v1.0.1.2";
            // 
            // pnlFolder
            // 
            this.pnlFolder.AllowDrop = true;
            this.pnlFolder.BackColor = System.Drawing.Color.Transparent;
            this.pnlFolder.Controls.Add(this.lblCount);
            this.pnlFolder.Controls.Add(this.img_folder);
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
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(144)))), ((int)(((byte)(225)))));
            this.lblCount.Location = new System.Drawing.Point(42, 12);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(177, 106);
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
            this.btnClearList.Click += new System.EventHandler(this.BtnClearList_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(450, 415);
            this.Controls.Add(this.btnClearList);
            this.Controls.Add(this.pnlFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnStitch);
            this.Controls.Add(this.lstDrop);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Stitch";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_folder)).EndInit();
            this.pnlFolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClearList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStitch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstDrop;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblDrop;
        private System.Windows.Forms.PictureBox img_folder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlFolder;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.FolderBrowserDialog dependencyFolderLocator;
        private System.Windows.Forms.PictureBox btnClearList;
    }
}


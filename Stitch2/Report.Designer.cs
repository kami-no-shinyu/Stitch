namespace Stitch2
{
    partial class Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report));
            this.lblsuccess = new System.Windows.Forms.Label();
            this.lblfail = new System.Windows.Forms.Label();
            this.lstSucceed = new System.Windows.Forms.ListView();
            this.lstFail = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblsuccess
            // 
            this.lblsuccess.AutoSize = true;
            this.lblsuccess.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsuccess.Location = new System.Drawing.Point(113, 70);
            this.lblsuccess.Name = "lblsuccess";
            this.lblsuccess.Size = new System.Drawing.Size(133, 28);
            this.lblsuccess.TabIndex = 2;
            this.lblsuccess.Text = "Success ( 12 )";
            // 
            // lblfail
            // 
            this.lblfail.AutoSize = true;
            this.lblfail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblfail.Location = new System.Drawing.Point(418, 69);
            this.lblfail.Name = "lblfail";
            this.lblfail.Size = new System.Drawing.Size(97, 28);
            this.lblfail.TabIndex = 2;
            this.lblfail.Text = "Failed(15)";
            // 
            // lstSucceed
            // 
            this.lstSucceed.FullRowSelect = true;
            this.lstSucceed.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstSucceed.HideSelection = false;
            this.lstSucceed.LabelWrap = false;
            this.lstSucceed.Location = new System.Drawing.Point(47, 111);
            this.lstSucceed.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.lstSucceed.Name = "lstSucceed";
            this.lstSucceed.Size = new System.Drawing.Size(247, 404);
            this.lstSucceed.TabIndex = 3;
            this.lstSucceed.TileSize = new System.Drawing.Size(240, 20);
            this.lstSucceed.UseCompatibleStateImageBehavior = false;
            this.lstSucceed.View = System.Windows.Forms.View.List;
            this.lstSucceed.DoubleClick += new System.EventHandler(this.lstSucceed_DoubleClick);
            // 
            // lstFail
            // 
            this.lstFail.FullRowSelect = true;
            this.lstFail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstFail.HideSelection = false;
            this.lstFail.LabelWrap = false;
            this.lstFail.Location = new System.Drawing.Point(343, 111);
            this.lstFail.Name = "lstFail";
            this.lstFail.Size = new System.Drawing.Size(247, 404);
            this.lstFail.TabIndex = 4;
            this.lstFail.TileSize = new System.Drawing.Size(200, 40);
            this.lstFail.UseCompatibleStateImageBehavior = false;
            this.lstFail.View = System.Windows.Forms.View.List;
            this.lstFail.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.lstFail.DoubleClick += new System.EventHandler(this.lstFail_DoubleClick);
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
            this.panel1.Size = new System.Drawing.Size(636, 62);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(264, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Auto Knit R Files";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(144)))), ((int)(((byte)(225)))));
            this.label1.Location = new System.Drawing.Point(287, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stitch";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(636, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstFail);
            this.Controls.Add(this.lstSucceed);
            this.Controls.Add(this.lblfail);
            this.Controls.Add(this.lblsuccess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Report";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Report";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Report_FormClosing);
            this.Load += new System.EventHandler(this.Report_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblsuccess;
        private System.Windows.Forms.Label lblfail;
        private System.Windows.Forms.ListView lstSucceed;
        private System.Windows.Forms.ListView lstFail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
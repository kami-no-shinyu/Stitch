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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSucceed = new System.Windows.Forms.ListView();
            this.lstFail = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Success ( 12 )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Failed(15)";
            // 
            // lstSucceed
            // 
            this.lstSucceed.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstSucceed.HideSelection = false;
            this.lstSucceed.LabelWrap = false;
            this.lstSucceed.Location = new System.Drawing.Point(54, 106);
            this.lstSucceed.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.lstSucceed.Name = "lstSucceed";
            this.lstSucceed.Size = new System.Drawing.Size(247, 404);
            this.lstSucceed.TabIndex = 3;
            this.lstSucceed.TileSize = new System.Drawing.Size(200, 20);
            this.lstSucceed.UseCompatibleStateImageBehavior = false;
            this.lstSucceed.View = System.Windows.Forms.View.List;
            this.lstSucceed.DoubleClick += new System.EventHandler(this.lstSucceed_DoubleClick);
            // 
            // lstFail
            // 
            this.lstFail.LabelWrap = false;
            this.lstFail.Location = new System.Drawing.Point(343, 106);
            this.lstFail.Name = "lstFail";
            this.lstFail.Size = new System.Drawing.Size(247, 404);
            this.lstFail.TabIndex = 4;
            this.lstFail.TileSize = new System.Drawing.Size(200, 20);
            this.lstFail.UseCompatibleStateImageBehavior = false;
            this.lstFail.View = System.Windows.Forms.View.List;
            this.lstFail.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.lstFail.DoubleClick += new System.EventHandler(this.lstFail_DoubleClick);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 553);
            this.Controls.Add(this.lstFail);
            this.Controls.Add(this.lstSucceed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstSucceed;
        private System.Windows.Forms.ListView lstFail;
    }
}
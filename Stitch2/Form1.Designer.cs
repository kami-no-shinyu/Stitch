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
            this.label1 = new System.Windows.Forms.Label();
            this.lstDrop = new System.Windows.Forms.ListBox();
            this.btnStitch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stitch";
            // 
            // lstDrop
            // 
            this.lstDrop.AllowDrop = true;
            this.lstDrop.FormattingEnabled = true;
            this.lstDrop.ItemHeight = 16;
            this.lstDrop.Location = new System.Drawing.Point(80, 85);
            this.lstDrop.Name = "lstDrop";
            this.lstDrop.Size = new System.Drawing.Size(224, 196);
            this.lstDrop.TabIndex = 1;
            this.lstDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragDrop);
            this.lstDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.LstDrop_DragEnter);
            // 
            // btnStitch
            // 
            this.btnStitch.Location = new System.Drawing.Point(148, 318);
            this.btnStitch.Name = "btnStitch";
            this.btnStitch.Size = new System.Drawing.Size(75, 23);
            this.btnStitch.TabIndex = 2;
            this.btnStitch.Text = "Stitch";
            this.btnStitch.UseVisualStyleBackColor = true;
            this.btnStitch.Click += new System.EventHandler(this.BtnStitch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(377, 401);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStitch);
            this.Controls.Add(this.lstDrop);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstDrop;
        private System.Windows.Forms.Button btnStitch;
        private System.Windows.Forms.Button button1;
    }
}


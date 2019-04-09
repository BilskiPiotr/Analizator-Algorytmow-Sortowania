namespace Analizator_Algorytmow_Sortowania
{
    partial class BubbleSortDemo
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
            this.pbDemo = new System.Windows.Forms.PictureBox();
            this.btDemoStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDemo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDemo
            // 
            this.pbDemo.BackColor = System.Drawing.Color.Ivory;
            this.pbDemo.Location = new System.Drawing.Point(-1, 55);
            this.pbDemo.Margin = new System.Windows.Forms.Padding(0);
            this.pbDemo.Name = "pbDemo";
            this.pbDemo.Size = new System.Drawing.Size(985, 510);
            this.pbDemo.TabIndex = 1;
            this.pbDemo.TabStop = false;
            this.pbDemo.Click += new System.EventHandler(this.PbDemo_Click);
            // 
            // btDemoStatus
            // 
            this.btDemoStatus.BackColor = System.Drawing.Color.Ivory;
            this.btDemoStatus.Enabled = false;
            this.btDemoStatus.FlatAppearance.BorderSize = 0;
            this.btDemoStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDemoStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btDemoStatus.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btDemoStatus.Location = new System.Drawing.Point(731, 507);
            this.btDemoStatus.Name = "btDemoStatus";
            this.btDemoStatus.Size = new System.Drawing.Size(232, 34);
            this.btDemoStatus.TabIndex = 2;
            this.btDemoStatus.Text = "Click to start DEMO";
            this.btDemoStatus.UseVisualStyleBackColor = false;
            this.btDemoStatus.Click += new System.EventHandler(this.BtDemoStatus_Click);
            // 
            // BubbleSortDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btDemoStatus);
            this.Controls.Add(this.pbDemo);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BubbleSortDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bubble Sort Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BubbleSortDemo_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BubbleSortDemo_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pbDemo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox pbDemo;
        private System.Windows.Forms.Button btDemoStatus;
    }
}
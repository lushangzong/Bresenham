namespace bresenham
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Options = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.start_button = new System.Windows.Forms.Button();
            this.center_button = new System.Windows.Forms.Button();
            this.end_button = new System.Windows.Forms.Button();
            this.radius_button = new System.Windows.Forms.Button();
            this.draw_button = new System.Windows.Forms.Button();
            this.clean_button = new System.Windows.Forms.Button();
            this.radius_box = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Options});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1033, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Options
            // 
            this.Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.arcToolStripMenuItem});
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(79, 24);
            this.Options.Text = "Options";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // arcToolStripMenuItem
            // 
            this.arcToolStripMenuItem.Name = "arcToolStripMenuItem";
            this.arcToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.arcToolStripMenuItem.Text = "Arc";
            this.arcToolStripMenuItem.Click += new System.EventHandler(this.arcToolStripMenuItem_Click);
            // 
            // PictureBox
            // 
            this.PictureBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.PictureBox.Location = new System.Drawing.Point(12, 31);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(1001, 601);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox.TabIndex = 1;
            this.PictureBox.TabStop = false;
            this.PictureBox.WaitOnLoad = true;
            this.PictureBox.Click += new System.EventHandler(this.PictureBox_Click);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(12, 638);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(83, 33);
            this.start_button.TabIndex = 2;
            this.start_button.Text = "选择起点";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // center_button
            // 
            this.center_button.Location = new System.Drawing.Point(12, 638);
            this.center_button.Name = "center_button";
            this.center_button.Size = new System.Drawing.Size(83, 33);
            this.center_button.TabIndex = 3;
            this.center_button.Text = "选择圆心";
            this.center_button.UseVisualStyleBackColor = true;
            this.center_button.Click += new System.EventHandler(this.center_button_Click);
            // 
            // end_button
            // 
            this.end_button.Location = new System.Drawing.Point(318, 638);
            this.end_button.Name = "end_button";
            this.end_button.Size = new System.Drawing.Size(83, 33);
            this.end_button.TabIndex = 4;
            this.end_button.Text = "选择终点";
            this.end_button.UseVisualStyleBackColor = true;
            this.end_button.Click += new System.EventHandler(this.end_button_Click);
            // 
            // radius_button
            // 
            this.radius_button.Location = new System.Drawing.Point(318, 638);
            this.radius_button.Name = "radius_button";
            this.radius_button.Size = new System.Drawing.Size(83, 33);
            this.radius_button.TabIndex = 5;
            this.radius_button.Text = "输入半径";
            this.radius_button.UseVisualStyleBackColor = true;
            // 
            // draw_button
            // 
            this.draw_button.Location = new System.Drawing.Point(624, 638);
            this.draw_button.Name = "draw_button";
            this.draw_button.Size = new System.Drawing.Size(83, 33);
            this.draw_button.TabIndex = 6;
            this.draw_button.Text = "画图";
            this.draw_button.UseVisualStyleBackColor = true;
            this.draw_button.Click += new System.EventHandler(this.draw_button_Click);
            // 
            // clean_button
            // 
            this.clean_button.Location = new System.Drawing.Point(930, 638);
            this.clean_button.Name = "clean_button";
            this.clean_button.Size = new System.Drawing.Size(83, 33);
            this.clean_button.TabIndex = 7;
            this.clean_button.Text = "清除";
            this.clean_button.UseVisualStyleBackColor = true;
            this.clean_button.Click += new System.EventHandler(this.clean_button_Click);
            // 
            // radius_box
            // 
            this.radius_box.Location = new System.Drawing.Point(407, 644);
            this.radius_box.Name = "radius_box";
            this.radius_box.Size = new System.Drawing.Size(115, 25);
            this.radius_box.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1033, 674);
            this.Controls.Add(this.radius_box);
            this.Controls.Add(this.clean_button);
            this.Controls.Add(this.draw_button);
            this.Controls.Add(this.radius_button);
            this.Controls.Add(this.end_button);
            this.Controls.Add(this.center_button);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(100, 100);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Options;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arcToolStripMenuItem;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button center_button;
        private System.Windows.Forms.Button end_button;
        private System.Windows.Forms.Button radius_button;
        private System.Windows.Forms.Button draw_button;
        private System.Windows.Forms.Button clean_button;
        private System.Windows.Forms.TextBox radius_box;
    }
}


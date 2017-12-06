namespace VS2017LayoutCleanup
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
            this.lSelectTip = new System.Windows.Forms.Label();
            this.bSelectDir = new System.Windows.Forms.Button();
            this.tbLayoutDir = new System.Windows.Forms.TextBox();
            this.fbdSelectDir = new System.Windows.Forms.FolderBrowserDialog();
            this.bCleanup = new System.Windows.Forms.Button();
            this.lClenupTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lSelectTip
            // 
            this.lSelectTip.AutoSize = true;
            this.lSelectTip.Location = new System.Drawing.Point(12, 23);
            this.lSelectTip.Name = "lSelectTip";
            this.lSelectTip.Size = new System.Drawing.Size(113, 12);
            this.lSelectTip.TabIndex = 0;
            this.lSelectTip.Text = "请选择离线包目录：";
            // 
            // bSelectDir
            // 
            this.bSelectDir.Location = new System.Drawing.Point(351, 50);
            this.bSelectDir.Name = "bSelectDir";
            this.bSelectDir.Size = new System.Drawing.Size(87, 23);
            this.bSelectDir.TabIndex = 1;
            this.bSelectDir.Text = "选择离线目录";
            this.bSelectDir.UseVisualStyleBackColor = true;
            this.bSelectDir.Click += new System.EventHandler(this.bSelectDir_Click);
            // 
            // tbLayoutDir
            // 
            this.tbLayoutDir.Location = new System.Drawing.Point(14, 50);
            this.tbLayoutDir.Name = "tbLayoutDir";
            this.tbLayoutDir.Size = new System.Drawing.Size(331, 21);
            this.tbLayoutDir.TabIndex = 2;
            // 
            // fbdSelectDir
            // 
            this.fbdSelectDir.Description = "请选择离线目录";
            this.fbdSelectDir.ShowNewFolderButton = false;
            // 
            // bCleanup
            // 
            this.bCleanup.Location = new System.Drawing.Point(14, 94);
            this.bCleanup.Name = "bCleanup";
            this.bCleanup.Size = new System.Drawing.Size(75, 23);
            this.bCleanup.TabIndex = 3;
            this.bCleanup.Text = "开始清理";
            this.bCleanup.UseVisualStyleBackColor = true;
            this.bCleanup.Click += new System.EventHandler(this.bCleanup_Click);
            // 
            // lClenupTip
            // 
            this.lClenupTip.AutoSize = true;
            this.lClenupTip.Location = new System.Drawing.Point(105, 99);
            this.lClenupTip.Name = "lClenupTip";
            this.lClenupTip.Size = new System.Drawing.Size(341, 12);
            this.lClenupTip.TabIndex = 4;
            this.lClenupTip.Text = "清理的过期安装包，自动移入Backup目录，请确认后人工删除。";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 138);
            this.Controls.Add(this.lClenupTip);
            this.Controls.Add(this.bCleanup);
            this.Controls.Add(this.tbLayoutDir);
            this.Controls.Add(this.bSelectDir);
            this.Controls.Add(this.lSelectTip);
            this.Name = "Form1";
            this.Text = "VS2017 离线包清理工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSelectTip;
        private System.Windows.Forms.Button bSelectDir;
        private System.Windows.Forms.TextBox tbLayoutDir;
        private System.Windows.Forms.FolderBrowserDialog fbdSelectDir;
        private System.Windows.Forms.Button bCleanup;
        private System.Windows.Forms.Label lClenupTip;
    }
}


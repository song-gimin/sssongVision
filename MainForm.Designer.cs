namespace sssongVision
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.setUpToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1632, 33);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageOpenToolStripMenuItem,
            this.imageSaveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.fileToolStripMenuItem.Text = " File";
            // 
            // imageOpenToolStripMenuItem
            // 
            this.imageOpenToolStripMenuItem.Name = "imageOpenToolStripMenuItem";
            this.imageOpenToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.imageOpenToolStripMenuItem.Text = "Image Open";
            this.imageOpenToolStripMenuItem.Click += new System.EventHandler(this.imageOpenToolStripMenuItem_Click);
            // 
            // imageSaveToolStripMenuItem
            // 
            this.imageSaveToolStripMenuItem.Name = "imageSaveToolStripMenuItem";
            this.imageSaveToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.imageSaveToolStripMenuItem.Text = "Image Save";
            this.imageSaveToolStripMenuItem.Click += new System.EventHandler(this.imageSaveToolStripMenuItem_Click);
            // 
            // setUpToolStripMenuItem
            // 
            this.setUpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem1});
            this.setUpToolStripMenuItem.Name = "setUpToolStripMenuItem";
            this.setUpToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.setUpToolStripMenuItem.Text = "Setup";
            // 
            // setupToolStripMenuItem1
            // 
            this.setupToolStripMenuItem1.Name = "setupToolStripMenuItem1";
            this.setupToolStripMenuItem1.Size = new System.Drawing.Size(161, 34);
            this.setupToolStripMenuItem1.Text = "Setup";
            this.setupToolStripMenuItem1.Click += new System.EventHandler(this.setupToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1632, 965);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "sssongVision";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem1;
    }
}


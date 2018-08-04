namespace MogwaicoinMiner
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMinerInfo = new System.Windows.Forms.Panel();
            this.pnlCarousal = new System.Windows.Forms.Panel();
            this.oneMinerNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.taskbarMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMainInfo = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.taskbarMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1409, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.advancedToolStripMenuItem.Text = "SETTINGS";
            this.advancedToolStripMenuItem.Click += new System.EventHandler(this.advancedToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.donateToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.aboutToolStripMenuItem.Text = "HELP";
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(132, 26);
            this.donateToolStripMenuItem.Text = "HELP";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(132, 26);
            this.aboutToolStripMenuItem1.Text = "ABOUT";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // pnlMinerInfo
            // 
            this.pnlMinerInfo.BackColor = System.Drawing.Color.White;
            this.pnlMinerInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMinerInfo.Location = new System.Drawing.Point(11, 383);
            this.pnlMinerInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMinerInfo.Name = "pnlMinerInfo";
            this.pnlMinerInfo.Size = new System.Drawing.Size(1386, 440);
            this.pnlMinerInfo.TabIndex = 2;
            this.pnlMinerInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMinerInfo_Paint);
            // 
            // pnlCarousal
            // 
            this.pnlCarousal.BackColor = System.Drawing.Color.White;
            this.pnlCarousal.Location = new System.Drawing.Point(995, 41);
            this.pnlCarousal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlCarousal.Name = "pnlCarousal";
            this.pnlCarousal.Size = new System.Drawing.Size(403, 325);
            this.pnlCarousal.TabIndex = 0;
            // 
            // oneMinerNotifyIcon
            // 
            this.oneMinerNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("oneMinerNotifyIcon.Icon")));
            this.oneMinerNotifyIcon.Text = "MogwaicoinMiner";
            this.oneMinerNotifyIcon.Visible = true;
            this.oneMinerNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.oneMinerNotifyIcon_MouseDoubleClick);
            // 
            // taskbarMenu
            // 
            this.taskbarMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.taskbarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.taskbarMenu.Name = "taskbarMenu";
            this.taskbarMenu.Size = new System.Drawing.Size(115, 52);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pnlMainInfo
            // 
            this.pnlMainInfo.BackColor = System.Drawing.Color.White;
            this.pnlMainInfo.Location = new System.Drawing.Point(12, 41);
            this.pnlMainInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMainInfo.Name = "pnlMainInfo";
            this.pnlMainInfo.Size = new System.Drawing.Size(965, 325);
            this.pnlMainInfo.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1409, 832);
            this.Controls.Add(this.pnlMainInfo);
            this.Controls.Add(this.pnlCarousal);
            this.Controls.Add(this.pnlMinerInfo);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Mogwaicoin One Click Miner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.taskbarMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Panel pnlMinerInfo;
        private System.Windows.Forms.Panel pnlCarousal;
        private System.Windows.Forms.NotifyIcon oneMinerNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip taskbarMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMainInfo;
    }
}


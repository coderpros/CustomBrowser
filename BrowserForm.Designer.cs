namespace CustomBrowser
{
    partial class BrowserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.MainMenuStrip = new System.Windows.Forms.ToolStrip();
            this.CloseWindowButton = new System.Windows.Forms.ToolStripButton();
            this.MaximizeWindowButton = new System.Windows.Forms.ToolStripButton();
            this.RestoreWindowButton = new System.Windows.Forms.ToolStripButton();
            this.MinimizeWindowButton = new System.Windows.Forms.ToolStripButton();
            this.FormCaptionLabel = new System.Windows.Forms.ToolStripLabel();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.NotifyIconStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStripContainer
            // 
            this.ToolStripContainer.BottomToolStripPanelVisible = false;
            // 
            // ToolStripContainer.ContentPanel
            // 
            resources.ApplyResources(this.ToolStripContainer.ContentPanel, "ToolStripContainer.ContentPanel");
            this.ToolStripContainer.ContentPanel.Controls.Add(this.StatusLabel);
            this.ToolStripContainer.ContentPanel.Controls.Add(this.OutputLabel);
            this.ToolStripContainer.ContentPanel.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.ToolStripContainer, "ToolStripContainer");
            this.ToolStripContainer.LeftToolStripPanelVisible = false;
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.RightToolStripPanelVisible = false;
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            resources.ApplyResources(this.ToolStripContainer.TopToolStripPanel, "ToolStripContainer.TopToolStripPanel");
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.MainMenuStrip);
            this.ToolStripContainer.TopToolStripPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToolStripContainer.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // StatusLabel
            // 
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            this.StatusLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.StatusLabel.Name = "StatusLabel";
            // 
            // OutputLabel
            // 
            resources.ApplyResources(this.OutputLabel, "OutputLabel");
            this.OutputLabel.BackColor = System.Drawing.Color.Silver;
            this.OutputLabel.Name = "OutputLabel";
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(25)))));
            this.MainMenuStrip.CanOverflow = false;
            resources.ApplyResources(this.MainMenuStrip, "MainMenuStrip");
            this.MainMenuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.MainMenuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseWindowButton,
            this.MaximizeWindowButton,
            this.RestoreWindowButton,
            this.MinimizeWindowButton,
            this.FormCaptionLabel});
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainMenuStrip.Stretch = true;
            this.MainMenuStrip.DoubleClick += new System.EventHandler(this.toolStrip1_DoubleClick);
            this.MainMenuStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseMove);
            // 
            // CloseWindowButton
            // 
            this.CloseWindowButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CloseWindowButton.AutoToolTip = false;
            this.CloseWindowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.CloseWindowButton, "CloseWindowButton");
            this.CloseWindowButton.ForeColor = System.Drawing.Color.Silver;
            this.CloseWindowButton.Name = "CloseWindowButton";
            this.CloseWindowButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MaximizeWindowButton
            // 
            this.MaximizeWindowButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MaximizeWindowButton.AutoToolTip = false;
            this.MaximizeWindowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.MaximizeWindowButton, "MaximizeWindowButton");
            this.MaximizeWindowButton.ForeColor = System.Drawing.Color.Silver;
            this.MaximizeWindowButton.Name = "MaximizeWindowButton";
            this.MaximizeWindowButton.Click += new System.EventHandler(this.MaximizeWindowButton_Click);
            // 
            // RestoreWindowButton
            // 
            this.RestoreWindowButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RestoreWindowButton.AutoToolTip = false;
            this.RestoreWindowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.RestoreWindowButton, "RestoreWindowButton");
            this.RestoreWindowButton.ForeColor = System.Drawing.Color.Silver;
            this.RestoreWindowButton.Name = "RestoreWindowButton";
            this.RestoreWindowButton.Click += new System.EventHandler(this.RestoreWindowButton_Click);
            // 
            // MinimizeWindowButton
            // 
            this.MinimizeWindowButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MinimizeWindowButton.AutoToolTip = false;
            this.MinimizeWindowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.MinimizeWindowButton, "MinimizeWindowButton");
            this.MinimizeWindowButton.ForeColor = System.Drawing.Color.Silver;
            this.MinimizeWindowButton.Name = "MinimizeWindowButton";
            this.MinimizeWindowButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // FormCaptionLabel
            // 
            this.FormCaptionLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormCaptionLabel.Name = "FormCaptionLabel";
            resources.ApplyResources(this.FormCaptionLabel, "FormCaptionLabel");
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconStrip;
            resources.ApplyResources(this.NotifyIcon, "NotifyIcon");
            this.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // NotifyIconStrip
            // 
            this.NotifyIconStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.NotifyIconStrip.Name = "NotifyIconStrip";
            resources.ApplyResources(this.NotifyIconStrip, "NotifyIconStrip");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // BrowserForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.ToolStripContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BrowserForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Resize += new System.EventHandler(this.BrowserForm_Resize);
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.ContentPanel.PerformLayout();
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.NotifyIconStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer ToolStripContainer;
        private System.Windows.Forms.ToolStrip MainMenuStrip;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.ToolStripButton MinimizeWindowButton;
        private System.Windows.Forms.ToolStripButton CloseWindowButton;
        private System.Windows.Forms.ToolStripLabel FormCaptionLabel;
        private System.Windows.Forms.ToolStripButton MaximizeWindowButton;
        private System.Windows.Forms.ToolStripButton RestoreWindowButton;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyIconStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}
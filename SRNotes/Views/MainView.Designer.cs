namespace SRNotes
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ColoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForegroundColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenustripColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSizeInputtoolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.MainTextBox = new System.Windows.Forms.RichTextBox();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(1218, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.ColoursToolStripMenuItem,
            this.FontSizeToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openSettingsToolStripMenuItem.Text = "Open settings";
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.OpenSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // ColoursToolStripMenuItem
            // 
            this.ColoursToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ColoursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackgroundColourToolStripMenuItem,
            this.ForegroundColourToolStripMenuItem,
            this.MenustripColourToolStripMenuItem});
            this.ColoursToolStripMenuItem.Name = "ColoursToolStripMenuItem";
            this.ColoursToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ColoursToolStripMenuItem.Text = "Colours";
            // 
            // BackgroundColourToolStripMenuItem
            // 
            this.BackgroundColourToolStripMenuItem.Name = "BackgroundColourToolStripMenuItem";
            this.BackgroundColourToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.BackgroundColourToolStripMenuItem.Text = "Background";
            this.BackgroundColourToolStripMenuItem.Click += new System.EventHandler(this.BackgroundToolStripMenuItem_Click);
            // 
            // ForegroundColourToolStripMenuItem
            // 
            this.ForegroundColourToolStripMenuItem.Name = "ForegroundColourToolStripMenuItem";
            this.ForegroundColourToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.ForegroundColourToolStripMenuItem.Text = "Foreground";
            this.ForegroundColourToolStripMenuItem.Click += new System.EventHandler(this.ForegroundToolStripMenuItem_Click);
            // 
            // MenustripColourToolStripMenuItem
            // 
            this.MenustripColourToolStripMenuItem.Name = "MenustripColourToolStripMenuItem";
            this.MenustripColourToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.MenustripColourToolStripMenuItem.Text = "Menustrip";
            this.MenustripColourToolStripMenuItem.Click += new System.EventHandler(this.MenustripToolStripMenuItem_Click);
            // 
            // FontSizeToolStripMenuItem
            // 
            this.FontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FontSizeInputtoolStripTextBox});
            this.FontSizeToolStripMenuItem.Name = "FontSizeToolStripMenuItem";
            this.FontSizeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FontSizeToolStripMenuItem.Text = "Font size";
            // 
            // FontSizeInputtoolStripTextBox
            // 
            this.FontSizeInputtoolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FontSizeInputtoolStripTextBox.Name = "FontSizeInputtoolStripTextBox";
            this.FontSizeInputtoolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.FontSizeInputtoolStripTextBox.Text = "11.0";
            this.FontSizeInputtoolStripTextBox.TextChanged += new System.EventHandler(this.FontSizeInputtoolStripTextBox_TextChanged);
            // 
            // MainTextBox
            // 
            this.MainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainTextBox.HideSelection = false;
            this.MainTextBox.Location = new System.Drawing.Point(13, 39);
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.ReadOnly = true;
            this.MainTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.MainTextBox.Size = new System.Drawing.Size(1185, 560);
            this.MainTextBox.TabIndex = 1;
            this.MainTextBox.Text = "";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1218, 609);
            this.Controls.Add(this.MainTextBox);
            this.Controls.Add(this.MainMenuStrip);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            this.Text = "SRNotes";
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.RichTextBox MainTextBox;
        private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ColoursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackgroundColourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ForegroundColourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenustripColourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox FontSizeInputtoolStripTextBox;
    }
}


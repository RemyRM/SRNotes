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
            this.MainAppMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ColoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackgroundColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ForegroundColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenustripColourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontSizeInputtoolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.hotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScrollUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScrollDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScrollingSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContinuousScrollingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContinuousFalseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContinuousTrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrollSpeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScrollSpeedToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SelectCurrentLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectLineFalseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectLineTrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectedLineOffsetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectedLineOffsetToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.LoadLastFileOnOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadLastFileFalseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadLastFileTrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StoreImageWindowPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StoreImageWinPosFalseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StoreImageWinPosTrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageWindowAlwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageWindowOnTopFalseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageWindowOnTopTrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTextBox = new System.Windows.Forms.RichTextBox();
            this.MainAppMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainAppMenuStrip
            // 
            this.MainAppMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.SettingsToolStripMenuItem});
            this.MainAppMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainAppMenuStrip.Name = "MainAppMenuStrip";
            this.MainAppMenuStrip.Size = new System.Drawing.Size(1218, 24);
            this.MainAppMenuStrip.TabIndex = 0;
            this.MainAppMenuStrip.Text = "menuStrip1";
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
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.ColoursToolStripMenuItem,
            this.FontSizeToolStripMenuItem,
            this.hotkeysToolStripMenuItem,
            this.ScrollingSettingsToolStripMenuItem,
            this.LoadLastFileOnOpenToolStripMenuItem,
            this.StoreImageWindowPositionToolStripMenuItem,
            this.ImageWindowAlwaysOnTopToolStripMenuItem});
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.SettingsToolStripMenuItem.Text = "Settings";
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            this.openSettingsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.openSettingsToolStripMenuItem.Text = "Open settings";
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.OpenSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // ColoursToolStripMenuItem
            // 
            this.ColoursToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ColoursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackgroundColourToolStripMenuItem,
            this.ForegroundColourToolStripMenuItem,
            this.MenustripColourToolStripMenuItem});
            this.ColoursToolStripMenuItem.Name = "ColoursToolStripMenuItem";
            this.ColoursToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.ColoursToolStripMenuItem.Text = "Colours";
            // 
            // BackgroundColourToolStripMenuItem
            // 
            this.BackgroundColourToolStripMenuItem.Name = "BackgroundColourToolStripMenuItem";
            this.BackgroundColourToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.BackgroundColourToolStripMenuItem.Text = "Background";
            this.BackgroundColourToolStripMenuItem.Click += new System.EventHandler(this.BackgroundToolStripMenuItem_Click);
            // 
            // ForegroundColourToolStripMenuItem
            // 
            this.ForegroundColourToolStripMenuItem.Name = "ForegroundColourToolStripMenuItem";
            this.ForegroundColourToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ForegroundColourToolStripMenuItem.Text = "Foreground";
            this.ForegroundColourToolStripMenuItem.Click += new System.EventHandler(this.ForegroundToolStripMenuItem_Click);
            // 
            // MenustripColourToolStripMenuItem
            // 
            this.MenustripColourToolStripMenuItem.Name = "MenustripColourToolStripMenuItem";
            this.MenustripColourToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.MenustripColourToolStripMenuItem.Text = "Menustrip";
            this.MenustripColourToolStripMenuItem.Click += new System.EventHandler(this.MenustripToolStripMenuItem_Click);
            // 
            // FontSizeToolStripMenuItem
            // 
            this.FontSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FontSizeInputtoolStripTextBox});
            this.FontSizeToolStripMenuItem.Name = "FontSizeToolStripMenuItem";
            this.FontSizeToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
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
            // hotkeysToolStripMenuItem
            // 
            this.hotkeysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScrollUpToolStripMenuItem,
            this.ScrollDownToolStripMenuItem});
            this.hotkeysToolStripMenuItem.Name = "hotkeysToolStripMenuItem";
            this.hotkeysToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.hotkeysToolStripMenuItem.Text = "Hotkeys";
            // 
            // ScrollUpToolStripMenuItem
            // 
            this.ScrollUpToolStripMenuItem.Name = "ScrollUpToolStripMenuItem";
            this.ScrollUpToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.ScrollUpToolStripMenuItem.Text = "Scroll Up";
            this.ScrollUpToolStripMenuItem.Click += new System.EventHandler(this.ScrollUpToolStripMenuItem_Click);
            // 
            // ScrollDownToolStripMenuItem
            // 
            this.ScrollDownToolStripMenuItem.Name = "ScrollDownToolStripMenuItem";
            this.ScrollDownToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.ScrollDownToolStripMenuItem.Text = "Scroll Down";
            this.ScrollDownToolStripMenuItem.Click += new System.EventHandler(this.ScrollDownToolStripMenuItem_Click);
            // 
            // ScrollingSettingsToolStripMenuItem
            // 
            this.ScrollingSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContinuousScrollingToolStripMenuItem,
            this.scrollSpeedToolStripMenuItem,
            this.SelectCurrentLineToolStripMenuItem,
            this.SelectedLineOffsetToolStripMenuItem});
            this.ScrollingSettingsToolStripMenuItem.Name = "ScrollingSettingsToolStripMenuItem";
            this.ScrollingSettingsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.ScrollingSettingsToolStripMenuItem.Text = "Scrolling";
            // 
            // ContinuousScrollingToolStripMenuItem
            // 
            this.ContinuousScrollingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContinuousFalseToolStripMenuItem,
            this.ContinuousTrueToolStripMenuItem});
            this.ContinuousScrollingToolStripMenuItem.Name = "ContinuousScrollingToolStripMenuItem";
            this.ContinuousScrollingToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.ContinuousScrollingToolStripMenuItem.Text = "Continuous scrolling";
            // 
            // ContinuousFalseToolStripMenuItem
            // 
            this.ContinuousFalseToolStripMenuItem.Checked = true;
            this.ContinuousFalseToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ContinuousFalseToolStripMenuItem.Name = "ContinuousFalseToolStripMenuItem";
            this.ContinuousFalseToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ContinuousFalseToolStripMenuItem.Text = "False";
            this.ContinuousFalseToolStripMenuItem.Click += new System.EventHandler(this.ContinuousFalseToolStripMenuItem_Click);
            // 
            // ContinuousTrueToolStripMenuItem
            // 
            this.ContinuousTrueToolStripMenuItem.Name = "ContinuousTrueToolStripMenuItem";
            this.ContinuousTrueToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ContinuousTrueToolStripMenuItem.Text = "True";
            this.ContinuousTrueToolStripMenuItem.Click += new System.EventHandler(this.ContinuousTrueToolStripMenuItem_Click);
            // 
            // scrollSpeedToolStripMenuItem
            // 
            this.scrollSpeedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScrollSpeedToolStripTextBox});
            this.scrollSpeedToolStripMenuItem.Name = "scrollSpeedToolStripMenuItem";
            this.scrollSpeedToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.scrollSpeedToolStripMenuItem.Text = "Scroll speed";
            // 
            // ScrollSpeedToolStripTextBox
            // 
            this.ScrollSpeedToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ScrollSpeedToolStripTextBox.Name = "ScrollSpeedToolStripTextBox";
            this.ScrollSpeedToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.ScrollSpeedToolStripTextBox.Text = "1";
            this.ScrollSpeedToolStripTextBox.TextChanged += new System.EventHandler(this.ScrollSpeedToolStripTextBox1_TextChanged);
            // 
            // SelectCurrentLineToolStripMenuItem
            // 
            this.SelectCurrentLineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectLineFalseToolStripMenuItem,
            this.SelectLineTrueToolStripMenuItem});
            this.SelectCurrentLineToolStripMenuItem.Name = "SelectCurrentLineToolStripMenuItem";
            this.SelectCurrentLineToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.SelectCurrentLineToolStripMenuItem.Text = "Select current line";
            // 
            // SelectLineFalseToolStripMenuItem
            // 
            this.SelectLineFalseToolStripMenuItem.Name = "SelectLineFalseToolStripMenuItem";
            this.SelectLineFalseToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.SelectLineFalseToolStripMenuItem.Text = "False";
            this.SelectLineFalseToolStripMenuItem.Click += new System.EventHandler(this.SelectLineFalseToolStripMenuItem_Click);
            // 
            // SelectLineTrueToolStripMenuItem
            // 
            this.SelectLineTrueToolStripMenuItem.Name = "SelectLineTrueToolStripMenuItem";
            this.SelectLineTrueToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.SelectLineTrueToolStripMenuItem.Text = "True";
            this.SelectLineTrueToolStripMenuItem.Click += new System.EventHandler(this.SelectLineTrueToolStripMenuItem_Click);
            // 
            // SelectedLineOffsetToolStripMenuItem
            // 
            this.SelectedLineOffsetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectedLineOffsetToolStripTextBox});
            this.SelectedLineOffsetToolStripMenuItem.Name = "SelectedLineOffsetToolStripMenuItem";
            this.SelectedLineOffsetToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.SelectedLineOffsetToolStripMenuItem.Text = "Selected line offset";
            // 
            // SelectedLineOffsetToolStripTextBox
            // 
            this.SelectedLineOffsetToolStripTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SelectedLineOffsetToolStripTextBox.Name = "SelectedLineOffsetToolStripTextBox";
            this.SelectedLineOffsetToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.SelectedLineOffsetToolStripTextBox.TextChanged += new System.EventHandler(this.SelectedLineOffsetToolStripTextBox_TextChanged);
            // 
            // LoadLastFileOnOpenToolStripMenuItem
            // 
            this.LoadLastFileOnOpenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadLastFileFalseToolStripMenuItem,
            this.LoadLastFileTrueToolStripMenuItem});
            this.LoadLastFileOnOpenToolStripMenuItem.Name = "LoadLastFileOnOpenToolStripMenuItem";
            this.LoadLastFileOnOpenToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.LoadLastFileOnOpenToolStripMenuItem.Text = "Load last file on open";
            // 
            // LoadLastFileFalseToolStripMenuItem
            // 
            this.LoadLastFileFalseToolStripMenuItem.Name = "LoadLastFileFalseToolStripMenuItem";
            this.LoadLastFileFalseToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.LoadLastFileFalseToolStripMenuItem.Text = "False";
            this.LoadLastFileFalseToolStripMenuItem.Click += new System.EventHandler(this.LoadLastFileFalseToolStripMenuItem_Click);
            // 
            // LoadLastFileTrueToolStripMenuItem
            // 
            this.LoadLastFileTrueToolStripMenuItem.Name = "LoadLastFileTrueToolStripMenuItem";
            this.LoadLastFileTrueToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.LoadLastFileTrueToolStripMenuItem.Text = "True";
            this.LoadLastFileTrueToolStripMenuItem.Click += new System.EventHandler(this.LoadLastFileTrueToolStripMenuItem_Click);
            // 
            // StoreImageWindowPositionToolStripMenuItem
            // 
            this.StoreImageWindowPositionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StoreImageWinPosFalseToolStripMenuItem,
            this.StoreImageWinPosTrueToolStripMenuItem});
            this.StoreImageWindowPositionToolStripMenuItem.Name = "StoreImageWindowPositionToolStripMenuItem";
            this.StoreImageWindowPositionToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.StoreImageWindowPositionToolStripMenuItem.Text = "Store image window position";
            // 
            // StoreImageWinPosFalseToolStripMenuItem
            // 
            this.StoreImageWinPosFalseToolStripMenuItem.Name = "StoreImageWinPosFalseToolStripMenuItem";
            this.StoreImageWinPosFalseToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.StoreImageWinPosFalseToolStripMenuItem.Text = "False";
            this.StoreImageWinPosFalseToolStripMenuItem.Click += new System.EventHandler(this.StoreImageWinPosFalseToolStripMenuItem_Click);
            // 
            // StoreImageWinPosTrueToolStripMenuItem
            // 
            this.StoreImageWinPosTrueToolStripMenuItem.Name = "StoreImageWinPosTrueToolStripMenuItem";
            this.StoreImageWinPosTrueToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.StoreImageWinPosTrueToolStripMenuItem.Text = "True";
            this.StoreImageWinPosTrueToolStripMenuItem.Click += new System.EventHandler(this.StoreImageWinPosTrueToolStripMenuItem_Click);
            // 
            // ImageWindowAlwaysOnTopToolStripMenuItem
            // 
            this.ImageWindowAlwaysOnTopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImageWindowOnTopFalseToolStripMenuItem,
            this.ImageWindowOnTopTrueToolStripMenuItem});
            this.ImageWindowAlwaysOnTopToolStripMenuItem.Name = "ImageWindowAlwaysOnTopToolStripMenuItem";
            this.ImageWindowAlwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.ImageWindowAlwaysOnTopToolStripMenuItem.Text = "Image window always on top";
            // 
            // ImageWindowOnTopFalseToolStripMenuItem
            // 
            this.ImageWindowOnTopFalseToolStripMenuItem.Name = "ImageWindowOnTopFalseToolStripMenuItem";
            this.ImageWindowOnTopFalseToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ImageWindowOnTopFalseToolStripMenuItem.Text = "False";
            this.ImageWindowOnTopFalseToolStripMenuItem.Click += new System.EventHandler(this.ImageWindowOnTopFalseToolStripMenuItem_Click);
            // 
            // ImageWindowOnTopTrueToolStripMenuItem
            // 
            this.ImageWindowOnTopTrueToolStripMenuItem.Name = "ImageWindowOnTopTrueToolStripMenuItem";
            this.ImageWindowOnTopTrueToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ImageWindowOnTopTrueToolStripMenuItem.Text = "True";
            this.ImageWindowOnTopTrueToolStripMenuItem.Click += new System.EventHandler(this.ImageWindowOnTopTrueToolStripMenuItem_Click);
            // 
            // MainTextBox
            // 
            this.MainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainTextBox.HideSelection = false;
            this.MainTextBox.Location = new System.Drawing.Point(12, 40);
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.ReadOnly = true;
            this.MainTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.MainTextBox.Size = new System.Drawing.Size(1194, 609);
            this.MainTextBox.TabIndex = 1;
            this.MainTextBox.Text = "";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1218, 661);
            this.Controls.Add(this.MainTextBox);
            this.Controls.Add(this.MainAppMenuStrip);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainView";
            this.Text = "SRNotes";
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.MainAppMenuStrip.ResumeLayout(false);
            this.MainAppMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainAppMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.RichTextBox MainTextBox;
        private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ColoursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BackgroundColourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ForegroundColourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenustripColourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox FontSizeInputtoolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem hotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScrollUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScrollDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScrollingSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContinuousScrollingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContinuousFalseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContinuousTrueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scrollSpeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox ScrollSpeedToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem SelectCurrentLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectLineFalseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectLineTrueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectedLineOffsetToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox SelectedLineOffsetToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem LoadLastFileOnOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadLastFileFalseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadLastFileTrueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StoreImageWindowPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StoreImageWinPosFalseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StoreImageWinPosTrueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageWindowAlwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageWindowOnTopFalseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageWindowOnTopTrueToolStripMenuItem;
    }
}


namespace SRNotes.Views
{
    partial class SetHotKeyForm
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
            this.FuncToBindLabel = new System.Windows.Forms.Label();
            this.SaveKeybindButton = new System.Windows.Forms.Button();
            this.PressedKeyPreview = new System.Windows.Forms.TextBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FuncToBindLabel
            // 
            this.FuncToBindLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FuncToBindLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FuncToBindLabel.Location = new System.Drawing.Point(21, 16);
            this.FuncToBindLabel.Name = "FuncToBindLabel";
            this.FuncToBindLabel.Size = new System.Drawing.Size(283, 36);
            this.FuncToBindLabel.TabIndex = 0;
            this.FuncToBindLabel.Text = "Scroll";
            this.FuncToBindLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveKeybindButton
            // 
            this.SaveKeybindButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveKeybindButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.SaveKeybindButton.ForeColor = System.Drawing.Color.Black;
            this.SaveKeybindButton.Location = new System.Drawing.Point(91, 174);
            this.SaveKeybindButton.Name = "SaveKeybindButton";
            this.SaveKeybindButton.Size = new System.Drawing.Size(144, 40);
            this.SaveKeybindButton.TabIndex = 2;
            this.SaveKeybindButton.Text = "Save";
            this.SaveKeybindButton.UseVisualStyleBackColor = true;
            this.SaveKeybindButton.Click += new System.EventHandler(this.SaveKeybindButton_Click);
            // 
            // PressedKeyPreview
            // 
            this.PressedKeyPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PressedKeyPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.PressedKeyPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PressedKeyPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.PressedKeyPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.PressedKeyPreview.ForeColor = System.Drawing.Color.White;
            this.PressedKeyPreview.Location = new System.Drawing.Point(25, 55);
            this.PressedKeyPreview.Name = "PressedKeyPreview";
            this.PressedKeyPreview.ReadOnly = true;
            this.PressedKeyPreview.Size = new System.Drawing.Size(269, 61);
            this.PressedKeyPreview.TabIndex = 3;
            this.PressedKeyPreview.Text = "~";
            this.PressedKeyPreview.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PressedKeyPreview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PressedKeyPreview_KeyDown);
            // 
            // InfoLabel
            // 
            this.InfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.InfoLabel.Location = new System.Drawing.Point(5, 129);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(303, 23);
            this.InfoLabel.TabIndex = 4;
            this.InfoLabel.Text = "Click inside the box and press the key to bind";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetHotKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(317, 241);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.PressedKeyPreview);
            this.Controls.Add(this.SaveKeybindButton);
            this.Controls.Add(this.FuncToBindLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetHotKeyForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SetHotKeyForm";
            this.Shown += new System.EventHandler(this.SetHotKeyForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FuncToBindLabel;
        private System.Windows.Forms.Button SaveKeybindButton;
        private System.Windows.Forms.TextBox PressedKeyPreview;
        private System.Windows.Forms.Label InfoLabel;
    }
}
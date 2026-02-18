namespace ClipboardNavigator
{
    partial class MainSettingsForm
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
            cbAutoStart = new CheckBox();
            cbAutoHide = new CheckBox();
            SuspendLayout();
            // 
            // cbAutoStart
            // 
            cbAutoStart.AutoSize = true;
            cbAutoStart.Location = new Point(12, 12);
            cbAutoStart.Name = "cbAutoStart";
            cbAutoStart.Size = new Size(195, 24);
            cbAutoStart.TabIndex = 0;
            cbAutoStart.Text = "Auto Start with Windows";
            cbAutoStart.UseVisualStyleBackColor = true;
            cbAutoStart.CheckedChanged += cbAutoStart_CheckedChanged;
            // 
            // cbAutoHide
            // 
            cbAutoHide.AutoSize = true;
            cbAutoHide.Enabled = false;
            cbAutoHide.Location = new Point(34, 42);
            cbAutoHide.Name = "cbAutoHide";
            cbAutoHide.Size = new Size(112, 24);
            cbAutoHide.TabIndex = 1;
            cbAutoHide.Text = "Start hidden";
            cbAutoHide.UseVisualStyleBackColor = true;
            cbAutoHide.CheckedChanged += cbAutoHide_CheckedChanged;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbAutoHide);
            Controls.Add(cbAutoStart);
            Name = "MainSettingsForm";
            Text = "SettingsForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private CheckBox cbAutoStart;
        private CheckBox cbAutoHide;
    }
}
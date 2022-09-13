namespace ClipboardNavigator
{
    partial class ClipboardListBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbClipboardHistory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbClipboardHistory
            // 
            this.lbClipboardHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbClipboardHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbClipboardHistory.FormattingEnabled = true;
            this.lbClipboardHistory.ItemHeight = 20;
            this.lbClipboardHistory.Location = new System.Drawing.Point(0, 0);
            this.lbClipboardHistory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbClipboardHistory.Name = "lbClipboardHistory";
            this.lbClipboardHistory.Size = new System.Drawing.Size(359, 535);
            this.lbClipboardHistory.TabIndex = 2;
            this.lbClipboardHistory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbClipboardHistory_MouseClick);
            // 
            // ClipboardListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbClipboardHistory);
            this.Name = "ClipboardListBox";
            this.Size = new System.Drawing.Size(359, 535);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lbClipboardHistory;
    }
}

namespace ClipboardNavigator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvClipboardHistory = new System.Windows.Forms.ListView();
            this.lbClipboardHistory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lvClipboardHistory
            // 
            this.lvClipboardHistory.Location = new System.Drawing.Point(0, 0);
            this.lvClipboardHistory.Name = "lvClipboardHistory";
            this.lvClipboardHistory.Size = new System.Drawing.Size(661, 116);
            this.lvClipboardHistory.TabIndex = 0;
            this.lvClipboardHistory.UseCompatibleStateImageBehavior = false;
            this.lvClipboardHistory.View = System.Windows.Forms.View.List;
            // 
            // lbClipboardHistory
            // 
            this.lbClipboardHistory.FormattingEnabled = true;
            this.lbClipboardHistory.ItemHeight = 15;
            this.lbClipboardHistory.Location = new System.Drawing.Point(44, 187);
            this.lbClipboardHistory.Name = "lbClipboardHistory";
            this.lbClipboardHistory.Size = new System.Drawing.Size(493, 139);
            this.lbClipboardHistory.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 431);
            this.Controls.Add(this.lbClipboardHistory);
            this.Controls.Add(this.lvClipboardHistory);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView lvClipboardHistory;
        private ListBox lbClipboardHistory;
    }
}
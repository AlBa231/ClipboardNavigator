namespace ClipboardNavigator
{
    partial class TaskBarPopupForm
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
            this.timerHideForm = new System.Windows.Forms.Timer(this.components);
            this.lbClipboardHistory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // timerHideForm
            // 
            this.timerHideForm.Interval = 2000;
            this.timerHideForm.Tick += new System.EventHandler(this.timerHideForm_Tick);
            // 
            // lbClipboardHistory
            // 
            this.lbClipboardHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbClipboardHistory.FormattingEnabled = true;
            this.lbClipboardHistory.ItemHeight = 20;
            this.lbClipboardHistory.Location = new System.Drawing.Point(0, 0);
            this.lbClipboardHistory.Name = "lbClipboardHistory";
            this.lbClipboardHistory.Size = new System.Drawing.Size(357, 480);
            this.lbClipboardHistory.TabIndex = 0;
            // 
            // TaskBarPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 480);
            this.ControlBox = false;
            this.Controls.Add(this.lbClipboardHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskBarPopupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TaskBarPopupForm";
            this.TopMost = true;
            this.MouseEnter += new System.EventHandler(this.TaskBarPopupForm_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.TaskBarPopupForm_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerHideForm;
        private ListBox lbClipboardHistory;
    }
}
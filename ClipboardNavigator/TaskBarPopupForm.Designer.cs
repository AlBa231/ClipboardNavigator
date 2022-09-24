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
            this.clipboardListBox = new ClipboardNavigator.ClipboardListBox();
            this.SuspendLayout();
            // 
            // timerHideForm
            // 
            this.timerHideForm.Interval = 2000;
            this.timerHideForm.Tick += new System.EventHandler(this.timerHideForm_Tick);
            // 
            // clipboardListBox
            // 
            this.clipboardListBox.ClipboardFacade = null;
            this.clipboardListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clipboardListBox.Location = new System.Drawing.Point(0, 0);
            this.clipboardListBox.Name = "clipboardListBox";
            this.clipboardListBox.SelectedItem = null;
            this.clipboardListBox.Size = new System.Drawing.Size(357, 480);
            this.clipboardListBox.TabIndex = 1;
            this.clipboardListBox.MouseEnter += new System.EventHandler(this.TaskBarPopupForm_MouseEnter);
            this.clipboardListBox.MouseLeave += new System.EventHandler(this.TaskBarPopupForm_MouseLeave);
            // 
            // TaskBarPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 480);
            this.ControlBox = false;
            this.Controls.Add(this.clipboardListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskBarPopupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TaskBarPopupForm";
            this.TopMost = true;
            this.Enter += new System.EventHandler(this.TaskBarPopupForm_Enter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerHideForm;
        private ClipboardListBox clipboardListBox;
    }
}
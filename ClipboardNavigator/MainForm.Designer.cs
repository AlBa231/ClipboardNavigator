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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            mainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem1 = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            splitContainer = new SplitContainer();
            textBoxCurrentClipboard = new TextBox();
            clipboardListBox = new ClipboardListBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            notifyIcon = new NotifyIcon(components);
            contextMenuNotifyIcon = new ContextMenuStrip(components);
            hideShowToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem1 = new ToolStripMenuItem();
            panel1 = new Panel();
            btnHide = new Button();
            btnOk = new Button();
            showHideMainWindowToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            statusStrip1.SuspendLayout();
            contextMenuNotifyIcon.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1 });
            toolStrip1.Location = new Point(0, 28);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(755, 27);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(29, 24);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // mainMenu
            // 
            mainMenu.ImageScalingSize = new Size(20, 20);
            mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(755, 28);
            mainMenu.TabIndex = 3;
            mainMenu.Text = "mainMenu";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem1
            // 
            settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            settingsToolStripMenuItem1.Size = new Size(145, 26);
            settingsToolStripMenuItem1.Text = "Settings";
            settingsToolStripMenuItem1.Click += settingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(145, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 55);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(textBoxCurrentClipboard);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(clipboardListBox);
            splitContainer.Size = new Size(755, 520);
            splitContainer.SplitterDistance = 523;
            splitContainer.TabIndex = 4;
            // 
            // textBoxCurrentClipboard
            // 
            textBoxCurrentClipboard.Dock = DockStyle.Fill;
            textBoxCurrentClipboard.Location = new Point(0, 0);
            textBoxCurrentClipboard.Multiline = true;
            textBoxCurrentClipboard.Name = "textBoxCurrentClipboard";
            textBoxCurrentClipboard.ScrollBars = ScrollBars.Both;
            textBoxCurrentClipboard.Size = new Size(523, 520);
            textBoxCurrentClipboard.TabIndex = 0;
            // 
            // clipboardListBox
            // 
            clipboardListBox.ClipboardFacade = null;
            clipboardListBox.Dock = DockStyle.Fill;
            clipboardListBox.Location = new Point(0, 0);
            clipboardListBox.Name = "clipboardListBox";
            clipboardListBox.SelectedItem = null;
            clipboardListBox.Size = new Size(228, 520);
            clipboardListBox.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 549);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(755, 26);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(55, 20);
            toolStripStatusLabel1.Text = "Rows:0";
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipText = "test";
            notifyIcon.ContextMenuStrip = contextMenuNotifyIcon;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Clipboard Navigator";
            notifyIcon.Visible = true;
            notifyIcon.MouseClick += notifyIcon_MouseClick;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // contextMenuNotifyIcon
            // 
            contextMenuNotifyIcon.ImageScalingSize = new Size(20, 20);
            contextMenuNotifyIcon.Items.AddRange(new ToolStripItem[] { hideShowToolStripMenuItem, showHideMainWindowToolStripMenuItem, settingsToolStripMenuItem, exitToolStripMenuItem1 });
            contextMenuNotifyIcon.Name = "contextMenuStrip2";
            contextMenuNotifyIcon.Size = new Size(246, 128);
            // 
            // hideShowToolStripMenuItem
            // 
            hideShowToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            hideShowToolStripMenuItem.Name = "hideShowToolStripMenuItem";
            hideShowToolStripMenuItem.Size = new Size(245, 24);
            hideShowToolStripMenuItem.Text = "Hide/Show";
            hideShowToolStripMenuItem.Click += hideShowToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(245, 24);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem1
            // 
            exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            exitToolStripMenuItem1.Size = new Size(245, 24);
            exitToolStripMenuItem1.Text = "Exit";
            exitToolStripMenuItem1.Click += exitToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnHide);
            panel1.Controls.Add(btnOk);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 512);
            panel1.Name = "panel1";
            panel1.Size = new Size(755, 37);
            panel1.TabIndex = 6;
            // 
            // btnHide
            // 
            btnHide.Location = new Point(370, 3);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(94, 29);
            btnHide.TabIndex = 0;
            btnHide.Text = "Cancel";
            btnHide.UseVisualStyleBackColor = true;
            btnHide.Click += hideShowToolStripMenuItem_Click;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(250, 3);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(94, 29);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // showHideMainWindowToolStripMenuItem
            // 
            showHideMainWindowToolStripMenuItem.Name = "showHideMainWindowToolStripMenuItem";
            showHideMainWindowToolStripMenuItem.Size = new Size(245, 24);
            showHideMainWindowToolStripMenuItem.Text = "Show/Hide Main window";
            showHideMainWindowToolStripMenuItem.Click += showHideMainWindowToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnHide;
            ClientSize = new Size(755, 575);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Controls.Add(splitContainer);
            Controls.Add(toolStrip1);
            Controls.Add(mainMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = mainMenu;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Clipboard Navigator";
            FormClosing += MainForm_FormClosing;
            PreviewKeyDown += MainForm_PreviewKeyDown;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            contextMenuNotifyIcon.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private MenuStrip mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private SplitContainer splitContainer;
        private TextBox textBoxCurrentClipboard;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuNotifyIcon;
        private ToolStripMenuItem hideShowToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem1;
        private Panel panel1;
        private Button btnHide;
        private Button btnOk;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem1;
        private ClipboardListBox clipboardListBox;
        private ToolStripMenuItem showHideMainWindowToolStripMenuItem;
    }
}
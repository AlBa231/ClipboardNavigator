namespace ClipboardNavigator.Plugins;

partial class PluginListForm
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
        components = new System.ComponentModel.Container();
        timerClose = new System.Windows.Forms.Timer(components);
        panelPlugins = new FlowLayoutPanel();
        SuspendLayout();
        // 
        // timerClose
        // 
        timerClose.Interval = 5000;
        timerClose.Tick += timerClose_Tick;
        // 
        // panelPlugins
        // 
        panelPlugins.AutoScroll = true;
        panelPlugins.Dock = DockStyle.Fill;
        panelPlugins.FlowDirection = FlowDirection.TopDown;
        panelPlugins.Location = new Point(0, 0);
        panelPlugins.Name = "panelPlugins";
        panelPlugins.Size = new Size(404, 205);
        panelPlugins.TabIndex = 0;
        panelPlugins.WrapContents = false;
        // 
        // PluginListForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(404, 205);
        Controls.Add(panelPlugins);
        Name = "PluginListForm";
        Text = "Plugins";
        MouseEnter += PluginListForm_MouseEnter;
        MouseLeave += PluginListForm_MouseLeave;
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Timer timerClose;
    private FlowLayoutPanel panelPlugins;
}
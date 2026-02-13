namespace ClipboardNavigator.Plugins;

partial class PluginRowControl
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginRowControl));
        tableLayoutPanel = new TableLayoutPanel();
        lblName = new Label();
        btnSettings = new Button();
        tableLayoutPanel.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel
        // 
        tableLayoutPanel.ColumnCount = 2;
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel.Controls.Add(lblName, 0, 0);
        tableLayoutPanel.Controls.Add(btnSettings, 1, 0);
        tableLayoutPanel.Dock = DockStyle.Fill;
        tableLayoutPanel.Location = new Point(0, 0);
        tableLayoutPanel.Name = "tableLayoutPanel";
        tableLayoutPanel.RowCount = 1;
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel.Size = new Size(319, 62);
        tableLayoutPanel.TabIndex = 0;
        tableLayoutPanel.TabStop = true;
        // 
        // lblName
        // 
        lblName.AutoEllipsis = true;
        lblName.AutoSize = true;
        lblName.Dock = DockStyle.Fill;
        lblName.Location = new Point(3, 0);
        lblName.Name = "lblName";
        lblName.Size = new Size(255, 62);
        lblName.TabIndex = 0;
        // 
        // btnSettings
        // 
        btnSettings.BackColor = Color.Transparent;
        btnSettings.Image = (Image)resources.GetObject("btnSettings.Image");
        btnSettings.Location = new Point(264, 3);
        btnSettings.Name = "btnSettings";
        btnSettings.Size = new Size(52, 52);
        btnSettings.TabIndex = 1;
        btnSettings.UseVisualStyleBackColor = false;
        btnSettings.Click += btnSettings_Click;
        // 
        // PluginRowControl
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(tableLayoutPanel);
        Name = "PluginRowControl";
        Size = new Size(319, 62);
        tableLayoutPanel.ResumeLayout(false);
        tableLayoutPanel.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel;
    private Label lblName;
    private Button btnSettings;
}

namespace ClipboardNavigator.Code.Windows.Forms;

partial class PluginSettingsForm
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
        panelButtons = new Panel();
        OK = new Button();
        propertyGrid = new PropertyGrid();
        panelButtons.SuspendLayout();
        SuspendLayout();
        // 
        // panelButtons
        // 
        panelButtons.Controls.Add(OK);
        panelButtons.Dock = DockStyle.Bottom;
        panelButtons.Location = new Point(0, 499);
        panelButtons.Name = "panelButtons";
        panelButtons.Size = new Size(504, 68);
        panelButtons.TabIndex = 0;
        // 
        // OK
        // 
        OK.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        OK.DialogResult = DialogResult.OK;
        OK.Location = new Point(179, 12);
        OK.Name = "OK";
        OK.Size = new Size(175, 44);
        OK.TabIndex = 0;
        OK.Text = "Apply";
        OK.UseVisualStyleBackColor = true;
        // 
        // propertyGrid
        // 
        propertyGrid.BackColor = SystemColors.Control;
        propertyGrid.Dock = DockStyle.Fill;
        propertyGrid.Location = new Point(0, 0);
        propertyGrid.Name = "propertyGrid";
        propertyGrid.Size = new Size(504, 499);
        propertyGrid.TabIndex = 1;
        // 
        // SettingsForm
        // 
        AcceptButton = OK;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(504, 567);
        Controls.Add(propertyGrid);
        Controls.Add(panelButtons);
        Name = "PluginSettingsForm";
        Text = "SettingsForm";
        panelButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panelButtons;
    private Button OK;
    private PropertyGrid propertyGrid;
}

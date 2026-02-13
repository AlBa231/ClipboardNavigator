using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClipboardNavigator.Plugins;

public partial class PluginListForm : Form
{
    public PluginListForm()
    {
        InitializeComponent();
        Init();
    }

    private void Init()
    {
    }

    private void timerClose_Tick(object sender, EventArgs e)
    {
        Close();
    }

    private void PluginListForm_MouseEnter(object sender, EventArgs e)
    {
        timerClose.Stop();
    }

    private void PluginListForm_MouseLeave(object sender, EventArgs e)
    {
        timerClose.Start();
    }
}

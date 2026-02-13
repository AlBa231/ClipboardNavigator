using ClipboardNavigator.Lib.Plugins.Interfaces;

namespace ClipboardNavigator.Plugins;

public partial class PluginListForm : Form
{
    private readonly IPluginFactory _pluginFactory;
    private readonly Func<PluginRowControl> _pluginRowControlFactory;

    public PluginListForm(IPluginFactory pluginFactory, Func<PluginRowControl> pluginRowControlFactory)
    {
        _pluginFactory = pluginFactory;
        _pluginRowControlFactory = pluginRowControlFactory;
        InitializeComponent();
        Init();
    }

    private void Init()
    {
        panelPlugins.Controls.Clear();
        foreach (IPlugin plugin in _pluginFactory.Plugins)
        {
            PluginRowControl pluginControl = _pluginRowControlFactory();
            pluginControl.Plugin = plugin;
            panelPlugins.Controls.Add(pluginControl);
        }
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

using System.ComponentModel;
using ClipboardNavigator.Lib;
using ClipboardNavigator.Lib.Windows;

namespace ClipboardNavigator;

public partial class ClipboardListBox : UserControl, IClipboardListBox
{
    public event ClipboardSelectedItem SelectionChanged;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IClipboardFacade ClipboardFacade
    {
        get;
        set
        {
            field = value;
            Init();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IClipboardDataProvider DataProvider { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ClipboardData? SelectedItem
    {
        get => lbClipboardHistory.SelectedItem as ClipboardData;
        set => lbClipboardHistory.SelectedItem = value;
    }

    public ClipboardListBox()
    {
        InitializeComponent();
    }

    private void Init()
    {
        lbClipboardHistory.DataSource = ClipboardFacade?.History;
    }

    private void lbClipboardHistory_MouseClick(object sender, MouseEventArgs e)
    {
        if (lbClipboardHistory.SelectedItem is not ClipboardData item) return;
        DataProvider.SetCurrentValue(item);
        OnSelectionChanged(item);
    }

    protected virtual void OnSelectionChanged(ClipboardData value)
    {
        SelectionChanged?.Invoke(value);
    }
}

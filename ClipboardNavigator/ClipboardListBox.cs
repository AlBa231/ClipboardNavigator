using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipboardNavigator.Lib;

namespace ClipboardNavigator;

public partial class ClipboardListBox : UserControl
{
    private IClipboardFacade clipboardFacade;

    public event ClipboardSelectedItem SelectionChanged;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IClipboardFacade ClipboardFacade
    {
        get => clipboardFacade;
        set
        {
            clipboardFacade = value;
            Init();
        }
    }

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
        if (lbClipboardHistory.SelectedItem is ClipboardData item) 
            ClipboardFacade.CurrentValue = item;
        OnSelectionChanged(ClipboardFacade.CurrentValue);
    }

    protected virtual void OnSelectionChanged(ClipboardData value)
    {
        SelectionChanged?.Invoke(value);
    }
}

public delegate void ClipboardSelectedItem(ClipboardData value);
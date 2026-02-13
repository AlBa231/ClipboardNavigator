using ClipboardNavigator.Lib;

namespace ClipboardNavigator;

public partial class TaskBarPopupForm : Form
{
    public TaskBarPopupForm(IClipboardFacade clipboardHistory)
    {
        if (clipboardHistory == null) throw new ArgumentNullException(nameof(clipboardHistory));
        InitializeComponent();
        clipboardListBox.ClipboardFacade = clipboardHistory;
    }

    public void SetupLocation()
    {
        Left = Cursor.Position.X;
        Top = Cursor.Position.Y - Height;
    }

    private void timerHideForm_Tick(object sender, EventArgs e)
    {
        Hide();
    }

    private void TaskBarPopupForm_MouseEnter(object sender, EventArgs e)
    {
        timerHideForm.Stop();
    }

    private void TaskBarPopupForm_MouseLeave(object sender, EventArgs e)
    {
        timerHideForm.Start();
    }

    private void TaskBarPopupForm_Enter(object sender, EventArgs e)
    {

    }

    public void ToggleVisibility()
    {
        if (Visible) 
            Hide();
        else
        {
            Show();
            SetupLocation();
        }
    }
}
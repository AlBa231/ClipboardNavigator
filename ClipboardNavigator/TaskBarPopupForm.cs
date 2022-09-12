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

namespace ClipboardNavigator
{
    public partial class TaskBarPopupForm : Form
    {
        public TaskBarPopupForm(BindingList<ClipboardData> clipboardHistory)
        {
            InitializeComponent();
            lbClipboardHistory.DataSource = clipboardHistory;
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
    }
}

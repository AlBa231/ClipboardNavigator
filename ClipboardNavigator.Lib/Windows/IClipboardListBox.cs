namespace ClipboardNavigator.Lib.Windows;

public interface IClipboardListBox
{
    event ClipboardSelectedItem SelectionChanged;
    IClipboardFacade ClipboardFacade { get; set; }
    IClipboardDataProvider DataProvider { get; set; }
    ClipboardData? SelectedItem { get; set; }
}

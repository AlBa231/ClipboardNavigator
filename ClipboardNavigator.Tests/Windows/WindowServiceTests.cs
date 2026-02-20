using ClipboardNavigator.Code.Windows;
using ClipboardNavigator.Code.Windows.Forms;
using ClipboardNavigator.Code.Windows.Forms.Plugins;

namespace ClipboardNavigator.Tests.Windows;

public class WindowServiceTests
{
    [Fact]
    public void ShowSettingsDialog_ShouldShowValidForm()
    {
        // Arrange
        var serviceProviderMock = new Mock<IServiceProvider>();
        var windowService = new WindowService(serviceProviderMock.Object);
        var settings = new TestSettings { Setting1 = "test", Setting2 = 42 };

        // Act
        Assert.Throws<InvalidOperationException>(() => windowService.ShowSettingsDialog(settings));

        // Assert
        serviceProviderMock.Verify(x => x.GetService(typeof(PluginSettingsForm)), Times.Once);
        serviceProviderMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void ShowPluginsDialog_ShouldShowValidForm()
    {
        // Arrange
        var serviceProviderMock = new Mock<IServiceProvider>();
        var windowService = new WindowService(serviceProviderMock.Object);

        // Act
        Assert.Throws<InvalidOperationException>(() => windowService.ShowPluginsDialog());

        // Assert
        serviceProviderMock.Verify(x => x.GetService(typeof(PluginListForm)), Times.Once);
        serviceProviderMock.VerifyNoOtherCalls();
    }
}

internal class TestSettings
{
    public string Setting1 { get; set; }

    public int Setting2 { get; set; }
}

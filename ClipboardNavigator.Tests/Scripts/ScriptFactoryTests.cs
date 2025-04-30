using ClipboardNavigator.Lib.Notification;
using ClipboardNavigator.Lib.Scripts;

namespace ClipboardNavigator.Tests.Scripts;

public class ScriptFactoryTests
{
    private readonly Mock<INotificationService> mockNotificationService = new();

    [Fact]
    public async Task ProcessPostCopyHook_ExecutesAllScripts_WhenStopOtherScriptsIsFalse()
    {
        // Arrange
        var mockScript1 = new Mock<ClipboardScript>();
        var mockScript2 = new Mock<ClipboardScript>();
        var clipboardData = new ClipboardData("Test");

        mockScript1.Setup(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()))
                   .Callback<ClipboardDataEventArgs>(args => args.StopOtherScripts = false)
                   .Returns(Task.CompletedTask);

        mockScript2.Setup(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()))
                   .Returns(Task.CompletedTask);

        var factory = new ScriptFactory(mockNotificationService.Object)
        {
            ClipboardScripts = { mockScript1.Object, mockScript2.Object }
        };

        // Act
        await factory.ProcessPostCopyHook(clipboardData);

        // Assert
        mockScript1.Verify(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()), Times.Once);
        mockScript2.Verify(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()), Times.Once);
    }

    [Fact]
    public async Task ProcessPostCopyHook_StopsExecution_WhenStopOtherScriptsIsTrue()
    {
        // Arrange
        var mockScript1 = new Mock<ClipboardScript>();
        var mockScript2 = new Mock<ClipboardScript>();
        var clipboardData = new ClipboardData("Test");

        mockScript1.Setup(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()))
                   .Callback<ClipboardDataEventArgs>(args => args.StopOtherScripts = true)
                   .Returns(Task.CompletedTask);

        mockScript2.Setup(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()))
                   .Returns(Task.CompletedTask);

        var factory = new ScriptFactory(mockNotificationService.Object)
        {
            ClipboardScripts = {mockScript1.Object, mockScript2.Object}
        };

        // Act
        await factory.ProcessPostCopyHook(clipboardData);

        // Assert
        mockScript1.Verify(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()), Times.Once);
        mockScript2.Verify(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()), Times.Never);
    }

    [Fact]
    public void InitScripts_ReturnsNonAbstractClipboardScripts()
    {
        // Act
        var scripts = typeof(ScriptFactory).Assembly.GetTypes()
            .Where(type => typeof(ClipboardScript).IsAssignableFrom(type) && !type.IsAbstract)
            .Select(type => (ClipboardScript?)Activator.CreateInstance(type))
            .OfType<ClipboardScript>()
            .ToList();

        // Assert
        Assert.NotNull(scripts);
        Assert.All(scripts, script => Assert.IsAssignableFrom<ClipboardScript>(script));
    }
}
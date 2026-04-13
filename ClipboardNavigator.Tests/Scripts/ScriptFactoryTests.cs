using ClipboardNavigator.Lib.Scripts;

namespace ClipboardNavigator.Tests.Scripts;

public class ScriptFactoryTests
{
    private readonly Mock<IServiceProvider> _serviceProviderMock = new();

    [Fact]
    public async Task ProcessPostCopyHook_ExecutesAllScripts_WhenStopOtherScriptsIsFalse()
    {
        // Arrange
        var mockScript1 = new Mock<ITestScript1>();
        var mockScript2 = new Mock<ITestScript2>();
        var clipboardData = new ClipboardData("Test");
        mockScript1.Setup(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()))
                   .Callback<ClipboardDataEventArgs>(args => args.StopOtherScripts = false)
                   .Returns(Task.CompletedTask);
        mockScript2.Setup(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()))
                   .Returns(Task.CompletedTask);
        _serviceProviderMock.Setup(x => x.GetService(typeof(IEnumerable<IClipboardScript>))).Returns(new IClipboardScript[] { mockScript1.Object, mockScript2.Object });

        var factory = new ScriptFactory(_serviceProviderMock.Object);

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
        var mockScript1 = new Mock<ITestScript1>();
        var mockScript2 = new Mock<ITestScript2>();
        var clipboardData = new ClipboardData("Test");

        mockScript1.Setup(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()))
                   .Callback<ClipboardDataEventArgs>(args => args.StopOtherScripts = true)
                   .Returns(Task.CompletedTask);

        mockScript2.Setup(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()))
                   .Returns(Task.CompletedTask);

        _serviceProviderMock.Setup(x => x.GetService(typeof(IEnumerable<IClipboardScript>))).Returns(new IClipboardScript[] { mockScript1.Object, mockScript2.Object });

        var factory = new ScriptFactory(_serviceProviderMock.Object);

        // Act
        await factory.ProcessPostCopyHook(clipboardData);

        // Assert
        mockScript1.Verify(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()), Times.Once);
        mockScript2.Verify(s => s.Execute(It.IsAny<ClipboardDataEventArgs>()), Times.Never);
    }
}

public interface ITestScript1:IClipboardScript;
public interface ITestScript2:IClipboardScript;

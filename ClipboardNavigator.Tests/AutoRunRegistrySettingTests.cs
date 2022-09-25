namespace ClipboardNavigator.Tests;

public class AutoRunRegistrySettingTests
{
    [Fact]
    public void TestSetRegistryValue()
    {
        var regKeyMock = new Mock<IRegistrySetting>();
        var setting = new AutoRunRegistrySetting("D:\\TEMP\\appPath.exe", regKeyMock.Object);

        setting.IsAutoStart = true;

        regKeyMock.VerifySet( r => r.RunPath = "D:\\TEMP\\appPath.exe");
    }
    
    [Fact]
    public void TestIgnoreDuplicateValue()
    {
        var regKey = new TestRegistrySetting();
        var setting = new AutoRunRegistrySetting("D:\\TEMP\\appPath.exe", regKey);

        setting.IsAutoStart = true;
        setting.IsAutoStart = true;
        setting.IsAutoStart = true;
        setting.IsAutoStart = true;

        Assert.Equal(1, regKey.SetRunPathCount);
    }

    [Fact]
    public void TestDeleteRegistryValue()
    {
        var regKeyMock = new Mock<IRegistrySetting>();
        var setting = new AutoRunRegistrySetting("D:\\TEMP\\appPath.exe", regKeyMock.Object);

        setting.IsAutoStart = false;

        regKeyMock.VerifySet( r => r.RunPath = null);
    }

    private class TestRegistrySetting : IRegistrySetting
    {
        private string? runPath;

        public string? RunPath
        {
            get => runPath;
            set
            {
                runPath = value;
                SetRunPathCount++;
            }
        }

        public int SetRunPathCount { get; private set; }
    }
}
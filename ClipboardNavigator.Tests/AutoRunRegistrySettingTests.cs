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
    public void TestDeleteRegistryValue()
    {
        var regKeyMock = new Mock<IRegistrySetting>();
        var setting = new AutoRunRegistrySetting("D:\\TEMP\\appPath.exe", regKeyMock.Object);

        setting.IsAutoStart = false;

        regKeyMock.VerifySet( r => r.RunPath = null);
    }
}
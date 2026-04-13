using ClipboardNavigator.Lib.IO;
using ClipboardNavigator.Lib.Notification;
using ClipboardNavigator.Lib.Scripts;
using ClipboardNavigator.Tests.TestHelpers;

namespace ClipboardNavigator.Tests.Scripts;

public class UpdateAwsCredentialsScriptTests
{
    [Fact]
    public async Task Execute_DefaultCredentials_ReplacesCredentials()
    {
        // Arrange
        var notificationServiceMock = new Mock<INotificationService>();
        var fileServiceMock = new Mock<IFileService>();
        var script = new UpdateAwsCredentialsScript(notificationServiceMock.Object, fileServiceMock.Object);
        fileServiceMock.Setup(fs => fs.ReadAllTextAsync(It.IsAny<string>())).ReturnsAsync(
            """
            [default]
            aws_access_key_id = TESTKEY
            aws_secret_access_key = TESTSECRET
            aws_session_token = TESTTOKEN
            output=json
            region=us-east-2
            toolkit_artifact_guid=d836215c-1f95-4c94-a175-ce5797622f35
            [another]
            """);

        // Act
        var clipboardData = new ClipboardDataEventArgs(new ClipboardData("aws_access_key_id = NEWKEY\naws_secret_access_key = NEWSECRET\naws_session_token = NEWTOKEN"));
        await script.Execute(clipboardData);

        // Assert
        var credentialsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".aws", "credentials");
        fileServiceMock.Verify(fs=>fs.WriteAllTextAsync(credentialsPath, StrIt.Is("""
                                                                         [default]
                                                                         aws_access_key_id = NEWKEY
                                                                         aws_secret_access_key = NEWSECRET
                                                                         aws_session_token = NEWTOKEN
                                                                         output=json
                                                                         region=us-east-2
                                                                         toolkit_artifact_guid=d836215c-1f95-4c94-a175-ce5797622f35
                                                                         [another]
                                                                         """)));
    }

}

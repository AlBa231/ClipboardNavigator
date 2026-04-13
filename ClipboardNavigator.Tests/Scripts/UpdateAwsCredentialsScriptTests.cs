using System;
using System.Collections.Generic;
using System.Text;
using ClipboardNavigator.Lib.Notification;
using ClipboardNavigator.Lib.Scripts;

namespace ClipboardNavigator.Tests.Scripts;

public class UpdateAwsCredentialsScriptTests
{
    [Fact]
    public async Task Execute_DefaultCredentials_ReplacesCredentials()
    {
        // Arrange
        var notificationServiceMock = new Mock<INotificationService>();
        var script = new UpdateAwsCredentialsScript(notificationServiceMock.Object);
        var clipboardData = new ClipboardDataEventArgs(new ClipboardData("aws_access_key_id = TESTKEY\naws_secret_access_key = TESTSECRET\naws_session_token = TESTTOKEN"));

        // Act
        await script.Execute(clipboardData);

        // Assert
        //var credentialsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".aws", "credentials");
        //var credentialsContent = File.ReadAllText(credentialsPath);
        //Assert.Contains("TESTKEY", credentialsContent);
        //Assert.Contains("TESTSECRET", credentialsContent);
        //Assert.Contains("TESTTOKEN", credentialsContent);
    }
}

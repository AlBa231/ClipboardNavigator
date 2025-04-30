using System.Text.RegularExpressions;

namespace ClipboardNavigator.Lib.Scripts;
public class UpdateAwsCredentialsScript:ClipboardScript
{
    private static readonly Regex AwsCredentialsRegex = new(@"(?<AWS_Credentials>aws_access_key_id\s*=\s*(\S+)\s*[\r\n]+aws_secret_access_key\s*=\s*(\S+)\s*[\r\n]+aws_session_token\s*=\s*(\S+)\s*)", RegexOptions.Multiline | RegexOptions.IgnoreCase);

    protected override async Task TryExecute(ClipboardDataEventArgs clipboardData)
    {
        var match = AwsCredentialsRegex.Match(clipboardData.Data.Text);
        if (!match.Success) return;

        await ReplaceCredentialsAsync(match.Groups["AWS_Credentials"].Value);

        clipboardData.StopOtherScripts = true;
    }

    private async Task ReplaceCredentialsAsync(string newCredentials)
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".aws", "credentials");
        var credentialsFileData = await File.ReadAllTextAsync(path);

        var newCredentialsData = AwsCredentialsRegex.Replace(credentialsFileData, newCredentials + Environment.NewLine);

        await File.WriteAllTextAsync(path, newCredentialsData);

        NotificationService?.ShowBalloonText("AWS Credentials have been updated");
    }
}

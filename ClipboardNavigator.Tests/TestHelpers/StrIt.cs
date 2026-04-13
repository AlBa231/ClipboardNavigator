namespace ClipboardNavigator.Tests.TestHelpers;

internal static class StrIt
{
    public static string Is(string expected) => It.Is<string>(str => StringsAreEqualIgnoringLineEndings(str, expected));

    private static bool StringsAreEqualIgnoringLineEndings(string str1, string str2)
    {
        var normalizedStr1 = str1.Replace("\r\n", "\n").Replace("\r", "\n");
        var normalizedStr2 = str2.Replace("\r\n", "\n").Replace("\r", "\n");
        return normalizedStr1 == normalizedStr2;
    }
}

namespace ClipboardNavigator.Lib.IO;

public class FileService:IFileService
{
    public Task<string> ReadAllTextAsync(string path) => File.ReadAllTextAsync(path);

    public Task WriteAllTextAsync(string path, string contents) => File.WriteAllTextAsync(path, contents);
}

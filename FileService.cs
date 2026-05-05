using System.IO;

public class FileService
{
    public string LoadFile(string path)
    {
        return File.ReadAllText(path);
    }

    public void SaveFile(string path, string content)
    {
        File.WriteAllText(path, content);
    }
}
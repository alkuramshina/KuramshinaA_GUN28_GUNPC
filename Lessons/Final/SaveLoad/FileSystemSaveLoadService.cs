using System.Text.Json;

namespace BasicCsharp.Lessons.Final.SaveLoad;

public class FileSystemSaveLoadService<T> : ISaveLoadService<T>
{
    public void SaveData(T data, string path)
    {
        var json = JsonSerializer.Serialize(data);
        File.WriteAllText(path, json);
    }

    public T? LoadData(string path)
    {
        if (!File.Exists(path))
        {
            throw new Exception("Save file doesn't exist!");
        }

        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(json);
    }

    public bool SaveExists(string path) => File.Exists(path);
}
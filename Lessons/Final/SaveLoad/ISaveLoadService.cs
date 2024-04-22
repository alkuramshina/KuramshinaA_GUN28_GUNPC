namespace BasicCsharp.Lessons.Final.SaveLoad;

public interface ISaveLoadService<T>
{
    void SaveData(T data, string path);
    T? LoadData(string path);
    bool SaveExists(string path);
}
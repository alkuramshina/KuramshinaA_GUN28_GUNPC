using BasicCsharp.Lessons.Final.Games;
using BasicCsharp.Lessons.Final.SaveLoad;

namespace BasicCsharp.Lessons.Final.Game.Builder;

public interface IBuilderSupporter<out TLoadSaveService, TData, TGame>
    where TGame : CasinoGameBase
    where TLoadSaveService : ISaveLoadService<TData>
{
    TLoadSaveService BuildSaveLoadService();
    Dictionary<string, TGame> BuildGames();
}
using Template._Project.Scripts.Services.PersistentProgress;

namespace ZombieBarrels.Services.Progress
{
    public interface IProgressUpdater : ISavedProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}
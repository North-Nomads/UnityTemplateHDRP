namespace Template._Project.Scripts.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        /*
        private Dictionary<int, MobConfig> _zombieConfigs;

        public void LoadLevels()
            => _levels = Resources.LoadAll<LevelConfig>("Configs/Levels").ToDictionary(x => x.LevelID, x => x);

        public LevelConfig ForLevel(int levelID)
            => _levels.GetValueOrDefault(levelID);
        */

        public void LoadConfigs()
        {
            // LoadLevels();
        }
    }
}
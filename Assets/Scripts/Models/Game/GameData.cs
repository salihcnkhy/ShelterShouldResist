
namespace Game.Model
{
    using Game.Constants;
    using Game.Generic.SKObserver;
    using Game.Model.CoreData;
    using UnityEngine;

    public class GameData
    {
        public Player Player;
        public bool IsNewLoad;
        public int WaveCount;
        public int CurrentDay;
        public int CurrentTime;
        public int DaysToNextWave;
        public TimeRange CurrentTimeRange;
        public GameData()
        {
            Player = new Player();
            IsNewLoad = true;
            WaveCount = 1;
            CurrentDay = 1;
            DaysToNextWave = 3;
            CurrentTimeRange = TimeRange.Day;
            CurrentTime = CurrentTimeRange.GetTime();

        }
        public GameData(Player Player, int WaveCount, int CurrentDay, int DaysToNextWave, bool IsNewLoad)
        {
            this.Player = Player;
            this.IsNewLoad = IsNewLoad;
            this.WaveCount = WaveCount;
            this.CurrentDay = CurrentDay;
            this.DaysToNextWave = DaysToNextWave;
            this.CurrentTimeRange = TimeRange.Day;
            this.CurrentTime = CurrentTimeRange.GetTime();

        }

        // Player
        // Placable Object List
        // Wave Count

    }

  

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Model.CoreData
{
    [Serializable]
    public class GameDataBinary
    {

        private GameDataBinary() { }

        public PlayerBinary PlayerBinary;

        private int WaveCount;
        private int CurrentDay;
        private int DaysToNextWave;
        public static GameDataBinary InitWithGameData(GameData gameData)
        {
            return new GameDataBinary
            {
                PlayerBinary = PlayerBinary.InitWithPlayerData(gameData.Player),
                WaveCount = gameData.WaveCount,
                CurrentDay = gameData.CurrentDay,
                DaysToNextWave = gameData.DaysToNextWave
            };
        }

        public GameData ConvertGameData()
        {
            return new GameData(PlayerBinary.ConvertPlayer(), WaveCount, CurrentDay, DaysToNextWave, false);

        }
    }

}

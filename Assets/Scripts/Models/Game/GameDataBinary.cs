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


        public static GameDataBinary InitWithGameData(GameData gameData)
        {
            return new GameDataBinary
            {
                PlayerBinary = PlayerBinary.InitWithPlayerData(gameData.Player)
            };
        }

        public GameData ConvertGameData()
        {
            return new GameData(PlayerBinary.ConvertPlayer(), false);

        }
    }

}

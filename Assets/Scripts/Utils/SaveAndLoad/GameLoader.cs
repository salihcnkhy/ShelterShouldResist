using Game.Model;
using Game.Model.CoreData;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


namespace Game.Utils.SaveLoad
{
    public class GameLoader
    {
        public GameData LoadGameData()
        {
           
            string path = Application.persistentDataPath + "/gameData.data";
            if (File.Exists(path))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(path, FileMode.Open);
                GameDataBinary gameDataBinary = (GameDataBinary)bf.Deserialize(file);
                Debug.Log("Game Loaded");
                return gameDataBinary.ConvertGameData();
            }
            Debug.Log("No Load Files, Creating New Game Data");
            return new GameData();
        }
    }

}

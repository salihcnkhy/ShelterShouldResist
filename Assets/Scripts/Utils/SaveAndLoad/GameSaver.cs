using Game.Model;
using Game.Model.CoreData;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



namespace Game.Utils.SaveLoad
{
    public class GameSaver 
    {
        public void SaveGameData(GameData gameData)
        {
            string path = Application.persistentDataPath + "/gameData.data";

            GameDataBinary gameDataBinary = GameDataBinary.InitWithGameData(gameData);
           
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(path);
            bf.Serialize(file, gameDataBinary);
            file.Close();
            Debug.Log("Game Saved");
        }
    }
}

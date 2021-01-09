
namespace Game.Model
{
    using Game.Model.CoreData;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameData
    {
        public Player Player;
        public bool IsNewLoad;
        public GameData()
        {
            Player = new Player();
            IsNewLoad = true;
        }
        public GameData(Player player, bool isNewLoad)
        {
            this.Player = player;
            this.IsNewLoad = isNewLoad;
        }

        // Player
        // Placable Object List
        // Wave Count


    }

}

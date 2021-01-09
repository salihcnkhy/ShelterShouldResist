



namespace Game.Model.CoreData
{
    using System;
    using UnityEngine;

    [Serializable]
    public class PlayerBinary
    {

        private PlayerBinary() { }

        private int Coin;
        private float dX;
        private float dY;
        public static PlayerBinary InitWithPlayerData(Player player)
        {
            return new PlayerBinary
            {
                Coin = player.Coin,
                dX = player.Position.x,
                dY = player.Position.y
            };
        } 

        public Player ConvertPlayer()
        {

            return new Player(Coin, new Vector2(dX,dY));
            
        }
    }

}

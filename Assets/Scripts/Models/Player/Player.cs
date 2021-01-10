using Game.Generic.SKObserver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Model
{
    public class Player
    {

        public SKObservableInt Coin;
        private Vector2 _position;

        public Player()
        {
            Coin = new SKObservableInt();
            Position = Vector2.zero;
        }

        public Player(int coin, Vector2 position)
        {
            Coin = new SKObservableInt(coin);
            this.Position = position;
        }
  
        public Vector2 Position
        {
            get { return _position; }
            set  { _position = value;  }
        }
    }

}

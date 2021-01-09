using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Model
{
    public class Player
    {

        public delegate void CoinChanges(int coin);
        public event CoinChanges OnCoinChange;


        private int _coin = 0;
        private Vector2 _position;

        public Player()
        {
            Coin = 0;
            Position = Vector2.zero;
        }

        public Player(int coin, Vector2 position)
        {
            this.Coin = coin;
            this.Position = position;
        }
  
        public int Coin
        {
            get { return _coin; }
            set
            {
                _coin = value;
                OnCoinChange?.Invoke(value);
            }
        }
        public Vector2 Position
        {
            get { return _position; }
            set  { _position = value;  }
        }
    }

}

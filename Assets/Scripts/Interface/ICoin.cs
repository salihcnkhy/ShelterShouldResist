using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Interface.Interaction.Coin
{
    public interface ICoin 
    {
        void CollectCoin(Action afterCollect);
    }

}



namespace Game.GameObjects.Collectable
{
    using Game.Interface.Interaction.Coin;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CollectableTestObject : MonoBehaviour, ICoin
    {
        public void CollectCoin(Action afterCollect)
        {
            afterCollect?.Invoke();
        }
    }
}


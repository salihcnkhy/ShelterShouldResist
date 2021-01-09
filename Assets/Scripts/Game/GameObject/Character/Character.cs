
namespace Game.GameObject.Character
{
    using Game.Generic;
    using Game.Interface.Interaction;
    using Game.Interface.Interaction.Coin;
    using Game.Model;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using UnityEngine;


    public class Character : BaseObject
    {

       Player PlayerRef;

       public void SetPlayerModel(ref Player playerModel)
        {
            this.PlayerRef = playerModel;
            SetProperitiesFromPlayerModel();
        }

        private void SetProperitiesFromPlayerModel()
        {
            transform.position = PlayerRef.Position;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Handle all object collison here or create new class for it

            collision.gameObject
                .GetComponent<ICoin>()?
                .CollectCoin(IncreaseCoin);
        }

        private void IncreaseCoin()
        {
            if (PlayerRef != null)
                PlayerRef.Coin += 10;
        }
    }

}

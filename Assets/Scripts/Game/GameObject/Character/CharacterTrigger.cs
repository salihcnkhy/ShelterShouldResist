using Game.Generic;
using Game.Interface.Interaction;
using Game.Interface.Interaction.Coin;
using Game.Model;
using UnityEngine;

namespace Game.GameObjects.Character
{
    public class CharacterTrigger : BaseObject
    {
        Player PlayerRef;

        public override void PreInit()
        {
            PlayerRef = gameObject.GetComponent<Character>().GetPlayerModel();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Handle all object collison here or create new class for it

            collision.gameObject
                .GetComponent<ICoin>()?
                .CollectCoin(IncreaseCoin);

            collision.gameObject
                .GetComponent<IInteractable>()?
                .HandleTriggerEnterInteraction(this);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            collision.gameObject
                 .GetComponent<IInteractable>()?
                 .HandleTriggerExitInteraction(this);
        }

        private void IncreaseCoin()
        {
            //if (PlayerRef != null)
           //     PlayerRef.Coin.Increase(10);
        }

    }

}

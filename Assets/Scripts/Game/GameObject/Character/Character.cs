
namespace Game.GameObjects.Character
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
        CharacterMovement CharacterMovement;
        CameraControl CameraControl;
        public override void Init()
        {
            CharacterMovement = gameObject.GetComponent<CharacterMovement>();
            CameraControl = gameObject.GetComponent<CameraControl>();

            CameraControl.Init();
        }

        public void SetPlayerModel(ref Player playerModel)
        {
            this.PlayerRef = playerModel;
            SetProperitiesFromPlayerModel();
        }

        private void SetProperitiesFromPlayerModel()
        {
            transform.position = PlayerRef.Position;
        }

        public override void HandleUpdate()
        {
            CharacterMovement.HandleUpdate();
            CameraControl.HandleUpdate();
        }

        public override void HandleFixedUpdate()
        {
            CharacterMovement.HandleFixedUpdate();
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
                PlayerRef.Coin.Increase(10);
        }


    }

}

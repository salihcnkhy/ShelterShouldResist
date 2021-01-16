
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
        CharacterTrigger CharacterTrigger;
        public override void PreInit()
        {
            CharacterMovement = gameObject.GetComponent<CharacterMovement>();
            CameraControl = gameObject.GetComponent<CameraControl>();
            CharacterTrigger = gameObject.GetComponent<CharacterTrigger>();

            CharacterMovement.InjectShared(Shared);
        }

        public override void Init()
        {
            CameraControl.Init();
        }

        public void SetPlayerModel(ref Player playerModel)
        {
            this.PlayerRef = playerModel;
            SetProperitiesFromPlayerModel();
        }
        public Player GetPlayerModel()
        {
            return this.PlayerRef;
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

    }

}

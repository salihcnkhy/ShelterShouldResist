
namespace Game.Systems.EnemyCreation
{
    using Game.Generic;
    using Game.Generic.Base;
    using Game.Generic.SKObserver;
    using Game.Interface.Systems;
    using Game.Model.Systems;
    using Game.Systems.EventSystem;
    using System.Collections;
    using System.Collections.Generic;

    using UnityEngine;

    public class EnemyCreationSystem : BaseSubSystem
    {
        public EnemyCreationSystem(MainSystemShared Shared) : base(Shared)
        {

        }

        protected override void SetEvents()
        {
            base.SetEvents();
        }

        protected override void SetSubSystem()
        {
            Shared.EventSystem.PrepareNewWaveTrigger.OnTriggerEvent += OnPrepareNewWaveTrigger;
            Shared.EventSystem.SendNewWaveTrigger.OnTriggerEvent += OnSendNewWaveTrigger;
        }

        private void OnPrepareNewWaveTrigger()
        {
            Debug.LogWarning("Preparing For new Wave");
            // set prepares for new wave
        }

        private void OnSendNewWaveTrigger()
        {
            Debug.LogWarning("NEW WAVE HAS ARRIVED!!!");

            // Send enemies 
        }
    }

}


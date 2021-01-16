
namespace Game.Systems.WaveSystem
{
    using Game.Constants;
    using Game.Generic.Base;
    using Game.Generic.SKObserver;
    using Game.Interface.Systems;
    using Game.Model;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Game.Systems.EventSystem;
    using Game.Model.Systems;

    public class WaveSystem : BaseSubSystem
    {

        public WaveSystem(MainSystemShared Shared) : base(Shared)
        {
            SetSubSystem();
        }

        protected override void SetSubSystem()
        {
            SetEvents();
        }

        protected override void SetEvents()
        {
            Shared.EventSystem.DaysToNextWave.OnChangeEvent += DaysToNextWaveChanged;

        }

        private void DaysToNextWaveChanged(int newValue)
        {
            if (newValue == 0)
            {
                Shared.EventSystem.CurrentTimeRange.OnChangeEvent += CurrentTimeRangeChanged;
                Shared.EventSystem.PrepareNewWaveTrigger.Fire();
            }
            else if(newValue < 0)
            {
                // calc new daysToNextwave
                Shared.EventSystem.DaysToNextWave.Set(2);
            }
        }

        private void CurrentTimeRangeChanged(TimeRange newValue)
        {
            if (newValue.Equals(TimeRange.Night))
            {
                Shared.EventSystem.SendNewWaveTrigger.Fire();
                Shared.EventSystem.CurrentTimeRange.OnChangeEvent -= CurrentTimeRangeChanged;
            }
        }
    }

}

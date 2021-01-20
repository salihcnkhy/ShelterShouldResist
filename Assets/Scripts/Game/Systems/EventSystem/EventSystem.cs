using Game.Constants;
using Game.Generic.SKObserver;
using Game.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Systems.EventSystem
{
    public sealed class EventSystem
    {

        public SKObservableInt CoinCount { get; set; }
        public SKObservableInt WaveCount { get; set; }
        public SKObservableTrigger NewDayTrigger { get; set; }
        public SKObservableInt CurrentDay { get; set; }
        public SKObservableInt CurrentTime { get; set; }
        public SKObservableInt DaysToNextWave { get; set; }
        public SKObservable<TimeRange> CurrentTimeRange { get; set; }

        public SKObservable<bool> BuildMenuOpenTrigger { get; set; }
        public SKObservableTrigger BuildApprovedTrigger { get; set; }
        public SKObservableTrigger BuildCanceledTrigger { get; set; }
        public SKObservable<bool> BuildSucceedValue { get; set; }
        public SKObservable<PlaceableObject> SelectedPlaceableObject { get; set; }

        public SKObservableTrigger SendNewWaveTrigger { get; set; }
        public SKObservableTrigger PrepareNewWaveTrigger { get; set; }

        public SKObservableObjectTrigger BuildPlaceableObject { get; set; }
        public EventSystem(GameData GameData)
        {

            CoinCount = new SKObservableInt(GameData.Player.Coin);
            WaveCount = new SKObservableInt(GameData.WaveCount);
            CurrentDay = new SKObservableInt(GameData.CurrentDay);
            CurrentTime = new SKObservableInt(GameData.CurrentTime);
            DaysToNextWave = new SKObservableInt(GameData.DaysToNextWave);
            CurrentTimeRange = new SKObservable<TimeRange>(GameData.CurrentTimeRange);
            NewDayTrigger = new SKObservableTrigger();
          
            #region Building
            SelectedPlaceableObject = new SKObservable<PlaceableObject>(null);
            BuildMenuOpenTrigger = new SKObservable<bool>(false);
            BuildPlaceableObject = new SKObservableObjectTrigger();
            BuildApprovedTrigger = new SKObservableTrigger();
            BuildCanceledTrigger = new SKObservableTrigger();
            BuildSucceedValue = new SKObservable<bool>(false);
            #endregion

            SendNewWaveTrigger = new SKObservableTrigger();
            PrepareNewWaveTrigger = new SKObservableTrigger();
        }
    }

}

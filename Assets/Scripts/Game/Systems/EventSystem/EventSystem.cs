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

        public SKObservableInt CoinCount;
        public SKObservableInt WaveCount;
        public SKObservableInt CurrentDay;
        public SKObservableInt CurrentTime;
        public SKObservableInt DaysToNextWave;
        public SKObservable<TimeRange> CurrentTimeRange;

        public SKObservableTrigger SendNewWaveTrigger;
        public SKObservableTrigger PrepareNewWaveTrigger;
        public SKObservable<bool> BuildMenuOpenTrigger;
        public SKObservableObjectTrigger BuildPlaceableObject;

        public EventSystem(GameData GameData)
        {

            CoinCount = new SKObservableInt(GameData.Player.Coin);
            WaveCount = new SKObservableInt(GameData.WaveCount);
            CurrentDay = new SKObservableInt(GameData.CurrentDay);
            CurrentTime = new SKObservableInt(GameData.CurrentTime);
            DaysToNextWave = new SKObservableInt(GameData.DaysToNextWave);
            CurrentTimeRange = new SKObservable<TimeRange>(GameData.CurrentTimeRange);

            BuildMenuOpenTrigger = new SKObservable<bool>(false);
            BuildPlaceableObject = new SKObservableObjectTrigger();

        SendNewWaveTrigger = new SKObservableTrigger();
            PrepareNewWaveTrigger = new SKObservableTrigger();
        }
    }

}

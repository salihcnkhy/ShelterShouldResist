
namespace Game.Systems.Environment
{
    using Game.Generic.Base;
    using Game.Interface.Systems;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Game.Systems.EventSystem;
    using Game.Generic;
    using Game.Model.Systems;
    using UnityEngine.Experimental.Rendering.Universal;
    using Game.GameObjects.Background;

    public sealed class EnvironmentSystem : BaseSubSystem
    {


        private GameObject EnvironmentObject;
        private Transform CharacterTransform;

        private Transform PlaceablesObjectTransform;
        
        private ParallaxEffect ParallaxEffect;
        
        private Light2D BackgroundLight;
        private Light2D GroundLight;
        Coroutine LerpColorCoroutine;

        private PlaceableObject SelectedPlaceableObject;

        public EnvironmentSystem(MainSystemShared Shared) : base(Shared)
        {
            BackgroundLight = GameObject.FindGameObjectWithTag("BackgroundLight").GetComponent<Light2D>();
            GroundLight = GameObject.FindGameObjectWithTag("GroundLight").GetComponent<Light2D>();

            CharacterTransform = GameObject.FindGameObjectWithTag("Player").transform;
            EnvironmentObject = GameObject.FindGameObjectWithTag("Environment");
            PlaceablesObjectTransform = EnvironmentObject.transform.Find("Placeables");
            ParallaxEffect = EnvironmentObject.GetComponent<ParallaxEffect>();

            SetSubSystem();
        }

        protected override void SetSubSystem()
        {
            CurrentTimeRangeChanged(Shared.GameData.CurrentTimeRange);
            CreateEnvironment();
            SetEvents();
           // AddBaseObjects();
        }
        protected override void SetEvents()
        {
            Shared.EventSystem.CurrentTimeRange.OnChangeEvent += CurrentTimeRangeChanged;
            Shared.EventSystem.SelectedPlaceableObject.OnChangeEvent += OnPlaceableObjectSelected;
        }

        private void OnPlaceableObjectSelected(PlaceableObject newValue)
        {
            SelectedPlaceableObject = GameObject.Instantiate(newValue, CharacterTransform);
            Shared.EventSystem.BuildApprovedTrigger.OnTriggerEvent += OnSelectedBuildingApproveClick;
            Shared.EventSystem.BuildCanceledTrigger.OnTriggerEvent += OnSelectedBuildingCancelClick;
        }

        private void OnSelectedBuildingCancelClick()
        {
            SelectedPlaceableObject.DestroySelf();
            Shared.EventSystem.BuildApprovedTrigger.OnTriggerEvent -= OnSelectedBuildingApproveClick;
            Shared.EventSystem.BuildCanceledTrigger.OnTriggerEvent -= OnSelectedBuildingCancelClick;
        }

        private void OnSelectedBuildingApproveClick()
        {
            if(!SelectedPlaceableObject.HasBlocked)
            {
                SelectedPlaceableObject.SetParent(PlaceablesObjectTransform);
                SelectedPlaceableObject.HasPlaced = true;
                AddBaseObject(SelectedPlaceableObject);
                Shared.EventSystem.BuildApprovedTrigger.OnTriggerEvent -= OnSelectedBuildingApproveClick;
                Shared.EventSystem.BuildCanceledTrigger.OnTriggerEvent -= OnSelectedBuildingCancelClick;
                Shared.EventSystem.BuildSucceedValue.Set(true);
            }
            else
            {
                Shared.EventSystem.BuildSucceedValue.Set(false);
                Debug.LogWarning("Engel var yerleştirilemedi");
            }

        }

        protected override void AddBaseObjects()
        {
            AddBaseObject(ParallaxEffect);
        }
      
        private void CreateEnvironment()
        {

        }

        #region Time Changes
        private void CurrentTimeRangeChanged(Constants.TimeRange newValue)
        {
            Color targetColor;
            Color startColor;
            float step = 0.01f;

            if (LerpColorCoroutine != null)
                Shared.MonoBehaviourReferance.StopCoroutine(LerpColorCoroutine);

            switch (newValue)
            {
                case Constants.TimeRange.Dawn:
                    targetColor = Constants.DayCycleTimeColorConstant.DayColor;
                    startColor = Constants.DayCycleTimeColorConstant.DawnColor;
                    LerpColorCoroutine = Shared.MonoBehaviourReferance.StartCoroutine(LerpColor(Constants.DayCycleConstant.DawnLong, step, startColor, targetColor));
                    break;
                case Constants.TimeRange.Day:
                    targetColor = Constants.DayCycleTimeColorConstant.EveningColor;
                    startColor = Constants.DayCycleTimeColorConstant.DayColor;
                    LerpColorCoroutine = Shared.MonoBehaviourReferance.StartCoroutine(LerpColor(Constants.DayCycleConstant.DayLong, step, startColor, targetColor));
                    break;
                case Constants.TimeRange.Evening:
                    targetColor = Constants.DayCycleTimeColorConstant.NightColor;
                    startColor = Constants.DayCycleTimeColorConstant.EveningColor;
                    LerpColorCoroutine = Shared.MonoBehaviourReferance.StartCoroutine(LerpColor(Constants.DayCycleConstant.EveningLong, step, startColor, targetColor));
                    break;
                case Constants.TimeRange.Night:
                    targetColor = Constants.DayCycleTimeColorConstant.DawnColor;
                    startColor = Constants.DayCycleTimeColorConstant.NightColor;
                    LerpColorCoroutine = Shared.MonoBehaviourReferance.StartCoroutine(LerpColor(Constants.DayCycleConstant.NightLong, step, startColor, targetColor));
                    break;
            }
        }
        IEnumerator LerpColor(float TimeRangeDuration, float OneStepTime, Color from, Color to)
        {
            float Progress = 0;
            float Increment = OneStepTime / TimeRangeDuration;

            while (Progress < 1)
            {
                BackgroundLight.color = Color.Lerp(from, to, Progress);
                GroundLight.color = Color.Lerp(from, to, Progress);
                Progress += Increment;
                yield return new WaitForSeconds(OneStepTime);
            }
        }
        #endregion
    }
}

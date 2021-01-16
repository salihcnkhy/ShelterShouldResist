
namespace Game.Systems.Environment
{
    using Game.GameObjects.Ground;
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
        private DefaultGround DefaultGround;
        private GameObject EnvironmentObject;
        private ParallaxEffect ParallaxEffect;
        private List<DefaultGround> DefaultGrounds;
        private Light2D BackgroundLight;
        private Light2D GroundLight;
        Coroutine LerpColorCoroutine;

        public EnvironmentSystem(MainSystemShared Shared) : base(Shared)
        {
            BackgroundLight = GameObject.FindGameObjectWithTag("BackgroundLight").GetComponent<Light2D>();
            GroundLight = GameObject.FindGameObjectWithTag("GroundLight").GetComponent<Light2D>();
            
            EnvironmentObject = GameObject.FindGameObjectWithTag("Environment");
            ParallaxEffect = EnvironmentObject.GetComponent<ParallaxEffect>();

            DefaultGround = Resources.Load<DefaultGround>("Prefabs/Game/Environment/Ground");
            DefaultGrounds = new List<DefaultGround>();
            SetSubSystem();
        }

        protected override void SetSubSystem()
        {
            CurrentTimeRangeChanged(Shared.GameData.CurrentTimeRange);
            CreateEnvironment();
            SetEvents();
            AddBaseObjects();
        }
        protected override void SetEvents()
        {
            Shared.EventSystem.CurrentTimeRange.OnChangeEvent += CurrentTimeRangeChanged;
        }

        protected override void AddBaseObjects()
        {
            AddBaseObject(ParallaxEffect);
            DefaultGrounds.ForEach(item => AddBaseObject(item));
        }

        private void CurrentTimeRangeChanged(Constants.TimeRange newValue)
        {
            Color targetColor;
            Color startColor;
            float step = 0.01f;

            if(LerpColorCoroutine != null)
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
        IEnumerator LerpColor(float TimeRangeDuration,float OneStepTime ,Color from, Color to)
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

        private void CreateEnvironment()
        {
            CreateGrounds();
            //Belki sonradan ground üstüne koyulacak şeyleri burada oluşturursun 
        }

        private void CreateGrounds()
        {
            var ground = GameObject.Instantiate(DefaultGround, EnvironmentObject.transform);
            DefaultGrounds.Add(ground);
            for (int i = 1; i < 200; i++)
            {
                ground = GameObject.Instantiate(DefaultGround, EnvironmentObject.transform);
                DefaultGrounds.Add(ground);
                if (i % 2 == 0) ground.SetPosition(DefaultGrounds[i - 1], i); // Add right
                else ground.SetPosition(DefaultGrounds[i - 1], -i); // Add Left
            }
        }
    }
}

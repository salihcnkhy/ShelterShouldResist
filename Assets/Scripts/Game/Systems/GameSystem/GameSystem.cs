
namespace Game.Systems.GameSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using UnityEngine;
    using UnityEngine.SceneManagement;

    using Game.GameObjects.Character;
    using Game.Model;
    using Game.Constants;
    using Game.Generic;
    using Game.Interface.Systems;

    using Game.Systems.Environment;
    using Game.Systems.UISystem;
    using Game.Systems.DayCycle;
    using Game.Systems.Save;
    using Game.Systems.WaveSystem;
    using Game.Generic.SKObserver;
    using Game.Systems.EnemyCreation;
    using Game.Systems.EventSystem;
    using Game.Generic.Base;

    public class GameSystem : BaseMainSystem
    {


        private Character CharacterObject;

        private void Awake() => DontDestroyOnLoad(this);

        public override void InitMainSystem(GameData gameData)
        {
            Shared.GameData = gameData;
            Shared.ObservableBaseObjects = SKObservableList<BaseObject>.Empty();
            Shared.MonoBehaviourReferance = this;
            Shared.EventSystem = new EventSystem(Shared.GameData);
            SceneManager.sceneLoaded += OnSceneLoaded;

            base.InitMainSystem(gameData);
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;

            CreateBaseObjects();
            InitSystems();
            Shared.EventSystem.NewDayTrigger.OnTriggerEvent += OnNewDayTrigger;

        }

        private void OnNewDayTrigger()
        {
            Shared.GameData.CurrentDay = Shared.EventSystem.CurrentDay.Get();
            Shared.GameData.CurrentTime = Shared.EventSystem.CurrentTime.Get();
            Shared.GameData.CurrentTimeRange = TimeRange.Day;
            Shared.GameData.DaysToNextWave = Shared.EventSystem.DaysToNextWave.Get();
            Shared.GameData.WaveCount = Shared.EventSystem.WaveCount.Get();
            Shared.GameData.Player.Coin = Shared.EventSystem.CoinCount.Get();
            Shared.GameData.Player.Position = CharacterObject.transform.position;
        }

        #region Base Objects Init

        private void CreateBaseObjects()
        {
            CreateCharacter();
        }

        private void CreateCharacter()
        {
            CharacterObject = Resources.Load<Character>("Prefabs/Player/Knight");
            CharacterObject = Instantiate(CharacterObject);
            CharacterObject.SetPlayerModel(ref Shared.GameData.Player);
            Shared.ObservableBaseObjects.Append(CharacterObject);
        }
        #endregion

        #region System Init 
        private void InitSystems()
        {
            AddSubSystem<UISystem>();
            AddSubSystem<EnvironmentSystem>();
            AddSubSystem<SaveSystem>();
            AddSubSystem<DayCycleSystem>();
            AddSubSystem<WaveSystem>();
            AddSubSystem<EnemyCreationSystem>();
        }

        #endregion

        #region GameFlow 


        #endregion
    }

}


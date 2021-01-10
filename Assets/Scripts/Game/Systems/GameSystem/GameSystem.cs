
namespace Game.Systems.GameSystem
{
    using UnityEngine;
    using Game.Systems.UISystem;
    using Game.GameObjects.Character;
    using Game.Model;
    using UnityEngine.SceneManagement;
    using System.Collections;
    using Game.Utils.SaveLoad;
    using Game.Generic.SKObserver;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System;

    public class GameSystem : MonoBehaviour
    {

        private UISystem UISystem;
        private GameData GameData;

        private Character CharacterObject;

        private bool IsGameSceneLoaded = false;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            Debug.Log("Scene Loaded");
            InstantiateBaseObjects();
            SetupSystems();
            RunInit();
            IsGameSceneLoaded = true;
            StartCoroutine(GameSaverPerSec());
        }

        public void SetGameData(GameData gameData)
        {
            GameData = gameData;
        }

        private void InstantiateBaseObjects()
        {
            CharacterObject = Resources.Load<Character>("Prefabs/Player/Knight");
            CharacterObject = Instantiate(CharacterObject);
            CharacterObject.SetPlayerModel(ref GameData.Player);

        }
        private void SetupSystems()
        {
            UISystem = new UISystemBuilder().Make(GameData);
        }

        private void RunInit()
        {
            CharacterObject.Init();
        }

        private void Update()
        {
            if(IsGameSceneLoaded)
            {
                CharacterObject.HandleUpdate();
            }
        }

        private void FixedUpdate()
        {
            if (IsGameSceneLoaded)
            {
                CharacterObject.HandleFixedUpdate();
            }
        }

        IEnumerator GameSaverPerSec()
        {
            while(true)
            {
                yield return new WaitForSeconds(1);
                GameData.Player.Position = CharacterObject.transform.position;
                new GameSaver().SaveGameData(GameData);

            }
        }
    }

}


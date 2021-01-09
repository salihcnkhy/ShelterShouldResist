
namespace Game.Systems.GameSystem
{
    using UnityEngine;
    using Game.Systems.UISystem;
    using Game.GameObject.Character;
    using Game.Model;
    using UnityEngine.SceneManagement;
    using System.Collections;
    using Game.Utils.SaveLoad;

    public class GameSystem : MonoBehaviour
    {

        private UISystem UISystem;
        private GameData GameData;

        private Character CharacterObject;

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
            StartCoroutine(GameSaverPerSec());
        }

        public void SetGameData(GameData gameData)
        {
            GameData = gameData;
        }

        private void InstantiateBaseObjects()
        {
            CharacterObject = Resources.Load<Character>("Prefabs/Player/Character");
            CharacterObject = Instantiate(CharacterObject);
            CharacterObject.SetPlayerModel(ref GameData.Player);

        }
        private void SetupSystems()
        {
            UISystem = new UISystemBuilder().Make(GameData.Player);
        }

        IEnumerator GameSaverPerSec()
        {
            while(true)
            {
                yield return new WaitForSeconds(3);
                GameData.Player.Position = CharacterObject.transform.position;
                new GameSaver().SaveGameData(GameData);

            }
   
        }
    }

}


using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Game.Systems.GameSystem;
using Game.Model;
using System;
using Game.Utils.SaveLoad;

namespace Game.MainMenu
{
    public class MainMenu : MonoBehaviour
    {

        public Button ContinueBtn;
        public Button NewGameBtn;
        public Button SettingsBtn;
        public Button ExitBtn;

        private GameData gameData;

        void Start()
        {
            SetUIComponents();
        }

        private void SetUIComponents()
        {

            //TODO: Check game is saved before for Continue button
            SetGameData();
            SetButtonActions();
        }

        private void SetGameData()
        {
            var gameLoader = new GameLoader();
            gameData = gameLoader.LoadGameData();
        }

        private void SetButtonActions()
        {
            ContinueBtn.gameObject.SetActive(!gameData.IsNewLoad);
            ContinueBtn.onClick.AddListener(OnContinueGamePress);

            NewGameBtn.onClick.AddListener(OnStartNewGamePress);

            SettingsBtn.onClick.AddListener(OnSettingsPress);

            ExitBtn.onClick.AddListener(OnExitPress);
        }

        private void OnContinueGamePress()
        {
   
            Debug.Log("Continue Game");
            LoadGameScene();
        }

        private void OnStartNewGamePress()
        {
            Debug.Log("Starting New Game");
            this.gameData = new GameData();
            // TODO: you could show message if gameData exist before, like "Are you sure? Your all process will be deleted!"
            LoadGameScene();
        }

        private void OnSettingsPress()
        {
            Debug.Log("Settings Button");

        }

        private void OnExitPress()
        {
            Debug.Log("Exit Game");

        }

        private void LoadGameScene()
        {
            var gameSystem = new GameSystemBuilder().Make(this.gameData);
            SceneManager.LoadScene(1);
        }

    }

}

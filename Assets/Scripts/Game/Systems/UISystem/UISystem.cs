
namespace Game.Systems.UISystem
{
    using Game.Interface.Systems;
    using Game.Model;
    using Game.Utils.SaveLoad;
    using UnityEngine;
    using UnityEngine.UI;

    using Text = TMPro.TextMeshProUGUI;

    public class UISystem : IBaseSystem
    {

        Canvas canvas;
        GameData GameData;
        private Text ScoreText;

        public UISystem(Canvas canvas, GameData gameData)
        {
            this.canvas = canvas;
            this.GameData = gameData;
        }

        public void RunSystem()
        {
            SetComponents();
            SetupViews();
            SetPlayerEvents();
        }

        private void SetComponents()
        {
            ScoreText = canvas.transform.Find("Text").GetComponent<Text>();
        }

        private void SetupViews()
        {
            ScoreText.text = GameData.Player.Coin.Get().ToString();
        }

        private void SetPlayerEvents()
        {
            GameData.Player.Coin.OnChangeEvent += OnCoinTextChange;
        }
        private void OnCoinTextChange(int coin)
        {
            ScoreText.text = coin.ToString();
        }

  
    }
}

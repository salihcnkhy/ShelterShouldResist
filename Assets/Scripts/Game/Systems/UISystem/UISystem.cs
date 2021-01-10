
namespace Game.Systems.UISystem
{
    using Game.Model;
    using Game.Utils.SaveLoad;
    using UnityEngine;
    using UnityEngine.UI;

    using Text = TMPro.TextMeshProUGUI;

    public class UISystem
    {

        Canvas canvas;

        private Text ScoreText;

        public UISystem(Canvas canvas)
        {
            this.canvas = canvas;
            SetComponents();
        }

        private void SetComponents()
        {
            ScoreText = canvas.transform.Find("Text").GetComponent<Text>();
        }

        public void InjectGameData(GameData gameData)
        {
            SetupViews(gameData);
            SetPlayerEvents(gameData.Player);
        }
        public void SetupViews(GameData gameData)
        {
            ScoreText.text = gameData.Player.Coin.Get().ToString();
        }

        public void SetPlayerEvents(Player player)
        {
            player.Coin.OnChangeEvent += OnCoinTextChange;
        }


        private void OnCoinTextChange(int coin)
        {
            ScoreText.text = coin.ToString();
        }

    }
}

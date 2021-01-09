
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
        public void SetPlayerEvents(Player player)
        {
            ScoreText.text = player.Coin.ToString();
            player.OnCoinChange += OnCoinTextChange;
        }


        private void OnCoinTextChange(int coin)
        {
            ScoreText.text = coin.ToString();
        }

    }
}

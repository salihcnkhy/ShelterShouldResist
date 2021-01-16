
namespace Game.Systems.UISystem
{
    using Game.Generic.Base;
    using Game.Interface.Systems;
    using Game.Model;
    using Game.Utils.SaveLoad;
    using UnityEngine;
    using UnityEngine.UI;
    using Game.Systems.EventSystem;
    using Text = TMPro.TextMeshProUGUI;
    using Game.Generic;
    using System.Collections.Generic;
    using Game.Model.Systems;


    public class UISystem : BaseSubSystem
    {

        Canvas canvas;
        private Text ScoreText;
        private GameObject BuildPanel; 

        public UISystem(MainSystemShared Shared) : base(Shared)
        {
            canvas = GameObject.FindObjectOfType<Canvas>();
            SetSubSystem();
        }

        protected override void SetSubSystem()
        {
            SetComponents();
            SetupViews();
            SetEvents();
        }
        protected override void SetEvents()
        {
            Shared.EventSystem.CoinCount.OnChangeEvent += OnCoinChanged;
            Shared.EventSystem.BuildMenuOpenTrigger.OnChangeEvent += BuildMenuOpenTriggered; ;
        }

        private void BuildMenuOpenTriggered(bool newValue)
        {
            BuildPanel.SetActive(newValue);
        }

        private void SetComponents()
        {
            ScoreText = canvas.transform.Find("Text").GetComponent<Text>();
            BuildPanel = canvas.transform.Find("BuildPanel").gameObject;
        }

        private void SetupViews()
        {
            ScoreText.text = Shared.EventSystem.CoinCount.Get().ToString();
        }

        private void OnCoinChanged(int newValue)
        {
            ScoreText.text = newValue.ToString();
        }


    }
}

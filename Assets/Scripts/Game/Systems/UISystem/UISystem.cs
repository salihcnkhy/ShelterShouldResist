
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
    using System.Linq;
    using Game.GameObjects.Character;

    public class UISystem : BaseSubSystem
    {

        Canvas canvas;

        private Text ScoreText;
        private Button BuildBtn;
        private GameObject PlaceableObjectImagePrefab;

        private GameObject BuildPanel;

        private GameObject SelectedBuildingPanel;
        private Button SelectedBuildingAproveBtn;
        private Button SelectedBuildingCancelBtn;

        private Transform BuildContent;

        private List<ScriptablePlaceableObject> PlaceableObjects;
        public UISystem(MainSystemShared Shared) : base(Shared)
        {
            canvas = GameObject.FindObjectOfType<Canvas>();
            SetSubSystem();
        }

        protected override void SetSubSystem()
        {
            PlaceableObjectImagePrefab = Resources.Load<GameObject>("Prefabs/Game/UI/PlaceableObjectImage");
            PlaceableObjects = Resources.LoadAll<ScriptablePlaceableObject>("Prefabs/Game/Environment/Buildings/ScriptableObjects").ToList();

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

            SelectedBuildingPanel = canvas.transform.Find("SelectedBuildingPanel").gameObject;
            SelectedBuildingAproveBtn = SelectedBuildingPanel.transform.Find("AproveBtn").GetComponent<Button>();
            SelectedBuildingCancelBtn = SelectedBuildingPanel.transform.Find("CancelBtn").GetComponent<Button>();

            SelectedBuildingCancelBtn.onClick.AddListener(SelectedBuildingCancelButtonClick);
            SelectedBuildingAproveBtn.onClick.AddListener(SelectedBuildingAproveButtonClick);


            var scroll = BuildPanel.transform.Find("ScrollView");
            var view = scroll.Find("Viewport");
            BuildContent = view.Find("Content");
            BuildBtn = canvas.transform.Find("BuildBtn").GetComponent<Button>();

            BuildBtn.onClick.AddListener(delegate { BuildMenuOpenTriggered(true); });

            PlaceableObjects.ForEach(item =>
            {
                var gameObject = GameObject.Instantiate(PlaceableObjectImagePrefab, BuildContent.transform);
                gameObject.GetComponent<Image>().sprite = item.MenuSprite;
                gameObject.GetComponent<Button>().onClick
                .AddListener(delegate { BuidingItemOnClick(item); });
            });
        }
        private void BuidingItemOnClick(ScriptablePlaceableObject scriptablePlaceableObject)
        {
            BuildMenuOpenTriggered(false);
            SetActiveSelectedBuildingActionPanel(true);
            Shared.EventSystem.SelectedPlaceableObject.Set(scriptablePlaceableObject.PlaceableObject);
        }

        private void SetActiveSelectedBuildingActionPanel(bool active)
        {
            SelectedBuildingPanel.SetActive(active);
        }

        private void SelectedBuildingAproveButtonClick()
        {
            Shared.EventSystem.BuildSucceedValue.OnChangeEvent += OnBuildSucceedWithValue;
            Shared.EventSystem.BuildApprovedTrigger.Fire();
        }

        private void OnBuildSucceedWithValue(bool newValue)
        {
            // TODO: Eğer newValue false geldiyse engel olduğundan dolayı objeyi koyamamışıszdır UI üzerinde bir şey göster.
            SetActiveSelectedBuildingActionPanel(!newValue);
            Shared.EventSystem.BuildSucceedValue.OnChangeEvent -= OnBuildSucceedWithValue;
        }

        private void SelectedBuildingCancelButtonClick()
        {
            SetActiveSelectedBuildingActionPanel(false);
            BuildMenuOpenTriggered(true);
            Shared.EventSystem.BuildCanceledTrigger.Fire();
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

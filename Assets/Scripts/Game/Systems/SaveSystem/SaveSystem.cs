
namespace Game.Systems.Save
{
    using Game.Generic.Base;
    using Game.Interface.Systems;
    using Game.Model;
    using Game.Utils.SaveLoad;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Game.Systems.EventSystem;
    using Game.Generic;
    using Game.Model.Systems;

    public class SaveSystem : BaseSubSystem
    {


        public SaveSystem(MainSystemShared Shared) : base(Shared)
        {
            SetSubSystem();
        }

        protected override void SetSubSystem()
        {
            Shared.EventSystem.WaveCount.OnChangeEvent += WaveChanged;
        }
        private void WaveChanged(int newValue)
        {
            SaveGameData();
        }

        private void SaveGameData()
        {
            GameSaver saver = new GameSaver();
            saver.SaveGameData(Shared.GameData);
        }
    }

}
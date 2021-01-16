using Game.Generic;
using Game.Generic.Base;
using Game.Generic.SKObserver;
using Game.Systems.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Model.Systems
{
    public sealed class MainSystemShared
    {
        public List<BaseSubSystem> SubSystems { get; set; }
        public EventSystem EventSystem { get; set; }
        public SKObservableList<BaseObject> ObservableBaseObjects { get; set; }
        public MonoBehaviour MonoBehaviourReferance { get; set; }
        public GameData GameData { get; set; }

    }
}


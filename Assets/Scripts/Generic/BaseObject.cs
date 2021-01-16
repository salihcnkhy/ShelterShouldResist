using Game.Model.Systems;
using Game.Systems.EventSystem;
using Game.Systems.GameSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Generic
{
    public abstract class BaseObject : MonoBehaviour
    {
        protected MainSystemShared Shared;
        public void InjectShared(MainSystemShared Shared)
        {
            this.Shared = Shared;
        }
        public virtual void PreInit() {  }
        public virtual void Init() {  }
        public virtual void HandleUpdate() {  }
        public virtual void HandleFixedUpdate() { }
        public virtual void HandleLateUpdate() { }

    }

}

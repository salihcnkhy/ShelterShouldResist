using Game.Model.Systems;
using Game.Systems.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Generic.Base
{
    public class BaseSubSystem
    {
        protected MainSystemShared Shared;

        public BaseSubSystem(MainSystemShared Shared)
        {
            this.Shared = Shared;
        }

        protected virtual void SetSubSystem() { }
        protected virtual void SetEvents() { }
        protected virtual void AddBaseObjects() { }
        protected void AddBaseObject(BaseObject BaseObject) 
        {
            Shared.ObservableBaseObjects.Append(BaseObject);
        }

    }

}

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
        public virtual void PreInit() 
        {
            Debug.LogWarning("BaseObject Pre init");
        }
        public virtual void Init() {  }
        public virtual void HandleUpdate() {  }
        public virtual void HandleFixedUpdate() { }
        public virtual void HandleLateUpdate() { }

        public void DestroySelf()
        {
            GameObject.Destroy(this.gameObject);
        }
        public void RemoveSelf()
        {
            if (Shared != null)
                Shared.ObservableBaseObjects.Remove(this);

            GameObject.Destroy(this.gameObject);
        }
        public void SetParent(Transform parent)
        {
            this.transform.SetParent(parent);
        }
    }

}

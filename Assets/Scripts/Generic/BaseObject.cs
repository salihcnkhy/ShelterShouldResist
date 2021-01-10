using Game.Systems.GameSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Generic
{
    public abstract class BaseObject : MonoBehaviour
    {
        public virtual void Init() {  }
        public virtual void HandleUpdate() {  }
        public virtual void HandleFixedUpdate() { }

    }

}

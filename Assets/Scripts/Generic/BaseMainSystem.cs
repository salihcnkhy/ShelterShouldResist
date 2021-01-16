using Game.Model;
using Game.Model.Systems;
using System;
using System.Linq;
using UnityEngine;

namespace Game.Generic.Base
{

    public abstract class BaseMainSystem : MonoBehaviour
    {
        protected MainSystemShared Shared = new MainSystemShared();

        public void AddSubSystem<T>() where T : BaseSubSystem
        {
            T newSubSystem = (T)Activator.CreateInstance(typeof(T), Shared);
            Shared.SubSystems.Add(newSubSystem);
        }

        public virtual void InitMainSystem(GameData GameData) 
        {
            SetEvents();
        }
        private void SetEvents()
        {
            Shared.ObservableBaseObjects.OnNewElementAppenedEvent += BaseObjectListNewElementAppend;
        }

        private void BaseObjectListNewElementAppend(BaseObject newValue)
        {
            newValue.InjectShared(Shared);
            newValue.PreInit();
            newValue.Init();
        }

        #region Updates 
        private void Update()
        {

          foreach (var baseObj in Shared.ObservableBaseObjects.Get())
            {
                baseObj.HandleUpdate();
            }
        }

        private void FixedUpdate()
        {
            foreach (var baseObj in Shared.ObservableBaseObjects.Get())
            {
                    baseObj.HandleFixedUpdate();
            }
            
        }

        private void LateUpdate()
        {
            foreach (var baseObj in Shared.ObservableBaseObjects.Get())
            {
                    baseObj.HandleLateUpdate();
            }
        }
        #endregion
    }
}


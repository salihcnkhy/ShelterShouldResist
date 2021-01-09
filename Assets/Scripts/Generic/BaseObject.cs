using Game.Systems.GameSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Generic
{
    public class BaseObject : MonoBehaviour
    {
       protected GameSystem gameSystem;

       virtual public void Preinit()
        {

        }

        virtual public void Init()
        {

        }
        


        public void SetGameSystem(GameSystem gameSystem)
        {
            this.gameSystem = gameSystem;
        }
    }

}

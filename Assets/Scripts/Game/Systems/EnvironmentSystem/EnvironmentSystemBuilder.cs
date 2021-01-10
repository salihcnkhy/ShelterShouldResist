using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Systems.Environment
{
    public class EnvironmentSystemBuilder
    {
        public EnvironmentSystem Make()
        {
            var environmentObj = GameObject.Find("Environment");
            var environmentSystem = new EnvironmentSystem(environmentObj);

            return environmentSystem;
        }
    }

}

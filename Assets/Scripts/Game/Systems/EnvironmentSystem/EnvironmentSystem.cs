using Game.GameObjects.Ground;
using Game.Interface.Systems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Systems.Environment
{
    public class EnvironmentSystem : IBaseSystem
    {
        private DefaultGround DefaultGround;
        private GameObject EnvironmentObj;
        private List<DefaultGround> DefaultGrounds;

        public EnvironmentSystem(GameObject environmentObj)
        {
            DefaultGround = Resources.Load<DefaultGround>("Prefabs/Game/Environment/Ground");
            EnvironmentObj = environmentObj;
            DefaultGrounds = new List<DefaultGround>();
        }

        public void RunSystem()
        {
            CreateEnvironment();
        }

        private void CreateEnvironment()
        {
            var ground = GameObject.Instantiate(DefaultGround, EnvironmentObj.transform);
            DefaultGrounds.Add(ground);
            for (int i = 1; i< 200; i++)
            {
                ground = GameObject.Instantiate(DefaultGround, EnvironmentObj.transform);
                DefaultGrounds.Add(ground);
                if (i % 2 == 0)  ground.SetPosition(DefaultGrounds[i - 1], i); // Add right
                else ground.SetPosition(DefaultGrounds[i-1], -i); // Add Left
            }

        }


    }
}

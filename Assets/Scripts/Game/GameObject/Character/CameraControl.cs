using Game.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameObjects.Character
{
    public class CameraControl : BaseObject
    {

        private Camera MainCamera;
        public override void Init()
        {
            MainCamera = Camera.main;
        }

        public override void HandleUpdate()
        {
            var tempPosition = MainCamera.transform.position;
            tempPosition.x = transform.position.x;
            MainCamera.transform.position = tempPosition;
        }
    }

}

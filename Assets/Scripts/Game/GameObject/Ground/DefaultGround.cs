using Game.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GameObjects.Ground
{
    public class DefaultGround : BaseObject
    {
        public void SetPosition(DefaultGround referance, int offset)
        {
            var tempPosition = referance.transform.position;
            tempPosition.x += (float)offset * 3f;
            transform.position = tempPosition;
        }

    }

}


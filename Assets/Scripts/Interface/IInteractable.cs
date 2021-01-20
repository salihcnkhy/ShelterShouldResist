

namespace Game.Interface.Interaction
{
    using Game.Generic;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public interface IInteractable
    {
        void HandleTriggerEnterInteraction(BaseObject TriggeredObject);
        void HandleTriggerExitInteraction(BaseObject TriggeredObject);
    }

}

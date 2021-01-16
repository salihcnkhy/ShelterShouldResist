using Game.Generic;
using Game.Interface.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.GameObjects.Ground
{
    public class DefaultGround : BaseObject, IInteractable
    {
        public Transform MiddleGroundTransform;
        public GameObject InteractionGameObject;
        private GameObject PlacedBuilding;
        public void SetPosition(DefaultGround referance, int offset)
        {
            var tempPosition = referance.transform.position;
            tempPosition.x += (float)offset * 3f;
            transform.position = tempPosition;
        }
        public void HandleTriggerEnterInteraction()
        {
            InteractionGameObject.SetActive(true);
        }

        public void HandleTriggerExitInteraction()
        {
            InteractionGameObject.SetActive(false);
            Shared.EventSystem.BuildMenuOpenTrigger.Set(false);

        }

        public override void HandleUpdate()
        {
           if(Input.GetKeyDown(KeyCode.E))
            {
                if(InteractionGameObject.activeSelf)
                {
                    if (PlacedBuilding == null)
                    {
                        Shared.EventSystem.BuildMenuOpenTrigger.Set(true);
                        Shared.EventSystem.BuildPlaceableObject.OnTriggerEvent += BuildPlaceableObjectTrigger;
                    }
                    else
                    {
                        // Building already placed so when you pressed E try to upgrade building
                    }
                }
            }
        }

        private void BuildPlaceableObjectTrigger(BaseObject Object)
        {
            Shared.EventSystem.BuildPlaceableObject.OnTriggerEvent -= BuildPlaceableObjectTrigger;

            // Build selected Object
        }
    }
}


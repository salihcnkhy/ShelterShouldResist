using Game.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.GameObjects.Background
{
    public class ParallaxEffect : BaseObject
    {

        [SerializeField]
        private List<ParallaxUnit> BackgroundLayers;
        private Transform CameraTransform;
        private Vector3 LastCameraPosition;

        public override void Init()
        {
            CameraTransform = Camera.main.transform;
            LastCameraPosition = CameraTransform.position;
            BackgroundLayers.ForEach(unit => unit.CalculateTextureUnitSizeX());
        }

        public override void HandleLateUpdate()
        {
            Vector3 deltaMovement = CameraTransform.position - LastCameraPosition;
            foreach(var unit in BackgroundLayers)
            {
                unit.SpriteRenderer.transform.position += new Vector3(deltaMovement.x * unit.FlowSpeed.x, deltaMovement.y * unit.FlowSpeed.y);
                if (unit.ShouldTransport(CameraTransform.transform))
                {
                    float offsetPositionX = (CameraTransform.position.x - unit.SpriteRenderer.transform.position.x) % unit.TextureUnitSizeX;
                    unit.SpriteRenderer.transform.position = new Vector3(CameraTransform.position.x + offsetPositionX, unit.SpriteRenderer.transform.position.y);
                }
            }
            LastCameraPosition = CameraTransform.position;
        }
    }

}


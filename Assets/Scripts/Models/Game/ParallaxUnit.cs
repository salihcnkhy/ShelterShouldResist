using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ParallaxUnit 
{
    [SerializeField]
    public SpriteRenderer SpriteRenderer;
    [SerializeField]
    public Vector2 FlowSpeed = new Vector2(.1f,.1f);

    [NonSerialized]
    public float TextureUnitSizeX;
    public void CalculateTextureUnitSizeX()
    {
        Sprite sprite = SpriteRenderer.sprite;
        Texture2D texture = sprite.texture;
        TextureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    public bool ShouldTransport(Transform cameraTransform) => Mathf.Abs( cameraTransform.position.x - SpriteRenderer.transform.position.x) >= TextureUnitSizeX;


}

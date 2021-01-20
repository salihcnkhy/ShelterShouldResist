using Game.Generic;
using Game.Interface.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaceableObject : BaseObject
{
    public string Name;
    public int Level;
    public SpriteRenderer SpriteRenderer;

    [NonSerialized]
    public bool HasPlaced = false;
    private bool _HasBlocked = false;

    public bool HasBlocked 
    { 
        get { return _HasBlocked; }
        set
        {
            if (value)
                SetColor(Color.red);
            else
                SetColor(Color.white);
            _HasBlocked = value;
        } 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (HasBlocked)
            return;
        if(collision.CompareTag("Placeable"))
            HasBlocked = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (HasBlocked)
        {
            if (collision.CompareTag("Placeable"))
                HasBlocked = false;
        }
    }

    private void SetColor(Color color)
    {
        if(!HasPlaced)
        SpriteRenderer.color = color;
    }


}

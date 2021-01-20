using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PleaceableObject", menuName = "Create Placeable", order = 1)]
public class ScriptablePlaceableObject : ScriptableObject
{
    public PlaceableObject PlaceableObject;
    public Sprite MenuSprite;
}

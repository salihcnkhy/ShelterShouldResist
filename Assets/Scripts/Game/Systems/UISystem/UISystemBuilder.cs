
namespace Game.Systems.UISystem
{
    using Game.Model;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class UISystemBuilder
    {


        public UISystem Make(Player player)
        {
            GameObject uiElement = Resources.Load<GameObject>("Prefabs/Game/UI/UIElements");
            uiElement = GameObject.Instantiate<GameObject>(uiElement);
            UISystem uiSystem = new UISystem(uiElement.GetComponentInChildren<Canvas>());
            uiSystem.SetPlayerEvents(player);
            return uiSystem;
        }
    }
}


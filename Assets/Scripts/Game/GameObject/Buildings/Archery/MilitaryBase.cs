using Game.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryBase : PlaceableObject
{
    private int SoldierPerLevel = 1;
    [SerializeField]
    private Soldier SoldierPrefab;
    List<BaseObject> SoldierList;
    public override void PreInit()
    {
        SoldierList = new List<BaseObject>();
        Debug.LogError("Preinti of" + Name);
        Shared.EventSystem.NewDayTrigger.OnTriggerEvent += OnNewDayEvent;
    }

    private void OnNewDayEvent()
    {
        int SoldierCountDiff = SoldierPerLevel * Level - SoldierList.Count;

        for (int i = 0; i < SoldierCountDiff; i++ )
        {
            var soldier = GameObject.Instantiate<Soldier>(SoldierPrefab, transform);
            Shared.ObservableBaseObjects.Append(soldier);
            SoldierList.Add(soldier);
        }

    }

    public override void HandleUpdate()
    {
        foreach(var soldier in SoldierList)
        {
            soldier.HandleUpdate();
        }
    }

    public override void HandleFixedUpdate()
    {
        foreach (var soldier in SoldierList)
        {
            soldier.HandleFixedUpdate();
        }
    }
}

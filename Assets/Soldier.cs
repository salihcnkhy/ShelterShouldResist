using Game.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    void HandleAttacker(BaseObject Attackable);
}

public class Soldier : BaseObject, IAttacker
{
    public string Name;
    public float MaxHealth;
    public float Damage;
    public float MaxHealthIncreaseFactorPerLevel;
    public float MaxDamageIncreaseFactorPerLevel;
    public int Level;
    public AIMovementController MovementController;
    public void HandleAttacker(BaseObject Attackable)
    {
        MovementController.SetFollowedObject(Attackable);
    }

    public override void HandleFixedUpdate()
    {
        MovementController.HandleFixedUpdate();
    }
    public override void HandleUpdate()
    {
        MovementController.HandleUpdate();
    }

}

using Game.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : BaseObject
{
    [SerializeField]
    private BaseObject Attacker;
    public float DetectionRadius;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Attacker is IAttacker)
        if(collision.CompareTag("Enemy"))
        {
            var baseObj = collision.GetComponent<BaseObject>();
            (Attacker as IAttacker).HandleAttacker(baseObj);
        }
            
    }

}

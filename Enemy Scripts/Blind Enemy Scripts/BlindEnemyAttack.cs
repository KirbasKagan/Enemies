using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindEnemyAttack : MonoBehaviour
{
    PlayerHealt target;
    [SerializeField] private float damage = 100f;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealt>();
    }

    public void AttackHitEvent()
    {
        target.TakeDamage(damage);
        if(target == null) return;
    }
}

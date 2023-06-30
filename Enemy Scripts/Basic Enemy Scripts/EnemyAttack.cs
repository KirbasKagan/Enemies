using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealt target;
    [SerializeField] private float damage = 40f;

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

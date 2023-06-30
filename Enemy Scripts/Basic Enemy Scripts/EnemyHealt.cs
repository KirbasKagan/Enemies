using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using Random = UnityEngine.Random;

public class EnemyHealt : MonoBehaviour
{
   [SerializeField] public float health = 100f;
   [SerializeField] private ParticleSystem bloodStream;
   [SerializeField] private List<GameObject> organ = new List<GameObject>();

   public void TakeDamage(float damage)
   {
      BroadcastMessage("OnTakenDamage"); // Eğer bulunduğu objenin içerisinde ise direk onu çağırır.
      health -= damage;
      if (health <= 0)
      {
         CreateOrgan();
         Instantiate(bloodStream, transform.position, Quaternion.identity);
         Destroy(gameObject);
      }
   }

   public void CreateOrgan()
   {
      int n = Random.Range(0,12);
         
      for(int i=0; i<=n; i++)
      {
         int k = Random.Range(0, 12);
         Instantiate(organ[k], transform.position, quaternion.identity);
      }
   }
}

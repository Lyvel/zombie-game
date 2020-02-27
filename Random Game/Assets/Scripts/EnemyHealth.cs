using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 100f;
    public float HitRate = 1f;
    public float Damage = 10f;

    float nextHit;

    private void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 2 &&
            nextHit < Time.time)
        {
            nextHit = Time.time + HitRate;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Health -= Damage;
        }
    }
}

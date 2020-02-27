using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldBarricade : MonoBehaviour
{
    public float Health = 100f;
    public float Damage = 25f;

    public float HitRate = 1f;

    float nextHit;

    private void Update()
    {
        if (Health <= 0)
        {
            GetComponent<NavMeshObstacle>().enabled = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && nextHit < Time.time)
        {
            nextHit = Time.time + HitRate;
            Health -= Damage;
        }
    }
}

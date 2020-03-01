using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 100f;
    public float HitRate = 1f;
    public float Damage = 10f;

    float nextHit;

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject, 5);
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<EnemyMovement>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(transform.right);
        }

        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 2 &&
            nextHit < Time.time)
        {
            nextHit = Time.time + HitRate;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().Health -= Damage;
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
    }
}

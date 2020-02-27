using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100f;

    private void Update()
    {
        if (Health <= 0)
        {
            Health = 0;
            //Player dead
        }
    }
}

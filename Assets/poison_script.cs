using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison_script : MonoBehaviour
{
    public float poisonTimer = 5;
    public int poisonDPS = 2;
    public float DPSTimer = 1;
    private bool inGas = false;
    private Collider enemy;

    // Update is called once per frame
    void Update()
    {
        // Count down timers
        poisonTimer -= Time.deltaTime;
        DPSTimer -= Time.deltaTime;

        // Do damage when in the gas
        if(inGas && DPSTimer <= 0 && enemy != null){
            enemy.GetComponent<EnemyController>().DamageEnemy(poisonDPS);
            DPSTimer = 1;
        }

        // When timer is up, destroy poison
        if(poisonTimer <= 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider nearbyObject)
    {
        //Debug.Log(nearbyObject.name);

        // Do damage to enemies
        if(nearbyObject.tag == "Enemy"){
            // Explosion force on enemy transform
                // Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                // if(rb != null){ 
                //     rb.AddExplosionForce(explosiveForce, transform.position, explosiveRadius);
                // }

            enemy = nearbyObject;
            inGas = true;
        }
    }

    void OnTriggerExit(Collider nearbyObject)
    {
        inGas = false;
    }
}
